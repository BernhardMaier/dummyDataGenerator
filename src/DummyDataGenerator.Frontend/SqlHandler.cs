using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DummyDataGenerator.Frontend.Interfaces;

namespace DummyDataGenerator.Frontend
{
  public static class SqlHandler
  {
    public static string[] CreateScript(
      IEnumerable<Customer> customers,
      IEnumerable<Vehicle> vehicles,
      IEnumerable<Connection> connections)
    {
      customers = customers.ToList();
      vehicles = vehicles.ToList();
      connections = connections.ToList();

      var script = new List<string>();

      AddCommentHeader(script, customers.Count(), vehicles.Count(), connections.Count());
      AddSqlEntities(script, customers, nameof(customers).ToUpper());
      AddSqlEntities(script, vehicles, nameof(vehicles).ToUpper());
      AddSqlEntities(script, connections, nameof(connections).ToUpper());

      return script.ToArray();
    }

    private static void AddCommentHeader(ICollection<string> script, int customers, int vehicles, int connections)
    {
      script.Add("/*");
      script.Add("########################################");
      script.Add($"# Creation date: {DateTime.Now}");
      script.Add($"# Customers: {customers}");
      script.Add($"# Vehicles: {vehicles}");
      script.Add($"# Connections: {connections}");
      script.Add("########################################");
      script.Add("*/");
      script.Add(string.Empty);
    }

    private static void AddSqlEntities(ICollection<string> script, IEnumerable<ISqlEntity> list, string name)
    {
      list = list.ToList();
      script.Add($"-- {name} ({list.Count()})");
      foreach (var element in list)
        script.Add(element.AsInsertScript());
      script.Add(string.Empty);
    }

    public static void SaveScript(string path, string[] content)
    {
      File.WriteAllLines(path, content);
    }
  }
}