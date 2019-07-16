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
using TheaterSchedule.BLL;
using TheaterSchedule.DALwp.Fake_Repositories;
using TheaterSchedule.DALwp.Repositories;
using TheaterSchedule.MiddlewareComponents;
using TheaterSchedule.BLL.Helpers;
using Hangfire;
using Hangfire.Dashboard;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;
using System.IO;
using System;
using TheaterSchedule.Extensions;
using TheaterSchedule.BLL.Models;

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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1.0",
                    Title = "Theater Schedule",
                    Description = "Theater Schedule ASP.NET Core Web API",
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddOptions();

            services.Configure<AuthOptions>(Configuration.GetSection(Constants.AuthOption));            

            services.AddAuthenticationService();
            
            //repositories
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<ISettingsRepository, SettingsRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepositoryWp>();
            services.AddScoped<IPerfomanceRepository, PerfomanceRepositoryWp>();
            services.AddScoped<IPerformanceDetailsRepository, PerformanceDetailsRepositoryWp>();
            services.AddScoped<IWishlistRepository, WishlistRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IIsCheckedPerformanceRepository, IsCheckedPerformanceRepository>();
            services.AddScoped<IPushTokenRepository, PushTokenRepository>();
            services.AddScoped<ICreativeTeamRepository, CreativeTeamRepositoryWpFake>();
            services.AddScoped<ITagRepository, TagRepositoryWp>();
            services.AddScoped<IPerformanceScheduleRepository, PerformanceScheduleRepositoryWp>();
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<INotificationFrequencyRepository, NotificationFrequencyRepository>();
            services.AddScoped<IResetCodeRepository, ResetCodeRepository>();
            //uow
            services.AddScoped<ITheaterScheduleUnitOfWork, TheaterScheduleUnitOfWork>();
            //services            
            services.AddScoped<ISettingsService, SettingsService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IRefreshTokenService, RefreshTokenService>();
            services.AddScoped<IScheduleService, ScheduleServiceWp>();
            services.AddScoped<IPostersService, PostersService>();
            services.AddScoped<IPerformanceDetailsService, PerformanceDetailsServiceWp>();
            services.AddScoped<IWishlistService, WishlistService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IPushTokenService, PushTokenService>();
            services.AddSingleton<IPushNotificationsService, PushNotificationsService>();
            services.AddScoped<ICreativeTeamService, CreativeTeamService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IPerformanceScheduleService, PerformanceScheduleService>();
            services.AddScoped<ICacheProvider, CacheProvider>();
            //services.AddScoped<ISendDataToGoogleFormService, SendDataToGoogleFormService>();
            services.AddScoped<IGetDataFromGoogleFormService, GetDataFromGoogleFormService>();
            services.AddMemoryCache();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IResetCodeService, ResetCodeService>();
            services.AddScoped<IEmailService, EmailService>();
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

            app.UseAuthentication();

            app.UseHttpsRedirection();


            app.UseStaticFiles();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                c.RoutePrefix = string.Empty;
            });

            loggerFactory.AddFile("Logs/myapp-{Date}.txt");
            app.UseToken();
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
