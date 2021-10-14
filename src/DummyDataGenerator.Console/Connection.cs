using System.Collections.Generic;

namespace DummyDataGeneratorConsole
{
    public record Connection
    {
        public Customer Customer { get; }
        public Vehicle Vehicle { get; }

        public Connection(Customer customer, Vehicle vehicle)
        {
            Customer = customer;
            Vehicle = vehicle;
        }

        public static IEnumerable<Connection> CreateMany(
            int count,
            IEnumerable<Customer> customers,
            IEnumerable<Vehicle> vehicles,
            IDummyDataGenerator ddg)
        {
            var connections = new List<Connection>();
            
            for (var i = 0; i < count; i++)
            {
                //TODO create random connection. But be aware: Customer can have many cars, but a car can only have one customer
            }

            return connections;
        }
    }
}