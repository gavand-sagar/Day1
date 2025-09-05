using Microsoft.AspNetCore.Mvc;

namespace Day1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        // api/WeatherForecast
        [HttpGet()]
        public string GetMyName()
        {
            return "Sagar Gavand";
        }


        // api/WeatherForecast/MyFriendsName
        [HttpGet("MyFriendsName")]
        public string GetMyFriends()
        {
            return "Sagar Gavand";
        }
    }
}
