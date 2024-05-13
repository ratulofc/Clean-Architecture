using Ecommerce.Core.Interfaces.Repositories;
using Ecommerce.Core.Interfaces.Services;
using Ecommerce.Core.Services;
using Ecommerce.Infrastructure.Repositories;

namespace Ecommerce.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();


            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
