namespace ProjectManagementSystem.ViewModels
{
    public class EditProjectViewModel : CreateProjectViewModel
    {
        public int Id { get; set; }
        public string ProjectNumber { get; set; } = string.Empty;
    }
}