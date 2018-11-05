using System;
using System.Threading.Tasks;

namespace CampanhaBrinquedo.Domain.Interfaces.Actions
{
    public interface IDelete
    {
        void Delete(Guid id);
        Task DeleteAsync(Guid id);
    }
}