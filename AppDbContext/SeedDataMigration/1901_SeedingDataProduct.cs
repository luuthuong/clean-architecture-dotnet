using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDbContext.SeedDataMigration
{
    public class _1901_SeedingDataProduct : DataSeedMigrationBase
    {
        public override string Key => "Init_product";

        public override async  Task ExecuteAsync(AppDBContext context, IServiceProvider serviceProvider)
        {
        }
    }
}
