using AtendimentoConsultorio.Domain.Enums;

namespace AtendimentoConsultorio.Domain.Entities
{
    public class Atendimento
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public StatusEnum Status { get; set; }
        public Medico Medico { get; set; }
        public int MedicoId { get; set; }
        public Paciente Paciente { get; set; }
        public int PacienteId { get; set; }
        public Sala Sala { get; set; }
        public int SalaId { get; set;}
    }
}
