using Imobiliaria.Models;

namespace Imobiliaria.ViewModels
{
    public class ClientDetailsViewModel
    {
        public Client Client { get; set; }
        public List<Contract> Contracts { get; set; } = new List<Contract>();
    }

}
