using System.ComponentModel.DataAnnotations;

namespace ProjectManagementSystem.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        public int ProjectCount { get; set; }
    }
}