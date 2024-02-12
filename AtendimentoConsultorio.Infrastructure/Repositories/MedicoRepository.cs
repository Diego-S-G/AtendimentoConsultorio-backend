using AtendimentoConsultorio.Domain.Entities;
using AtendimentoConsultorio.Domain.Interfaces;
using AtendimentoConsultorio.Infrastructure.Datas;
using Microsoft.EntityFrameworkCore;

namespace AtendimentoConsultorio.Infrastructure.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly AtendimentoConsultorioDbContext _context;
        public MedicoRepository(AtendimentoConsultorioDbContext context)
        {
            _context = context;
        }
        private Medico GetMedicoById(int id)
        {
            if (id == 0)
            {
                return null;
            }

            var entity = _context.Medicos.FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }

            return entity;
        }
        public async Task<Medico> CreateAsync(Medico medico)
        {
            await _context.Medicos.AddAsync(medico);

            _context.SaveChanges();
            return medico;
        }

        public bool Delete(int id)
        {
            var entity = GetMedicoById(id);

            if (entity == null)
            {
                return false;
            }

            _context.Medicos.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public async Task<Medico> GetCompleteAsync(int id)
        {
            var entity = GetMedicoById(id);

            if (entity == null)
            {
                return null;
            }

            return entity;
        }

        public async Task<IEnumerable<Medico>> GetListAsync()
        {
            var entity = await _context.Medicos.ToListAsync();

            return entity;
        }

        public async Task<Medico> UpdateAsync(int id, Medico medico)
        {
            var entity = GetMedicoById(id);

            if (entity == null)
            {
                return null;
            }

            entity.Nome = medico.Nome;
            entity.Especialidade = medico.Especialidade;

            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
