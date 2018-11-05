using MongoDB.Bson.Serialization.Attributes;

namespace Transporte.Full
{
    public class Rastreabillity
    {
        public Rastreabillity() { }

        public Rastreabillity(int year) => Year = year;

        [BsonElement("year")]
        public int Year { get; set; }
    }
}