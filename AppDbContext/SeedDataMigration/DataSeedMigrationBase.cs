namespace AppDbContext.SeedDataMigration
{
    public abstract class DataSeedMigrationBase
    {
        public abstract string Key { get; }
        public abstract Task ExecuteAsync(AppDBContext context, IServiceProvider serviceProvider);
    }
}
