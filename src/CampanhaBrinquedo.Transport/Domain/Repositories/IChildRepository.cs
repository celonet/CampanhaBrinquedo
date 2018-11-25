using System.Collections.Generic;
using System.Threading.Tasks;
using CampanhaBrinquedo.Transport.Model;

namespace CampanhaBrinquedo.Transport.Data.Repositories
{
    public interface IChildRepository
    {
        Task<Campaign> GetCampaign(int year);
        Task<IEnumerable<Child>> GetChilds();
        Task InsertCampaign(Campaign campaign);
        Task UpdateCampaign(Campaign campaign);
        Task InsertChild(Child child);
        Task UpdateChild(Child newChild);
    }
}