using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Transporte.Full
{
    public class Community : Rastreabillity
    {
        public Community(int year, string name, string neighborhood) : base(year)
        {
            this.Name = name;
            this.Neighborhood = neighborhood;
        }

        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("neighborhood")]
        public string Neighborhood { get; set; }
    }
}