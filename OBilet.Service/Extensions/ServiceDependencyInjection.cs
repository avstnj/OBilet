using Microsoft.Extensions.DependencyInjection;
using OBilet.Service.Abstract;
using OBilet.Service.Concreate;

namespace OBilet.Service.Extensions
{
    public static class ServiceDependencyInjection
    {
        public static void ConfigureServiceDI(this IServiceCollection services)
        {
            #region Dependency Injection
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<IBusLocationService, BusLocationService>();
            services.AddScoped<IBusJourneyService, BusJourneyService>();
            #endregion
        }
    }
}
