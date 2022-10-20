namespace WeatherReportSystem.Public.Models
{
    public class ClientDataExport
    {
        public bool Success { get; set; }

        public WeatherDataExport WeatherData { get; set; }
    }
}
