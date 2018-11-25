using CampanhaBrinquedo.Transport.Data.Repositories;
using CampanhaBrinquedo.Transport.Utils;
using CampanhaBriquedo.CrossCutting.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CampanhaBrinquedo.Transport
{
    internal class Program
    {
        public static IConfigurationRoot Configuration { get; set; }

        public static async Task Main()
        {
            ConfigureConfiguration();

            ServiceProvider serviceProvider = ConfigureDI();

            var campaignManager = serviceProvider.GetService<ICampaignManager>();
            await campaignManager.CreateCampaign();
            await campaignManager.Migrate();

            Console.WriteLine("Press any key to finish");
            Console.ReadKey();
        }

        private static ServiceProvider ConfigureDI()
        {
            return new ServiceCollection()
                .Configure<MongoOptions>(options => Configuration.GetSection("Mongo").Bind(options))
                .Configure<CampaignOptions>(options => Configuration.GetSection("Campaign").Bind(options))
                .AddSingleton<IConnectionFactory<IMongoDatabase>, MongoDbFactory>()
                .AddScoped<ICriancaRepository, XmlRepository>()
                .AddScoped<IChildRepository, ChildRepository>()
                .AddScoped<ICampaignManager, CampaignManager>()
                .BuildServiceProvider();
        }

        private static void ConfigureConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
        }
    }
}
