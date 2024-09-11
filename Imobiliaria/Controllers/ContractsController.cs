using Imobiliaria.Models;
using Microsoft.AspNetCore.Mvc;

namespace Imobiliaria.Controllers
{
    [Route("[controller]")]
    public class ContractsController : Controller
    {
        private readonly FakeDbContext _context;

        public ContractsController(FakeDbContext context)
        {
            _context = context;
        }

        // Read
        [Route("[action]/{id:int}")]
        public IActionResult Details(int id)
        {
            var contract = _context.Contracts.FirstOrDefault(x => x.Id == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // Update
        [HttpGet]
        [Route("[action]/{id:int}")]
        public IActionResult Edit(int id)
        {
            var contract = _context.Contracts.FirstOrDefault(x => x.Id == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        [HttpPost]
        [Route("[action]/{id:int}")]
        public IActionResult Edit(Contract model)
        {
            if (ModelState.IsValid)
            {
                var contract = _context.Contracts.FirstOrDefault(c => c.Id == model.Id);
                if (contract != null)
                {

                    contract.ContractState = model.ContractState;

                    return RedirectToAction("Details", new { id = contract.Id });
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
            var contract = _context.Contracts.FirstOrDefault(_ => _.Id == id);
            if (contract == null)
            {
                return NotFound();
            }
            

            return View(contract);
        }

        [HttpPost]
        [Route("[action]/{id:int}")]
        public IActionResult Delete(int id, int propertyId, int clientId)
        {

            Client client = _context.GetClientById(clientId);
            Property property = _context.GetPropertyById(propertyId);

            client.Properties.Remove(property);
            property.Client = null;
            property.ClientId = null;

            _context.RemoveContract(id);

            return RedirectToAction("Index", "Home");
        }

    }
}
