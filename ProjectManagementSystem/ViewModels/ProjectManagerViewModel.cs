using System.ComponentModel.DataAnnotations;

namespace ProjectManagementSystem.ViewModels
{
    public class ProjectManagerViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Manager Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public int ProjectCount { get; set; }
    }
}