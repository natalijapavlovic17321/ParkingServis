using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Projekat.Models;

namespace Projekat2
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
             services.AddCors(p => 
            {
                p.AddPolicy("CORS", builder =>
                {
                 builder.AllowAnyMethod()
                        .AllowAnyHeader()
                        //.AllowAnyOrigin();
                        .WithOrigins(new string[]
                        {"http://127.0.0.1:5500"
                        });
                });
            });
            services.AddCors(p => 
            {
                p.AddPolicy("CORSAll", policy =>
                {
                   policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
            services.AddCors(p => 
            {
                p.AddPolicy("CORSUser", policy =>
                {
                   policy.AllowAnyHeader().AllowAnyOrigin().WithMethods("POST","PUT","GET");
                });
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Projekat2", Version = "v1" });
            });
            services.AddDbContext<ParkinziContext>(options =>{
                options.UseSqlServer(Configuration.GetConnectionString("ParkinziCS"));
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Projekat2 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CORS");

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}
