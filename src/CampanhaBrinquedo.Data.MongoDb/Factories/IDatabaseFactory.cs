using CampanhaBriquedo.CrossCutting.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CampanhaBrinquedo.Data.MongoDb.Factories
{
    public interface IDatabaseFactory
    {
        IMongoDatabase Get(IOptions<MongoOptions> mongoOptions);
    }
}
