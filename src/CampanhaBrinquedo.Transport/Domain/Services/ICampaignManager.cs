using System.Threading.Tasks;

namespace CampanhaBrinquedo.Transport
{
    internal interface ICampaignManager
    {
        Task CreateCampaign();
        Task Migrate();
    }
}