using System.Linq.Expressions;

namespace WebApp.Features.Workshops;

public interface IWorkshopFilterExpressionBuilder
{
    Expression<Func<Workshop, bool>> BuildExpression(WorkshopFilter filter);
    
    Expression<Func<Workshop, bool>> BuildExpression(WorkshopWithoutTextSearchFilter filter);
}