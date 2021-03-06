using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using APICatalogoJogos.Controladores.V1;
using APICatalogoJogos.Middleware;
using APICatalogoJogos.Repositorios;
using APICatalogoJogos.Servicos;
using APICatalogoJogos.InputModel;

namespace APICatalogoJogos
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
            services.AddScoped<IJogoServico, JogoServico>();
            services.AddScoped<IJogoRepositorio, JogoRepositorio>();

            services.AddControllers();

            //services.AddSwaeggerGen(c=>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "APICatalogoJogos", Version = "v1" });

            //    var basePath = AppDomain.CurrentDomain.BaseDirectory;
            //    var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
            //    c.IncludeXmlComments(Path.Combine(basePath, fileName));
            //}
            //);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ExceptionMiddleware>();

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
