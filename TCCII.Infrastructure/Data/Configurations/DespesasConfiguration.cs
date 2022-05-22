using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCCII.Deputados.Core.Entities;

namespace TCCII.Deputados.Infrastructure.Data.Configurations
{
    public class DespesasConfiguration : IEntityTypeConfiguration<Despesa>
    {
        public void Configure(EntityTypeBuilder<Despesa> builder)
        {
            builder
                .ToTable(nameof(Despesa));

            builder.HasKey(x => x.Id);            

            builder
                .Property(a => a.cnpjCpfFornecedor)                
                .HasColumnType("varchar(50)")
                .IsRequired(false);

            builder
               .Property(a => a.codDocumento)
               .HasColumnType("int");

            builder
               .Property(a => a.codLote)
               .HasColumnType("int");

            builder
               .Property(a => a.codTipoDocumento)
               .HasColumnType("int");

            builder
               .Property(a => a.dataDocumento)
               .HasColumnType("varchar(20)")
               .IsRequired(false);

            builder
               .Property(a => a.mes)
               .HasColumnType("int");

            builder
                .Property(a => a.ano)
                .HasColumnType("int");

            builder
               .Property(a => a.nomeFornecedor)
               .HasColumnType("varchar(200)")
               .IsRequired(false);
            
            builder
               .Property(a => a.numDocumento)
               .HasColumnType("varchar(50)")
               .IsRequired(false);
            
            builder
               .Property(a => a.numRessarcimento)
               .HasColumnType("varchar(50)")
               .IsRequired(false);
            
            builder
               .Property(a => a.parcela)
               .HasColumnType("int");
            
            builder
               .Property(a => a.tipoDespesa)
               .HasColumnType("varchar(200)")
               .IsRequired(false);
            
            builder
               .Property(a => a.tipoDocumento)
               .HasColumnType("varchar(200)")
               .IsRequired(false);
            
            builder
               .Property(a => a.urlDocumento)
               .HasColumnType("varchar(200)")
               .IsRequired(false);
            
            builder
               .Property(a => a.valorDocumento)
               .HasColumnType("decimal(18, 2)");
            
            builder
               .Property(a => a.valorGlosa)
               .HasColumnType("decimal(18, 2)");
            
            builder
               .Property(a => a.valorLiquido)
               .HasColumnType("decimal(18, 2)");

            builder
               .Property(a => a.notificada)
               .HasColumnType("int");
        }
    }
}
