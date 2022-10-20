using System.Xml.Serialization;

namespace WeatherReportSystem.Source2.Models
{
    [XmlType("response")]
    public class WeatherDataXmlExportModel
    {
        [XmlElement("success")]
        public bool Success { get; set; }

        [XmlElement("error")]
        public int Error { get; set; }

        [XmlElement("data")]
        public WeatherDataElementExportModel? Data { get; set; }
    }
}
