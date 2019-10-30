using CampanhaBrinquedo.Domain.Entities.Campaign;
using CampanhaBrinquedo.Domain.Repositories;
using CampanhaBrinquedo.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampanhaBrinquedo.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignServiceApp _campaignService;

        public CampaignController(ICampaignServiceApp campaignService) 
            => _campaignService = campaignService;

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Campaign>), 200)]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get()
        {
            var campaigns = await _campaignService.GetCurrent();
            return Ok(campaigns);
        }

        [HttpGet("informations")]
        [ProducesResponseType(typeof(IEnumerable<CampaignInformation>), 200)]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetDashBoard()
        {
            var metricsCampaign = await _campaignService.GetInformations();
            return Ok(metricsCampaign);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody]Campaign entity)
        {
            await _campaignService.CreateCampaign(entity);
            return Ok();
        }


        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Put([FromBody]Campaign entity)
        {
            await _campaignService.ChangeCampaign(entity);
            return Ok();
        }


        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _campaignService.DeleteCampaign(id);
            return Ok();
        }
    }
}
