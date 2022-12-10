using Contracts.Logger;
using Contracts.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployees.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IRepositoryManager repositoryManager;
        
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private ILoggerManager _logger; 
        public WeatherForecastController(ILoggerManager logger, IRepositoryManager repositoryManager) 
        { 
            _logger = logger; 
            this.repositoryManager = repositoryManager;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogInfo("Here is info message from our values controller."); 
            _logger.LogDebug("Here is debug message from our values controller."); 
            _logger.LogWarn("Here is warn message from our values controller."); 
            _logger.LogError("Here is an error message from our values controller.");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet(Name = "GetEmployees")]
        public IEnumerable<string> GetEmployees()
        {
            return new string[] { "value1", "value2" };
        }
    }
}