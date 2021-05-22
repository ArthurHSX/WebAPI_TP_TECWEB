using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Dados.Contexto;
using Dados.Repositorio;
using Dominio.Interfaces;
using Dominio.Entidades;
using Servico.Servicos;
using WebAPI.Models;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddDbContext<SqlServerContext>(options =>
            {
                var server = Configuration["database:sqlserver:server"];                
                var database = Configuration["database:sqlserver:database"];
                var username = Configuration["database:sqlserver:username"];
                var password = Configuration["database:sqlserver:password"];

                options.UseSqlServer($"Server={server};Database={database};Uid={username};Pwd={password}", opt =>
                {
                    opt.CommandTimeout(180);
                    opt.EnableRetryOnFailure(5);
                });
            });

            services.AddScoped<IRepositorioBase<Usuario>, TecWEBRepositorio<Usuario>>();
            services.AddScoped<IRepositorioBase<Sessao>, TecWEBRepositorio<Sessao>>();

            services.AddScoped<IServicoBase<Usuario>, BaseServico<Usuario>>();            
            services.AddScoped<IServicoBase<Sessao>, BaseServico<Sessao>>();

            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<CreateModeloUsuario, Usuario>();
                config.CreateMap<CreateModeloSessao, Sessao>();

                config.CreateMap<UpdateModeloUsuario, Usuario>();

                config.CreateMap<Usuario, UsuarioModelo>();                
                config.CreateMap<Sessao, SessaoModelo>();

            }).CreateMapper());


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });                        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
