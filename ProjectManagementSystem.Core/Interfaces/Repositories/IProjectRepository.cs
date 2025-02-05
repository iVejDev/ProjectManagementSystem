using ProjectManagementSystem.Core.Entities;

namespace ProjectManagementSystem.Core.Interfaces.Repositories
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        Task<IEnumerable<Project>> GetProjectsWithDetailsAsync();
        Task<Project?> GetProjectWithDetailsAsync(int id);
        Task<string> GenerateProjectNumberAsync();
    }
}