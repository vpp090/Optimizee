using MassTransit;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.Extensions.DependencyInjection;
using Optimal.API.Consumers;
using Optimal.API.Contracts;
using Optimal.API.Repos;
using Optimal.API.Services;
using OptimalPackage.Common;
using OptimalPackage.Events;
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

            services.AddScoped<IRedisRepo, RedisRepo>();
            services.AddScoped<IApiPublisher, ApiPublisher>();
            services.AddScoped<ISpecialMapper, SpecialMapper>();

            services.AddMassTransit(config =>
            {
                config.AddConsumer<WorkspaceSavedConsumer>();

                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(Configuration["EventBusSettings:HostAddress"]);

                    cfg.ReceiveEndpoint(EventBusConstants.WorkspaceQueue, e =>
                    {
                        e.ConfigureConsumer<WorkspaceSavedConsumer>(ctx);
                    });
                });
            });

            return services;
        }
    }
}
