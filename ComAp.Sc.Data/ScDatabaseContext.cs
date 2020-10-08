using Microsoft.EntityFrameworkCore;
using ComAp.Sc.Core.Models;
using ComAp.Sc.Core;
using Microsoft.Extensions.Options;

namespace ComAp.Sc.Data
{
    public class ScDatabaseContext : DbContext, IScDatabaseContext
    {
        private string sqFilePath;

        public ScDatabaseContext(IOptions<DatabaseConfiguration> databaseConfiguration) : base()
        {
            this.sqFilePath = databaseConfiguration.Value.SqliteFileLocation;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={sqFilePath}");
        }
        public DbSet<Comment> Comment { get; set; }
    }
}
