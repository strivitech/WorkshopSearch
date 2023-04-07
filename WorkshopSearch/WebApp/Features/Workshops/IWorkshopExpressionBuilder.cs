using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebApp.Common.Data;

namespace WebApp.Features.Workshops;

public interface IWorkshopExpressionBuilder
{
    Expression<Func<Workshop, bool>> BuildQuery(WorkshopFilter filter);
}