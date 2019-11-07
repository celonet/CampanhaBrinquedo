using CampanhaBrinquedo.Application.Services;
using CampanhaBrinquedo.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CampanhaBrinquedo.IoC
{
    public static class ServiceAppExtensions
    {
        public static IServiceCollection RegisterServiceApp(this IServiceCollection service) 
            => service
                .AddScoped<ICampaignServiceApp, CampaignService>()
                .AddScoped<IChildServiceApp, ChildService>()
                .AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }
}