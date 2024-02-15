using AtendimentoConsultorio.Application.Interfaces;
using AtendimentoConsultorio.Domain.Dtos;
using AtendimentoConsultorio.Domain.Entities;
using Microsoft.AspNetCore.Mvc;


namespace AtendimentoConsultorio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentoController : ControllerBase
    {
        private readonly IAtendimentoService _atendimentoService;
        private readonly IMedicoService _medicoService;
        private readonly IPacienteService _pacienteService;
        private readonly ISalaService _salaService;
        public AtendimentoController(IAtendimentoService service, IMedicoService medicoService, IPacienteService pacienteService, ISalaService salaService)
        {
            _atendimentoService = service;
            _medicoService = medicoService;
            _pacienteService = pacienteService;
            _salaService = salaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {

            var entities = await _atendimentoService.GetListAsync();

            if (entities == null)
            {
                return BadRequest();
            }

            var atendimento = entities.Select(x => new AtendimentoResponseDto
            {
                Id = x.Id,
                MedicoId = x.MedicoId,
                NomeMedico = x.Medico.Nome,
                PacienteId = x.PacienteId,
                NomePaciente = x.Paciente.Nome,
                SalaId = x.SalaId,
                NomeSala = x.Sala.ToString(),
                DataHora = x.DataHora,
                Status = (short)x.Status,
            });


            return Ok(atendimento);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Atendimento>> GetCompleteAsync(int id)
        {
            var entity = await _atendimentoService.GetCompleteAsync(id);

            if (entity == null)
            {
                return BadRequest();
            }

            return Ok(new Atendimento { Id = entity.Id, DataHora = entity.DataHora, Status = entity.Status, MedicoId = entity.MedicoId, PacienteId = entity.PacienteId, SalaId = entity.SalaId });
        }

        [HttpPost]
        public async Task<ActionResult<Atendimento>> PostAsync(AtendimentoInsertDto atendimentoDto)
        {
            var atendimento = new Atendimento
            {
                DataHora = DateTime.Now,
                Status = atendimentoDto.Status,
                MedicoId = atendimentoDto.MedicoId,
                PacienteId = atendimentoDto.PacienteId,
                SalaId = atendimentoDto.SalaId
            };

            var entity = await _atendimentoService.CreateAsync(atendimento);

            if (entity == null)
            {
                return BadRequest();
            }

            return Ok(new Atendimento { Id = entity.Id, DataHora = entity.DataHora, Status = entity.Status, MedicoId = entity.MedicoId, PacienteId = entity.PacienteId, SalaId = entity.SalaId });
        }

        [HttpPut()]
        public async Task<IActionResult> PutAsync(AtendimentoUpdateDto atendimentoDto)
        {
            var atendimento = new Atendimento
            {
                Id = atendimentoDto.Id,
                DataHora = atendimentoDto.DataHora,
                Status = atendimentoDto.Status,
                MedicoId = atendimentoDto.MedicoId,
                PacienteId = atendimentoDto.PacienteId,
                SalaId = atendimentoDto.SalaId
            };

            var entity = await _atendimentoService.UpdateAsync(atendimento.Id, atendimento);

            if (entity == null)
            {
                return BadRequest();
            }

            return Ok(new Atendimento { Id = entity.Id, DataHora = entity.DataHora, Status = entity.Status, MedicoId = entity.MedicoId, PacienteId = entity.PacienteId, SalaId = entity.SalaId });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _atendimentoService.Delete(id);

            if (!success)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
