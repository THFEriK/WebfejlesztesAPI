using Domain.Entities;
using EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using WebfejlesztesAPI.Services.Dto;

namespace WebfejlesztesAPI.Services.Impl
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtAuthService _jwtAuthService;
        private readonly WebDbContext _dbContext;

        public AuthenticationService(IJwtAuthService jwtAuthService, WebDbContext dbContext)
        {
            _jwtAuthService = jwtAuthService;
            _dbContext = dbContext;
        }

        public async Task<ActionResult> SignIn(SignInDto dto)
        {
            var userEntity = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);

            if (userEntity == null)
            {
                return new NotFoundResult();
            }

            if (userEntity.Password != HashPassword(dto.Password))
            {
                return new UnauthorizedResult();
            }

            return new OkObjectResult(_jwtAuthService.GenerateToken(userEntity));
        }

        public async Task<ActionResult> SignUp(SignUpDto dto)
        {
            var role = _dbContext.Roles.FirstOrDefaultAsync(x => x.Name == dto.Role).Result.Id;

            if (role == null)
            {
                return new NotFoundResult();
            }

            var userEntity = new UserEntity
            {
                Email = dto.Email,
                Password = HashPassword(dto.Password),
                Name = dto.Name,
                PhoneNumber = dto.PhoneNumber,
                Gender = dto.Gender,
                Address = dto.Address,
                RoleId = role
            };

            _dbContext.Users.Add(userEntity);

            await _dbContext.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<ActionResult> Initialization(string InitToken)
        {
            if (InitToken != "InitToken")
            {
                return new UnauthorizedResult();
            }

            _dbContext.Roles.Add(new RoleEntity { Id = 1, Name = "USER" });
            _dbContext.Roles.Add(new RoleEntity { Id = 2, Name = "ADMIN" });

            await _dbContext.SaveChangesAsync();

            return new OkResult();
        }

        private string HashPassword(string password)
        {
            int iterations = 500000;
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                for (int i = 0; i < iterations; i++)
                {
                    bytes = sha256.ComputeHash(bytes);
                }
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
