using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCCII.Deputados.Core.Entities.Identity;

namespace TCCII.Deputados.Infrastructure.Data.Configurations.Identity
{
    public class UserRolesConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {

            builder
                .ToTable("UserRole");

            builder.HasKey(ur => new { ur.UserId, ur.RoleId });

            builder
                .HasOne(userRole => userRole.Role)
                .WithMany(role => role.Users)
                .HasForeignKey(userRole => userRole.RoleId)
                .IsRequired();

            builder
                .HasOne(userRole => userRole.User)
                .WithMany(user => user.Roles)
                .HasForeignKey(userRole => userRole.UserId)
                .IsRequired();

        }
    }
}
