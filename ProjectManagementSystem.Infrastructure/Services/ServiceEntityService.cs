using ProjectManagementSystem.Core.Entities;
using ProjectManagementSystem.Core.Interfaces.Repositories;
using ProjectManagementSystem.Core.Interfaces.Services;

namespace ProjectManagementSystem.Infrastructure.Services
{
    public class ServiceEntityService : BaseService<Service>, IServiceEntityService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceEntityService(IServiceRepository serviceRepository)
            : base(serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<IEnumerable<Service>> GetServicesWithProjectsAsync()
        {
            return await _serviceRepository.GetServicesWithProjectsAsync();
        }
    }
}