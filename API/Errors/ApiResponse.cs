using System;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null )
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
            
            // null coalesing - says if thing on left is null, execute whats on the right
            // comes up in interviews 
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        
        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            // switch statements are new to C# version 8
            // rather than the 'case/break' cases.. we can do it like this just the case with an =>
            // for shorthand - see if this is the case with JS too ?Think it is - write an Article Medium

           return statusCode switch
           {
               400 => "A bad request you have made",
               401 => "Authorized, you are not",
               404 => "Resource not found, it was not",
               500 => "Errors are the path to the dark side",
                _ => null
            };
        }
    }
}