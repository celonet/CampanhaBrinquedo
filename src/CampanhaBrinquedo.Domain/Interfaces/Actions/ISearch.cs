using CampanhaBrinquedo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CampanhaBrinquedo.Domain.Interfaces.Actions
{
    public interface ISearch<T> where T : EntityBase
    {
        Task<IEnumerable<T>> List();
        Task<IEnumerable<T>> List(Expression<Func<T, bool>> expression);
        Task<T> FindById(Guid id);
        Task<T> FindByExpression(Expression<Func<T, bool>> expression);
    }
}