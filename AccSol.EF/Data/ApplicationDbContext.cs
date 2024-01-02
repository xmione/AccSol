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
        public virtual DbSet<JournalEntry> JournalEntries { get; set; } = null!;

    }
}
