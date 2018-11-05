using CampanhaBrinquedo.Domain.Entities.Child;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace CampanhaBrinquedo.Data.MongoDb.Mappings
{
    public class ChildMapping : IMongoMapping
    {
        public void Map()
        {
            BsonClassMap.RegisterClassMap<Child>(cm => {
                cm.AutoMap();
                cm.MapMember(c => c.Gender).SetSerializer(new EnumSerializer<Gender>(BsonType.String));
                cm.UnmapMember(c => c.Campaigns);
                //cm.UnmapMember(c => c.Printed);
            });
        }
    }
}
