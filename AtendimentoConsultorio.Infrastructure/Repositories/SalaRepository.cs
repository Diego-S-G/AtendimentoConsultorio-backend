using AtendimentoConsultorio.Domain.Entities;
using AtendimentoConsultorio.Domain.Interfaces;
using AtendimentoConsultorio.Infrastructure.Datas;
using Microsoft.EntityFrameworkCore;

namespace AtendimentoConsultorio.Infrastructure.Repositories
{
    public class SalaRepository :ISalaRepository
    {
        private readonly AtendimentoConsultorioDbContext _context;
        public SalaRepository(AtendimentoConsultorioDbContext context)
        {
            _context = context;
        }
        private Sala GetSalaById(int id)
        {
            if (id == 0)
            {
                return null;
            }

            var entity = _context.Salas.FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }

            return entity;
        }
        public async Task<Sala> CreateAsync(Sala sala)
        {
            await _context.Salas.AddAsync(sala);

            _context.SaveChanges();
            return sala;
        }

        public bool Delete(int id)
        {
            var entity = GetSalaById(id);

            if (entity == null)
            {
                return false;
            }

            _context.Salas.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public async Task<Sala> GetCompleteAsync(int id)
        {
            var entity = GetSalaById(id);

            if (entity == null)
            {
                return null;
            }

            return entity;
        }

        public async Task<IEnumerable<Sala>> GetListAsync()
        {
            var entity = await _context.Salas.ToListAsync();

            return entity;
        }

        public async Task<Sala> UpdateAsync(int id, Sala sala)
        {
            var entity = GetSalaById(id);

            if (entity == null)
            {
                return null;
            }

            entity.Sigla = sala.Sigla.ToUpper();
            entity.Descricao = sala.Descricao;

            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
