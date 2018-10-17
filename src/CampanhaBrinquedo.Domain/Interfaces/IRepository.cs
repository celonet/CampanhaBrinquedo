using CampanhaBrinquedo.Domain.Entities;
using CampanhaBrinquedo.Domain.Interfaces.Actions;

namespace CampanhaBrinquedo.Domain.Interfaces
{
    public interface IRepository<T> : ICreate<T>, IUpdate<T>, IDelete, ISearch<T> where T : EntityBase { }
}