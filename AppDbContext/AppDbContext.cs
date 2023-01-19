using Entities;
using Microsoft.EntityFrameworkCore;

namespace AppDbContext
{
    public class AppDBContext : IdentityDbContextBase<User, Role, UserRole, Guid>
    {
        public DbSet<SeedingHistory> SeedingHistory { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }

        public AppDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach(var entityType in builder.Model.GetEntityTypes())
            {
                string tableName = entityType.GetTableName();
                if(!string.IsNullOrEmpty(tableName) && tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            } 
            builder.HasDefaultSchema("App");
        }
    }
}
