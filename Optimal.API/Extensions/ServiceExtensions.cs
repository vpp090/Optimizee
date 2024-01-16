﻿using MassTransit;
using Optimal.API.Contracts;
using Optimal.API.Services;
using SpecMapperR;

namespace Optimal.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration Configuration)
        {
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
