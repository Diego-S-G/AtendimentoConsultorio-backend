﻿using AtendimentoConsultorio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AtendimentoConsultorio.Infrastructure.Datas
{
    public class AtendimentoConsultorioDbContext : DbContext
    {
        public AtendimentoConsultorioDbContext(DbContextOptions<AtendimentoConsultorioDbContext> options) : base(options) { }
        public virtual DbSet<Medico> Medicos { get; set; }
    }
}
