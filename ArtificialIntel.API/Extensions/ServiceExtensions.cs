using ArtificialIntel.API.Consumers;
using MassTransit;
using OptimalPackage.Common;
using SpecMapperR;
using ArtificialIntel.Application.Extensions;

namespace ArtificialIntel.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.RegisterAppServices();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceExtensions).Assembly));

            services.AddScoped<ISpecialMapper, SpecialMapper>();
            
            services.AddMassTransit(config =>
            {
                config.AddConsumer<IntroRequestConsumer>();

                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(Configuration["EventBusSettings:HostAddress"]);

                    cfg.ReceiveEndpoint(EventBusConstants.OptimalQueue, c =>
                    {
                        c.ConfigureConsumer<IntroRequestConsumer>(ctx);
                    });
                });
            });


            return services;
        }
    }
}
