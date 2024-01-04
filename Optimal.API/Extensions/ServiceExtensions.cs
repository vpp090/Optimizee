using Optimal.API.Contracts;
using Optimal.API.Services;

namespace Optimal.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IApiSender, ApiSender>();

            return services;
        }
    }
}
