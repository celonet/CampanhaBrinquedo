using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CampanhaBrinquedo.Domain.Entities;

namespace CampanhaBrinquedo.Domain.Interfaces.Actions
{
    public interface ISearch<T> where T : EntityBase
    {
        IQueryable<T> List();
        IQueryable<T> List(Func<T, bool> expression);
         T FindById(Guid id);
         T FindByExpression(Func<T, bool> expression);
        Task<T> FindByExpressionAsync(Expression<Func<T, bool>> expression);
    }
}