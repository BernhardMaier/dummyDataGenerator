using System;
using System.IO;
using System.Linq;
using DummyDataGenerator.Backend;

namespace DummyDataGenerator.Frontend
{
  public static class Program
  {
    public static void Main()
    {
      const string filename = "insertDummyData";
      const string extension = "sql";

      RequestIntegerInput("Please enter a seed number:", out var seed);
      
      do Process(filename, extension, seed);
      while (RequestBooleanInput("Do you want to create another script?"));
      
      Exit();
    }

    private static void Process(string filename, string extension, int seed)
    {
      RequestIntegerInput("Please enter how many customers/vehicles to generate:", out var count);

      var filePath = Path.Combine(Directory.GetCurrentDirectory(), $"{filename}_{count}.{extension}");
      var ssc = new SqlScriptCreator(filePath);
      var ddg = new Backend.DummyDataGenerator(seed);
      
      var customers = Customer.CreateMany(count, ddg).ToList();
      var vehicles = Vehicle.CreateMany(count, ddg).ToList();
      var connections = Connection.CreateMany(customers.ToArray(), vehicles.ToArray()).ToList();

      ssc.CreateScript(customers, vehicles, connections);
      ssc.SaveScript();

      PrintResult(ddg.Seed, customers.Count, vehicles.Count, connections.Count, ssc.FilePath);
    }

    private static void RequestIntegerInput(string message, out int inputVariable)
    {
      Console.WriteLine($"{message} (integer)");
      var input = Console.ReadLine();
      if (int.TryParse(input, out inputVariable)) return;
      Exit("Invalid input.");
    }

    private static bool RequestBooleanInput(string message)
    {
      Console.WriteLine($"{message} (y/n)");
      var input = Console.ReadLine();
      switch (input)
      {
        case "Y":
        case "y":
          return true;
        case "N":
        case "n":
          return false;
        default:
          Exit("Invalid input.");
          return false;
      }
    }

    private static void PrintResult(int seed, int customers, int vehicles, int connections, string path)
    {
      Console.WriteLine($"Used '{seed}' as seed.");
      Console.WriteLine($"Generated {customers} customers, {vehicles} vehicles and {connections} connections.");
      Console.WriteLine($"Script can be found at '{path}'");
    }

    private static void Exit(string? error = null)
    {
      if (error is not null)
        Console.WriteLine(error);

      Console.WriteLine("Press any key to exit.");
      Console.ReadKey();

      if (error is not null)
        Environment.Exit(1);
      Environment.Exit(0);
    }
  }
}