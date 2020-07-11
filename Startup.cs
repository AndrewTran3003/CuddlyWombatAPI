using CuddlyWombat.Models;
using CuddlyWombatAPI.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using CuddlyWombatAPI.Data;
using CuddlyWombatAPI.Services;
using AutoMapper;
using CuddlyWombatAPI.Infrastructure;
using Newtonsoft;

namespace CuddlyWombatAPI
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
            services
                .Configure<ItemEntity>(
                    Configuration.GetSection("Info")
                );
            services
                .AddScoped<IItemService, DefaultItemService>();
            services.AddAutoMapper(
                options => options.AddProfile<MappingProfile>());
            //Use in-memory database for quick development and testing
            //TODO: swap it out for a real database in production
            services.AddDbContext<CuddlyWombatDbContext>(
                options => options.UseInMemoryDatabase("CuddlyWombatInMemoryDb"));
            services
                .AddControllers().AddNewtonsoftJson();
            
               
            services
                .AddMvcCore(options =>
               {
                   options.Filters.Add<JsonExceptionFilter>();
                   options.Filters.Add<LinkRewritingFilter>();
               })
                .AddCors();

            services
                .AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ApiVersionReader
                = new MediaTypeApiVersionReader();
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionSelector
                = new CurrentImplementationApiVersionSelector(options);
            });
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            if (env.IsDevelopment())
            {
                app.UseOpenApi();
                app.UseSwaggerUi3();
            }
        }
    }
}
