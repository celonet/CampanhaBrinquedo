using CampanhaBrinquedo.Domain.Entities;

namespace CampanhaBrinquedo.Domain.Interfaces.Actions
{
    public interface IUpdate<in T> where T : EntityBase
    {
        void Update(T entitie);
    }
}