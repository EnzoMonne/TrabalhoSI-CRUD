namespace Imobiliaria.Models
{
    public class FakeDbContext
    {
        // Properties for storing simulated data
        public List<Client> Clients { get; set; } = new List<Client>();
        public List<Property> Properties { get; set; } = new List<Property>();
        public List<Contract> Contracts { get; set; } = new List<Contract>();

        public FakeDbContext()
        {
            // Initializes simulated data
            InitializeData();
        }

        // Initializes simulated dice
        private void InitializeData()
        {
            // Adding Customers
            Clients.Add(new Client { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" });
            Clients.Add(new Client { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com" });
            Clients.Add(new Client { Id = 3, FirstName = "Alice", LastName = "Johnson", Email = "alice.johnson@example.com" });
            Clients.Add(new Client { Id = 4, FirstName = "Bob", LastName = "Brown", Email = "bob.brown@example.com" });
            Clients.Add(new Client { Id = 5, FirstName = "Charlie", LastName = "Davis", Email = "charlie.davis@example.com" });
            Clients.Add(new Client { Id = 6, FirstName = "Emily", LastName = "Wilson", Email = "emily.wilson@example.com" });
            Clients.Add(new Client { Id = 7, FirstName = "Michael", LastName = "Taylor", Email = "michael.taylor@example.com" });
            Clients.Add(new Client { Id = 8, FirstName = "Sarah", LastName = "Moore", Email = "sarah.moore@example.com" });
            Clients.Add(new Client { Id = 9, FirstName = "David", LastName = "Anderson", Email = "david.anderson@example.com" });
            Clients.Add(new Client { Id = 10, FirstName = "Olivia", LastName = "Thomas", Email = "olivia.thomas@example.com" });

            // Adding Properties
            Properties.Add(new Property { Id = 1, Address = "123 Main St", Price = 250000, ClientId = 1, Client= GetClientById(1)});
            Properties.Add(new Property { Id = 2, Address = "456 Maple Ave", Price = 300000, ClientId = 1, Client = GetClientById(1) });
            Properties.Add(new Property { Id = 3, Address = "789 Oak Dr", Price = 350000, ClientId = 3, Client = GetClientById(3) });
            Properties.Add(new Property { Id = 4, Address = "101 Pine Rd", Price = 400000, ClientId = 4, Client = GetClientById(4) });
            Properties.Add(new Property { Id = 5, Address = "202 Birch Ln", Price = 450000, ClientId = 5, Client = GetClientById(5) });
            Properties.Add(new Property { Id = 6, Address = "303 Cedar Blvd", Price = 500000, ClientId = 6, Client = GetClientById(6) });
            Properties.Add(new Property { Id = 7, Address = "404 Elm St", Price = 550000, ClientId = 7, Client = GetClientById(7) });
            Properties.Add(new Property { Id = 8, Address = "505 Walnut St", Price = 600000, ClientId = 8, Client = GetClientById(8) });
            Properties.Add(new Property { Id = 9, Address = "606 Pinecrest Dr", Price = 650000, ClientId = 9, Client = GetClientById(9) });
            Properties.Add(new Property { Id = 10, Address = "707 Willow Way", Price = 700000, ClientId = 10, Client = GetClientById(10) });

            // Properties with no associated client
            Properties.Add(new Property { Id = 11, Address = "808 Spruce St", Price = 750000, ClientId = 0 });
            Properties.Add(new Property { Id = 12, Address = "909 Aspen Ct", Price = 800000, ClientId = 0 });
            Properties.Add(new Property { Id = 13, Address = "1010 Fir Dr", Price = 850000, ClientId = 0 });
            Properties.Add(new Property { Id = 14, Address = "1111 Redwood Blvd", Price = 900000, ClientId = 0 });
            Properties.Add(new Property { Id = 15, Address = "1212 Cypress Ln", Price = 950000, ClientId = 0 });

            // Adding Contracts
            Contracts.Add(new Contract { Id = 1, ClientId = 1, PropertyId = 1, ContractDate = DateTime.Now.AddMonths(-6), Client = GetClientById(1), Property = GetPropertyById(1) });
            Contracts.Add(new Contract { Id = 2, ClientId = 1, PropertyId = 2, ContractDate = DateTime.Now.AddMonths(-3), Client = GetClientById(1), Property = GetPropertyById(2) });
            Contracts.Add(new Contract { Id = 3, ClientId = 3, PropertyId = 3, ContractDate = DateTime.Now.AddMonths(-1), Client = GetClientById(3), Property = GetPropertyById(3) });
            Contracts.Add(new Contract { Id = 4, ClientId = 4, PropertyId = 4, ContractDate = DateTime.Now.AddMonths(-2), Client = GetClientById(4), Property = GetPropertyById(4) });
            Contracts.Add(new Contract { Id = 5, ClientId = 5, PropertyId = 5, ContractDate = DateTime.Now.AddMonths(-4), Client = GetClientById(5), Property = GetPropertyById(5) });
            Contracts.Add(new Contract { Id = 6, ClientId = 6, PropertyId = 6, ContractDate = DateTime.Now.AddMonths(-5), Client = GetClientById(6), Property = GetPropertyById(6) });
            Contracts.Add(new Contract { Id = 7, ClientId = 7, PropertyId = 7, ContractDate = DateTime.Now.AddMonths(-7), Client = GetClientById(7), Property = GetPropertyById(7) });
            Contracts.Add(new Contract { Id = 8, ClientId = 8, PropertyId = 8, ContractDate = DateTime.Now.AddMonths(-8), Client = GetClientById(8), Property = GetPropertyById(8) });
            Contracts.Add(new Contract { Id = 9, ClientId = 9, PropertyId = 9, ContractDate = DateTime.Now.AddMonths(-9), Client = GetClientById(9), Property = GetPropertyById(9) });
            Contracts.Add(new Contract { Id = 10, ClientId = 10, PropertyId = 10, ContractDate = DateTime.Now.AddMonths(-10), Client = GetClientById(10), Property = GetPropertyById(10) });

            // Updating customer properties with contracts
            foreach (var client in Clients)
            {
                client.Properties = Properties.Where(p => p.ClientId == client.Id).ToList();
            }
            foreach (var property in Properties)
            {
                foreach (var contract in Contracts) 
                { 
                    if (contract.PropertyId == property.Id)
                    {
                        property.Contract = contract;
                    }
                }
            }

        }


        // Methods for simulating CRUD operations

        public Client GetClientById(int id)
        {
            return Clients.SingleOrDefault(c => c.Id == id);
        }

        public void AddClient(Client client)
        {
            // Find the largest current ID
            int nextId = Clients.Any() ? Clients.Max(c => c.Id) + 1 : 1;

            // Assign the next ID to the new customer
            client.Id = nextId;

            // Add the new customer to the list
            Clients.Add(client);
        }
        
        public void RemoveClient(int id)
        {
            var client = GetClientById(id);
            if (client != null)
            {
                // Disassociates the client from their property
                foreach (var property in Properties.Where(p => p.ClientId == id))
                {
                    property.ClientId = 0; // There is no clients with ID 0, so we can set 0 here
                    property.Client = null;
                }

                // Remove the client
                Clients.Remove(client);
            }
        }

        public Property GetPropertyById(int id)
        {
            return Properties.SingleOrDefault(p => p.Id == id);
        }

        public void AddProperty(Property property)
        {
            // Find the largest current ID
            int nextId = Properties.Any() ? Properties.Max(p => p.Id) + 1 : 1;

            // Assign the next ID to the new customer
            property.Id = nextId;

            // Add the new customer to the list
            Properties.Add(property);
        }

        public void RemoveProperty(int id)
        {
            var property = GetPropertyById(id);

            if (property != null)
            {
                // Disassociates the property from its client
                var clientId = (int) property.ClientId;
                if (clientId != 0)
                {
                    var client = GetClientById(clientId);
                    client.Properties.Remove(property);
                }

                // Remove the property
                Properties.Remove(property);
            }
        }

        public Contract GetContractById(int id)
        {
            return Contracts.SingleOrDefault(c => c.Id == id);
        }

        public void AddContract(Contract contract)
        {
            // Find the largest current ID
            int nextId = Contracts.Any() ? Contracts.Max(c => c.Id) + 1 : 1;

            // Assign the next ID to the new customer
            contract.Id = nextId;

            Contracts.Add(contract);
        }

        public void RemoveContract(int id)
        {
            var contract = GetContractById(id);
            if (contract != null)
            {
                Contracts.Remove(contract);
            }
        }
    }
}
