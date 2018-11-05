using CampanhaBrinquedo.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CampanhaBrinquedo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _repository;

        public UserController(IUserRepository repository) => _repository = repository;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _repository.FindById(Guid.NewGuid());
            return Ok();
        }
    }
}