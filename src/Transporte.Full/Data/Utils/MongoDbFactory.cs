using MongoDB.Driver;

namespace Transporte.Full
{
    public class MongoDbFactory : IConnectionFactory<IMongoDatabase>
    {
        public IMongoDatabase GetConnection()
        {
            var connectionString = "";
            var client = new MongoClient(connectionString);
            return client.GetDatabase("CampanhaBrinquedo");
        }
    }
}