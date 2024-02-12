using AtendimentoConsultorio.Domain.Entities;
using AtendimentoConsultorio.Domain.Interfaces;
using AtendimentoConsultorio.Infrastructure.Datas;
using Microsoft.EntityFrameworkCore;

namespace AtendimentoConsultorio.Infrastructure.Repositories
{
    public class AtendimentoRepository : IAtendimentoRepository
    {
        private readonly AtendimentoConsultorioDbContext _context;
        public AtendimentoRepository(AtendimentoConsultorioDbContext context)
        {
            _context = context;
        }
        private Atendimento GetAtendimentoById(int id)
        {
            if (id == 0)
            {
                return null;
            }

            var entity = _context.Atendimentos.FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }

            return entity;
        }
        public async Task<Atendimento> CreateAsync(Atendimento atendimento)
        {
            await _context.Atendimentos.AddAsync(atendimento);

            _context.SaveChanges();
            return atendimento;
        }

        public bool Delete(int id)
        {
            var entity = GetAtendimentoById(id);

            if (entity == null)
            {
                return false;
            }

            _context.Atendimentos.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public async Task<Atendimento> GetCompleteAsync(int id)
        {
            var entity = GetAtendimentoById(id);

            if (entity == null)
            {
                return null;
            }

            return entity;
        }

        public async Task<IEnumerable<Atendimento>> GetListAsync()
        {
            var entity = await _context.Atendimentos.ToListAsync();

            return entity;
        }

        public async Task<Atendimento> UpdateAsync(int id, Atendimento atendimento)
        {
            var entity = GetAtendimentoById(id);

            if (entity == null)
            {
                return null;
            }

            entity.DataHora = atendimento.DataHora;
            entity.Status = atendimento.Status;
            entity.Medico = atendimento.Medico;
            entity.Paciente = atendimento.Paciente;
            entity.Sala = atendimento.Sala;

            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
