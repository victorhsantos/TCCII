using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCCII.Deputados.Core.Entities.Identity;

namespace TCCII.Deputados.Infrastructure.Data.Configurations.Identity
{
    public class RolesConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder
                .ToTable("Role");           
        }
    }
}
