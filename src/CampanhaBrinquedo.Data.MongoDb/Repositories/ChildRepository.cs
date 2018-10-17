using CampanhaBrinquedo.Domain.Entities.Child;
using CampanhaBrinquedo.Domain.Repositories;

namespace Campanhabrinquedo.Data.MongoDb.Repositories
{
    public class ChildRepository : Repository<Child>, IChildRepository
    {
        public ChildRepository()
            : base() { }
    }
}