// using System.Threading.Tasks;
// using API.Dtos;
// using API.Errors;
// using Core.Entities.Identity;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;
using API.DataTransferObjects;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            // to login we need a combo of the user manager to get the user

            var user = await _userManager.FindByIdAsync(loginDto.Email);

            if (user == null ) return Unauthorized(new ApiResponse(401));

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized(new ApiResponse(401));

            return new UserDto
            {
                Email = user.Email,
                Token = "this will be a token",
                DisplayName = user.DisplayName
            };
        }
    }
}