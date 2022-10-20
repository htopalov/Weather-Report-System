using Microsoft.AspNetCore.Mvc;
using WeatherReportSystem.Source2.Exceptions;
using WeatherReportSystem.Source2.Services;
using static WeatherReportSystem.Source2.Common.UrlConstants;

namespace WeatherReportSystem.Source2.Controllers
{
    [Route(Source2ControllerPath)]
    [ApiController]
    public class WeatherDataController : ControllerBase
    {
        private readonly IWeatherDataService weatherService;

        public WeatherDataController(IWeatherDataService weatherService)
            => this.weatherService = weatherService;

        [HttpGet(GetTodayPath)]
        public IActionResult GetTodayData()
        {
            //throw new ServiceUnavailableException();
            return Ok(this.weatherService.GetData());
        }
    }
}
