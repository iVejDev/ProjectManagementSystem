using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Core.Entities;

namespace ProjectManagementSystem.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectManager> ProjectManagers { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(p => p.ProjectNumber).IsRequired();
                entity.HasIndex(p => p.ProjectNumber).IsUnique();
                entity.Property(p => p.TotalPrice).HasPrecision(18, 2);

                entity.HasOne(p => p.Customer)
                    .WithMany(c => c.Projects)
                    .HasForeignKey(p => p.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.ProjectManager)
                    .WithMany(pm => pm.Projects)
                    .HasForeignKey(p => p.ProjectManagerId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Service)
                    .WithMany(s => s.Projects)
                    .HasForeignKey(p => p.ServiceId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Service>()
                .Property(s => s.HourlyRate)
                .HasPrecision(18, 2);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                else if (entry.State == EntityState.Modified)
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}