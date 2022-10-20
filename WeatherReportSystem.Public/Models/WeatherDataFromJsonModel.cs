using System.Text.Json.Serialization;

namespace WeatherReportSystem.Public.Models
{
    public class WeatherDataFromJsonModel
    {
        [JsonPropertyName("temperature")]
        public string Temperature { get; set; }

        [JsonPropertyName("pressure")]
        public string Pressure { get; set; }
    }
}
