using ProjectManagementSystem.Core.Enums;

namespace ProjectManagementSystem.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string ProjectNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }
        public ProjectStatus Status { get; set; }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;

        public int ProjectManagerId { get; set; }
        public string ProjectManagerName { get; set; } = string.Empty;

        public int ServiceId { get; set; }
        public string ServiceName { get; set; } = string.Empty;
        public decimal ServiceRate { get; set; }
    }
}