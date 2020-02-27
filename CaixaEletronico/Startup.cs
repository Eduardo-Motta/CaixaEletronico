using CaixaEletronico.Mutations;
using CaixaEletronico.Queries;
using CaixaEletronico.Schemas;
using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Services;

namespace CaixaEletronico
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
            services.AddSingleton<IRepository, RepositorioBase>();
            services.AddScoped<IContaCorrenteRepository, ContaCorrenteRepository>();
            services.AddScoped<IContaCorrenteServices, ContaCorrenteServices>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

            services.AddSingleton<ContaCorrenteQuery>();
            services.AddSingleton<ContaCorrenteMutation>();

            services.AddSingleton<ContaCorrenteType>();

            services.AddSingleton<ContaCorrenteSchema>();

            var serviceProvider = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new ContaCorrenteSchema(new FuncDependencyResolver(type => serviceProvider.GetService(type))));
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

            app.UseGraphiQl();
            app.UseMvc();
        }
    }
}
