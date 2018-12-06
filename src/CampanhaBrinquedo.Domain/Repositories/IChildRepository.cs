using CampanhaBrinquedo.Domain.Entities.Child;
using CampanhaBrinquedo.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampanhaBrinquedo.Domain.Repositories
{
    public interface IChildRepository : IRepository<Child>
    {
        Task<IEnumerable<Child>> GetCriancasPorCampanha(int year);
    }
}