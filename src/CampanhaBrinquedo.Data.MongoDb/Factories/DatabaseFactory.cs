using Campanhabrinquedo.IoC;
using CampanhaBrinquedo.Data.MongoDb.Mappings;
using CampanhaBriquedo.CrossCutting.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace CampanhaBrinquedo.Data.MongoDb.Factories
{

    public class DatabaseFactory : IDatabaseFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public DatabaseFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IMongoDatabase Get(IOptions<MongoOptions> mongoOptions)
        {
            RegisterConventions();
            var configuration = mongoOptions.Value;
            var mongoClient = new MongoClient(configuration.ConnectionString);
            return mongoClient.GetDatabase(configuration.Database);
        }

        private void RegisterConventions()
        {
            ConventionRegistry.Register("ActioConventions", new MongoConvention(), x => true);
            BsonSerializer.RegisterIdGenerator(typeof(Guid), CombGuidGenerator.Instance);
            var mappings = _serviceProvider.GetServices<IMongoMapping>();
            foreach(var mapping in mappings)
            {
                mapping.Map();
            }
        }
    }
}
