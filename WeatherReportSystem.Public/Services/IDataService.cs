using WeatherReportSystem.Public.Models;

namespace WeatherReportSystem.Public.Services
{
    public interface IDataService
    {
       Task<ClientDataExport> GetData();
    }
}
