using Application.Authentication;
using AutoMapper;
using Domain.Dtos.Authentication;
using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authService;
        public AuthenticationController(IMapper mapper, UserManager<User> userManager, IAuthenticationService authService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUserAsync([FromBody] UserRegistrationDto userForRegistration)
        {
            var user = _mapper.Map<User>(userForRegistration);
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            await _userManager.AddToRolesAsync(user, userForRegistration.Roles);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> AuthenticateAsync([FromBody] UserAuthenticationDto user)
        {
            if (!await _authService.ValidateUserAsync(user))
            {               
                return Unauthorized();
            }

            return Ok(new { Token = await _authService.CreateTokenAsync() });
        }
    }
}
