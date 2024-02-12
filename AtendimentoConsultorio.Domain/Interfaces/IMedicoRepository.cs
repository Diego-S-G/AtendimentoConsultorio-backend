using AtendimentoConsultorio.Domain.Entities;

namespace AtendimentoConsultorio.Domain.Interfaces
{
    public interface IMedicoRepository
    {
        Task<IEnumerable<Medico>> GetListAsync();
        Task<Medico> GetCompleteAsync(int id);
        Task<Medico> CreateAsync(Medico medico);
        Task<Medico> UpdateAsync(int id, Medico medico);
        bool Delete(int id);
    }
}
