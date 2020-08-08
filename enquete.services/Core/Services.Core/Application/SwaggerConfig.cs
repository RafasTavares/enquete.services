using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Core.Application;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;

namespace Services.Core
{
    public static class SwaggerConfig
    {
        public static void UseSwagger(
            this IApplicationBuilder app,
            IHostingEnvironment env,
            IConfiguration configuration)
        {
            var informacoesApi = configuration.GetInfoApi();

            var pathIISApplication = configuration["PathIISApplication"];
#if DEBUG
            pathIISApplication = "";
#endif
            var endpointSwagger = $"{pathIISApplication}/swagger/v1/swagger.json";

            app.UseSwagger();

            app.UseSwaggerUI(s =>
            {
                var nome = $"{informacoesApi.Versao} | {env.EnvironmentName.ToString()}";
                s.SwaggerEndpoint(endpointSwagger, nome);
            });
        }

        public static void AddSwagger(this IServiceCollection services, IConfiguration configuration, string xmlFile)
        {
            var info = configuration.GetInfoApiSwagger();

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc(info.Version, info);

                s.DocumentFilter<SwaggerEnumDescricao>();

                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                s.IncludeXmlComments(xmlPath);

                s.AddFluentValidationRules();
            });
        }

        public static Info GetInfoApiSwagger(this IConfiguration configuration)
        {
            var informacoesApi = GetInfoApi(configuration);

            var info = new Info()
            {
                Title = informacoesApi.Nome,
                Version = informacoesApi.VersaoUsoSwagger,
                Description = informacoesApi.Descricao,
                TermsOfService = "https://github.com/RafasTavares/",
                Contact = new Contact
                {
                    Email = "rafaeltavaresandrade@gmail.com",
                    Name = "Rafael Tavares"
                }
            };

            return info;
        }

        private static ApplicationInfo GetInfoApi(this IConfiguration configuration)
        {
            var nomeApi = configuration["InformacoesApi:Nome"];
            var versaoUsoSwagger = configuration["InformacoesApi:VersaoUsoSwagger"];
            var versaoApi = configuration["InformacoesApi:Versao"];
            var descricao = configuration["InformacoesApi:Descricao"];
            var info = new ApplicationInfo(nomeApi, versaoUsoSwagger, versaoApi, descricao);

            return info;
        }
    }
}
