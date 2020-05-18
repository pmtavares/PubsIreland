using System;
using System.Net;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Infrastructured.Errors
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate Next;
        private readonly ILogger<ErrorHandlerMiddleware> Logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger )
        {
            Next = next;
            Logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await Next(context);
            }
            catch(Exception ex)
            {
                await HandleExceptionAsync(context, ex, Logger);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex, ILogger<ErrorHandlerMiddleware> logger)
        {
            object errors = null;

            switch (ex)
            {
                case RestExceptions re:
                    logger.LogError(ex, "REST ERROR");
                    errors = re.Erros;
                    context.Response.StatusCode = (int) re.Code;
                    break;
                case Exception e:
                    logger.LogError(ex, "SERVER ERROR");
                    errors = string.IsNullOrWhiteSpace(e.Message) ? "ERROR" : e.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            context.Response.ContentType = "application/json";

            if(errors != null)
            {
                var result = JsonConvert.SerializeObject(new { errors });

                await context.Response.WriteAsync(result);
            }

        }
    }
}
