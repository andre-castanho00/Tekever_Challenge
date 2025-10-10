using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tekever_Challenge.Models;

namespace Tekever_Challenge.Data
{
    public class DatabaseContext: IdentityDbContext<User>
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
