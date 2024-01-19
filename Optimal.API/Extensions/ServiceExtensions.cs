using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Optimal.API.Contracts;
using Optimal.API.Services;
using SpecMapperR;

namespace Optimal.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = Configuration["Redis:ConnectionString"];
            });

            services.AddScoped<IApiPublisher, ApiPublisher>();
            services.AddScoped<ISpecialMapper, SpecialMapper>();

            services.AddMassTransit(config =>
            {
                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(Configuration["EventBusSettings:HostAddress"]);
                });
            });

            return services;
        }
    }
}
