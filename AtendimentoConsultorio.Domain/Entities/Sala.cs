namespace AtendimentoConsultorio.Domain.Entities
{
    public class Sala
    {
        public int Id { get; set; }
        public string Sigla { get; set; }
        public string Descricao { get; set; }

        public override string ToString()
        {
            return $"{Sigla} - {Descricao}";
        }

    }
}
