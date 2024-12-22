using Domain.Entities;

namespace WebfejlesztesAPI.Services
{
    public interface IJwtAuthService
    {
        Dictionary<string, string> ExtractToken(string token);
        string GenerateToken(UserEntity userEntity);
        bool IsTokenValid(string token);
    }
}
