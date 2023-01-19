using AppDbContext;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace clean_architecture.Configuration
{
    public static class ExtensionCollection
    {
        public static IServiceCollection ConfigureIISIntegration(this IServiceCollection service, IConfiguration configuration)
        {
            return service.Configure<IISOptions>(iis =>
            {
                iis.AuthenticationDisplayName = configuration["IIS:DisplayName"];
                iis.AutomaticAuthentication = true;
            });
        }

        public static IServiceCollection ConfigDBContext(this IServiceCollection service, IConfiguration configuration)
        {
            return service.AddDbContext<AppDBContext>(context =>
            {
                context.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }

        public static IServiceCollection HandleRequiredService(this IServiceCollection service)
        {
            var serviceProvider = service.BuildServiceProvider();
            using (var scope = serviceProvider.CreateScope())
            {
                var provider = scope.ServiceProvider;
                var dbContext = provider.GetRequiredService<AppDBContext>();
                string connectionString = dbContext.Database.GetConnectionString() ?? string.Empty;
                Log.Information($"============= Connection string: {connectionString}");
                dbContext.Database.Migrate();
                DbInitializer.InitSeedingDataMigration(dbContext, serviceProvider).Wait();
                return service;
            }
        }

        public static IServiceCollection AddApplication(this IServiceCollection service)
        {

            return service;
        }
    }
}
