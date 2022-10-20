using Microsoft.AspNetCore.Mvc;
using WeatherReportSystem.Source1.Exceptions;
using WeatherReportSystem.Source1.Services;

using static WeatherReportSystem.Source1.Common.UrlConstants;

namespace WeatherReportSystem.Source1.Controllers
{
    [Route(Source1ControllerPath)]
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
            var data = this.weatherService.GetData();
            return Ok(data);
        }
    }
}
