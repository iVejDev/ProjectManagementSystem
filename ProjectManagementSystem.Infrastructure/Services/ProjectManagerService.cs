using ProjectManagementSystem.Core.Entities;
using ProjectManagementSystem.Core.Interfaces.Repositories;
using ProjectManagementSystem.Core.Interfaces.Services;

namespace ProjectManagementSystem.Infrastructure.Services
{
    public class ProjectManagerService : BaseService<ProjectManager>, IProjectManagerService
    {
        private readonly IProjectManagerRepository _projectManagerRepository;

        public ProjectManagerService(IProjectManagerRepository projectManagerRepository)
            : base(projectManagerRepository)
        {
            _projectManagerRepository = projectManagerRepository;
        }

        public async Task<IEnumerable<ProjectManager>> GetProjectManagersWithProjectsAsync()
        {
            return await _projectManagerRepository.GetProjectManagersWithProjectsAsync();
        }
    }
}