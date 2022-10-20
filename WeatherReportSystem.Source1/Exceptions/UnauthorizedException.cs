using System.Net;
using System.Runtime.Serialization;

namespace WeatherReportSystem.Source1.Exceptions
{
    [Serializable]
    public class UnauthorizedException : HttpExceptionBase
    {
        public UnauthorizedException() : base() { }

        public UnauthorizedException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public override HttpStatusCode StatusCode { get; protected set; } = HttpStatusCode.Unauthorized;

        public override string Message { get; } = "Unauthorized";
    }
}
