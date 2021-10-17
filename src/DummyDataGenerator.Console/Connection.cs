using System;
using System.Collections.Generic;
using System.Text;

namespace DummyDataGeneratorConsole
{
    public record Connection
    {
        public Guid Id { get; }
        public Customer Customer { get; }
        public Vehicle Vehicle { get; }

        public Connection(Customer customer, Vehicle vehicle, IDummyDataGenerator ddg)
        {
            Id = ddg.GenerateRandomGuid();
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
            sb.Append($"([Id],");
            sb.Append($"[Customer],");
            sb.Append($"[Vehicle])");
            sb.Append($" VALUES ");
            sb.Append($"({Id},");
            sb.Append($"{Customer.Id},");
            sb.Append($"{Vehicle.Id})");
            sb.Append($" GO");

            return sb.ToString();
        }

    }
}