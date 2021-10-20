using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DummyDataGenerator.Frontend
{
  public static class Program
  {
    public static void Main()
    {
      const string filename = "insertDummyData.sql";
      var path = Path.Combine(Directory.GetCurrentDirectory(), filename);

      RequestInput("Please enter a seed number (integer):", out var seed);
      RequestInput("Please enter how many customers/vehicles to generate (integer):", out var count);

      var ddg = new DummyDataGenerator(seed);
      var customers = Customer.CreateMany(count, ddg).ToList();
      var vehicles = Vehicle.CreateMany(count, ddg).ToList();
      var connections = Connection.CreateMany(customers.ToArray(), vehicles.ToArray()).ToList();

      var content = SqlHandler.CreateScript(customers, vehicles, connections);
      SqlHandler.SaveScript(path, content);

      PrintResult(ddg.Seed, customers.Count, vehicles.Count, connections.Count, path);
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

    private static void PrintResult(int seed, int customers, int vehicles, int connections, string path)
    {
      Console.WriteLine($"Used '{seed}' as seed.");
      Console.WriteLine($"Generated {customers} customers, {vehicles} vehicles and {connections} connections.");
      Console.WriteLine($"Script can be found at '{path}'");
      Console.WriteLine("Press any key to exit.");
      Console.ReadKey();
    }

  }
}