using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCCII.Deputados.Core.Entities;

namespace TCCII.Deputados.Infrastructure.Data.Configurations
{
    public class DeputadosConfiguration : IEntityTypeConfiguration<Deputado>
    {
        public void Configure(EntityTypeBuilder<Deputado> builder)
        {
            builder
              .ToTable(nameof(Deputado));

            builder.HasKey(x => x.Id);

            builder
                .Property(a => a.IdDeputado)
                .HasColumnType("int");

            builder
                .Property(a => a.Email)
                .HasColumnType("varchar(200)")
                .IsRequired(false);

            builder
                .Property(a => a.IdLegislatura)
                .HasColumnType("int");

            builder
                .Property(a => a.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired(false);

            builder
                .Property(a => a.SiglaPartido)
                .HasColumnType("varchar(25)")
                .IsRequired(false);

            builder
                .Property(a => a.SiglaUf)
                .HasColumnType("varchar(25)");

            builder
                .Property(a => a.Uri)
                .HasColumnType("varchar(300)")
                .IsRequired(false);

            builder
                .Property(a => a.UriPartido)
                .HasColumnType("varchar(300)")
                .IsRequired(false);

            builder
                .Property(a => a.UrlFoto)
                .HasColumnType("varchar(300)")
                .IsRequired(false);
        }
    }
}
