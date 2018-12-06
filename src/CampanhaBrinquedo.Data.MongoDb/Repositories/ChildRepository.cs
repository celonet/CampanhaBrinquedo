using System.Collections.Generic;
using System.Threading.Tasks;
using CampanhaBrinquedo.Data.MongoDb.Factories;
using CampanhaBrinquedo.Domain.Entities.Child;
using CampanhaBrinquedo.Domain.Repositories;
using CampanhaBriquedo.CrossCutting.Options;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Campanhabrinquedo.Repository.Repositories
{
    public class ChildRepository : Repository<Child>, IChildRepository
    {
        public ChildRepository(
            IDatabaseFactory databaseFactory,
            IOptions<MongoOptions> mongoOptions
        ) : base(databaseFactory, mongoOptions, "Child") { }

        public async Task<IEnumerable<Child>> GetCriancasPorCampanha(int year)
        {
            var spec = new BsonDocument("campaigns.year", new BsonDocument("$eq", year));
            return await this.Collection.Find(spec).ToListAsync();
        }
    }
}