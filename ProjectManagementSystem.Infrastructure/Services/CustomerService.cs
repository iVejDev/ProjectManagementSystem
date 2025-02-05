using ProjectManagementSystem.Core.Entities;
using ProjectManagementSystem.Core.Interfaces.Repositories;
using ProjectManagementSystem.Core.Interfaces.Services;

namespace ProjectManagementSystem.Infrastructure.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
            : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> GetCustomersWithProjectsAsync()
        {
            return await _customerRepository.GetCustomersWithProjectsAsync();
        }
    }
}