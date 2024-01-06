using AccSol.EF.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AccSol.EF.Data
{
    public partial class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public virtual DbSet<Coa> Coas { get; set; } = null!;
        public virtual DbSet<ProjectCode> ProjectCodes { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<PettyCash> PettyCashes { get; set; } = null!;
        public virtual DbSet<Journal> JournalEntries { get; set; } = null!;
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure index for unique constraint on PCFNo with appropriate column type
            modelBuilder.Entity<PettyCash>()
                .Property(p => p.PCFNo)
                .HasMaxLength(255) // Adjust the maximum length accordingly
                .IsRequired(); // Ensure the column is not nullable

            modelBuilder.Entity<PettyCash>()
                .HasIndex(p => p.PCFNo)
                .IsUnique()
                .HasDatabaseName("IX_PettyCashes_PCFNo"); // Specify the index name

            // Other configurations...

            base.OnModelCreating(modelBuilder);
        }
    }
}
