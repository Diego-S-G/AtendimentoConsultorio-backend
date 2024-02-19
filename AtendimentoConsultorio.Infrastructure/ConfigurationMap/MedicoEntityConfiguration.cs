using AtendimentoConsultorio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtendimentoConsultorio.Infrastructure.ConfigurationMap
{
    public class MedicoEntityConfiguration : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable(nameof(Medico));

            builder.HasKey(x => x.Id);

            builder.Property((x) => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property((x) => x.Especialidade)
                .HasColumnName("Especialidade")
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .IsRequired();
        }
    }
}
