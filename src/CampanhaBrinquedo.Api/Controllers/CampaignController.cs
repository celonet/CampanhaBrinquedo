using CampanhaBrinquedo.Domain.Entities.Campaign;
using CampanhaBrinquedo.Domain.Repositories;
using CampanhaBrinquedo.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CampanhaBrinquedo.Api.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : BaseController
    {
        private readonly ICampaignServiceApp _campaignService;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public CampaignController(ICampaignServiceApp campaignService, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor) : base(userRepository, httpContextAccessor)
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

        [HttpPost("import/{year}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Import([FromRoute]int year, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("invalid file");
            }

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                await _campaignService.ImportCampaign(year, fileBytes);
            }

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

        [HttpPut("status/{changestatus}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Put([FromRoute]string changestatus)
        {
            Enum.TryParse(changestatus, out CampaignState status);
            var user = await GetUser();
            await _campaignService.ChangeState(status, user);
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
