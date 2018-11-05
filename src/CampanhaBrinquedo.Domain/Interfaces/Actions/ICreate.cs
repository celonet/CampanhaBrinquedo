using CampanhaBrinquedo.Domain.Entities;
using System.Threading.Tasks;

namespace CampanhaBrinquedo.Domain.Interfaces.Actions
{
    public interface ICreate<in T> where T : EntityBase
    {
        void Create(T entity);
        Task CreateAsync(T entity);
    }
}