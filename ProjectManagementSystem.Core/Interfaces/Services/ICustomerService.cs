using ProjectManagementSystem.Core.Entities;

namespace ProjectManagementSystem.Core.Interfaces.Services
{
    public interface ICustomerService : IBaseService<Customer>
    {
        Task<IEnumerable<Customer>> GetCustomersWithProjectsAsync();
    }
}