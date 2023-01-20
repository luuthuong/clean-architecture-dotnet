using AppDbContext.SeedDataMigration;
using Common;
using Microsoft.EntityFrameworkCore;

namespace AppDbContext
{
    public class DbInitializer
    {
        public static async Task InitSeedingDataMigration(AppDBContext dbContext, IServiceProvider serviceProvider)
        {
            var dataSeedMigration = AppDomain.CurrentDomain.GetAssemblies()
                                    .SelectMany(assembly => assembly.GetTypes())
                                    .Where(type =>type.IsSubclassOf(typeof(DataSeedMigrationBase)))
                                    .Select(x => (DataSeedMigrationBase)Activator.CreateInstance(x))
                                    .OrderBy(x => x.Key)
                                    .ToList();
            var keyHistory = await dbContext.SeedingHistory.Select(x => x.Key).ToListAsync();
            var notExecuteDataSeedingMigration = dataSeedMigration.Where(x => !keyHistory.Contains(x.Key)).ToList();
            foreach (var item in notExecuteDataSeedingMigration)
            {
                await item.UpAsync(dbContext, serviceProvider);
            }
        }
    }
}
