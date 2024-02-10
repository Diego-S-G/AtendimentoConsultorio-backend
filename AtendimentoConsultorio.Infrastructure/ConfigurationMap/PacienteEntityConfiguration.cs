using AtendimentoConsultorio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtendimentoConsultorio.Infrastructure.ConfigurationMap
{
    public class PacienteEntityConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable(nameof(Paciente));

            builder.HasKey(x => x.Id);

            builder.Property((x) => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Sexo)
                .HasColumnName("Sexo")
                .HasColumnType("number")
                .HasMaxLength(1)
                .IsRequired();
        }
    }
}
