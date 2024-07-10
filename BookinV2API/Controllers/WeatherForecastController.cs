using BookinV2.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookinV2API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing",
            "Bracing",
            "Chilly",
            "Cool",
            "Mild",
            "Warm",
            "Balmy",
            "Hot",
            "Sweltering",
            "Scorching",
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly BookingV2DBContext _dbContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, BookingV2DBContext dbContext)
        {
            this._logger = logger;
            this._dbContext = dbContext;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        [JwtBearerAuthorization]
        public IEnumerable<WeatherForecast> Get()
        {
            // var ty = this._dbContext.Users.ToList();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
            })
            .ToArray();
        }
    }
}
