using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Identity
{
    public class AppUser : IdentityUser
    // we can derirve from IdentityUser to get a class because <PackageReference Include="Microsoft.Extensions.Identity.Stores" Version="3.1.7"/>

    {
        public string DisplayName {get; set;}
        public Address Address {get; set;}
    }
}