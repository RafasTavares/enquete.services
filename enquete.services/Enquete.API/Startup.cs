using Enquete.Domain.AggregateModel.PollAggregate;
using Enquete.Infra.Context;
using Enquete.Infra.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Services.Core;
using System;
using System.Reflection;

namespace Enquete.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("Enquete.Domain");

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddJsonOptions(op =>
            {
                op.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<EnqueteContext>(op =>
                op.UseSqlServer(connectionString)
            );

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            services.AddSwagger(Configuration, xmlFile);

            //services.AddScoped<IdentityService>();
            services.AddMediatR(assembly);
            AddRepositories(services);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    var result = new ApplicationResponse();

                    foreach (var propriedade in context.ModelState.Keys)
                    {
                        var errosPropriedade = context.ModelState[propriedade];

                        foreach (var erroPropriedadeItem in errosPropriedade.Errors)
                        {
                            result.AddErro(erroPropriedadeItem.ErrorMessage);
                        }
                    }

                    return new UnprocessableEntityObjectResult(result);
                };
            });
        }

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

            app.UseSwagger(env, Configuration);
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }

        private void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IPollRepository, PollRepository>();
            services.AddScoped<IOptionRepository, OptionRepository>();
        }

        //Add Services

    }
}
