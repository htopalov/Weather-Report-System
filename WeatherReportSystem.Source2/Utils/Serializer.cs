using System.Xml;
using System.Xml.Serialization;
using WeatherReportSystem.Source2.Models;

namespace WeatherReportSystem.Source2.Utils
{
    public static class Serializer
    {
        public static string SerializeResponseBody(WeatherDataXmlExportModel body)
        {
            var serializer = new XmlSerializer(typeof(WeatherDataXmlExportModel));
            var serializerNamespaces = new XmlSerializerNamespaces();
            serializerNamespaces.Add("", "");
            using var strWriter = new Utf8Writer();
            using var xmlWriter = XmlWriter.Create(strWriter, new XmlWriterSettings { Indent = true });
            serializer.Serialize(xmlWriter, body, serializerNamespaces);
            var xmlResult = strWriter.ToString();

            return xmlResult;
        }
    }
}
