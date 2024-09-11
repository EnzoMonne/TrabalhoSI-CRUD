using Imobiliaria.Models;
using Imobiliaria.Models.Enums;
using Imobiliaria.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Imobiliaria.Controllers
{
    [Route("[controller]")]
    public class PropertiesController : Controller
    {
        private readonly FakeDbContext _context;

        public PropertiesController(FakeDbContext context) 
        {
            _context = context;
        }

        // Create
        [HttpGet]
        [Route("[action]")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Create(Property model) {
            if (ModelState.IsValid) {
                // Adds the new client to the context
                model.Client = null;
                model.ClientId = 0;
                _context.AddProperty(model);

                // Redirects to customer list or home page after success
                return RedirectToAction("Index", "Home");
            }

            // If the model is not valid, it returns to the creation view with the current data
            return View(model);
        }

        // Read
        [Route("[action]/{id:int}")]
        public IActionResult Details(int id)
        {
            var property = _context.Properties.FirstOrDefault(p => p.Id == id);
            if (property == null)
            {
                return NotFound();
            }
            int contractId = property.Contract?.Id ?? id;
            var contracts = _context.Contracts
                        .Where(p => p.Id == contractId)
                        .ToList();
            var viewModel = new PropertyDetailsViewModel
            {
                Property = property,
                Contracts = contracts
            };
            return View(viewModel);
        }

        // Update
        [HttpGet]
        [Route("[action]/{id:int}")]
        public IActionResult Edit(int id) 
        {
            var property = _context.Properties.FirstOrDefault(x => x.Id == id);
            return View(property);
        }

        [HttpPost]
        [Route("[action]/{id:int}")]
        public IActionResult Edit(Property model)
        {
            if (ModelState.IsValid)
            {
                var property = _context.Properties.FirstOrDefault(p => p.Id == model.Id);
                if (property != null)
                {
                    property.Address = model.Address;
                    property.Price = model.Price;

                    return RedirectToAction("Details", new { id = property.Id });
                }
                return NotFound();
            }
            return View(model);
        }

        // Delete
        [HttpGet]
        [Route("[action]/{id:int}")]
        public IActionResult Delete(int id) 
        {
            var property = _context.Properties.FirstOrDefault(_ => _.Id == id);

            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }

        [HttpPost]
        [Route("[action]/{id:int}")]
        public IActionResult Delete(Property model) {
            _context.RemoveProperty(model.Id);

            // Search for contracts related to the client
            var contracts = _context.Contracts.Where(contract => contract.Property.Id == model.Id).ToList();

            // Update the status of contracts to "closed"
            foreach (var contract in contracts)
            {
                contract.ContractState = ContractState.CLOSED;
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
