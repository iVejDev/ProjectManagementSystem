using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManagementSystem.Core.Entities;
using ProjectManagementSystem.Core.Interfaces.Services;
using ProjectManagementSystem.ViewModels;

namespace ProjectManagementSystem.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly ICustomerService _customerService;
        private readonly IProjectManagerService _projectManagerService;
        private readonly IServiceEntityService _serviceService;

        public ProjectsController(
            IProjectService projectService,
            ICustomerService customerService,
            IProjectManagerService projectManagerService,
            IServiceEntityService serviceService)
        {
            _projectService = projectService;
            _customerService = customerService;
            _projectManagerService = projectManagerService;
            _serviceService = serviceService;
        }

        public async Task<IActionResult> Index()
        {
            var projects = await _projectService.GetProjectsWithDetailsAsync();
            var viewModels = projects.Select(p => new ProjectViewModel
            {
                Id = p.Id,
                ProjectNumber = p.ProjectNumber,
                Name = p.Name,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                TotalPrice = p.TotalPrice,
                Status = p.Status,
                CustomerId = p.CustomerId,
                CustomerName = p.Customer.Name,
                ProjectManagerId = p.ProjectManagerId,
                ProjectManagerName = p.ProjectManager.Name,
                ServiceId = p.ServiceId,
                ServiceName = p.Service.Name,
                ServiceRate = p.Service.HourlyRate
            });

            return View(viewModels);
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = new CreateProjectViewModel
            {
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddMonths(1),
                Customers = new SelectList(await _customerService.GetAllAsync(), "Id", "Name"),
                ProjectManagers = new SelectList(await _projectManagerService.GetAllAsync(), "Id", "Name"),
                Services = new SelectList(await _serviceService.GetAllAsync(), "Id", "Name")
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProjectViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _projectService.CreateProjectWithTransactionAsync(
                        viewModel.Name,
                        viewModel.StartDate,
                        viewModel.EndDate,
                        viewModel.TotalPrice,
                        viewModel.CustomerId,
                        viewModel.ProjectManagerId,
                        viewModel.ServiceId);

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    // Fick hjälp av AI med att lägga till felmeddelande på svenska
                    ModelState.AddModelError("", "Ett fel uppstod när projektet skulle skapas. Försök igen.");
                }
            }

            viewModel.Customers = new SelectList(await _customerService.GetAllAsync(), "Id", "Name");
            viewModel.ProjectManagers = new SelectList(await _projectManagerService.GetAllAsync(), "Id", "Name");
            viewModel.Services = new SelectList(await _serviceService.GetAllAsync(), "Id", "Name");

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var project = await _projectService.GetProjectWithDetailsAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            var viewModel = new EditProjectViewModel
            {
                Id = project.Id,
                ProjectNumber = project.ProjectNumber,
                Name = project.Name,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                TotalPrice = project.TotalPrice,
                Status = project.Status,
                CustomerId = project.CustomerId,
                ProjectManagerId = project.ProjectManagerId,
                ServiceId = project.ServiceId,
                Customers = new SelectList(await _customerService.GetAllAsync(), "Id", "Name"),
                ProjectManagers = new SelectList(await _projectManagerService.GetAllAsync(), "Id", "Name"),
                Services = new SelectList(await _serviceService.GetAllAsync(), "Id", "Name")
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditProjectViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var project = await _projectService.GetByIdAsync(id);
                    if (project == null)
                    {
                        return NotFound();
                    }

                    project.Name = viewModel.Name;
                    project.StartDate = viewModel.StartDate;
                    project.EndDate = viewModel.EndDate;
                    project.TotalPrice = viewModel.TotalPrice;
                    project.Status = viewModel.Status;
                    project.CustomerId = viewModel.CustomerId;
                    project.ProjectManagerId = viewModel.ProjectManagerId;
                    project.ServiceId = viewModel.ServiceId;

                    await _projectService.UpdateAsync(project);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again.");
                }
            }

            viewModel.Customers = new SelectList(await _customerService.GetAllAsync(), "Id", "Name");
            viewModel.ProjectManagers = new SelectList(await _projectManagerService.GetAllAsync(), "Id", "Name");
            viewModel.Services = new SelectList(await _serviceService.GetAllAsync(), "Id", "Name");

            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var project = await _projectService.GetProjectWithDetailsAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            var viewModel = new ProjectViewModel
            {
                Id = project.Id,
                ProjectNumber = project.ProjectNumber,
                Name = project.Name,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                TotalPrice = project.TotalPrice,
                Status = project.Status,
                CustomerName = project.Customer.Name,
                ProjectManagerName = project.ProjectManager.Name,
                ServiceName = project.Service.Name
            };

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _projectService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}