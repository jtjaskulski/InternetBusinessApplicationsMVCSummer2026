using Company.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Company.PortalWWW
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = ApplyBuilderPatternToBuildApp(args);
            InitializeAutomaticMigrations(app);
            InitializeDevelopmentEnviroment(app);
            InitializeRoutingAndHttp(app);
            app.Run();
        }

        private static void InitializeRoutingAndHttp(WebApplication app)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();
            app.UseSession();
        }

        private static void InitializeDevelopmentEnviroment(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
        }

        private static WebApplication ApplyBuilderPatternToBuildApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<CompanyContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CompanyContext") ?? throw new InvalidOperationException("Connection string 'CompanyContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            RegisterSession(builder);
            var app = builder.Build();
            return app;
        }

        private static void RegisterSession(WebApplicationBuilder builder)
        {
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(40);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });
        }

        private static void InitializeAutomaticMigrations(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                try
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<CompanyContext>();
                    dbContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Error during database migration");
                }
            }
        }
    }
}