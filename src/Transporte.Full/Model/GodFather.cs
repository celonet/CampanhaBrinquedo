using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Transporte.Full
{
    public class GodFather : Rastreabillity
    {
        public GodFather() { }

        public GodFather(int year, string name, Community community, string telephone, string cellphone, string email) : base(year)
        {
            Name = name;
            Community = community;
            Telephone = telephone;
            CellPhone = cellphone;
            Email = email;
        }

        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("community")]
        public Community Community { get; set; }
        [BsonElement("telephone")]
        public string Telephone { get; set; }
        [BsonElement("cellphone")]
        public string CellPhone { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
    }
}