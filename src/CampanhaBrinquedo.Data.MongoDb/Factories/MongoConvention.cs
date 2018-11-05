using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using System.Collections.Generic;

namespace Campanhabrinquedo.IoC
{
    internal class MongoConvention : IConventionPack
    {
        public IEnumerable<IConvention> Conventions => new List<IConvention>
            {
                new IgnoreExtraElementsConvention(true),
                new EnumRepresentationConvention(BsonType.String),
                new CamelCaseElementNameConvention()
            };
    }
}
