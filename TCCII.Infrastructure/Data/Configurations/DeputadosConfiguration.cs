using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCCII.Core.Entities;

namespace TCCII.Infrastructure.Data.Configurations
{
    public class DeputadosConfiguration : IEntityTypeConfiguration<Deputados>
    {
        public void Configure(EntityTypeBuilder<Deputados> builder)
        {
            builder
              .ToTable(nameof(Deputados));

            builder.HasKey(x => x.Id);

            builder
                .Property(a => a.IdDeputado)
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property(a => a.Email)
                .HasColumnType("varchar(200)");                

            builder
                .Property(a => a.IdLegislatura)
                .HasColumnType("int");

            builder
                .Property(a => a.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder
                .Property(a => a.SiglaPartido)
                .HasColumnType("varchar(25)");

            builder
                .Property(a => a.SiglaUf)
                .HasColumnType("varchar(25)");

            builder
                .Property(a => a.Uri)
                .HasColumnType("varchar(300)");
            
            builder
                .Property(a => a.UriPartido)
                .HasColumnType("varchar(300)");

            builder
                .Property(a => a.UrlFoto)
                .HasColumnType("varchar(300)");
        }
    }
}
