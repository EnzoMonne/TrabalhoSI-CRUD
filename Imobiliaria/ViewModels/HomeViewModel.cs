using Imobiliaria.Models;

namespace Imobiliaria.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Client> Clients { get; set; }
        public IEnumerable<Property> Properties { get; set; }
        public IEnumerable<Contract> Contracts { get; set; }
    }
}
