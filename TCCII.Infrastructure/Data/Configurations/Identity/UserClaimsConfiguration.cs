using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCCII.Core.Entities.Identity;

namespace TCCII.Infrastructure.Data.Configurations.Identity
{
    public class UserClaimsConfiguration : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {

            builder
                .ToTable("UserClaim");

            builder
                .HasOne(userClaim => userClaim.User)
                .WithMany(user => user.Claims)
                .HasForeignKey(userClaim => userClaim.UserId);

        }
    }
}
