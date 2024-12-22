using Microsoft.AspNetCore.Mvc;
using WebfejlesztesAPI.Services.Dto;

namespace WebfejlesztesAPI.Services
{
    public interface IAuthenticationService
    {
        Task<ActionResult> SignUp(SignUpDto dto);
        Task<ActionResult> SignIn(SignInDto dto);
    }
}
