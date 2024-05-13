using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Ecommerce.Api
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            string serviceDescription = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "ServiceDescription.md"));
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("V1", new OpenApiInfo { 
                    Title = "Ecommerce",
                    Version = "V1", 
                    Description = serviceDescription, 
                    TermsOfService = new Uri("https://example.com/terms"), 
                    Contact = new OpenApiContact 
                    {
                        Name = "Ecommerce",
                        Email = "contact@email.com",
                        Url = new Uri("https://example.com/terms")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Ecommerce",
                        Url = new Uri("https://example.com/terms")
                    }
                });
                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                options.IncludeXmlComments(xmlPath);
                options.CustomOperationIds(e => $"{e.ActionDescriptor.RouteValues["controller"]}_{e.ActionDescriptor.RouteValues["Action"]}");
            });

            return services;
        }
        public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder app)
        {
            if (app is null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/V1/swagger.json", "Ecommerce V1"));

            return app;
        }
    }
}
