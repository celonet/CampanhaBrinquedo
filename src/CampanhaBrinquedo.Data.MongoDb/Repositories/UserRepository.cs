using CampanhaBrinquedo.Data.MongoDb.Factories;
using CampanhaBrinquedo.Domain.Entities.User;
using CampanhaBrinquedo.Domain.Repositories;
using CampanhaBriquedo.CrossCutting.Options;
using Microsoft.Extensions.Options;

namespace campanhabrinquedo.repository.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(
            IDatabaseFactory databaseFactory,
            IOptions<MongoOptions> mongoOptions
        )
            : base(databaseFactory, mongoOptions, "User") { }
    }
}