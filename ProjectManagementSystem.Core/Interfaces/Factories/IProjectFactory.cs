using ProjectManagementSystem.Core.Entities;

namespace ProjectManagementSystem.Core.Interfaces.Factories
{
    public interface IProjectFactory
    {
        Project CreateProject(
            string name,
            DateTime startDate,
            DateTime endDate,
            decimal totalPrice,
            int customerId,
            int projectManagerId,
            int serviceId);
    }
}