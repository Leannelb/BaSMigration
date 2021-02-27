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
        // TODO LLB  Regex needs to be updated to a more complex one 181

       [RegularExpression("^\\S{1}(?:.){4,}\\S$", 
       ErrorMessage = "Password must have 1 uppercase, 1 lowecase, 1 number, 1 alphanumeric character and be at least 6 characters in length")]
       public string Password {get; set;}
    }
}