using ProjectManagementSystem.Core.Entities;

namespace ProjectManagementSystem.Core.Interfaces.Repositories
{
    public interface IServiceRepository : IBaseRepository<Service>
    {
        Task<IEnumerable<Service>> GetServicesWithProjectsAsync();
    }
}