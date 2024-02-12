using AtendimentoConsultorio.Application.Interfaces;
using AtendimentoConsultorio.Domain.Entities;
using AtendimentoConsultorio.Domain.Interfaces;

namespace AtendimentoConsultorio.Application.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;
        public PacienteService(IPacienteRepository repository)
        {
            _pacienteRepository = repository;
        }
        public Task<Paciente> CreateAsync(Paciente paciente)
        {
            return _pacienteRepository.CreateAsync(paciente);
        }

        public bool Delete(int id)
        {
            return _pacienteRepository.Delete(id);
        }

        public Task<Paciente> GetCompleteAsync(int id)
        {
            return _pacienteRepository.GetCompleteAsync(id);
        }

        public Task<IEnumerable<Paciente>> GetListAsync()
        {
            return _pacienteRepository.GetListAsync();
        }

        public Task<Paciente> UpdateAsync(int id, Paciente paciente)
        {
            return _pacienteRepository.UpdateAsync(id, paciente);
        }
    }
}
