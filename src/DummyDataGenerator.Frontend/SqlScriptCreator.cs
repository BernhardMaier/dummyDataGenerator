using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DummyDataGenerator.Frontend.Interfaces;

namespace DummyDataGenerator.Frontend
{
  public class SqlScriptCreator
  {
    public string FilePath { get; }
    public List<string> Script { get; }

    public SqlScriptCreator(string filePath)
    {
      FilePath = filePath;
      Script = new List<string>();
    }

    public void CreateScript(IEnumerable<Customer> customers,
      IEnumerable<Vehicle> vehicles,
      IEnumerable<Connection> connections)
    {
      customers = customers.ToList();
      vehicles = vehicles.ToList();
      connections = connections.ToList();

      AddCommentHeader(customers.Count(), vehicles.Count(), connections.Count());
      AddSqlEntities(customers, nameof(customers).ToUpper());
      AddSqlEntities(vehicles, nameof(vehicles).ToUpper());
      AddSqlEntities(connections, nameof(connections).ToUpper());
      AddWorkaroundFooter();
    }

    private void AddCommentHeader(int customers, int vehicles, int connections)
    {
      Script.Add("/*");
      Script.Add("########################################");
      Script.Add($"# Creation date: {DateTime.Now}");
      Script.Add($"# Customers: {customers}");
      Script.Add($"# Vehicles: {vehicles}");
      Script.Add($"# Connections: {connections}");
      Script.Add("########################################");
      Script.Add("*/");
      Script.Add(string.Empty);
    }

    private void AddSqlEntities(IEnumerable<ISqlEntity> list, string name)
    {
      list = list.ToList();
      Script.Add($"-- {name} ({list.Count()})");
      foreach (var element in list)
        Script.Add(element.AsInsertScript());
      Script.Add(string.Empty);
    }

    private void AddWorkaroundFooter()
    {
      Script.Add("/*");
      Script.Add("#################################");
      Script.Add("## Workaround for ValueObjects ##");
      Script.Add("#################################");
      Script.Add("*/");
      Script.Add(string.Empty);
      Script.Add("UPDATE dbo.Vehicles SET Hsn = '', Tsn = '' WHERE Hsn is NULL and Tsn is NULL");
      Script.Add("GO");
    }
    
    public void SaveScript()
    {
      File.WriteAllLines(FilePath, Script);
    }
  }
}