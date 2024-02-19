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
        public bool DeleteAll()
        {
            var entities = GetListAsync();

            if (entities == null)
            {
                return false;
            }

            _context.Atendimentos.RemoveRange(entities.Result);
            _context.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<Atendimento>> GetListAsync()
        {
            var entity = await _context.Atendimentos
                .Include(x => x.Medico)
                .Include(x => x.Paciente)
                .Include(x => x.Sala)
                .ToListAsync();

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

        public async Task<IEnumerable<Atendimento>> GetFinishedList(short take)
        {
            var entity = await _context.Atendimentos
                 .Include(x => x.Medico)
                 .Include(x => x.Paciente)
                 .Include(x => x.Sala)
                 .Where(x => x.Status == Domain.Enums.StatusEnum.Atendido || x.Status == Domain.Enums.StatusEnum.Cancelado)
                 .Where(x => x.DataHora.Day == DateTime.Now.Day)
                 .OrderByDescending(x => x.DataHora)
                 .Take(3)
                 .ToListAsync();

            return entity;
        }

        public async Task<Atendimento> GetFirstInProcess()
        {
            var entity = await _context.Atendimentos
                 .Include(x => x.Medico)
                 .Include(x => x.Paciente)
                 .Include(x => x.Sala)
                 .Where(x => x.Status == Domain.Enums.StatusEnum.EmAndamento)
                 .OrderByDescending(x => x.DataHora)
                 .Take(1)
                 .SingleOrDefaultAsync();

            return entity;
        }
        public async Task<IEnumerable<Atendimento>> GetRestInProcessList()
        {
            var entity = await _context.Atendimentos
                 .Include(x => x.Medico)
                 .Include(x => x.Paciente)
                 .Include(x => x.Sala)
                 .Where(x => x.Status == Domain.Enums.StatusEnum.EmAndamento)
                 .OrderByDescending(x => x.DataHora)
                 .Skip(1)
                 .ToListAsync();

            return entity;
        }
    }
}
