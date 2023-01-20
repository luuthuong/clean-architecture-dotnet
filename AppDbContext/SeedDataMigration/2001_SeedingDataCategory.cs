using Entities;

namespace AppDbContext.SeedDataMigration
{
    public class _2001_SeedingDataCategory : DataSeedMigrationBase
    {
        public override string Key => "Init_Data_Category";

        private readonly int nums = 20;
        public override async Task ExecuteAsync(AppDBContext context, IServiceProvider serviceProvider)
        {
            var categories = new List<Category>();
            for(int i =0; i < nums; i++)
            {
                var category = new Category
                {
                    CreatedDate = DateTime.Now,
                    Name = $"Category {i}",
                };
                categories.Add(category);
            }
            await context.Category.AddRangeAsync(categories);
        }
    }
}
