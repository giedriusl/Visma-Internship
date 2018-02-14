using AnagramSolver.EFCF.Core.Model;
using System.Data.Entity;

namespace AnagramSolver.EFCF.Core.Context
{
    public class AnagramsContext : DbContext
    {
        public AnagramsContext() : base("Data Source=LT-LIT-SC-0015;Initial Catalog=AnagramsContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {

        }

        public DbSet<UserLogs> UserLogs { get; set; }
        public DbSet<CachedWords> CachedWords { get; set; }
        public DbSet<CachedAnagrams> CachedAnagrams { get; set; }
        public DbSet<Words> Words { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
