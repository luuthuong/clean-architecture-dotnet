using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDbContext.SeedDataMigration
{
    public class _2001_InitProductCategory : DataSeedMigrationBase
    {
        public override string Key => "Init_product_category";

        public override async Task ExecuteAsync(AppDBContext context, IServiceProvider serviceProvider)
        {
            await AddProductCategory(context);
        }

        private async Task AddProductCategory(AppDBContext dbContext)
        {
            var category = await dbContext.Category.FirstOrDefaultAsync();
            if (category == null) return;
            var products = await dbContext.Product.Take(500).ToListAsync();
            products.ForEach(product => product.CategoryId = category.Id);
            dbContext.Product.UpdateRange(products);
        }

    }
}
