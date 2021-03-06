using Elbek.MContent.DataAccess;
using Elbek.MContent.DataAccess.Repositories;
using Elbek.MContent.Services.CoreServices;
using Elbek.MContent.Services.ValidationServices.AuthorValidator;
using Elbek.MContent.Services.ValidationServices.ContentValidator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace Elbek.MContent.WebHost
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
            services.AddDbContext<MContentContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("LocalDbConnection"));
                }
            );
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Elbek.MContent.WebHost", Version = "v1" });
            });
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IAuthorValidationRules, AuthorValidationRules>();
            services.AddTransient<IAuthorValidationService, AuthorValidationService>();

            services.AddTransient<IContentService, ContentService>();
            services.AddTransient<IContentRepository, ContentRepository>();
            services.AddTransient<IContentValidationRules, ContentValidationRules>();
            services.AddTransient<IContentValidationService, ContentValidationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Elbek.MContent.WebHost v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
