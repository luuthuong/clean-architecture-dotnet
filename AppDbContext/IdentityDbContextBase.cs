using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppDbContext
{
    public class IdentityDbContextBase<TUser, TRole, TUserRole, TKey> : IdentityDbContext<TUser, TRole, TKey>
        where TKey : IEquatable<TKey>
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TUserRole : IdentityUserRole<TKey>
    {
        public IdentityDbContextBase(DbContextOptions options) : base(options)
        {
        }
    }
}