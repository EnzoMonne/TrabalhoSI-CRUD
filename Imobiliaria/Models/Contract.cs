using Imobiliaria.Models.Enums;

namespace Imobiliaria.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client? Client { get; set; }
        public int PropertyId { get; set; }
        public Property? Property { get; set; }
        public DateTime ContractDate { get; set; }
        public DateTime? dateTime { get; set; }

        public ContractState ContractState { get; set; }
    }
}
