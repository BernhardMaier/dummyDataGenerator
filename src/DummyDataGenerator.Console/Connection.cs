using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DummyDataGeneratorConsole
{
    public record Connection : ISqlEntity
    {
        public Customer Customer { get; }
        public Vehicle Vehicle { get; }

        public Connection(Customer customer, Vehicle vehicle)
        {
            Customer = customer;
            Vehicle = vehicle;
        }

        public static IEnumerable<Connection> CreateMany(
            Customer[] customers,
            Vehicle[] vehicles)
        {
            var connections = new List<Connection>();
            for (var i = 0; i < customers.Length; i++)
            {
                switch ((i+4)%4)
                {
                    case 0:
                    case 1:
                        continue;
                    case 2:
                        connections.Add(new Connection(customers[i], vehicles[i-1]));
                        break;
                    case 3:
                        connections.Add(new Connection(customers[i], vehicles[i-1]));
                        connections.Add(new Connection(customers[i], vehicles[i]));
                        break;
                }
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