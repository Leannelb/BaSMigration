using Core.Entities.Identity;

namespace Core.Entities
{
    public class Address
    {
        public int Id {get; set;}
   
        public string AppUserId {get; set;}
        public AppUser AppUser {get; set;}
    }
}