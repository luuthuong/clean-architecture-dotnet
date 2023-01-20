using Entities;
using Microsoft.EntityFrameworkCore;

namespace AppDbContext.SeedDataMigration
{
    public abstract class DataSeedMigrationBase
    {
        public abstract string Key { get; }
        public abstract Task ExecuteAsync(AppDBContext context, IServiceProvider serviceProvider);
        public async Task UpAsync(AppDBContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.SeedingHistory.AnyAsync(x => x.Key == Key))
                return;
            var seedData = new SeedingHistory
            {
                Key = Key,
                UpdatedDate = DateTime.UtcNow,
            };
            await ExecuteAsync(dbContext, serviceProvider);
            await dbContext.SeedingHistory.AddAsync(seedData);
            await dbContext.SaveChangesAsync();
        }
    }
}
