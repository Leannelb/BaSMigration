namespace API.Errors
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public ApiValidationErrorResponse() : base(400)
        {

        }

        public string[] Errors { get; internal set; }

        // public IEnumerable<string> 
    }
}