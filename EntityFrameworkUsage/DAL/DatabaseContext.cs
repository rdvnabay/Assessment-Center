using AssessmentLibrary;
using System.Data.Entity;

namespace EntityFrameworkUsage.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("ProjectContext") { }

        public DbSet<Account> Accounts { get; set; }
    }
}