
using AtendimentoConsultorio.Application.Interfaces;
using AtendimentoConsultorio.Application.Services;
using AtendimentoConsultorio.Domain.Interfaces;
using AtendimentoConsultorio.Infrastructure.Datas;
using AtendimentoConsultorio.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AtendimentoConsultorio.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AtendimentoConsultorioDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));

            builder.Services.AddScoped<IMedicoRepository, MedicoRepository>();
            builder.Services.AddScoped<IMedicoService, MedicoService>();

            builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
            builder.Services.AddScoped<IPacienteService, PacienteService>();

            builder.Services.AddScoped<ISalaRepository, SalaRepository>();
            builder.Services.AddScoped<ISalaService, SalaService>();

            builder.Services.AddScoped<IAtendimentoRepository, AtendimentoRepository>();
            builder.Services.AddScoped<IAtendimentoService, AtendimentoService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
