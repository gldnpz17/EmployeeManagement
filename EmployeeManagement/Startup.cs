using Application;
using Application.Common.Configuration;
using Application.Common.Mediator;
using AutoMapper;
using EmployeeManagement.Common.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class Startup
    {
        private readonly IWebHostEnvironment _environment;

        public Startup(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = (document) =>
                {
                    document.Info.Title = "EmployeeManagement API";
                    document.Info.Contact = new NSwag.OpenApiContact()
                    {
                        Name = "Firdaus Bisma Suryakusuma",
                        Email = "firdausbismasuryakusuma@mail.ugm.ac.id"
                    };
                };
            });

            services.AddControllers();

            services.AddRouting(config =>
            {
                config.LowercaseUrls = true;
            });

            services.AddSpaStaticFiles(config =>
            {
                config.RootPath = "client-app/build";
            });

            // Register application layer mediator.
            if (_environment.IsDevelopment())
            {
                var applicationMediator = new Bootstrapper(new ApplicationConfig()
                {
                    Environment = TypeOfEnvironment.Development
                }).Mediator;
                services.AddSingleton(typeof(IApplicationMediator), applicationMediator);
            }

            // Register object-to-object mapper.
            services.AddSingleton(typeof(IMapper), new Mapper(new AutomapperConfig().Configuration));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSpaStaticFiles();

            app.UseRouting();

            if (env.IsDevelopment())
            {
                app.UseOpenApi();
                app.UseSwaggerUi3();
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "client-app";
            });
        }
    }
}
