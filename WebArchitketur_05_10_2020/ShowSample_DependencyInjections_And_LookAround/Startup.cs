using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _006_DependencyInjections_EntityLib;
using DependencyInjections_SharedLib;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ShowSample_DependencyInjections_And_LookAround
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) //ServiceCollection ist der Startpunkt des internen IoC - Containers (Reisetasche) 
        {
            services.AddRazorPages();

            //Dictionary hat ein Key-Spalte + Werte-Spalte. Key=ICar 
            services.AddSingleton(typeof(ICar), typeof(MockCar));
            services.AddSingleton(typeof(ICar), typeof(Car)); // MockCar wird durch Car überschrieben
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
