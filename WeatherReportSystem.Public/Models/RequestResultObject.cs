namespace WeatherReportSystem.Public.Models
{
    public class RequestResultObject
    {
        public int StatusCode { get; set; }

        public WeatherDataExport WeatherData { get; set; }
    }
}
