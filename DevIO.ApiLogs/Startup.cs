using AutoMapper;
using DevIO.APILogs.Configuration;
using DevIO.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DevIO.APILogs
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (hostEnvironment.IsDevelopment())
            {
                //incluso: "DevIO.APILogs.csproj" => <UserSecretsId>7dab9b15-1049-45cc-9427-5970888e32a4</UserSecretsId>
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MeuDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddIdentityConfig(Configuration);

            //instalado o pacote: AutoMapper.Extensions.Microsoft.DependencyInjection
            services.AddAutoMapper(typeof(Startup));

            //***PARA IGNORAR VALIDA��O AUTOM�TICA*********************
            //services.Configure<ApiBehaviorOptions>(Options =>
            //{
            //    Options.SuppressModelStateInvalidFilter = true;
            //});
            //*********************************************************

            services.AddApiConfig();

            services.AddSwaggerConfig();

            services.AddLoggingConfig(Configuration);

            services.ResolveDependencies();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.UseApiConfig(env);

            app.UseSwaggerConfig(provider);

            app.UseLoggingConfiguration();
        }
    }
}
