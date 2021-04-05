using System;
using System.Text;
using HuyenVu.TaskManagement.API.Middlewares;
using HuyenVu.TaskManagement.Core.RepositoryInterface;
using HuyenVu.TaskManagement.Core.ServiceInterface;
using HuyenVu.TaskManagement.Infrastructure.Data;
using HuyenVu.TaskManagement.Infrastructure.Repositories;
using HuyenVu.TaskManagement.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace HuyenVu.TaskManagement.API
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
            services.AddControllers().AddNewtonsoftJson(x =>
                x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddDbContext<TaskManagementDbContext>(opts =>
                opts.UseLazyLoadingProxies()
                    .UseSqlServer(Configuration.GetConnectionString("TaskManagementDbConnectionString")));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<ITaskHistoryRepository, TaskHistoryRepository>();
            services.AddTransient<ITaskHistoryService, TaskHistoryService>();

            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<ITaskService, TaskService>();

            services.AddTransient<IJwtService, JwtService>();
            services.AddTransient<IDashboardService, DashboardService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(cfg =>
            {
                Console.WriteLine(Configuration["TokenSettings:PrivateKey"]);
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["TokenSettings:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = Configuration["TokenSettings:Audience"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenSettings:PrivateKey"]))
                };
            });

            services.AddAuthorization(cfg =>
            {
                var defaultAuthorizationPolicyBuilder =
                    new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                var defaultPolicy = defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser().Build();

                cfg.DefaultPolicy = defaultPolicy;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "HuyenVu.TaskManagement.API", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HuyenVu.TaskManagement.API v1"));
            }

            app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowCredentials().AllowAnyHeader()
                .AllowAnyMethod());

            app.UseHttpsRedirection();

            // app.UseMiddleware<PasswordHeaderCheckingMiddleware>();

            app.UsePasswordHeaderCheckingMiddleware();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}