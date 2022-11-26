using Contracts.Logger;
using LoggerService;

namespace CompanyEmployees.Extentions
{
    public static class ServiceExtentions
    {
        public static void ConfigureLoggerService(this IServiceCollection services) => services.AddScoped<ILoggerManager, LoggerManager>();
    }
}
