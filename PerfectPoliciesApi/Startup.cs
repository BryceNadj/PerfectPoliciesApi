using System;
using System.IO;
using System.Text;
using System.Reflection;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using PerfectPoliciesApi.Entities;

namespace PerfectPoliciesApi
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
            // Main VM
            // services.AddDbContext<PerfectPoliciesContext>(c => c.UseSqlServer(Configuration.GetConnectionString("PerfectPoliciesSqlServer")));

            // Tafe VM
            services.AddDbContext<PerfectPoliciesContext>(c => c.UseSqlServer(Configuration.GetConnectionString("TafeVmServer")));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opts =>
            {
                opts.RequireHttpsMetadata = false;
                opts.SaveToken = true;
                
                opts.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["Jwt:Audience"],
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))     
                };                
            });
            

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PerfectPoliciesApi", Version = "v1" });

                var workingDirectory = AppContext.BaseDirectory;
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

<<<<<<< HEAD
                //c.IncludeXmlComments(Path.Combine(workingDirectory, xmlFile));
=======
                // c.IncludeXmlComments(Path.Combine(workingDirectory, xmlFile));
>>>>>>> 72834038fd46208e881dc0e52196b1e72a6cf00e
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PerfectPoliciesApi v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
