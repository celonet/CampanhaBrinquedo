using MongoDB.Bson.Serialization.Attributes;

namespace Transporte.Full
{
    public class Clothing : Rastreabillity
    {
        public Clothing(int year, string description) : base(year) => this.Description = description;
        [BsonElement("description")]
        public string Description { get; set; }
    }
}