using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebfejlesztesAPI.Services;
using WebfejlesztesAPI.Services.Dto;
using WebfejlesztesAPI.Services.Impl;

namespace WebfejlesztesAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationService _authenticationService;
        public AuthenticationController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost("signin")]
        public async Task<ActionResult> SignIn([FromBody] SignInDto dto)
        {
            return await _authenticationService.SignIn(dto);
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<ActionResult> SignUp([FromBody] SignUpDto dto)
        {
            return await _authenticationService.SignUp(dto);
        }

        [AllowAnonymous]
        [HttpPost("init")]
        public async Task<ActionResult> InInitializationit(string initToken)
        {
            return await _authenticationService.Initialization(initToken);
        }
    }
}
