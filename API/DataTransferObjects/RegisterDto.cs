using System.ComponentModel.DataAnnotations;

namespace API.DataTransferObjects
{
    public class RegisterDto
    {
       [Required]
       public string DisplayName {get; set;}
       [Required]
       public string Email {get; set;}
       [Required]
       // got the regex from https://regexlib.com/Search.aspx?k=password and searched for password
       // this gives suggested Regex's
       
       [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$")]
       public string Password {get; set;}
    }
}