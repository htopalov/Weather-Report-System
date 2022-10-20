using System.Text;

namespace WeatherReportSystem.Source2.Utils
{
    public class Utf8Writer : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
}
