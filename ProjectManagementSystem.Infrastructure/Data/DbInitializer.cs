using ProjectManagementSystem.Core.Entities;

namespace ProjectManagementSystem.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context)
        {
            await context.Database.EnsureCreatedAsync();

            if (context.Customers.Any()) return;

            var customers = new List<Customer>
            {
                new Customer { Name = "Acme Corp", Email = "contact@acme.com", PhoneNumber = "076-121212" },
                new Customer { Name = "TechStart AB", Email = "info@techstart.com", PhoneNumber = "076-131313" }
            };
            await context.Customers.AddRangeAsync(customers);

            var projectManagers = new List<ProjectManager>
            {
                new ProjectManager { Name = "Akali Arcade", Email = "john@company.com" },
                new ProjectManager { Name = "Urgot Vel", Email = "jane@company.com" }
            };
            await context.ProjectManagers.AddRangeAsync(projectManagers);

            var services = new List<Service>
            {
                new Service { Name = "Web Development", HourlyRate = 1000m },
                new Service { Name = "Mobile Development", HourlyRate = 1200m }
            };
            await context.Services.AddRangeAsync(services);

            await context.SaveChangesAsync();
        }
    }
}