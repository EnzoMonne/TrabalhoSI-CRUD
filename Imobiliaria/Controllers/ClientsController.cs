using Imobiliaria.Models;
using Imobiliaria.Models.Enums;
using Imobiliaria.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Imobiliaria.Controllers
{
    [Route("[controller]")]
    public class ClientsController : Controller
    {
        private readonly FakeDbContext _context;

        public ClientsController(FakeDbContext context)
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

        // Create
        [HttpPost]
        [Route("[action]")]
        public IActionResult Create(Client model)
        {
            if (ModelState.IsValid)
            {
                // Adds the new client to the context
                _context.AddClient(model);

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
            var client = _context.Clients.FirstOrDefault(c => c.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            var contracts = _context.Contracts.Where(c => c.ClientId == id).ToList();

            var viewModel = new ClientDetailsViewModel
            {
                Client = client,
                Contracts = contracts
            };

            return View(viewModel);
        }

        // Update
        [HttpGet]
        [Route("[action]/{id:int}")]
        public IActionResult Edit(int id)
        {
            var client = _context.Clients.FirstOrDefault(c => c.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // (using POST for simplicity in this case)
        [HttpPost]
        [Route("[action]/{id:int}")]
        public IActionResult Edit(Client model)
        {
            if (ModelState.IsValid)
            {
                var client = _context.Clients.FirstOrDefault(c => c.Id == model.Id);
                if (client != null)
                {
                    client.FirstName = model.FirstName;
                    client.LastName = model.LastName;
                    client.Email = model.Email;

                    return RedirectToAction("Details", new { id = client.Id });
                }
                return NotFound();
            }
            return View(model);
        }

        // Add a property to a client
        [HttpGet]
        [Route("[action]/{id:int}")]
        public IActionResult LinkProperty(int id)
        {
            ViewData["ClientId"] = id;
            return View(_context.Properties);
        }

        // (using POST for simplicity in this case)
        [HttpPost]
        [Route("[action]/{id:int}")]
        public IActionResult LinkProperty(int clientId, int propertyId)
        {
            var client = _context.GetClientById(clientId);
            var property = _context.Properties.FirstOrDefault(p => p.Id == propertyId);

            if (client == null  || property == null) { return NotFound(); }

            client.Properties.Add(property);
            property.ClientId = client.Id;
            property.Client = client;
            // Generates a new contract
            var newContract = new Contract
            {
                ClientId = client.Id,
                Client = client,
                PropertyId = property.Id,
                Property = property,
                ContractDate = DateTime.Now,
                ContractState = ContractState.ACTIVE
            };
            // Adds the contract to the context
            _context.AddContract(newContract);
            property.Contract = newContract;

            return RedirectToAction("Index", "Home");
        }

        // Delete
        [HttpGet]
        [Route("[action]/{id:int}")]
        public IActionResult Delete(int id)
        {
            var client = _context.Clients.FirstOrDefault(c => c.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // (using POST for simplicity in this case)
        [HttpPost]
        [Route("[action]/{id:int}")]
        public IActionResult Delete(Client model)
        {
            // Search for contracts related to the client
            var contracts = _context.Contracts.Where(contract => contract.ClientId == model.Id).ToList();

            // Update the status of contracts to "closed"
            foreach (var contract in contracts)
            {
                contract.ContractState = ContractState.CLOSED;
            }

            _context.RemoveClient(model.Id);

            return RedirectToAction("Index", "Home");
        }

    }
}
