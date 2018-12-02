using System.Collections.Generic;
using System.Threading.Tasks;
using CampanhaBrinquedo.Domain.Entities.Child;

namespace CampanhaBrinquedo.Domain.Services
{
    public interface IChildServiceApp
    {
        Task<IEnumerable<Child>> Get();
    }
}