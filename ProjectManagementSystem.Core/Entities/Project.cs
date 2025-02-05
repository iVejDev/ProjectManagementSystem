using ProjectManagementSystem.Core.Enums;

namespace ProjectManagementSystem.Core.Entities
{
    public class Project : BaseEntity
    {
        public string ProjectNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }
        public ProjectStatus Status { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public int ProjectManagerId { get; set; }
        public ProjectManager ProjectManager { get; set; } = null!;

        public int ServiceId { get; set; }
        public Service Service { get; set; } = null!;
    }
}