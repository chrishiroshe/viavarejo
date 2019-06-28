using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Distance.Infra.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using Distance.Domain.Services;
using Distance.Domain;
using Distance.Domain.Entities;
using Distance.Domain.Interfaces;
using Distance.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication;
using Distance.WebAPI.Authorization;

namespace Distance.WebAPI
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
            //services.AddMvc().AddJsonOptions(
            //    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            //);
            // services.AddAuthorization(c=> c.AddPolicy("oi", new Microsoft.AspNetCore.Authorization.AuthorizationPolicy() { })
            services.AddAuthentication("BasicAuthentication")
             .AddScheme<AuthenticationSchemeOptions, AutenticacaoBasica>("BasicAuthentication", null);
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            //ADICIONA DOCUMENTACAO DO SWAGGER
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info() { Title = "Courses API", Description = "Swagger Web API Courses" });
            });

            var sqlConnection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DistanceContext>(options => options.UseSqlServer(sqlConnection, b => b.MigrationsAssembly("Distance.WebAPI")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
          
           // services.AddTransient<IServiceBase<Distancia>, ServiceBase<Distancia>>();
            services.AddTransient<IDistanciaService, DistanciaService>();
           // services.AddTransient<IServiceBase<CalculoHistoricoLog>, ServiceBase<CalculoHistoricoLog>>();
            services.AddScoped<IDistanciaRepository, DistanciaRepository>();
            services.AddScoped<ICalculoHistoricoLogRepository, CalculoHistoricoLogRepository>();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Core API"); });
        }
    }
}
