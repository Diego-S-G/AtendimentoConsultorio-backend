using AtendimentoConsultorio.Domain.Entities;

namespace AtendimentoConsultorio.Domain.Interfaces
{
    public interface ISalaRepository
    {
        Task<IEnumerable<Sala>> GetListAsync();
        Task<Sala> GetCompleteAsync(int id);
        Task<Sala> CreateAsync(Sala sala);
        Task<Sala> UpdateAsync(int id, Sala sala);
        bool Delete(int id);
    }
}
