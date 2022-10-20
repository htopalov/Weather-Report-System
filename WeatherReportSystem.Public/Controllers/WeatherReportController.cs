using Microsoft.AspNetCore.Mvc;
using WeatherReportSystem.Public.Services;
using static WeatherReportSystem.Public.Common.UrlConstants;

namespace WeatherReportSystem.Public.Controllers
{
    [Route(ReportControllerPath)]
    [ApiController]
    public class WeatherReportController : ControllerBase
    {
        private readonly IDataService dataService;

        public WeatherReportController(IDataService dataService) 
            => this.dataService = dataService;

        [HttpGet(GetReportPath)]
        public async Task<IActionResult> GetWeatherReport()
        {
            var result = await this.dataService.GetData();

            if (!result.Success)
            {
                return BadRequest("There was an error while handling your request.");
            }

            return Ok(result.WeatherData);

        }
    }
}
