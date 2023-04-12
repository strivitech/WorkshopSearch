using System.Linq.Expressions;
using WebApp.Common.Application;
using WebApp.Features.Directions;

namespace WebApp.Features.Workshops;

public class WorkshopFilterExpressionBuilder : IWorkshopFilterExpressionBuilder
{
    public Expression<Func<Workshop, bool>> BuildExpression(WorkshopFilter filter)
    {
        Expression<Func<Workshop, bool>> expression = PredicateBuilder.True<Workshop>();

        expression = FilterAddress(filter, expression);
        expression = FilterText(filter, expression);
        expression = FilterCategoryId(filter, expression);
        expression = FilterMinAge(filter, expression);
        expression = FilterMaxAge(filter, expression);
        expression = FilterPrice(filter, expression);
        expression = FilterWorkingDays(filter, expression);

        return expression;
    }

    private static Expression<Func<Workshop, bool>> FilterAddress(WorkshopFilter filter,
        Expression<Func<Workshop, bool>> expression)
    {
        expression = expression.And(workshop =>
            workshop.Address.Region == filter.RegionWithCity.Region &&
            workshop.Address.City == filter.RegionWithCity.City);

        return expression;
    }
    
    private static Expression<Func<Workshop, bool>> FilterWorkingDays(WorkshopFilter filter,
        Expression<Func<Workshop, bool>> expression)
    {
        if (filter.WorkingDays is not null && filter.WorkingDays.Any())
        {
            var days = filter.WorkingDays.Aggregate((current, next) => current | next);
            expression = expression.And(workshop => (workshop.Constrains.Days & days) > 0);
        }

        return expression;
    }

    private static Expression<Func<Workshop, bool>> FilterPrice(WorkshopFilter filter,
        Expression<Func<Workshop, bool>> expression)
    {
        if (filter.MinPrice != WorkshopDataConstants.Filter.MinPriceDefaultValue)
        {
            expression = expression.And(workshop => workshop.Constrains.Price >= filter.MinPrice);
        }

        if (filter.MaxPrice != WorkshopDataConstants.Filter.MaxPriceDefaultValue)
        {
            expression = expression.And(workshop => workshop.Constrains.Price <= filter.MaxPrice);
        }

        return expression;
    }

    private static Expression<Func<Workshop, bool>> FilterMaxAge(WorkshopFilter filter,
        Expression<Func<Workshop, bool>> expression)
    {
        if (filter.MaxAge != WorkshopDataConstants.Filter.MaxAgeDefaultValue)
        {
            expression = expression.And(workshop => workshop.Constrains.MaxAge <= filter.MaxAge);
        }

        return expression;
    }

    private static Expression<Func<Workshop, bool>> FilterMinAge(WorkshopFilter filter,
        Expression<Func<Workshop, bool>> expression)
    {
        if (filter.MinAge != WorkshopDataConstants.Filter.MinAgeDefaultValue)
        {
            expression = expression.And(workshop => workshop.Constrains.MinAge >= filter.MinAge);
        }

        return expression;
    }

    private static Expression<Func<Workshop, bool>> FilterCategoryId(WorkshopFilter filter,
        Expression<Func<Workshop, bool>> expression)
    {
        if (filter.CategoryId.HasValue)
        {
            expression = expression.And(workshop =>
                workshop.Directions.Any(direction => direction.Id == new DirectionId(filter.CategoryId.Value)));
        }

        return expression;
    }

    private static Expression<Func<Workshop, bool>> FilterText(WorkshopFilter filter,
        Expression<Func<Workshop, bool>> expression)
    {
        if (!string.IsNullOrWhiteSpace(filter.Text))
        {
            var tempPredicate = PredicateBuilder.False<Workshop>();
            var text = filter.Text.Trim();
            tempPredicate = tempPredicate.Or(workshop => workshop.Title.Contains(text));
            tempPredicate = tempPredicate.Or(workshop => workshop.Description.Contains(text));

            expression = expression.And(tempPredicate);
        }

        return expression;
    }
}