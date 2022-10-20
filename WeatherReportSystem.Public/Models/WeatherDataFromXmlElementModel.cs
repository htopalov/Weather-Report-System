using System.Xml.Serialization;

namespace WeatherReportSystem.Public.Models
{
    [XmlType("data")]
    public class WeatherDataFromXmlElementModel
    {
        [XmlElement("temperature")]
        public string Temperature { get; set; }

        [XmlElement("pressure")]
        public string Pressure { get; set; }
    }
}
