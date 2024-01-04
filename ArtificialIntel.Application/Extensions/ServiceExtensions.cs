using ArtificialIntel.Repos.Contracts;
using ArtificialIntel.Repos.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ArtificialIntel.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services.AddScoped<IOptimalRepo, OptimalRepository>();

            return services;
        }
    }
}
