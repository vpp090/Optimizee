using ArtificialIntel.API.Consumers;
using MassTransit;
using OptimalPackage.Common;
using SpecMapperR;
using ArtificialIntel.Application.Extensions;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;

namespace ArtificialIntel.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddHttpClient();

            services.RegisterAppServices(Configuration);
            
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Application.Extensions.ServiceExtensions).Assembly));

            services.AddScoped<ISpecialMapper, SpecialMapper>();
            
            services.AddMassTransit(config =>
            {
                config.AddConsumer<IntroRequestConsumer>();
                config.AddConsumer<CrossrefRequestConsumer>();

                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(Configuration["EventBusSettings:HostAddress"]);

                    cfg.ReceiveEndpoint(EventBusConstants.OptimalQueue, c =>
                    {
                        c.ConfigureConsumer<IntroRequestConsumer>(ctx);
                    });

                    cfg.ReceiveEndpoint(EventBusConstants.CrossrefQueue, c =>
                    {
                        c.ConfigureConsumer<CrossrefRequestConsumer>(ctx);
                    });
                });
            });


            return services;
        }
    }
}
