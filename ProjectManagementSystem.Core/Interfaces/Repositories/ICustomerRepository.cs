using ProjectManagementSystem.Core.Entities;

namespace ProjectManagementSystem.Core.Interfaces.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetCustomersWithProjectsAsync();
    }
}