using Microsoft.EntityFrameworkCore;
using Company.Intranet.Data;
namespace Company.Intranet
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
            builder.Services.AddDbContext<CompanyIntranetContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CompanyIntranetContext") ?? throw new InvalidOperationException("Connection string 'CompanyIntranetContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();
            return app;
        }

        private static void InitializeAutomaticMigrations(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                try
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<CompanyIntranetContext>();
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