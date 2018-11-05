using System;
using System.Threading.Tasks;
using Transporte.Full.Data.Repositories;

namespace Transporte.Full
{

    class Program
    {
        static async Task Main(string[] args)
        {
            var criancaRepository = new CriancaRepository(new SqlServerFactory());
            var childRepository = new ChildRepository(new MongoDbFactory());
            var campaignManager = new CampaignManager(criancaRepository, childRepository);

            campaignManager.CreateCampaign(new Campaign
            {
                Year = 2014,
                ChildrensQty = 200,
                Description = "",
                State = "Closed"
            });

            await campaignManager.Migrate();

            Console.WriteLine("Press any key to finishe");
            Console.ReadKey();
        }
    }
}