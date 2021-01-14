using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using API.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _env = env;
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = _env.IsDevelopment()
                    ? new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString())
                    : new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString());

                var options = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};

                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }
        }
    }
//     public class ExceptionMiddleware
//     {
//         private readonly RequestDelegate _next;
//         private readonly ILogger<ExceptionMiddleware> _logger;
//         private readonly IHostEnvironment _env;
//         public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
//         {
//             _env = env;
//             _logger = logger;
//             _next = next; 
//             //if there is no exception we want the middlewear to move  onto the next peice of middlewear *NOTE(1)

//         }

//         public async Task InvokeAsync(HttpContext context)
//         {
//             try 
//             {
//                 // *NOTE(1) use next for 
//                 await _next(context);

//             }
//             catch(Exception ex)
//            {
//                _logger.LogError(ex, ex.Message);
//                context.Response.ContentType = "application.json";
//                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
//                //were going to set the response to a 500 server error

// // if were in Dev or Prod, the response we send back is different - we send back a more detailed response in dev, with stack trace and message included.
// // in prod we just send back the code.
//                var response = _env.IsDevelopment()
//                 ? new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString()) //dev
//                 : new ApiException((int)HttpStatusCode.InternalServerError); //prod

//                 var options = new JsonSerializerOptions{PropertyNamingPolicy = 
//                 JsonNamingPolicy.CamelCase};

//                 var json = JsonSerializer.Serialize(response, options);

// // this gives the response back 
//            // var json = JsonSerializer.Serialize(response, options);

//                 await context.Response.WriteAsync(json);
//            }
//         }
 
//     }
}