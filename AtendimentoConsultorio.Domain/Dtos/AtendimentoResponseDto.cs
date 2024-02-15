using AtendimentoConsultorio.Domain.Entities;

namespace AtendimentoConsultorio.Domain.Dtos
{
    public class AtendimentoResponseDto
    {
        public int Id { get; set; }
        public int MedicoId { get; set; }
        public string NomeMedico { get; set; }
        public int PacienteId { get; set; }
        public string NomePaciente { get; set; }
        public int SalaId { get; set; }
        public string NomeSala { get; set; }
        public DateTime DataHora { get; set; }
        public short Status { get; set; }
    }
}
