using AtendimentoConsultorio.Application.Interfaces;
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

            return Ok(entities.Select(x => new { x.Id, x.DataHora, x.Status, x.MedicoId, x.Medico, x.PacienteId, x.Paciente, x.SalaId, x.Sala }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Atendimento>> GetCompleteAsync(int id)
        {
            var entity = await _atendimentoService.GetCompleteAsync(id);

            if (entity == null)
            {
                return BadRequest();
            }

            return Ok(new Atendimento { Id = entity.Id, DataHora = entity.DataHora, Status = entity.Status, Medico = entity.Medico, Paciente = entity.Paciente, Sala = entity.Sala });
        }

        [HttpPost]
        public async Task<ActionResult<Atendimento>> PostAsync(Atendimento atendimento)
        {
            var entity = await _atendimentoService.CreateAsync(atendimento);

            if (entity == null)
            {
                return BadRequest();
            }

            return Ok(new Atendimento { Id = entity.Id, DataHora = entity.DataHora, Status = entity.Status, Medico = entity.Medico, Paciente = entity.Paciente, Sala = entity.Sala });
        }

        [HttpPut()]
        public async Task<IActionResult> PutAsync(Atendimento atendimento)
        {
            var entity = await _atendimentoService.UpdateAsync(atendimento.Id, atendimento);

            if (entity == null)
            {
                return BadRequest();
            }

            return Ok(new Atendimento { Id = entity.Id, DataHora = entity.DataHora, Status = entity.Status, Medico = entity.Medico, Paciente = entity.Paciente, Sala = entity.Sala });
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
