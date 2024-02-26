using AtendimentoConsultorio.Application.Interfaces;
using AtendimentoConsultorio.Domain.Dtos;
using AtendimentoConsultorio.Domain.Entities;
using AtendimentoConsultorio.Domain.Enums;
using Microsoft.AspNetCore.Mvc;


namespace AtendimentoConsultorio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;
        public PacienteController(IPacienteService service)
        {
            _pacienteService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var entities = await _pacienteService.GetListAsync();

            if (entities == null)
            {
                return BadRequest();
            }

            return Ok(entities.Select(x => new { x.Id, x.Nome, x.Sexo }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> GetCompleteAsync(int id)
        {
            var entity = await _pacienteService.GetCompleteAsync(id);

            if (entity == null)
            {
                return BadRequest();
            }

            return Ok(new Paciente { Id = entity.Id, Nome = entity.Nome, Sexo = entity.Sexo });
        }

        [HttpPost]
        public async Task<ActionResult<Paciente>> PostAsync(PacienteInsertDto pacienteDto)
        {
            var paciente = new Paciente
            {
                Nome = pacienteDto.Nome,
                Sexo = (SexoEnum)pacienteDto.Sexo
            };

            var entity = await _pacienteService.CreateAsync(paciente);

            if (entity == null)
            {
                return BadRequest();
            }

            return Ok(new Paciente { Id = entity.Id, Nome = entity.Nome, Sexo = entity.Sexo });
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(PacienteUpdateDto pacienteDto)
        {
            var paciente = new Paciente
            {
                Id = pacienteDto.Id,
                Nome = pacienteDto.Nome,
                Sexo = (SexoEnum)pacienteDto.Sexo
            };

            var entity = await _pacienteService.UpdateAsync(paciente.Id, paciente);

            if (entity == null)
            {
                return BadRequest();
            }

            return Ok(new Paciente { Id = entity.Id, Nome = entity.Nome, Sexo = entity.Sexo });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _pacienteService.Delete(id);

            if (!success)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}