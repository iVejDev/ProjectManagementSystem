using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Core.Entities;
using ProjectManagementSystem.Core.Interfaces.Repositories;
using ProjectManagementSystem.Infrastructure.Data;

namespace ProjectManagementSystem.Infrastructure.Repositories
{
    public class ProjectManagerRepository : BaseRepository<ProjectManager>, IProjectManagerRepository
    {
        public ProjectManagerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProjectManager>> GetProjectManagersWithProjectsAsync()
        {
            return await _context.ProjectManagers
                .Include(pm => pm.Projects)
                .ToListAsync();
        }
    }
}