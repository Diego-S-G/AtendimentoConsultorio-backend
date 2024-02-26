using AtendimentoConsultorio.Application.Interfaces;
using AtendimentoConsultorio.Domain.Dtos;
using AtendimentoConsultorio.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AtendimentoConsultorio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoService _medicoService;
        public MedicoController(IMedicoService service)
        {
            _medicoService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var entities = await _medicoService.GetListAsync();

            if (entities == null)
            {
                return BadRequest();
            }

            return Ok(entities.Select(x => new { x.Id, x.Nome, x.Especialidade }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Medico>> GetCompleteAsync(int id)
        {
            var entity = await _medicoService.GetCompleteAsync(id);

            if (entity == null)
            {
                return BadRequest();
            }

            return Ok(new Medico { Id = entity.Id, Nome = entity.Nome, Especialidade = entity.Especialidade });
        }

        [HttpPost]
        public async Task<ActionResult<Medico>> PostAsync(MedicoInsertDto medicoDto)
        {
            var medico = new Medico
            {
                Nome = medicoDto.Nome,
                Especialidade = medicoDto.Especialidade
            };

            var entity = await _medicoService.CreateAsync(medico);

            if (entity == null)
            {
                return BadRequest();
            }

            return Ok(new Medico { Id = entity.Id, Nome = entity.Nome, Especialidade = entity.Especialidade });
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Medico medico)
        {
            var entity = await _medicoService.UpdateAsync(medico.Id, medico);

            if (entity == null)
            {
                return BadRequest();
            }

            return Ok(new Medico { Id = entity.Id, Nome = entity.Nome, Especialidade = entity.Especialidade });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _medicoService.Delete(id);

            if (!success)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
