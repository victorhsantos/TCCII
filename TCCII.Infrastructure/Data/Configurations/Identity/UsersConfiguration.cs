using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCCII.Core.Entities.Identity;

namespace TCCII.Infrastructure.Data.Configurations.Identity
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("User");

            builder
                .Property(user => user.FullName)
                .HasColumnType("varchar(90)");
                
        }
    }
}
