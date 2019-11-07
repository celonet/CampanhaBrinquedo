using System;
using System.Threading.Tasks;
using CampanhaBrinquedo.Domain.Entities.Campaign;
using CampanhaBrinquedo.Domain.Entities.User;

namespace CampanhaBrinquedo.Domain.Services
{
    public interface ICampaignServiceApp
    {
        Task<Campaign> GetCurrent();

        Task CreateCampaign(Campaign campaign);

        Task ChangeState(CampaignState state, User user);
        Task ChangeCampaign(Campaign entity);
        Task DeleteCampaign(Guid id);
        Task ImportCampaign(int year, byte[] file);
        Task<CampaignInformation> GetInformations();
    }
}