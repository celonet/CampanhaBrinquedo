using CampanhaBrinquedo.Domain.Entities.Campaign;
using MongoDB.Bson.Serialization;

namespace CampanhaBrinquedo.Data.MongoDb.Mappings
{
    public class CampaignMapping : IMongoMapping
    {
        public void Map()
        {
            if(!BsonClassMap.IsClassMapRegistered(typeof(Campaign)))
            {
                BsonClassMap.RegisterClassMap<Campaign>(cm =>
                {
                    cm.AutoMap();
                    cm.UnmapField(c => c.CampaignActionState);
                    cm.UnmapMember(c => c.State);
                });
            }
        }
    }
}
