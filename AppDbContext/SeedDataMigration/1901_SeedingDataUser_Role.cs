using Common;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
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
            await AddUser(serviceProvider, new User
            {
                UserName = "admin",
                Email = "Admin@gmail.com"
            });

            await AddUser(serviceProvider, new User
            {
                UserName = "user",
                Email = "User@gmail.com"
            });
            await AddRole(context);
        }

        private async Task AddUser(IServiceProvider serviceProvider, User user)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var existedUser = userManager.FindByNameAsync(user.UserName);
            if (existedUser != null) return;
            await userManager.CreateAsync(user, "123");
        }

        private async Task AddRole(AppDBContext dbContext)
        {
            var roles = new List<Role>()
            {
                new Role{ Name = RoleConstant.Admin },
                new Role{ Name = RoleConstant.User },
            };
            await dbContext.Roles.AddRangeAsync(roles);
        }
    }
}
