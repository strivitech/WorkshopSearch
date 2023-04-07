using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebApp.Common.Application;
using WebApp.Common.Data;
using WebApp.Features.Directions;

namespace WebApp.Features.Workshops;

public interface IWorkshopExpressionBuilder
{
    Expression<Func<Workshop, bool>> BuildQuery(WorkshopFilter filter);
}

public class WorkshopExpressionBuilder : IWorkshopExpressionBuilder
{
    public Expression<Func<Workshop, bool>> BuildQuery(WorkshopFilter filter)
    {
        Expression<Func<Workshop, bool>> expression = PredicateBuilder.True<Workshop>();

        expression = FilterText(filter, expression);
        expression = FilterCategoryId(filter, expression);
        expression = FilterMinAge(filter, expression);
        expression = FilterMaxAge(filter, expression);
        expression = FilterPrice(filter, expression);
        expression = FilterWorkingDays(filter, expression);

        return expression;
    }

    private static Expression<Func<Workshop, bool>> FilterWorkingDays(WorkshopFilter filter,
        Expression<Func<Workshop, bool>> query)
    {
        if (filter.WorkingDays is not null && filter.WorkingDays.Any())
        {
            var days = filter.WorkingDays.Aggregate((current, next) => current | next);
            query = query.And(workshop => (workshop.Constrains.Days & days) > 0);
        }

        return query;
    }

    private static Expression<Func<Workshop, bool>> FilterPrice(WorkshopFilter filter,
        Expression<Func<Workshop, bool>> query)
    {
        if (filter.MinPrice != WorkshopDataConstants.Filter.MinPriceDefaultValue)
        {
            query = query.And(workshop => workshop.Constrains.Price >= filter.MinPrice);
        }

        if (filter.MaxPrice != WorkshopDataConstants.Filter.MaxPriceDefaultValue)
        {
            query = query.And(workshop => workshop.Constrains.Price <= filter.MaxPrice);
        }

        return query;
    }

    private static Expression<Func<Workshop, bool>> FilterMaxAge(WorkshopFilter filter,
        Expression<Func<Workshop, bool>> query)
    {
        if (filter.MaxAge != WorkshopDataConstants.Filter.MaxAgeDefaultValue)
        {
            query = query.And(workshop => workshop.Constrains.MaxAge <= filter.MaxAge);
        }

        return query;
    }

    private static Expression<Func<Workshop, bool>> FilterMinAge(WorkshopFilter filter,
        Expression<Func<Workshop, bool>> query)
    {
        if (filter.MinAge != WorkshopDataConstants.Filter.MinAgeDefaultValue)
        {
            query = query.And(workshop => workshop.Constrains.MinAge >= filter.MinAge);
        }

        return query;
    }

    private static Expression<Func<Workshop, bool>> FilterCategoryId(WorkshopFilter filter,
        Expression<Func<Workshop, bool>> query)
    {
        if (filter.CategoryId.HasValue)
        {
            query = query.And(workshop =>
                workshop.Directions.Any(direction => direction.Id == new DirectionId(filter.CategoryId.Value)));
        }

        return query;
    }

    private static Expression<Func<Workshop, bool>> FilterText(WorkshopFilter filter,
        Expression<Func<Workshop, bool>> query)
    {
        if (!string.IsNullOrWhiteSpace(filter.Text))
        {
            var tempPredicate = PredicateBuilder.False<Workshop>();
            var text = filter.Text.Trim();
            tempPredicate = tempPredicate.Or(workshop => workshop.Title.Contains(text));
            tempPredicate = tempPredicate.Or(workshop => workshop.Description.Contains(text));

            query = query.And(tempPredicate);
        }

        return query;
    }
}