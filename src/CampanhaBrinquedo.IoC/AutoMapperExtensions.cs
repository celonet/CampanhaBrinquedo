using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Campanhabrinquedo.IoC
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection RegisterAutoMapper(this IServiceCollection services) => services
                .AddSingleton(Mapper.Configuration)
                .AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
    }
}
