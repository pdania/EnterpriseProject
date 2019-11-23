using System.Data.Entity;
using DBModels;
using EntityFrameworkWrapper.Migrations;

namespace EntityFrameworkWrapper
{
    public class RandomizerDBContext:DbContext
    {
        public RandomizerDBContext() : base("Randomizer")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RandomizerDBContext, Configuration>());
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RequestConfiguration());
        }
    }
}