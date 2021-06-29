using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkerModernManagementSystem.UI.InitialSeedData;
using WorkerModernManagementSystem.UI.Models;

namespace WorkerModernManagementSystem.UI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Occupation> Occupation { get; set; }

        public DbSet<MainMenuItem> MainMenus { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.PleaseSeedDb();
            base.OnModelCreating(builder);
        }
    }
}
