using System.Xml.Serialization;

namespace WeatherReportSystem.Public.Models
{
    [XmlType("response")]
    public class WeatherDataFromXmlModel
    {
        [XmlElement("data")]
        public WeatherDataFromXmlElementModel? Data { get; set; }

        [XmlElement("error")]
        public string Error { get; set; }

        [XmlElement("success")]
        public string Success { get; set; }
    }
}
