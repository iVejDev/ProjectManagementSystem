using ProjectManagementSystem.Core.Entities;

namespace ProjectManagementSystem.Core.Interfaces.Services
{
    public interface IProjectManagerService : IBaseService<ProjectManager>
    {
        Task<IEnumerable<ProjectManager>> GetProjectManagersWithProjectsAsync();
    }
}