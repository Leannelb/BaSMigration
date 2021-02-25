using System.Security.Claims;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace API.Extension
{
    public static class UserManagerExtentions
    {   
        public static async Task<AppUser> FindByEmailWithAddressAsync(this UserManager<AppUser> input, ClaimsPrincipal)
        {
            var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            return await input.Users.Include( x => x.Address ).SingleOrDefaultAsync(x => x.Email == email);
        }
        // , ClaimsPrincipal user)
        // {
        //     var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

        //     return await input.Users.Include(x => x.Address).SingleOrDefaultAsync
        // }
        
    }
}