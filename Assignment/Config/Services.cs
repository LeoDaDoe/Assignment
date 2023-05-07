using Assignment.Services;

namespace Assignment.Config
{
    public static class Services
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IApiRequestProcessingService, ApiRequestProcessingService>();
            services.AddTransient<ILoggingService, LoggingService>();
            services.AddTransient<ISortingService, SortingService>();
            services.AddTransient<IApiRequestProcessingService, ApiRequestProcessingService>();
            services.AddTransient<IApiInputValidationService, ApiInputValidationService>();
            return services;
        }
    }
}
