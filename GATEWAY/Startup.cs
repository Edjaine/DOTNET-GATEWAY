using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace GATEWAY
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddJsonFile("ocelot.json")
            .AddEnvironmentVariables();

      

            Console.WriteLine($" Ambiente -> {env.EnvironmentName}");

            Configuration = builder.Build();


        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
        var authenticationProviderKey = "afsdkjasjflxswafsdklk434orqiwup3457u-34oewir4irroqwiffv48mfs";

            services.AddControllers();
            
            services.AddAuthentication()
                .AddJwtBearer(authenticationProviderKey, x =>
                {
                });

            services.AddSwaggerGen(c =>{
                     c.SwaggerDoc("v1", new OpenApiInfo { Title = "GATEWAY", Version = "v1" });
            }); 

            services.AddOcelot(Configuration);
            services.AddSwaggerForOcelot(Configuration);
            

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

            app.UseSwagger();

            app.UseSwaggerForOcelotUI(opt => {
                opt.PathToSwaggerGenerator = "/swagger/docs";
            });
            
            app.UseSwaggerUI(c =>{
             c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseOcelot().Wait();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
