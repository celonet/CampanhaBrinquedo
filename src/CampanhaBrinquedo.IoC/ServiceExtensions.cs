using Microsoft.Extensions.DependencyInjection;

namespace Campanhabrinquedo.IoC
{
    internal static class ServiceExtensions
    {
        public static IServiceCollection RegisterService(this IServiceCollection services)
            => services
                //.AddScoped<IUserService, UserService>()
                //.AddScoped<ICampaignService, CampaignService>()
                //.AddScoped<ICommunityService, CommunityService>()
                //.AddScoped<IChildService, ChildService>()
                //.AddScoped<IGodFatherService, GodFatherService>()
                //.AddScoped<IResponsibleService, ResponsibleService>();
                ;
    }
}
