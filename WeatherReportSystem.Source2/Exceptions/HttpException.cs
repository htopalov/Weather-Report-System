using System.Net;
using System.Runtime.Serialization;

namespace WeatherReportSystem.Source2.Exceptions
{
    [Serializable]
    public class HttpException : HttpExceptionBase
    {
        public override HttpStatusCode StatusCode { get; protected set; } = HttpStatusCode.InternalServerError;

        public HttpException() : base() { }

        public HttpException(HttpStatusCode statusCode) : base() => StatusCode = statusCode;

        public HttpException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
