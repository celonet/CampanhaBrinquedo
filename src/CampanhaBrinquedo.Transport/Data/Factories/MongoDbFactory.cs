using CampanhaBriquedo.CrossCutting.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CampanhaBrinquedo.Transport.Utils
{
    public class MongoDbFactory : IConnectionFactory<IMongoDatabase>
    {
        private readonly MongoOptions _options;

        public MongoDbFactory(IOptions<MongoOptions> options) => _options = options.Value;

        public IMongoDatabase GetConnection()
        {
            var client = new MongoClient(_options.ConnectionString);
            return client.GetDatabase(_options.Database);
        }
    }
}