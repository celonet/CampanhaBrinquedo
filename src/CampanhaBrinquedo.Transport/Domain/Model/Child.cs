using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;

namespace CampanhaBrinquedo.Transport.Model
{
    public class Child
    {
        [BsonId(IdGenerator = typeof(CombGuidGenerator))]
        public Guid Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("age")]
        public IList<Age> Age { get; set; }
        [BsonElement("clothings")]
        public IList<Clothing> Clothings { get; set; }
        [BsonElement("communities")]
        public IList<Community> Communities { get; set; }
        [BsonElement("godfathers")]
        public IList<GodFather> Godfathers { get; set; }
        [BsonElement("responsiblies")]
        public IList<Responsible> Responsiblies { get; set; }
        [BsonElement("campaigns")]
        public IList<Campaign> Campaigns { get; set; }
        [BsonElement("printed")]
        public IList<Printed> Printed { get; set; }
        [BsonElement("pcd")]
        public bool PCD { get; set; }
        [BsonElement("gender")]
        public string Gender { get; set; }
    }
}