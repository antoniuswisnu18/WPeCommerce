using Microsoft.EntityFrameworkCore;
using WPeCommerceAPI.BusinessLogic.Repositories;
using WPeCommerceAPI.DataLayer;
using log4net;
using log4net.Config;
using WPeCommerceAPI.BusinessLogic.Services;
using Microsoft.AspNetCore.Identity;

namespace WPeCommerceAPI
{
    public class Startup
    {
        public IConfiguration _configuration;
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Startup));

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void serviceConfiguration(IServiceCollection services)
        {
            // Add services to the container.
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IReviewRepo, ReviewRepo>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            
            
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(_configuration["ConnectionStrings:DefaultConnection"]));
            services.AddDbContext<IdDbContext>(
                options => options.UseSqlServer(_configuration["ConnectionStrings:DefaultConnection"]));
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            options.SignIn.RequireConfirmedEmail = false)
                .AddEntityFrameworkStores<IdDbContext>();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            ConfigureLog4Net();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static void ConfigureLog4Net()
        {
            var logRepo = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepo, new System.IO.FileInfo("log4net.config"));
        }

    }
}
