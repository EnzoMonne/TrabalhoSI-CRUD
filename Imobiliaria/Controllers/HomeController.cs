using Imobiliaria.Models;
using Imobiliaria.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Imobiliaria.Controllers
{
    public class HomeController : Controller
    {
        private readonly FakeDbContext _context;

        public HomeController(FakeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                Clients = _context.Clients,
                Properties = _context.Properties,
                Contracts = _context.Contracts
            };

            return View(model);
        }
    }
}
