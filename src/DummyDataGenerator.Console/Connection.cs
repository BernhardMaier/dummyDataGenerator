using System.Collections.Generic;
using System.Text;

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
        
        public string AsInsertScript()
        {
            var sb = new StringBuilder();
            // sb.Append($"INSERT INTO [dbo].[Customers]");
            // sb.Append($" ( [Id]");
            // sb.Append($" , [LicensePlate]");
            // sb.Append($" , [Vin]");
            // sb.Append($" , [Mileage]");
            // sb.Append($" , [Tsn]");
            // sb.Append($" , [Hsn]");
            // sb.Append($" , [KTypeNumber]");
            // sb.Append($" , [Model]");
            // sb.Append($" , [Manufacturer])");
            // sb.Append($"VALUES");
            // sb.Append($" ( {Id}");
            // sb.Append($" , {LicensePlate}");
            // sb.Append($" , '{Vin}'");
            // sb.Append($" , '{Tsn}'");
            // sb.Append($" , '{Hsn}'");
            // sb.Append($" , '{KType}'");
            // sb.Append($" , '{Model}'");
            // sb.Append($" , '{Manufacturer}')");
            sb.Append($"GO");
            sb.Append($"");

            return sb.ToString();
        }

    }
}