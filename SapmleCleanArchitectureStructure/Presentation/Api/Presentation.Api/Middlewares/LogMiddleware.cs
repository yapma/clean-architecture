using Core.Domain.Contracts.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presentation.Api.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly ILogsService _logService;

        public LogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var stopWatch = Stopwatch.StartNew();
            var requestHeader = GetRequestHeadersAsJson(httpContext);
            var requestBody = await GetRequestBodyAsJson(httpContext);
            var requestQuery = GetQueryStrings(httpContext);
            var logService = httpContext.RequestServices.GetService<ILogsService>();
            var originalBodyStream = httpContext.Response.Body;
            using var responseBody = new MemoryStream();
            var response = httpContext.Response;
            response.Body = responseBody;
            
            await _next(httpContext);
            stopWatch.Stop();

            var responseHeader = GetRequestHeadersAsJson(httpContext);
            var responseBodyContent = await ReadResponseBody(response);
            await responseBody.CopyToAsync(originalBodyStream);

            await logService.AddRestApiRequestResponseLog(new Core.Domain.Entities.RestApiRequestResponse()
            {
                RequestHeader = requestHeader,
                RequestBody = requestBody,
                RequestQueryStrings = requestQuery,
                UrlPath = httpContext.Request.Path,
                DurationInMiliSecond = stopWatch.ElapsedMilliseconds,
                ResponseBody = responseBodyContent,
                ResponseHeader = responseHeader,
                DateTime = DateTime.Now,
                HttpStatusCode = httpContext.Response.StatusCode
            });
            ;
        }

        public string GetRequestHeadersAsJson(HttpContext context)
        {
            var headers = context.Request.Headers;
            var json = JsonSerializer.Serialize(headers);
            return json;
        }

        public async Task<string> GetRequestBodyAsJson(HttpContext context)
        {
            string requestBody = "";
            using (StreamReader reader = new StreamReader(context.Request.Body, Encoding.UTF8))
            {
                requestBody = await reader.ReadToEndAsync();
            }
            return requestBody;
        }

        public string GetQueryStrings(HttpContext context)
        {
            var queryStrings = context.Request.Query;

            string queryString = "";

            foreach (var query in queryStrings)
            {
                queryString += $"{query.Key}={query.Value}&";
            }

            queryString = queryString.TrimEnd('&');

            return queryString;
        }

        public string GetResponseHeadersAsJson(HttpContext context)
        {
            var headers = context.Response.Headers;
            var json = JsonSerializer.Serialize(headers);
            return json;
        }

        public async Task<string> GetResponseBodyAsJson(HttpContext context)
        {
            string responseBody = "";
            using (StreamReader reader = new StreamReader(context.Response.Body, Encoding.UTF8))
            {
                responseBody = await reader.ReadToEndAsync();
            }
            return responseBody;
        }

        private static async Task<string> ReadResponseBody(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var bodyAsText = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return bodyAsText;
        }
    }
}
