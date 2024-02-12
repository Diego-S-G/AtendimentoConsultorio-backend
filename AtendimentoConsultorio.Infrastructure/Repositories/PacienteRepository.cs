using AtendimentoConsultorio.Domain.Entities;
using AtendimentoConsultorio.Domain.Interfaces;
using AtendimentoConsultorio.Infrastructure.Datas;
using Microsoft.EntityFrameworkCore;

namespace AtendimentoConsultorio.Infrastructure.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly AtendimentoConsultorioDbContext _context;
        public PacienteRepository(AtendimentoConsultorioDbContext context)
        {
            _context = context;
        }
        private Paciente GetPacienteById(int id)
        {
            if (id == 0)
            {
                return null;
            }

            var entity = _context.Pacientes.FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }

            return entity;
        }
        public async Task<Paciente> CreateAsync(Paciente paciente)
        {
            await _context.Pacientes.AddAsync(paciente);

            _context.SaveChanges();
            return paciente;
        }

        public bool Delete(int id)
        {
            var entity = GetPacienteById(id);

            if (entity == null)
            {
                return false;
            }

            _context.Pacientes.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public async Task<Paciente> GetCompleteAsync(int id)
        {
            var entity = GetPacienteById(id);

            if (entity == null)
            {
                return null;
            }

            return entity;
        }

        public async Task<IEnumerable<Paciente>> GetListAsync()
        {
            var entity = await _context.Pacientes.ToListAsync();

            return entity;
        }

        public async Task<Paciente> UpdateAsync(int id, Paciente paciente)
        {
            var entity = GetPacienteById(id);

            if (entity == null)
            {
                return null;
            }

            entity.Nome = paciente.Nome;
            entity.Sexo = paciente.Sexo;

            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
