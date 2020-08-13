// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="Daniel Salgado">
//   This code is property of Daniel Salgado
// </copyright>
// <summary>
//   Defines the Startup type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DanielSalgado.IMCTest.Api
{
    using System;
    using System.IO;
    using System.Reflection;

    using AutoMapper;

    using DanielSalgado.IMCTest.Api.Domain;
    using DanielSalgado.IMCTest.Services.TaxCalculation.Interfaces;
    using DanielSalgado.IMCTest.Services.TaxCalculation.TaxJar.Infrastructure.Mapper;
    using DanielSalgado.IMCTest.Services.TaxCalculation.TaxJar.Service;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;

    public class Startup
    {
        /// <summary>
        /// The service resolver.
        /// </summary>
        /// <param name="customerType">
        /// The customer type.
        /// </param>
        public delegate ITaxCalculatorService ServiceResolver(CustomerType customerType);

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // we can setup multiple concrete registrations here for same service 
            services.AddTransient<TaxJarCalculatorService>();

            services.AddTransient<ServiceResolver>(serviceProvider => customerType =>
                {
                    switch (customerType)
                    {
                        case CustomerType.B2B:
                            return serviceProvider.GetService<TaxJarCalculatorService>();
                        case CustomerType.Regular:
                            // we can return other implementation here if we want
                            throw new NotImplementedException();
                            default:
                            throw new NotImplementedException();
                    }
                });


            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddMvc();

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            
            services.AddSwaggerGen(
                c =>
                    {
                        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tax Calculator API", Version = "v1" });
                        c.IncludeXmlComments(xmlPath);
                        //c.IncludeXmlComments(xmlApiDomain);
                    });

            services.AddAutoMapper(typeof(ApiServiceMapperProfile), typeof(TaxJarServiceMapperProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tax Calculator API V1");
                });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
