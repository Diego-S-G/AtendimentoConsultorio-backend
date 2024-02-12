using AtendimentoConsultorio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtendimentoConsultorio.Infrastructure.ConfigurationMap
{
    public class AtendimentoEntityConfiguration : IEntityTypeConfiguration<Atendimento>
    {
        public void Configure(EntityTypeBuilder<Atendimento> builder)
        {
            builder.ToTable(nameof(Atendimento));

            builder.HasKey(x => x.Id);

            builder.Property((x) => x.DataHora)
                .HasColumnName("DataAtendimento")
                .HasColumnType("datetime")
                .HasMaxLength(23)
                .IsRequired();

            builder.Property((x) => x.Status)
                .HasColumnName("Status")
                .HasColumnType("number")
                .HasMaxLength(1)
                .IsRequired();

            builder.Property((x) => x.MedicoId)
                .HasColumnName("MedicoId")
                .HasColumnType("number")
                .IsRequired();

            builder.Property((x) => x.PacienteId)
                .HasColumnName("PacienteId")
                .HasColumnType("number")
                .IsRequired();

            builder.Property((x) => x.SalaId)
                .HasColumnName("SalaId")
                .HasColumnType("number")
                .IsRequired();

            builder.HasOne(x => x.Medico)
                .WithMany()
                .HasForeignKey(x => x.MedicoId);

            builder.HasOne(x => x.Paciente)
                .WithMany()
                .HasForeignKey(x => x.PacienteId);

            builder.HasOne(x => x.Sala)
                .WithMany()
                .HasForeignKey(x => x.SalaId);
        }
    }
}
