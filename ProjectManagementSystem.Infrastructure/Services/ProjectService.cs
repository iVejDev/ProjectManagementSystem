using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Core.Entities;
using ProjectManagementSystem.Core.Interfaces.Factories;
using ProjectManagementSystem.Core.Interfaces.Repositories;
using ProjectManagementSystem.Core.Interfaces.Services;
using ProjectManagementSystem.Infrastructure.Data;

namespace ProjectManagementSystem.Infrastructure.Services
{
    public class ProjectService : BaseService<Project>, IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectFactory _projectFactory;
        private readonly ApplicationDbContext _context;

        public ProjectService(
            IProjectRepository projectRepository,
            IProjectFactory projectFactory,
            ApplicationDbContext context)
            : base(projectRepository)
        {
            _projectRepository = projectRepository;
            _projectFactory = projectFactory;
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetProjectsWithDetailsAsync()
        {
            return await _projectRepository.GetProjectsWithDetailsAsync();
        }

        public async Task<Project?> GetProjectWithDetailsAsync(int id)
        {
            return await _projectRepository.GetProjectWithDetailsAsync(id);
        }

        public async Task<Project> CreateProjectWithNumberAsync(Project project)
        {
            project.ProjectNumber = await _projectRepository.GenerateProjectNumberAsync();
            return await _projectRepository.AddAsync(project);
        }

        public async Task<Project> CreateProjectWithTransactionAsync(string name, DateTime startDate,
            DateTime endDate, decimal totalPrice, int customerId, int projectManagerId, int serviceId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Skapa projektet med factory
                var project = _projectFactory.CreateProject(name, startDate, endDate,
                    totalPrice, customerId, projectManagerId, serviceId);

                // Generera projektnummer
                project.ProjectNumber = await _projectRepository.GenerateProjectNumberAsync();

                // Spara projektet
                await _projectRepository.AddAsync(project);

                // Commit transaktion
                await transaction.CommitAsync();
                return project;
            }
            catch (Exception)
            {
                // Rollback vid fel
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}