using CampanhaBrinquedo.Domain.Entities.Child;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Linq;
using CampanhaBrinquedo.Domain.Services;
using CampanhaBrinquedo.Api.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace CampanhaBrinquedo.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ChildController : ControllerBase
    {
        private readonly IChildServiceApp _serviceApp;

        public ChildController(IChildServiceApp serviceApp) => _serviceApp = serviceApp;

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get()
        {
            var childs = await _serviceApp.Get();
            return Ok(childs.OrderBy(c => c.Name));
        }

        [HttpGet("all")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAll()
        {
            var childs = await _serviceApp.GetAll();
            return Ok(childs.OrderBy(c => c.Name));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get(Guid id)
        {
            var child = await _serviceApp.GetById(id);
            return Ok(child);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody]Child child)
        {
            await _serviceApp.Create(child);
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Put([FromBody]Child child)
        {
            await _serviceApp.Update(child);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Delete([FromBody]Guid id)
        {
            await _serviceApp.Delete(id);
            return Ok();
        }

        [HttpPut("associate")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Associate([FromBody]ChildAssociate childAssociate)
        {
            await _serviceApp.Associate(childAssociate.ChildId, childAssociate.AssociateChild);
            return Ok();
        }
    }
}