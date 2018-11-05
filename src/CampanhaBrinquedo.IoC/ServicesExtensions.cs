using Microsoft.Extensions.DependencyInjection;

namespace Campanhabrinquedo.IoC
{
    public static class ServicesExtensions
    {
        public static IServiceCollection RegisterAppService(this IServiceCollection services)
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
