using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CampanhaBrinquedo.Domain.Entities;
using CampanhaBrinquedo.Domain.Interfaces;

namespace Campanhabrinquedo.Data.MongoDb.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {

        public Repository()
        {
            
        }

        public virtual void Create(T entitie)
        {
            
        }

        public void Delete(Guid id)
        {
            
        }

        public T FindByExpression(Func<T, bool> expression)
        {
            return null;
        }

        public Task<T> FindByExpressionAsync(Expression<Func<T, bool>> expression)
        {
            return null;
        }

        public T FindById(Guid id)
        {
            return null;
        }

        public IQueryable<T> List()
        {
            return null;
        }

        public IQueryable<T> List(Func<T, bool> expression)
        {
            return null;
        }

        public void Update(T entitie)
        {
            
        }

        public void Dispose()
        {
            
        }
    }
}
