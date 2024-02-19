using AtendimentoConsultorio.Domain.Entities;

namespace AtendimentoConsultorio.Domain.Interfaces
{
    public interface IAtendimentoRepository
    {
        Task<IEnumerable<Atendimento>> GetListAsync();
        Task<IEnumerable<Atendimento>> GetFinishedList(short take);
        Task<IEnumerable<Atendimento>> GetInProcessList();
        Task<Atendimento> CreateAsync(Atendimento atendimento);
        Task<Atendimento> UpdateAsync(int id, Atendimento atendimento);
        bool Delete(int id);
    }
}
