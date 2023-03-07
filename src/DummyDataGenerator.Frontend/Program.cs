using System;
using System.IO;
using System.Linq;
using DummyDataGenerator.Backend;

namespace DummyDataGenerator.Frontend
{
  public static class Program
  {
    private const string Filename = "insertDummyData";
    private const string Extension = "sql";
    private const int DefaultSeed = 1337;
    private const int DefaultCustomerVehicleCount = 100;
    private const int DefaultArticleCount = 50;
    private const int DefaultLabourCount = 50;
    private const int DefaultTextBlockCount = 25;

    public static void Main()
    {
      do Process();
      while (RequestBooleanInput("Do you want to create another script?"));
      
      Exit();
    }

    private static void Process()
    {
      var seed = DefaultSeed;
      var customerVehicleCount = DefaultCustomerVehicleCount;
      var articleCount = DefaultArticleCount;
      var labourCount = DefaultLabourCount;
      var textBlockCount = DefaultTextBlockCount;
      
      PrintDefaults();
      
      if (RequestBooleanInput("Do you want to use other input values?"))
      {
        RequestIntegerInput("Please enter a seed number:", out seed);
        RequestIntegerInput("Please enter how many customers/vehicles to generate:", out customerVehicleCount);
        RequestIntegerInput("Please enter how many catalog articles to generate:", out articleCount);
        RequestIntegerInput("Please enter how many catalog labours to generate:", out labourCount);
        RequestIntegerInput("Please enter how many catalog text blocks to generate:", out textBlockCount);
      }

      var filePath = Path.Combine(Directory.GetCurrentDirectory(), $"{Filename}.{Extension}");
      var ssc = new SqlScriptCreator(filePath);
      var ddg = new Backend.DummyDataGenerator(seed);
      
      var customers = Customer.CreateMany(customerVehicleCount, ddg).ToList();
      var vehicles = Vehicle.CreateMany(customerVehicleCount, ddg).ToList();
      var connections = Connection.CreateMany(customers.ToArray(), vehicles.ToArray()).ToList();

      var taxRates = TaxRate.CreateMany(1, ddg).ToList();
      var articles = Article.CreateMany(articleCount, ddg, taxRates.First().Id).ToList();
      var labours = Labour.CreateMany(labourCount, ddg, taxRates.First().Id).ToList();
      var textBlocks = TextBlock.CreateMany(textBlockCount, ddg).ToList();

      ssc.CreateScript(customers, vehicles, connections, taxRates, articles, labours, textBlocks);
      ssc.SaveScript();

      PrintResult(ddg.Seed, customers.Count, vehicles.Count, connections.Count,
        taxRates.Count, articles.Count, labours.Count, textBlocks.Count, ssc.FilePath);
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

    private static void PrintDefaults()
    {
      Console.WriteLine("Default values:");
      Console.WriteLine($"  Seed to use: {DefaultSeed}");
      Console.WriteLine($"  Customer to generate: {DefaultCustomerVehicleCount}");
      Console.WriteLine($"  Vehicle to generate: {DefaultCustomerVehicleCount}");
      Console.WriteLine($"  Articles to generate: {DefaultArticleCount}");
      Console.WriteLine($"  Labours to generate: {DefaultLabourCount}");
      Console.WriteLine($"  Text blocks to generate: {DefaultTextBlockCount}");
    }

    private static void PrintResult(int seed, int customers, int vehicles, int connections,
      int taxRates, int articles, int labours, int textBlocks, string path)
    {
      Console.WriteLine($"Used '{seed}' as seed.");
      Console.WriteLine($"Generated {customers} customers, {vehicles} vehicles, {connections} connections, " +
                        $"{taxRates} tax rates, {articles} articles, {labours} labours and {textBlocks} text blocks.");
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