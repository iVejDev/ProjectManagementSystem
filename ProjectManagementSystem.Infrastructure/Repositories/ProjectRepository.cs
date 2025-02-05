using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Core.Entities;
using ProjectManagementSystem.Core.Interfaces.Repositories;
using ProjectManagementSystem.Infrastructure.Data;

namespace ProjectManagementSystem.Infrastructure.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Project>> GetProjectsWithDetailsAsync()
        {
            return await _context.Projects
                .Include(p => p.Customer)
                .Include(p => p.ProjectManager)
                .Include(p => p.Service)
                .ToListAsync();
        }

        public async Task<Project?> GetProjectWithDetailsAsync(int id)
        {
            return await _context.Projects
                .Include(p => p.Customer)
                .Include(p => p.ProjectManager)
                .Include(p => p.Service)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<string> GenerateProjectNumberAsync()
        {
            var lastProject = await _context.Projects
                .OrderByDescending(p => p.ProjectNumber)
                .FirstOrDefaultAsync();

            if (lastProject == null)
            {
                return "P-101";
            }

            var currentNumber = int.Parse(lastProject.ProjectNumber.Split('-')[1]);
            return $"P-{currentNumber + 1}";
        }
    }
}