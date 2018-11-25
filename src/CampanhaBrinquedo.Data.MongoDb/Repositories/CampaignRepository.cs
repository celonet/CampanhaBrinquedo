using CampanhaBrinquedo.Data.MongoDb.Factories;
using CampanhaBrinquedo.Domain.Entities.Campaign;
using CampanhaBrinquedo.Domain.Repositories;
using CampanhaBriquedo.CrossCutting.Options;
using Microsoft.Extensions.Options;

namespace Campanhabrinquedo.Repository.Repositories
{
    public class CampaignRepository : Repository<Campaign>, ICampaignRepository
    {
        public CampaignRepository(IDatabaseFactory databaseFactory, IOptions<MongoOptions> mongoOptions)
            : base(databaseFactory, mongoOptions, "Campaign") { }
    }
}