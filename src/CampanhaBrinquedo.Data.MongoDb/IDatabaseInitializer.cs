using System.Threading.Tasks;

namespace Campanhabrinquedo.Data.MongoDb
{
    public interface IDatabaseInitializer
    {
        Task InitializeAsync();
    }
}
