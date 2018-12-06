using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;

namespace CampanhaBrinquedo.Transport.Model
{
    public class Campaign
    {
        public Campaign()
        {

        }

        public Campaign(int year, string state)
        {
            this.Year = year;
            this.State = state;
            this.RegisterDate = DateTime.Now;
        }

        [BsonId(IdGenerator = typeof(CombGuidGenerator))]
        public Guid Id { get; set; }
        [BsonElement("year")]
        public int Year { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("childrensQty")]
        public int ChildrensQty { get; set; }
        [BsonElement("state")]
        public string State { get; set; }
        [BsonElement("registerDate")]
        public DateTime RegisterDate { get; set; }
    }
}