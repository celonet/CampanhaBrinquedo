using System.Threading.Tasks;
using CampanhaBrinquedo.Domain.Entities.Campaign;
using CampanhaBrinquedo.Domain.Repositories;
using CampanhaBrinquedo.Domain.Services;

namespace CampanhaBrinquedo.Application.Services
{
    public class CampaignService : ICampaignServiceApp
    {
        private readonly ICampaignRepository _repository;

        public CampaignService(ICampaignRepository repository) => _repository = repository;

        public Task ChangeState()
        {
            throw new System.NotImplementedException();
        }

        public Task CreateCampaign(Campaign campaign) => _repository.CreateAsync(campaign);

        public async Task<Campaign> GetCurrent() => await _repository.FindByExpression(_ => _.State == CampaignState.Open);
    }
}