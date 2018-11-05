using MongoDB.Bson.Serialization.Attributes;

namespace Transporte.Full
{
    public class Printed : Rastreabillity
    {
        public Printed(int year, bool printed) : base(year) => this.HasPrinted = printed;
        [BsonElement("hasPrinted")]
        public bool HasPrinted { get; set; }
    }
}