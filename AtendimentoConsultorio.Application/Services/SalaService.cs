using AtendimentoConsultorio.Application.Interfaces;
using AtendimentoConsultorio.Domain.Entities;
using AtendimentoConsultorio.Domain.Interfaces;

namespace AtendimentoConsultorio.Application.Services
{
    public class SalaService :ISalaService
    {
        private readonly ISalaRepository _salaRepository;
        public SalaService(ISalaRepository repository)
        {
            _salaRepository = repository;
        }
        public Task<Sala> CreateAsync(Sala sala)
        {
            return _salaRepository.CreateAsync(sala);
        }

        public bool Delete(int id)
        {
            return _salaRepository.Delete(id);
        }

        public Task<Sala> GetCompleteAsync(int id)
        {
            return _salaRepository.GetCompleteAsync(id);
        }

        public Task<IEnumerable<Sala>> GetListAsync()
        {
            return _salaRepository.GetListAsync();
        }

        public Task<Sala> UpdateAsync(int id, Sala sala)
        {
            return _salaRepository.UpdateAsync(id, sala);
        }
    }
}
