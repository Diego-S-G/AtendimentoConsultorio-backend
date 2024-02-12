using AtendimentoConsultorio.Domain.Enums;

namespace AtendimentoConsultorio.Domain.Dtos
{
    public class PacienteInsertDto
    {
        public string Nome { get; set; }
        public SexoEnum Sexo { get; set; }
    }
}
