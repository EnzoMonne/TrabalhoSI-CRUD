using System.ComponentModel.DataAnnotations;

namespace Imobiliaria.Models {
    public class Property {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Address of property is required")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "The Price of property is required")]
        public decimal Price { get; set; }
        public int? ClientId { get; set; }
        public Client? Client { get; set; }
        public Contract? Contract { get; set; }

        public override string ToString() {
            return $"Property ID: {Id}, Address: {Address}, Price: {Price:C}, " +
                   $"Client ID: {ClientId?.ToString() ?? "None"}, " +
                   $"Client Name: {Client?.FullName ?? "No Client"}, " +
                   $"Contract: {(Contract != null ? "Yes" : "No")}";
        }
    }
}
