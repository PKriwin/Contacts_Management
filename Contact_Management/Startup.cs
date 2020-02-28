using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contact_Management.Database;
using Contact_Management.Database.CQRS;
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


namespace Contact_Management
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
            services.AddControllers();
            RegisterSwagger(services);
            RegisterDBContext(services);
            RegisterCQRS(services);
        }

        private void RegisterSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Contacts Management Api", Version = "v1" });
            });
        }

        private void RegisterDBContext(IServiceCollection services)
        {
            services.AddDbContext<ContactManagementDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ContactManagement")));
        }

        private void RegisterCQRS(IServiceCollection services)
        {
            services.AddTransient<IContactManagementQuery, ContactManagementQuery>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contacts Management Api V1");
            });
        }
    }
}
