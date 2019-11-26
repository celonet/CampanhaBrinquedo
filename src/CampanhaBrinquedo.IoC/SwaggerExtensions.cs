using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CampanhaBrinquedo.IoC
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection service) 
            => service.AddSwaggerGen(_ =>
                        {
                            _.SwaggerDoc(
                                "v1",
                                new Info
                                {
                                    Title = "Campanha do Brinquedo",
                                    Version = "v1",
                                    Description = "Api para Campanha do Brinquedo",
                                    Contact = new Contact
                                    {
                                        Name = "Marcelo Lopes",
                                        Url = "https://github.com/celonet/CampanhaBrinquedo"
                                    }
                                }
                            );
                        });

        public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder app) 
            => app
                .UseSwagger()
                .UseSwaggerUI(_ =>
                    {
                        _.SwaggerEndpoint("/swagger/v1/swagger.json", "Campanha do Brinquedo");
                    });
    }
}
