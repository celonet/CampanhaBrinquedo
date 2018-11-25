using CampanhaBrinquedo.Transport.Model;
using CampanhaBrinquedo.Transport.Utils;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampanhaBrinquedo.Transport.Data.Repositories
{
    public class ChildRepository : IChildRepository
    {
        private IConnectionFactory<IMongoDatabase> _connectionFactory;
        private readonly IMongoDatabase _database;

        public ChildRepository(IConnectionFactory<IMongoDatabase> connectionFactory)
        {
            _connectionFactory = connectionFactory;
            _database = _connectionFactory.GetConnection();
        }

        private IMongoCollection<Campaign> _campaignCollection => _database.GetCollection<Campaign>("Campaign");

        private IMongoCollection<Child> _childCollection => _database.GetCollection<Child>("Child");

        public async Task InsertCampaign(Campaign campaign)
        {
            try
            {
                await _campaignCollection.InsertOneAsync(campaign);
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
                await _childCollection.InsertOneAsync(child);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<IEnumerable<Child>> GetChilds()
        {
            try
            {
                return await _childCollection.AsQueryable().ToListAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public async Task UpdateChild(Child newChild)
        {
            try
            {
                await _childCollection.ReplaceOneAsync(_ => _.Id == newChild.Id, newChild);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<Campaign> GetCampaign(int year)
        {
            try
            {
                return await _campaignCollection.Find(_ => _.Year == year).FirstOrDefaultAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public async Task UpdateCampaign(Campaign campaign)
        {
            try
            {
                await _campaignCollection.ReplaceOneAsync(_ => _.Year == campaign.Year, campaign);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
