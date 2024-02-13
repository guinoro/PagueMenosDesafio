using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PagueMenosDesafio.Models;
using PagueMenosDesafio.Services;
using PagueMenosDesafio.Controllers;

namespace PagueMenosDesafio
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime and is used to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<EstoqueService, EstoqueService>();
            services.AddScoped<LojaService, LojaService>();
            services.AddScoped<PrecoService, PrecoService>();
            // Adiciona o contexto do Entity Framework
            services.AddDbContext<PagueMenosContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PagueMenosDB")));
        }

        // This method gets called by the runtime and is used to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
