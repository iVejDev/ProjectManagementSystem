using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManagementSystem.Core.Enums;

namespace ProjectManagementSystem.ViewModels
{
    public class CreateProjectViewModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Total Price")]
        [DataType(DataType.Currency)]
        public decimal TotalPrice { get; set; }

        [Required]
        public ProjectStatus Status { get; set; }

        [Required]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        public SelectList? Customers { get; set; }

        [Required]
        [Display(Name = "Project Manager")]
        public int ProjectManagerId { get; set; }
        public SelectList? ProjectManagers { get; set; }

        [Required]
        [Display(Name = "Service")]
        public int ServiceId { get; set; }
        public SelectList? Services { get; set; }
    }
}