﻿using ArtificialIntel.Repos.Contracts;
using ArtificialIntel.Repos.Repositories;
using ArtificialIntel.Services.AppServices;
using ArtificialIntel.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace ArtificialIntel.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services.AddScoped<IOptimalRepo, OptimalRepository>();
            services.AddScoped<IGptService, GptService>();

            return services;
        }
    }
}
