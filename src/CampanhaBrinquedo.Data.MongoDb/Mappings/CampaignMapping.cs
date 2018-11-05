using CampanhaBrinquedo.Domain.Entities.Campaign;
using MongoDB.Bson.Serialization;

namespace CampanhaBrinquedo.Data.MongoDb.Mappings
{
    public class CampaignMapping : IMongoMapping
    {
        public void Map()
        {
            BsonClassMap.RegisterClassMap<Campaign>(cm =>
            {
                cm.AutoMap();
                cm.UnmapMember(c => c.State);
                //.SetSerializer(new EnumSerializer<ICampaignState>(BsonType.String));
            });
        }
    }
}
