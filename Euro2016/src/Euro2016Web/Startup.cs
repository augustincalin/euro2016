using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Microsoft.EntityFrameworkCore;
using Euro2016Web.Model;
using Euro2016Web.ViewModel;
using Euro2016Web.Core.Services;
using Euro2016Web.Core.Interfaces.Services;
using Euro2016Web.Core.Model;
using Euro2016Web.Core.Interfaces;
using Euro2016Web.Infrastructure.Data;

namespace Euro2016Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            var connection = @"Server=ALIEN\SQLEXPRESS;Database=EURO2016DB;Trusted_Connection=True;";
            services.AddDbContext<EURO2016DBContext>(options => options.UseSqlServer(connection));

            services.AddScoped<DbContext, EURO2016DBContext>();
            services.AddScoped<IMatchRepository, EfMatchRepository>();
            services.AddScoped<IRepository<Bet>, EfRepository<Bet>>();
            services.AddScoped<IRepository<Group>, EfRepository<Group>>();
            services.AddScoped<IRepository<User>, EfRepository<User>>();
            services.AddScoped<IRepository<Match>, EfRepository<Match>>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IMatchService, MatchService>();
            services.AddScoped<IBetService, BetService>();

            services.AddScoped<IHomeService, HomeService>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
