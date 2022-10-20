using System.Net;
using System.Runtime.Serialization;

namespace WeatherReportSystem.Source2.Exceptions
{
    [Serializable]
    public class ServiceUnavailableException : HttpExceptionBase
    {
        public ServiceUnavailableException() : base() { }

        public ServiceUnavailableException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public override HttpStatusCode StatusCode { get; protected set; } = HttpStatusCode.ServiceUnavailable;

        public override string Message { get; } = "Offline";
    }
}
