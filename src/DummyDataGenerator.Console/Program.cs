using System;
using System.IO;
using System.Linq;

namespace DummyDataGeneratorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "dummydata.sql");
            
            Console.WriteLine("Please enter a seed number (integer):");
            var inputSeed = Console.ReadLine();
            if(!int.TryParse(inputSeed, out var seed))
                Environment.Exit(1);
            
            Console.WriteLine("Please enter how many customer to generate (integer):");
            var inputCustomerCount = Console.ReadLine();
            if(!int.TryParse(inputCustomerCount, out var customerCount))
                Environment.Exit(1);
            
            Console.WriteLine("Please enter how many vehicles to generate (integer):");
            var inputVehicleCount = Console.ReadLine();
            if(!int.TryParse(inputVehicleCount, out var vehicleCount))
                Environment.Exit(1);
            
            Console.WriteLine("Please enter how many connections to generate (integer):");
            var inputConnectionCount = Console.ReadLine();
            if(!int.TryParse(inputConnectionCount, out var connectionCount))
                Environment.Exit(1);
            
            var ddg = new DummyDataGenerator(seed);
            var customers = Customer.CreateMany(customerCount, ddg).ToList();
            var vehicles = Vehicle.CreateMany(vehicleCount, ddg).ToList();
            var connections = Connection.CreateMany(connectionCount, customers, vehicles, ddg).ToList();

            var script = SqlHandler.CreateScript(customers, vehicles, connections);
            SqlHandler.SaveScript(path, script);
            
            Console.WriteLine($"Script can be found at '{path}'");
        }
    }
}
