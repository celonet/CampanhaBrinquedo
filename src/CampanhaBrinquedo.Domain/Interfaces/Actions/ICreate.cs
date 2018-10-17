using CampanhaBrinquedo.Domain.Entities;

namespace CampanhaBrinquedo.Domain.Interfaces.Actions
{
    public interface ICreate<in T> where T : EntityBase
    {
        void Create(T entitie);
    }
}