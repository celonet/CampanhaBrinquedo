using CampanhaBrinquedo.Domain.Entities.User;
using CampanhaBrinquedo.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CampanhaBrinquedo.Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected new readonly string User;
        protected IUserRepository _userRepository;

        public BaseController(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            User = httpContextAccessor.HttpContext.User.Identity.Name;
        }

        protected Task<User> GetUser() => _userRepository.FindByExpression(_ => _.Email == User);
    }
}
