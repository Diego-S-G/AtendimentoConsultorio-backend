using AtendimentoConsultorio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtendimentoConsultorio.Infrastructure.ConfigurationMap
{
    public class SalaEntityConfiguration : IEntityTypeConfiguration<Sala>
    {
        public void Configure(EntityTypeBuilder<Sala> builder)
        {
            builder.ToTable(nameof(Sala));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Sigla)
                .HasColumnName("Sigla")
                .HasColumnType("varchar")
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
