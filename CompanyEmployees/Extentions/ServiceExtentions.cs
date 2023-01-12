using CompanyEmployees.ResponseFormatter;
using Contracts.Logger;
using Contracts.Repository;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Persistance.Repositories;
using Repository.Services;

namespace CompanyEmployees.Extentions
{
    public static class ServiceExtentions
    {
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddScoped<ILoggerManager, LoggerManager>();
        public static void ConfigureRepositoryService(this IServiceCollection services) => 
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) => 
            services.AddDbContext<RepositoryContext>(opts => 
            opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

        public static IMvcBuilder AddCustomCSVFormatter(this IMvcBuilder builder) => 
            builder.AddMvcOptions(config => 
            config.OutputFormatters.Add(new CsvOutputFormatter()));

        public static void ConfigureResponseCaching(this IServiceCollection services) => services.AddResponseCaching();
    }
}
