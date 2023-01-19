using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDbContext.SeedDataMigration
{
    public class _1901_SeedingDataUser_Role : DataSeedMigrationBase
    {
        public override string Key => "Seeding_User_Role";

        public override async Task ExecuteAsync(AppDBContext context, IServiceProvider serviceProvider)
        {
        }
    }
}
