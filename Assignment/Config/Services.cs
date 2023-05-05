﻿using Assignment.Services;

namespace Assignment.Config
{
    public static class Services
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<ICalculationsService, CalculationsService>();
            return services;
        }
    }
}
