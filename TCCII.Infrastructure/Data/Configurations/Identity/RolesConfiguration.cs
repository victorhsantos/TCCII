using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCCII.Core.Entities.Identity;

namespace TCCII.Infrastructure.Data.Configurations.Identity
{
    public class RolesConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder
                .ToTable("Role");



            //TODO: Codigo apenas para desenvolvimento LOCAL, será removido!!!
            builder.HasData(
                new Role
                {
                    Id = 99999,
                    Name = "AceleroID Administrator",
                    NormalizedName = "ACELEROID ADMINISTRATOR"
                });

            builder.HasData(
                new Role
                {
                    Id = 99998,
                    Name = "AceleroID User",
                    NormalizedName = "ACELEROID USER"
                });            
        }
    }
}
