using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystem.Core.Entities;
using ProjectManagementSystem.Core.Interfaces.Services;
using ProjectManagementSystem.ViewModels;

namespace ProjectManagementSystem.Controllers
{
    public class ProjectManagersController : Controller
    {
        private readonly IProjectManagerService _projectManagerService;

        public ProjectManagersController(IProjectManagerService projectManagerService)
        {
            _projectManagerService = projectManagerService;
        }

        public async Task<IActionResult> Index()
        {
            var managers = await _projectManagerService.GetProjectManagersWithProjectsAsync();
            var viewModels = managers.Select(m => new ProjectManagerViewModel
            {
                Id = m.Id,
                Name = m.Name,
                Email = m.Email,
                ProjectCount = m.Projects.Count
            });

            return View(viewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectManagerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var manager = new ProjectManager
                {
                    Name = viewModel.Name,
                    Email = viewModel.Email
                };

                await _projectManagerService.CreateAsync(manager);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var manager = await _projectManagerService.GetByIdAsync(id);
            if (manager == null)
            {
                return NotFound();
            }

            var viewModel = new ProjectManagerViewModel
            {
                Id = manager.Id,
                Name = manager.Name,
                Email = manager.Email
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProjectManagerViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var manager = await _projectManagerService.GetByIdAsync(id);
                    if (manager == null)
                    {
                        return NotFound();
                    }

                    manager.Name = viewModel.Name;
                    manager.Email = viewModel.Email;

                    await _projectManagerService.UpdateAsync(manager);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    // AI-assistans användes för att lägga till felhantering här
                    ModelState.AddModelError("", "Unable to save changes. Try again.");
                }
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var manager = await _projectManagerService.GetByIdAsync(id);
            if (manager == null)
            {
                return NotFound();
            }

            var viewModel = new ProjectManagerViewModel
            {
                Id = manager.Id,
                Name = manager.Name,
                Email = manager.Email
            };

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _projectManagerService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}