using System;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Transporte.Full.Data.Repositories
{
    public class ChildRepository
    {
        private IConnectionFactory<IMongoDatabase> _connectionFactory;
        private readonly IMongoDatabase _database;

        public ChildRepository(IConnectionFactory<IMongoDatabase> connectionFactory)
        {
            _connectionFactory = connectionFactory;
            _database = _connectionFactory.GetConnection();
        }

        public async Task InsertCampaign(Campaign campaign)
        {
            try
            {
                var collection = _database.GetCollection<Campaign>("Campaign");
                await collection.InsertOneAsync(campaign);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task InsertChild(Child child)
        {
            try
            {
                var collection = _database.GetCollection<Child>("Child");
                await collection.InsertOneAsync(child);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
