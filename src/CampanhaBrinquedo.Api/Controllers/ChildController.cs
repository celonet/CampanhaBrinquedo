using CampanhaBrinquedo.Domain.Entities.Child;
using CampanhaBrinquedo.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Linq;
using CampanhaBrinquedo.Domain.Entities.Campaign;
using CampanhaBrinquedo.Domain.Services;

namespace CampanhaBrinquedo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildController : ControllerBase
    {
        private readonly IChildServiceApp _serviceApp;

        public ChildController(IChildServiceApp serviceApp) => _serviceApp = serviceApp;

        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get()
        {
            var childs = await _serviceApp.Get();
            return Ok(childs.OrderBy(c => c.Name));
        }

        // [HttpGet("{id}")]
        // [ProducesResponseType(200)]
        // [ProducesResponseType(204)]
        // [ProducesResponseType(400)]
        // [ProducesResponseType(500)]
        // public async Task<IActionResult> Get(Guid id)
        // {
        //     var child = await _repository.FindById(id);
        //     return Ok(child);
        // }

        // [HttpPost]
        // [ProducesResponseType(200)]
        // [ProducesResponseType(400)]
        // [ProducesResponseType(500)]
        // public async Task<IActionResult> Post([FromBody]Child child)
        // {
        //     await _repository.CreateAsync(child);
        //     return Ok();
        // }

        // [HttpPut]
        // [ProducesResponseType(200)]
        // [ProducesResponseType(400)]
        // [ProducesResponseType(500)]
        // public async Task<IActionResult> Put([FromBody]Child child)
        // {
        //     await _repository.UpdateAsync(child);
        //     return Ok();
        // }

        // [HttpDelete]
        // [ProducesResponseType(200)]
        // [ProducesResponseType(400)]
        // [ProducesResponseType(500)]
        // public async Task<IActionResult> Delete([FromBody]Guid id)
        // {
        //     await _repository.DeleteAsync(id);
        //     return Ok();
        // }
    }
}