using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using PhoneShop.Application.Interfaces;

namespace PhoneShop.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext later
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}