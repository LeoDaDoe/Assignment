using Assignment.Services;

namespace Assignment.Config
{
    public class Services
    {
        public IServiceCollection RegisterServices(IServiceCollection services)
        {
            services.AddTransient<ICalculationsService, CalculationsService>();
            return services;
        }
    }
}
