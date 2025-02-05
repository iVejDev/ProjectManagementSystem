namespace ProjectManagementSystem.Core.Entities
{
    public class Service : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public decimal HourlyRate { get; set; }
        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}