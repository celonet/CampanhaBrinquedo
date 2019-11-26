using CampanhaBrinquedo.Api.ViewModel;
using CampanhaBrinquedo.CrossCutting.Options;
using CampanhaBrinquedo.Domain.Entities.User;
using CampanhaBrinquedo.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaBrinquedo.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly JwtIssuerOptions _jwtOptions;

        public UserController(IOptions<JwtIssuerOptions> jwtOptions, IUserRepository repository)
        {
            _repository = repository;
            _jwtOptions = jwtOptions.Value;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get(Guid userId)
        {
            var user = await _repository.FindById(userId);
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UserViewModel userViewModel)
        {
            var userExists = await _repository.FindByExpression(_ => _.Email == userViewModel.Email);
            if (userExists != null)
            {
                return BadRequest("Usuario já existe");
            }

            var newUser = new User(userViewModel.Name, userViewModel.Email, userViewModel.Password);
            await _repository.CreateAsync(newUser);

            return Created("User", newUser);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("token")]
        public async Task<IActionResult> GenerateToken([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(model);
            }

            var result = await _repository.Authenticate(model.User, model.Password);
            if (result == null)
            {
                return BadRequest("Invalid username or password");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, result.Email),
                new Claim(ClaimTypes.Email, result.Email),
                new Claim(ClaimTypes.Name, result.Email)
            };

            var tokenExpiration = TimeSpan.FromSeconds(_jwtOptions.Expiration);
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtOptions.SecretKey));
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                _jwtOptions.Issuer,
                _jwtOptions.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(tokenExpiration),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            );

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return Ok(new
            {
                access_token = encodedJwt,
                expires_in = (int)tokenExpiration.TotalSeconds
            });
        }
    }
}