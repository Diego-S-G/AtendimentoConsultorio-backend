using AtendimentoConsultorio.Domain.Entities;

namespace AtendimentoConsultorio.Domain.Interfaces
{
    public interface IAtendimentoRepository
    {
        Task<IEnumerable<Atendimento>> GetListAsync();
        Task<IEnumerable<Atendimento>> GetFinishedList(short take);
        Task<Atendimento> GetFirstInProcess();
        Task<IEnumerable<Atendimento>> GetRestInProcessList();
        Task<Atendimento> CreateAsync(Atendimento atendimento);
        Task<Atendimento> UpdateAsync(int id, Atendimento atendimento);
        bool Delete(int id);
        bool DeleteAll();
    }
}
