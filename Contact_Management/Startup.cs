using AutoMapper;
using Contact_Management.Database;
using Contact_Management.Database.CQRS.Command;
using Contact_Management.Database.CQRS.Query;
using Contact_Management.Mapping;
using Contact_Management.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            RegisterAutomapper(services);
            RegisterCQRS(services);
            RegisterBusinessServices(services);
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
            services.AddTransient<IContactQuery, ContactQuery>();
            services.AddTransient<ICompanyQuery, CompanyQuery>();
            services.AddTransient<IContactCommand, ContactCommand>();
            services.AddTransient<ICompanyCommand, CompanyCommand>();
        }

        private void RegisterAutomapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            var mapper = mappingConfig.CreateMapper();

            services.AddSingleton<IMapper>(mapper);
        }

        private void RegisterBusinessServices(IServiceCollection services)
        {
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<ICompanyService, CompanyService>();
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
