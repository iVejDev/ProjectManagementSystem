using System.ComponentModel.DataAnnotations;

namespace ProjectManagementSystem.ViewModels
{
    public class ServiceViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Service Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Hourly Rate")]
        [DataType(DataType.Currency)]
        public decimal HourlyRate { get; set; }

        public int ProjectCount { get; set; }
    }
}