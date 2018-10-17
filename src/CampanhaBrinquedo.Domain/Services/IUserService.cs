using System.Threading.Tasks;
using CampanhaBrinquedo.Domain.Entities.User;

namespace CampanhaBrinquedo.Domain.Services
{
    public interface IUserService : IServiceActions<User>
    {
        Task<bool> LogarUsuario(string usuario, string senha);
    }
}