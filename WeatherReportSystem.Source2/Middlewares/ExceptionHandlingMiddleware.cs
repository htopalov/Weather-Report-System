using WeatherReportSystem.Source2.Exceptions;
using WeatherReportSystem.Source2.Models;
using WeatherReportSystem.Source2.Utils;

namespace WeatherReportSystem.Source2.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
            => this.next = next;

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/xml";
            var response = context.Response;

            var errorResponse = new WeatherDataXmlExportModel();

            switch (exception)
            {
                case UnauthorizedException:
                    errorResponse.Error = 1;
                    break;

                case ServiceUnavailableException:
                    errorResponse.Error = 3;
                    break;

                default:
                    errorResponse.Error = 2;
                    break;
            }

            var result = Serializer.SerializeResponseBody(errorResponse);

            await context.Response.WriteAsync(result);
        }
    }
}
