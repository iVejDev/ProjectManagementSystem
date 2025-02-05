using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Core.Entities;
using ProjectManagementSystem.Core.Interfaces.Repositories;
using ProjectManagementSystem.Infrastructure.Data;

namespace ProjectManagementSystem.Infrastructure.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Customer>> GetCustomersWithProjectsAsync()
        {
            return await _context.Customers
                .Include(c => c.Projects)
                .ToListAsync();
        }
    }
}