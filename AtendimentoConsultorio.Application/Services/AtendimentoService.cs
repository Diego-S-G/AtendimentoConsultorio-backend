using AtendimentoConsultorio.Application.Interfaces;
using AtendimentoConsultorio.Domain.Entities;
using AtendimentoConsultorio.Domain.Interfaces;

namespace AtendimentoConsultorio.Application.Services
{
    public class AtendimentoService : IAtendimentoService
    {
        private readonly IAtendimentoRepository _atendimentoRepository;
        private readonly IMedicoRepository _medicoRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly ISalaRepository _salaRepository;
        public AtendimentoService(IAtendimentoRepository repository, IMedicoRepository medicoRepository, IPacienteRepository pacienteRepository, ISalaRepository salaRepository)
        {
            _atendimentoRepository = repository;
            _medicoRepository = medicoRepository;
            _pacienteRepository = pacienteRepository;
            _salaRepository = salaRepository;
        }
        public Task<Atendimento> CreateAsync(Atendimento atendimento)
        {
            ValidarTiposComplexos(atendimento);

            return _atendimentoRepository.CreateAsync(atendimento);
        }

        private void ValidarTiposComplexos(Atendimento atendimento)
        {
            if (!atendimento.MedicoId.Equals(0))
            {
                var medico = _medicoRepository.GetCompleteAsync(atendimento.MedicoId);
                atendimento.Medico = medico.Result;
            }

            if (!atendimento.PacienteId.Equals(0))
            {
                var paciente = _pacienteRepository.GetCompleteAsync(atendimento.PacienteId);
                atendimento.Paciente = paciente.Result;
            }

            if (!atendimento.SalaId.Equals(0))
            {
                var sala = _salaRepository.GetCompleteAsync(atendimento.SalaId);
                atendimento.Sala = sala.Result;
            }
        }

        public bool Delete(int id)
        {
            return _atendimentoRepository.Delete(id);
        }

        public Task<IEnumerable<Atendimento>> GetListAsync()
        {
            return _atendimentoRepository.GetListAsync();
        }

        public Task<Atendimento> UpdateAsync(int id, Atendimento atendimento)
        {
            ValidarTiposComplexos(atendimento);

            return _atendimentoRepository.UpdateAsync(id, atendimento);
        }

        public Task<IEnumerable<Atendimento>> GetFinishedList(short take)
        {
            return _atendimentoRepository.GetFinishedList(take);
        }

        public Task<IEnumerable<Atendimento>> GetInProcessList()
        {
            return _atendimentoRepository.GetInProcessList();
        }

        public bool DeleteAll()
        {
            return _atendimentoRepository.DeleteAll();
        }
    }
}
