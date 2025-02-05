using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystem.Core.Entities;
using ProjectManagementSystem.Core.Interfaces.Services;
using ProjectManagementSystem.ViewModels;

namespace ProjectManagementSystem.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IServiceEntityService _serviceService;

        public ServicesController(IServiceEntityService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task<IActionResult> Index()
        {
            var services = await _serviceService.GetServicesWithProjectsAsync();
            var viewModels = services.Select(s => new ServiceViewModel
            {
                Id = s.Id,
                Name = s.Name,
                HourlyRate = s.HourlyRate,
                ProjectCount = s.Projects.Count
            });

            return View(viewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var service = new Service
                {
                    Name = viewModel.Name,
                    HourlyRate = viewModel.HourlyRate
                };

                await _serviceService.CreateAsync(service);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var service = await _serviceService.GetByIdAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            var viewModel = new ServiceViewModel
            {
                Id = service.Id,
                Name = service.Name,
                HourlyRate = service.HourlyRate
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ServiceViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var service = await _serviceService.GetByIdAsync(id);
                    if (service == null)
                    {
                        return NotFound();
                    }

                    service.Name = viewModel.Name;
                    service.HourlyRate = viewModel.HourlyRate;

                    await _serviceService.UpdateAsync(service);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again.");
                }
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var service = await _serviceService.GetByIdAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            var viewModel = new ServiceViewModel
            {
                Id = service.Id,
                Name = service.Name,
                HourlyRate = service.HourlyRate
            };

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _serviceService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}