using AtendimentoConsultorio.Domain.Enums;

namespace AtendimentoConsultorio.Domain.Entities
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public SexoEnum Sexo { get; set; }
    }
}
