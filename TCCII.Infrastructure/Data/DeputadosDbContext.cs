using TCCII.Infrastructure.Data.Configurations.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TCCII.Core.Entities.Identity;
using TCCII.Infrastructure.Data.Configurations;

namespace TCCII.Infrastructure.Data
{
    public class DeputadosDbContext :
        IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public DeputadosDbContext(DbContextOptions<DeputadosDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleClaimsConfiguration());
            modelBuilder.ApplyConfiguration(new RolesConfiguration());
            modelBuilder.ApplyConfiguration(new UserClaimsConfiguration());
            modelBuilder.ApplyConfiguration(new UserLoginsConfiguration());
            modelBuilder.ApplyConfiguration(new UsersConfiguration());
            modelBuilder.ApplyConfiguration(new UserRolesConfiguration());
            modelBuilder.ApplyConfiguration(new UserTokensConfiguration());            
            modelBuilder.ApplyConfiguration(new DeputadosConfiguration());
            modelBuilder.ApplyConfiguration(new UserDeputadosConfiguration());                        

        }
    }
}
