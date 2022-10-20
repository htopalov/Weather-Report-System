using WeatherReportSystem.Source1.Models;

namespace WeatherReportSystem.Source1.Services
{
    public interface IWeatherDataService
    {
        WeatherDataExportModel GetData();
    }
}
