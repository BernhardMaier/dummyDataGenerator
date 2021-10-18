using System;
using System.Collections.Generic;
using System.Text;

namespace DummyDataGeneratorConsole
{
    public record Connection
    {
        public Customer Customer { get; }
        public Vehicle Vehicle { get; }

        public Connection(Customer customer, Vehicle vehicle, IDummyDataGenerator ddg)
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
        
        public string AsInsertScript()
        {
            var sb = new StringBuilder();
            sb.Append($"INSERT INTO [dbo].[Connections] ");
            sb.Append($"[CustomerId],");
            sb.Append($"[VehicleId])");
            sb.Append($" VALUES ");
            sb.Append($"{Customer.Id},");
            sb.Append($"{Vehicle.Id})");
            sb.Append($" GO");

            return sb.ToString();
        }

    }
}