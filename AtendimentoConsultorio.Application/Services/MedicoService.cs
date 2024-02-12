using AtendimentoConsultorio.Application.Interfaces;
using AtendimentoConsultorio.Domain.Entities;
using AtendimentoConsultorio.Domain.Interfaces;

namespace AtendimentoConsultorio.Application.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository _medicoRepository;
        public MedicoService(IMedicoRepository repository)
        {
            _medicoRepository = repository;
        }
        public Task<Medico> CreateAsync(Medico medico)
        {
            return _medicoRepository.CreateAsync(medico);
        }

        public bool Delete(int id)
        {
            return _medicoRepository.Delete(id);
        }

        public Task<Medico> GetCompleteAsync(int id)
        {
            return _medicoRepository.GetCompleteAsync(id);
        }

        public Task<IEnumerable<Medico>> GetListAsync()
        {
            return _medicoRepository.GetListAsync();
        }

        public Task<Medico> UpdateAsync(int id, Medico medico)
        {
            return _medicoRepository.UpdateAsync(id, medico);
        }
    }
}
