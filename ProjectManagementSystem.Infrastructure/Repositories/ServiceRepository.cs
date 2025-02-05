using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Core.Entities;
using ProjectManagementSystem.Core.Interfaces.Repositories;
using ProjectManagementSystem.Infrastructure.Data;

namespace ProjectManagementSystem.Infrastructure.Repositories
{
    public class ServiceRepository : BaseRepository<Service>, IServiceRepository
    {
        public ServiceRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Service>> GetServicesWithProjectsAsync()
        {
            return await _context.Services
                .Include(s => s.Projects)
                .ToListAsync();
        }
    }
}