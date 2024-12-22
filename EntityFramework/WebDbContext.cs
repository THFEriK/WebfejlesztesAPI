using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework
{
    //dotnet ef database update --verbose --project .\EntityFramework\EntityFramework.csproj --startup-project .\WebfejlesztesAPI\WebfejlesztesAPI.csproj
    public class WebDbContext : DbContext
    {
        public virtual DbSet<UserEntity> Users { get; set; } = null!;
        public virtual DbSet<CharterEntity> Charters { get; set; } = null!;
        public virtual DbSet<RoleEntity> Roles { get; set; } = null!;

        public WebDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
