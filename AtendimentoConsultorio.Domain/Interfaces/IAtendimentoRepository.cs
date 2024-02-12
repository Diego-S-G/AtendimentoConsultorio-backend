using AtendimentoConsultorio.Domain.Entities;

namespace AtendimentoConsultorio.Domain.Interfaces
{
    public interface IAtendimentoRepository
    {
        Task<IEnumerable<Atendimento>> GetListAsync();
        Task<Atendimento> GetCompleteAsync(int id);
        Task<Atendimento> CreateAsync(Atendimento atendimento);
        Task<Atendimento> UpdateAsync(int id, Atendimento atendimento);
        bool Delete(int id);
    }
}
