using System.Xml.Serialization;

namespace WeatherReportSystem.Source2.Models
{
    [XmlType("data")]
    public class WeatherDataElementExportModel
    {
        [XmlElement("temperature")]
        public string Temperature { get; set; }

        [XmlElement("pressure")]
        public string Pressure { get; set; }
    }
}
