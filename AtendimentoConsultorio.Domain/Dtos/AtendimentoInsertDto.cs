using AtendimentoConsultorio.Domain.Enums;

namespace AtendimentoConsultorio.Domain.Dtos
{
    public class AtendimentoInsertDto
    {
        public StatusEnum Status { get; set; }
        public int MedicoId { get; set; }
        public int PacienteId { get; set; }
        public int SalaId { get; set; }
    }
}
