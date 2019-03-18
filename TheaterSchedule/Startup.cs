using Entities.Models;
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
using TheaterSchedule.DALwp.Fake_Repositories;
using TheaterSchedule.DALwp.Repositories;
using TheaterSchedule.MiddlewareComponents;
using Hangfire;
using Hangfire.Dashboard;

namespace TheaterSchedule
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHangfire(configuration =>
            {
                configuration.UseSqlServerStorage(
                    Configuration.GetConnectionString("TheaterConnectionString"));
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.Configure<CookiePolicyOptions>(options =>
            {
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
            services.AddScoped<IPerfomanceRepository, PerfomanceRepositoryWp>();
            services.AddScoped<IPerformanceDetailsRepository, PerformanceDetailsRepositoryWp>();
            services.AddScoped<IWishlistRepository, WishlistRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IExcursionRepository, ExcursionRepository>();
            services.AddScoped<IIsCheckedPerformanceRepository, IsCheckedPerformanceRepository>();
            services.AddScoped<IPromoActionRepository, PromoActionRepository>();
            services.AddScoped<IPushTokenRepository, PushTokenRepository>();
            services.AddScoped<ICreativeTeamRepository, CreativeTeamRepositoryWpFake>();
            services.AddScoped<ITagRepository, TagRepositoryWp>();
            services.AddScoped<IPerformanceScheduleRepository, PerformanceScheduleRepositoryWp>();
            services.AddScoped<IRepository, Repository>();
            //uow
            services.AddScoped<ITheaterScheduleUnitOfWork, TheaterScheduleUnitOfWork>();
            //services
            services.AddScoped<ISettingsService, SettingsService>();
            services.AddScoped<IScheduleService, ScheduleService>();
            services.AddScoped<IPostersService, PostersService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IPerformanceDetailsService, PerformanceDetailsServiceWp>();
            services.AddScoped<IWishlistService, WishlistService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IExcursionService, ExcursionService>();
            services.AddScoped<IPromoActionService, PromoActionService>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IPushTokenService, PushTokenService>();
            services.AddSingleton<IPushNotificationsService, PushNotificationsService>();
            services.AddScoped<ICreativeTeamService, CreativeTeamService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IPerformanceScheduleService, PerformanceScheduleService>();
            services.AddMemoryCache();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseHangfireServer();
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { new AllowAllAuthorizationFilter() }
            });

            RecurringJob.AddOrUpdate<PushNotificationsService>(service => service.SendPushNotification(), "0 9 * * *");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            loggerFactory.AddFile("Logs/myapp-{Date}.txt");
            app.UseToken();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }

    internal class AllowAllAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            return true;
        }
    }
}
