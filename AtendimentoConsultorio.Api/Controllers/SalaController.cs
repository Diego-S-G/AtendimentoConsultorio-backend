using AtendimentoConsultorio.Application.Interfaces;
using AtendimentoConsultorio.Domain.Dtos;
using AtendimentoConsultorio.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AtendimentoConsultorio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private readonly ISalaService _salaService;
        public SalaController(ISalaService service)
        {
            _salaService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var entities = await _salaService.GetListAsync();

            if (entities == null)
            {
                return BadRequest();
            }

            return Ok(entities.Select(x => new { x.Id, x.Sigla, x.Descricao }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sala>> GetCompleteAsync(int id)
        {
            var entity = await _salaService.GetCompleteAsync(id);

            if (entity == null)
            {
                return BadRequest();
            }

            return Ok(new Sala { Id = entity.Id, Sigla = entity.Sigla, Descricao = entity.Descricao });
        }

        [HttpPost]
        public async Task<ActionResult<Sala>> PostAsync(SalaInsertDto salaDto)
        {
            var sala = new Sala
            {
                Sigla = salaDto.Sigla.ToUpper(),
                Descricao = salaDto.Descricao
            };

            var entity = await _salaService.CreateAsync(sala);

            if (entity == null)
            {
                return BadRequest();
            }

            return Ok(new Sala { Id = entity.Id, Sigla = entity.Sigla, Descricao = entity.Descricao });
        }

        [HttpPut()]
        public async Task<IActionResult> PutAsync(Sala sala)
        {
            var entity = await _salaService.UpdateAsync(sala.Id, sala);

            if (entity == null)
            {
                return BadRequest();
            }

            return Ok(new Sala { Id = entity.Id, Sigla = entity.Sigla, Descricao = entity.Descricao });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _salaService.Delete(id);

            if (!success)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
