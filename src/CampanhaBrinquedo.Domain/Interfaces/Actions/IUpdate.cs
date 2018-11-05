using CampanhaBrinquedo.Domain.Entities;
using System.Threading.Tasks;

namespace CampanhaBrinquedo.Domain.Interfaces.Actions
{
    public interface IUpdate<in T> where T : EntityBase
    {
        void Update(T entity);
        Task UpdateAsync(T entity);
    }
}