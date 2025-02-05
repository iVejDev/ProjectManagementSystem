using ProjectManagementSystem.Core.Entities;

namespace ProjectManagementSystem.Core.Interfaces.Services
{
    public interface IProjectService : IBaseService<Project>
    {
        Task<IEnumerable<Project>> GetProjectsWithDetailsAsync();
        Task<Project?> GetProjectWithDetailsAsync(int id);
        Task<Project> CreateProjectWithNumberAsync(Project project);
        Task<Project> CreateProjectWithTransactionAsync(
            string name,
            DateTime startDate,
            DateTime endDate,
            decimal totalPrice,
            int customerId,
            int projectManagerId,
            int serviceId);
    }
}