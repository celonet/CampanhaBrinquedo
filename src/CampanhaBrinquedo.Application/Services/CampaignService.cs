using CampanhaBrinquedo.Domain.Entities.Campaign;
using CampanhaBrinquedo.Domain.Entities.Child;
using CampanhaBrinquedo.Domain.Repositories;
using CampanhaBrinquedo.Domain.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CampanhaBrinquedo.Application.Services
{
    public class CampaignService : ICampaignServiceApp
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly IChildRepository _childRepository;

        public CampaignService(ICampaignRepository campaignRepository, IChildRepository childRepository)
        {
            _campaignRepository = campaignRepository;
            _childRepository = childRepository;
        }

        public async Task ChangeCampaign(Campaign entity) => await _campaignRepository.UpdateAsync(entity);

        public async Task ChangeState(CampaignState state)
        {
            //var campaign = await GetCurrent();
            throw new System.NotImplementedException();
        }

        public async Task CreateCampaign(Campaign campaign) => await _campaignRepository.CreateAsync(campaign);

        public async Task DeleteCampaign(Guid id) => await _campaignRepository.DeleteAsync(id);

        public async Task<Campaign> GetCurrent() => await _campaignRepository.FindByExpression(_ => _.State == CampaignState.Open);

        public async Task<CampaignInformation> GetInformations()
        {
            var campaign = await GetCurrent();
            var childs = await _childRepository.GetCriancasPorCampanha(campaign.Year);
            var communities = childs.SelectMany(_ => _.Communities).Select(_ => _.Name).Distinct();
            var godFathers = childs.SelectMany(_ => _.GodFathers).Select(_ => _.Name).Distinct();
            return new CampaignInformation(
                campaign.Year, 
                new CampaignAnalitics
                {
                    Capacity = campaign.ChildrensQty,
                    ChildrenQty = childs.Count(),
                    CommunityQty = communities.Count(),
                    GodFatherQty = godFathers.Count(),
                }, 
                new GenderAnalitcs
                {
                    MaleQty = childs.Count(_ => _.Gender == Gender.Male),
                    FemaleQty = childs.Count(_ => _.Gender == Gender.Woman)
                }
            );
        }

        public Task ImportCampaign(byte[] file)
        {
            throw new NotImplementedException();
        }
    }
}