using CampanhaBrinquedo.Domain.Entities.User;
using CampanhaBrinquedo.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CampanhaBrinquedo.Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected new readonly string User;
        protected IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BaseController(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            User = HttpContext.User.Identity.Name;
            _httpContextAccessor = httpContextAccessor;

            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

        }

        protected Task<User> GetUser() => _userRepository.FindByExpression(_ => _.Name == User);
    }
}
