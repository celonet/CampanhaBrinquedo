using Microsoft.AspNetCore.Builder;

namespace CampanhaBrinquedo.IoC
{
    public static class CorsExtensions
    {
        public static IApplicationBuilder ConfigureCors(this IApplicationBuilder app)
        {
            return app.UseCors(builder => builder
                   .AllowAnyMethod()
                   .AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowCredentials()
                );
        }
    }
}
