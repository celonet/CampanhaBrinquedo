using CampanhaBrinquedo.Data.MongoDb.Factories;
using CampanhaBrinquedo.Domain.Entities.Child;
using CampanhaBrinquedo.Domain.Repositories;
using CampanhaBriquedo.CrossCutting.Options;
using Microsoft.Extensions.Options;

namespace campanhabrinquedo.repository.Repositories
{
    public class ChildRepository : Repository<Child>, IChildRepository
    {
        public ChildRepository(
            IDatabaseFactory databaseFactory,
            IOptions<MongoOptions> mongoOptions
        ) : base(databaseFactory, mongoOptions, "Child") { }
    }
}