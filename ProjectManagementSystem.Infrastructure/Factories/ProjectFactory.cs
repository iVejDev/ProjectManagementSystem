using ProjectManagementSystem.Core.Entities;
using ProjectManagementSystem.Core.Enums;
using ProjectManagementSystem.Core.Interfaces.Factories;

namespace ProjectManagementSystem.Infrastructure.Factories
{
    public class ProjectFactory : IProjectFactory
    {
        public Project CreateProject(
            string name,
            DateTime startDate,
            DateTime endDate,
            decimal totalPrice,
            int customerId,
            int projectManagerId,
            int serviceId)
        {
            return new Project
            {
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                TotalPrice = totalPrice,
                Status = ProjectStatus.NotStarted,
                CustomerId = customerId,
                ProjectManagerId = projectManagerId,
                ServiceId = serviceId
            };
        }
    }
}