using CampanhaBrinquedo.Data.MongoDb.Factories;
using CampanhaBrinquedo.Data.MongoDb.Mappings;
using CampanhaBriquedo.CrossCutting.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Campanhabrinquedo.IoC
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection RegisterDatabase(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var configuration = provider.GetService<IConfiguration>();

            return services
                .Configure<MongoOptions>(options => configuration.GetSection("Mongo").Bind(options))
                .AddSingleton<IDatabaseFactory, DatabaseFactory>()
                .AddTransient<IMongoMapping, EntityBaseMapping>()
                .AddTransient<IMongoMapping, ChildMapping>();
        }
    }
}
