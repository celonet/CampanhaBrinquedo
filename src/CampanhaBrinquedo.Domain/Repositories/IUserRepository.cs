using CampanhaBrinquedo.Domain.Interfaces;
using CampanhaBrinquedo.Domain.Entities.User;
using System.Threading.Tasks;

namespace CampanhaBrinquedo.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Authenticate(string user, string password);
    }
}