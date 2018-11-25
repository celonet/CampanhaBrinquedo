using Campanhabrinquedo.Repository.Repositories;
using CampanhaBrinquedo.Domain.Interfaces;
using CampanhaBrinquedo.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Campanhabrinquedo.IoC
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services) => services
                .AddSingleton<IUserRepository, UserRepository>()
                .AddSingleton<ICampaignRepository, CampaignRepository>()
                .AddSingleton<IChildRepository, ChildRepository>()
                .AddSingleton(typeof(IRepository<>), typeof(Repository<>));
    }
}
