using AtendimentoConsultorio.Domain.Entities;

namespace AtendimentoConsultorio.Application.Interfaces
{
    public interface IPacienteService
    {
        Task<IEnumerable<Paciente>> GetListAsync();
        Task<Paciente> GetCompleteAsync(int id);
        Task<Paciente> CreateAsync(Paciente paciente);
        Task<Paciente> UpdateAsync(int id,Paciente paciente);
        bool Delete(int id);
    }
}
