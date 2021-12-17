using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

namespace Apl.ERP.API.Configurations
{
    public static class SwaggerConfiguration
    {
        private static string version;

        public static IServiceCollection AddSwaggerService(this IServiceCollection services, Assembly assembly)
        {
            version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc($"v{version}", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Domingo Matte hiriart"
                    },
                    Title = "MEDGRUO - API WEB",
                    Version = $"v{version}"
                }); ;
            });

            return services;
        }

        public static IApplicationBuilder AddSwaggerApplication(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "MEDGRUPO";
                c.SwaggerEndpoint($"/swagger/v{version}/swagger.json", $"v{version}");
            });

            return app;
        }
    }
}
