using CompanyEmployees.ActionFilters;
using CompanyEmployees.Extentions;
using CompanyEmployees.Utilities;
using CompanyEmployees.Utilities.Constants;
using Contracts.Logger;
using Contracts.Utility;
using Entities.DataTransferObjects;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using NLog;
using Repository.DataShaping;
using System.Reflection;

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureRepositoryService();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddScoped<ValidationFilterAttribute>();
builder.Services.AddScoped<ValidateCompanyExistsAttribute>();
builder.Services.AddScoped<IDataShaper<EmployeeDto>, DataShaper<EmployeeDto>>();
builder.Services.AddScoped<EmployeeLinks>();

builder.Services.ConfigureResponseCaching();
builder.Services.AddHttpCacheHeaders(
    (expirationModelOptions) =>
    {
        expirationModelOptions.MaxAge = 65;
        expirationModelOptions.CacheLocation = Marvin.Cache.Headers.CacheLocation.Private;
    },
    (validationModelOptions) =>
    {
        validationModelOptions.MustRevalidate = true;
    });

builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
    config.CacheProfiles.Add(CacheProfileConstants.Profile120Seconds, new CacheProfile { Duration = 120 });
}).
AddXmlDataContractSerializerFormatters().
AddCustomCSVFormatter();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin();
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                      });
});
builder.Services.ConfigureLoggerService();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;

    var logger = services.GetRequiredService<ILoggerManager>();


    app.ConfigureExceptionHandler(logger);

}
app.UseResponseCaching();
app.UseHttpCacheHeaders();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
