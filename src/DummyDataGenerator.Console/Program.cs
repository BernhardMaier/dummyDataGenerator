using System;
using System.IO;
using System.Linq;

namespace DummyDataGeneratorConsole
{
    public static class Program
    {
        public static void Main()
        {
            const string filename = "insertDummyData.sql";
            
            var path = Path.Combine(Directory.GetCurrentDirectory(), filename);
            Console.WriteLine($"Script will be saved at '{path}'");
            
            RequestInput("Please enter a seed number (integer):", out var seed);
            RequestInput("Please enter how many customers/vehicles to generate (integer):", out var count);
            
            var ddg = new DummyDataGenerator(seed);
            var customers = Customer.CreateMany(count, ddg).ToList();
            var vehicles = Vehicle.CreateMany(count, ddg).ToList();
            var connections = Connection.CreateMany(customers.ToArray(), vehicles.ToArray()).ToList();

            var content = SqlHandler.CreateScript(customers, vehicles, connections);
            SqlHandler.SaveScript(path, content);
            
            Console.WriteLine($"Used '{ddg.Seed}' as seed.");
            Console.WriteLine($"Generated {customers.Count} customers, {vehicles.Count} vehicles and {connections.Count} connections.");
            Console.WriteLine($"Script can be found at '{path}'");
            
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void RequestInput(string message, out int inputVariable)
        {
            Console.WriteLine(message);
            var input = Console.ReadLine();
            if (int.TryParse(input, out inputVariable)) return;
            Console.WriteLine("Invalid input. Press any key to exit.");
            Console.ReadKey();
            Environment.Exit(1);
        }
    }
}
