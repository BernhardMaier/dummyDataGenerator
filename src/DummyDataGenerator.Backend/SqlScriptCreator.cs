using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DummyDataGenerator.Backend.Interfaces;

namespace DummyDataGenerator.Backend
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

    public void CreateScript(
      IEnumerable<Customer> customers,
      IEnumerable<Vehicle> vehicles,
      IEnumerable<Connection> connections,
      IEnumerable<TaxRate> taxRates,
      IEnumerable<Article> catalogArticles,
      IEnumerable<Labour> catalogLabours,
      IEnumerable<TextBlock> catalogTextBlocks)
    {
      customers = customers.ToList();
      vehicles = vehicles.ToList();
      connections = connections.ToList();
      taxRates = taxRates.ToList();
      catalogArticles = catalogArticles.ToList();
      catalogLabours = catalogLabours.ToList();
      catalogTextBlocks = catalogTextBlocks.ToList();

      AddCommentHeader(
        customers.Count(), vehicles.Count(), connections.Count(), taxRates.Count(),
        catalogArticles.Count(), catalogLabours.Count(), catalogTextBlocks.Count());
      AddSqlEntities(customers, nameof(customers).ToUpper());
      AddSqlEntities(vehicles, nameof(vehicles).ToUpper());
      AddSqlEntities(connections, nameof(connections).ToUpper());
      AddSqlEntities(taxRates, nameof(taxRates).ToUpper());
      AddSqlEntities(catalogArticles, nameof(catalogArticles).ToUpper());
      AddSqlEntities(catalogLabours, nameof(catalogLabours).ToUpper());
      AddSqlEntities(catalogTextBlocks, nameof(catalogTextBlocks).ToUpper());
    }

    private void AddCommentHeader(
      int customers,
      int vehicles,
      int connections,
      int taxRates,
      int catalogArticles,
      int catalogLabours,
      int catalogTextBlocks)
    {
      Script.Add("/*");
      Script.Add("########################################");
      Script.Add($"# Creation date: {DateTime.Now}");
      Script.Add($"# Customers: {customers}");
      Script.Add($"# Vehicles: {vehicles}");
      Script.Add($"# Connections: {connections}");
      Script.Add($"# TaxRates: {taxRates}");
      Script.Add($"# CatalogArticles: {catalogArticles}");
      Script.Add($"# CatalogLabours: {catalogLabours}");
      Script.Add($"# CatalogTextBlocks: {catalogTextBlocks}");
      Script.Add("########################################");
      Script.Add("*/");
      Script.Add(string.Empty);
    }

    private void AddSqlEntities(IEnumerable<ISqlEntity> list, string name)
    {
      list = list.ToList();
      if (!list.Any()) return;
      
      Script.Add($"-- {name} ({list.Count()})");
      foreach (var element in list)
        Script.Add(element.AsInsertScript());
      Script.Add(string.Empty);
    }

    public void SaveScript() => File.WriteAllLines(FilePath, Script);
  }
}