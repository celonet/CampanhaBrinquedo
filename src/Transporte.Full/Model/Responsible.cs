using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Transporte.Full
{
    public class Responsible : Rastreabillity
    {
        public Responsible(int year, string name, string rg) : base(year)
        {
            this.Name = name;
            this.RG = rg;
        }

        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("rg")]
        public string RG { get; set; }
    }
}