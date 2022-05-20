using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCCII.Deputados.Core.Entities;

namespace TCCII.Deputados.Infrastructure.Data.Configurations
{
    public class UserDeputadosConfiguration : IEntityTypeConfiguration<UserDeputados>
    {
        public void Configure(EntityTypeBuilder<UserDeputados> builder)
        {
            builder
               .ToTable(nameof(UserDeputados));

            builder.HasKey(us => new { us.UserId, us.DeputadosId });

            builder
                .HasOne(userDeputados => userDeputados.Deputado)
                .WithMany(deputado => deputado.Users)
                .HasForeignKey(userDeputados => userDeputados.DeputadosId)
                .IsRequired();

            builder
                .HasOne(userDeputados => userDeputados.User)
                .WithMany(user => user.Deputados)
                .HasForeignKey(userDeputados => userDeputados.UserId)
                .IsRequired();
        }
    }
}
