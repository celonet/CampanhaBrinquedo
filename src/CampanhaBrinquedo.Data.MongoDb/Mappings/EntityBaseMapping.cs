using CampanhaBrinquedo.Domain.Entities;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

namespace CampanhaBrinquedo.Data.MongoDb.Mappings
{

    public class EntityBaseMapping : IMongoMapping
    {
        public void Map()
        {
            BsonClassMap.RegisterClassMap<EntityBase>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(c => c.Id).SetIdGenerator(CombGuidGenerator.Instance);
            });
        }
    }
}
