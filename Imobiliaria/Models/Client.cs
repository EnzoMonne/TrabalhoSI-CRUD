using System.ComponentModel.DataAnnotations;

namespace Imobiliaria.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string? Email { get; set; }

        public List<Property> Properties { get; set; } = new List<Property>();

        public string FullName => $"{FirstName} {LastName}";

        public override string ToString()
        {
            return $"Client Id: {Id}, Full Name: {FullName}, Email: {Email}";
        }
    }
}
