namespace API.DataTransferObjects
{
    public class UserDto
    {
        public string Email { get; set; }
       // public string Username {get; set;}
        public string Token {get; set;}
        public string DisplayName { get; internal set; }
    }
}