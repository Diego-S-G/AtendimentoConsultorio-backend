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
        public AtendimentoController(IAtendimentoService service)
        {
            _atendimentoService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var entities = await _atendimentoService.GetListAsync();

            if (entities == null)
            {
                return BadRequest();
            }

            return Ok(entities.Select(x => new { x.Id, x.DataHora, x.Status, x.MedicoId, x.PacienteId, x.SalaId }));
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
                DataHora = atendimentoDto.DataHora,
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
