using ProjectManagementSystem.Core.Entities;

namespace ProjectManagementSystem.Core.Interfaces.Services
{
    public interface IServiceEntityService : IBaseService<Service>
    {
        Task<IEnumerable<Service>> GetServicesWithProjectsAsync();
    }
}