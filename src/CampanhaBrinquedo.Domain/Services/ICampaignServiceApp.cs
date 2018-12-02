using System.Threading.Tasks;
using CampanhaBrinquedo.Domain.Entities.Campaign;

namespace CampanhaBrinquedo.Domain.Services
{
    public interface ICampaignServiceApp
    {
        Task<Campaign> GetCurrent();

        Task CreateCampaign(Campaign campaign);

        Task ChangeState();
    }
}