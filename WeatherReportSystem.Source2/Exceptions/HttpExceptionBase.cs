using System.Net;
using System.Runtime.Serialization;

namespace WeatherReportSystem.Source2.Exceptions
{
    [Serializable]
    public abstract class HttpExceptionBase : Exception
    {
        public abstract HttpStatusCode StatusCode { get; protected set; }

        protected HttpExceptionBase() : base() { }

        public HttpExceptionBase(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            var statusCode = info.GetValue(nameof(StatusCode), typeof(HttpStatusCode));
            if (statusCode != null)
                StatusCode = (HttpStatusCode)statusCode;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info));

            info.AddValue(nameof(StatusCode), StatusCode);
            base.GetObjectData(info, context);
        }
    }
}
