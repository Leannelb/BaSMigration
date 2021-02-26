using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.DataTransferObjects;
using API.Errors;
using API.Extension;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
       
        ITokenService tokenService, IMapper mapper)
        {
            _mapper = mapper;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

    [Authorize]
    [HttpGet]
    //client gives me a token from customers last login
    public async Task<ActionResult<UserDto>> GetCurrentUser()
    {
        var user = await _userManager.FindByEmailFromClaimsPrinciple(HttpContext.User);

        return new UserDto
        {
            Email = user.Email,
            Token = _tokenService.CreateToken(user),
            DisplayName = user.DisplayName
        };
    }

    //client can check if an email already exists for async validaion on client side.
    // server side will not accept dupes already
    [HttpGet("emailexists")]
    public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
    {
        return await _userManager.FindByEmailAsync(email) != null;
    }

    // have an error working through it 
    // cannot find claim type investigate
    [Authorize]
    [HttpGet("address")]
    public async Task<ActionResult<AddressDto>> GetUserAddress()
    {
        var user = await _userManager.FindUserByClaimsPrincipleWithAddressAsync(HttpContext.User);

        return _mapper.Map<Address, AddressDto>(user.Address);

    }

    [Authorize]
    [HttpPut("address")]
    public async Task<ActionResult<AddressDto>> UpdateUserAddress(AddressDto address)
    {
        var user = await _userManager.FindUserByClaimsPrincipleWithAddressAsync(HttpContext.User);

        user.address = _mapper.Map<AddressDto, Address>(address);

        return null;
    }

    // method to log a user in !
    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        // to login we need a combo of the user manager to get the user

        var user = await _userManager.FindByEmailAsync(loginDto.Email);

        if (user == null) return Unauthorized(new ApiResponse(401));

        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

        if (!result.Succeeded) return Unauthorized(new ApiResponse(401));

        return new UserDto
        {
            Email = user.Email,
            Token = _tokenService.CreateToken(user),
            DisplayName = user.DisplayName
        };
    }
    // method to register a new user  !
    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        var user = new AppUser
        {
            DisplayName = registerDto.DisplayName,
            Email = registerDto.Email,
            UserName = registerDto.Email
        };

        var result = await _userManager.CreateAsync(user, registerDto.Password);

        if (!result.Succeeded) return BadRequest(new ApiResponse(400));

        return new UserDto
        {
            Email = user.Email,
            Token = _tokenService.CreateToken(user),
            DisplayName = user.DisplayName
        };
    }
}
}