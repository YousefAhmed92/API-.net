using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Data.Entities.IdentityEntities;
using Store.Services.HandleResponses;
using Store.Services.UserService;
using Store.Services.UserService.Dtos;

namespace Store.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(IUserService userService , UserManager<AppUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto input)
        {
            var user = await _userService.Login(input);
            if (user is null)
                return BadRequest(new CustomException(400, "email does not exist"));

            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto input)
        {
            var user = await _userService.Register(input);

            if (user is null)
                return BadRequest(new CustomException(400, "email already exist"));

            return Ok(user);
        }

        [HttpGet("llllllll")]
        public async Task<UserDto> GetCurrentUserDetails()
        {
            var UserId = User?.FindFirst("UserId");

            var user = await _userManager.FindByIdAsync(UserId.Value);

            return new UserDto
            {
                Id = Guid.Parse(user.Id),
                DisplayName = user.DisplayName,
                Email = user.Email,
            };
        }




    }
}
