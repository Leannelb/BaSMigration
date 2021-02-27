
using System.ComponentModel.DataAnnotations;

public class AddressDto
{
        [Required]
        public string FirstName {get; set;}

        [Required]
        public string LastName {get; set;}
        [Required]
        public string Street {get; set;}
        [Required]
        public string City {get; set;}
        [Required]
        public string State { get; set;}
        [Required]
        public string ZipCode {get; set;}

// vs code shortcut to add all of these in one line: Shift+Ctrl+Alt and Up or Down
}