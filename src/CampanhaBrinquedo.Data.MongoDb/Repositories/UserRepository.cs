using CampanhaBrinquedo.Domain.Entities.User;
using CampanhaBrinquedo.Domain.Repositories;

namespace Campanhabrinquedo.Data.MongoDb.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository()
            : base() { }
    }
}