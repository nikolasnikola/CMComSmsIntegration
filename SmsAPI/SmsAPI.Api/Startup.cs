using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SmsAPI.Application.Queries;
using SmsAPI.Infrastructure;
using SmsAPI.Infrastructure.CMDotCom;
using SmsAPI.Infrastructure.Options;
using SmsAPI.Infrastructure.Repositories;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace SmsAPI.Api
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SmsAPI.Api", Version = "v1" });
            });

            var connectionString = Configuration.GetConnectionString("SMSApiContext");
            services.AddDbContext<SMSApiContext>(x => x.UseSqlServer(connectionString));

            services.AddMediatR(GetApplicationsAssemblies());

            services.Configure<CMClientOptions>(Configuration.GetSection(nameof(CMClientOptions)));

            services.AddScoped<ICmTextClient, CmTextClient>()
                    .AddScoped<IUserQueries, UserQueries>()
                    .AddScoped<ISMSResponseRepository, SMSResponseRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmsAPI.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static Assembly[] GetApplicationsAssemblies()
        {
            return AppDomain
                .CurrentDomain
                .GetAssemblies()
                .Where(f => f.FullName.StartsWith("SmsAPI.Application", true, Thread.CurrentThread.CurrentCulture)).ToArray();
        }
    }
}
