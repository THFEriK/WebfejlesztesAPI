using Domain.Entities;
using EntityFramework;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebfejlesztesAPI.Services.Impl
{
    public class JwtAuthService : IJwtAuthService
    {
        private readonly IConfiguration _config;
        private readonly WebDbContext _dbContext;

        public JwtAuthService(IConfiguration configuration, WebDbContext dbContext)
        {
            _config = configuration;
            _dbContext = dbContext;
        }

        public Dictionary<string, string> ExtractToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            var claims = jwtToken.Claims.ToDictionary(claim => claim.Type, claim => claim.Value);
            return claims;
        }

        public string GenerateToken(UserEntity userEntity)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            string key = _config["Jwt:Key"];
            string issuer = _config["Jwt:Issuer"];
            string audience = _config["Jwt:Aduience"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var permClaims = new List<Claim>
            {
                new Claim("id", userEntity.Id.ToString()),
                new Claim("email", userEntity.Email),
                new Claim("name", userEntity.Name),
                new Claim("roleId", userEntity.RoleId.ToString()),
            };

            var token = new JwtSecurityToken(issuer, audience, permClaims, expires: DateTime.Now.AddDays(1), signingCredentials: credentials);
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;

        }

        public bool IsTokenValid(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = _config["Jwt:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = _config["Jwt:Aduience"],
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
