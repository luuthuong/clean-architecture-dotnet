using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDbContext.SeedDataMigration
{
    public class _1901_SeedingDataProduct : DataSeedMigrationBase
    {
        private readonly int _nums = 10_000;
        public override string Key => "Init_product";

        public override async Task ExecuteAsync(AppDBContext dbContext, IServiceProvider serviceProvider)
        {
            IList<Product> products = new List<Product>();
            for (int i = 0; i < _nums; i++)
            {
                var product = new Product
                {
                    CreatedDate = DateTime.Now,
                    Description = $"Description {i}",
                    Name = $"Product Name {i}",
                    Price = (float)(i * 75.5),
                    Quantity = i
                };
                products.Add(product);
            }
            await dbContext.Product.AddRangeAsync(products);
        }
        
    }
}
