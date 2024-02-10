using AtendimentoConsultorio.Domain.Enums;

namespace AtendimentoConsultorio.Domain.Entities
{
    public class Atendimento
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public StatusEnum Status { get; set; }
    }
}
