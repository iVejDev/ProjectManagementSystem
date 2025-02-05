using ProjectManagementSystem.Core.Entities;

namespace ProjectManagementSystem.Core.Interfaces.Repositories
{
    public interface IProjectManagerRepository : IBaseRepository<ProjectManager>
    {
        Task<IEnumerable<ProjectManager>> GetProjectManagersWithProjectsAsync();
    }
}