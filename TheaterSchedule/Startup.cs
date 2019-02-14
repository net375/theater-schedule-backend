﻿using Entities.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TheaterSchedule.BLL.Interfaces;
using TheaterSchedule.BLL.Services;
using TheaterSchedule.DAL.Interfaces;
using TheaterSchedule.DAL.Repositories;
using TheaterSchedule.MiddlewareComponents;

namespace TheaterSchedule
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            }); 

            services.AddDbContext<TheaterDatabaseContext>(options => options.UseSqlServer
                (Configuration.GetConnectionString("TheaterConnectionString")), ServiceLifetime.Scoped);
            //repositories
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<ISettingsRepository, SettingsRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<IPerfomanceRepository, PerfomanceRepository>();
            services.AddScoped<IPerformanceDetailsRepository, PerformanceDetailsRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IPromoActionRepository, PromoActionRepository>();
            //uow
            services.AddScoped<ITheaterScheduleUnitOfWork, TheaterScheduleUnitOfWork>();
            //services
            services.AddScoped<ISettingsService, SettingsService>();
            services.AddScoped<IScheduleService, ScheduleService>();
            services.AddScoped<IPostersService, PostersService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IPerformanceDetailsService, PerformanceDetailsService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IPromoActionService, PromoActionService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
                          
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            loggerFactory.AddFile("Logs/myapp-{Date}.txt");
            app.UseToken();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
