using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystem.Core.Entities;
using ProjectManagementSystem.Core.Interfaces.Services;
using ProjectManagementSystem.ViewModels;

namespace ProjectManagementSystem.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _customerService.GetCustomersWithProjectsAsync();
            var viewModels = customers.Select(c => new CustomerViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                ProjectCount = c.Projects.Count
            });

            return View(viewModels);
        }

        public IActionResult Create()
        {
            return View();
        }


        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var customer = new Customer
                {
                    Name = viewModel.Name,
                    Email = viewModel.Email,
                    PhoneNumber = viewModel.PhoneNumber
                };

                await _customerService.CreateAsync(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            var viewModel = new CustomerViewModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CustomerViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var customer = await _customerService.GetByIdAsync(id);
                    if (customer == null)
                    {
                        return NotFound();
                    }

                    customer.Name = viewModel.Name;
                    customer.Email = viewModel.Email;
                    customer.PhoneNumber = viewModel.PhoneNumber;

                    await _customerService.UpdateAsync(customer);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    // Fick hjälp av AI med att lägga till en ModelState-felhantering
                    // för att visa ett felmeddelande om uppdateringen misslyckas.
                    ModelState.AddModelError("", "Unable to save changes. Try again.");
                }
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            var viewModel = new CustomerViewModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber
            };

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _customerService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}