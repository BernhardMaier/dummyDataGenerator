using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using DummyDataGenerator.Backend.Interfaces;

[assembly: InternalsVisibleTo("DummyDataGenerator.Backend.Test")]
namespace DummyDataGenerator.Backend
{
  public record Connection : ISqlEntity
  {
    internal Connection(Customer customer, Vehicle vehicle)
    {
      Customer = customer;
      Vehicle = vehicle;
    }

    private Customer Customer { get; }
    private Vehicle Vehicle { get; }

    public string AsInsertScript()
    {
      var sb = new StringBuilder();

      sb.Append("INSERT INTO [dbo].[CustomerVehicleConnections] ");
      sb.Append("([CustomerId],");
      sb.Append("[VehicleId])");
      sb.Append(" VALUES ");
      sb.Append($"('{Customer.Id}',");
      sb.Append($"'{Vehicle.Id}')");
      sb.Append(Environment.NewLine);
      sb.Append("GO");

      return sb.ToString().Replace("''", "NULL");
    }

    public static IEnumerable<Connection> CreateMany(
      Customer[] customers,
      Vehicle[] vehicles)
    {
      var connections = new List<Connection>();
      for (var i = 0; i < customers.Length; i++)
        switch ((i + 4) % 4)
        {
          case 0:
          case 1:
            continue;
          case 2:
            connections.Add(new Connection(customers[i], vehicles[i - 1]));
            break;
          case 3:
            connections.Add(new Connection(customers[i], vehicles[i - 1]));
            connections.Add(new Connection(customers[i], vehicles[i]));
            break;
        }

      return connections;
    }
  }
}