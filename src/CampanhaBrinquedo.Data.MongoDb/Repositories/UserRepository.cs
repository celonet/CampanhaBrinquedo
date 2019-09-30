using System.Threading.Tasks;
using CampanhaBrinquedo.Data.MongoDb.Factories;
using CampanhaBrinquedo.Domain.Entities.User;
using CampanhaBrinquedo.Domain.Repositories;
using CampanhaBriquedo.CrossCutting.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Campanhabrinquedo.Repository.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(
            IDatabaseFactory databaseFactory,
            IOptions<MongoOptions> mongoOptions
        ) : base(databaseFactory, mongoOptions, "User") { }

        public Task<User> Authenticate(string user, string password) => Collection.Find(_ => _.Email == user && _.Password == password).FirstOrDefaultAsync();
    }
}