using Imobiliaria.Models;

namespace Imobiliaria.ViewModels {
    public class PropertyDetailsViewModel {
        public Property? Property { get; set; }
        public List<Contract> Contracts { get; set; }
    }
}
