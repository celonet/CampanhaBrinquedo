using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Campanhabrinquedo.Data.MongoDb
{
    public partial class MongoInitializer : IDatabaseInitializer
    {
        private bool _initialized;
        private readonly IMongoDatabase _database;

        public MongoInitializer(IMongoDatabase database) => _database = database;

        public void Initialize()
        {
            if (_initialized)
                return;

            RegisterConventions();
            _initialized = true;
        }

        private void RegisterConventions()
        {
            ConventionRegistry.Register("ActioConventions", new MongoConvention(), _ => true);
        }
    }
}
