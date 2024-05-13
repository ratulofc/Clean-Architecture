using Ecommerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Api
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            services.AddCors(options => 
                options.AddPolicy("corspolicy", build =>
                    {
                        build.WithOrigins("http://localhost:5173")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    }));
        }
        public static void ConfigureDBContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<StoreDBContext>(opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConStr"))
            );
        }
    }
}
