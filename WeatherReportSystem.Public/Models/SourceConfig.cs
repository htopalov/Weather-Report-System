namespace WeatherReportSystem.Public.Models
{
    public class SourceConfig
    {
        public string BaseUrl { get; set; }

        public string SecurityKey { get; set; }

        public int RequestTimeout { get; set; }

        public string ContentTypeOfResponse { get; set; }

        public string DataEndpoint { get; set; }
    }
}
