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

    public string AsSqlScript()
    {
      var sb = new StringBuilder();

      sb.Append($"UPDATE [dbo].[Vehicles] SET [OwnerId] = '{Customer.Id}' ");
      sb.Append($"FROM [dbo].[Vehicles] WHERE [Id] = '{Vehicle.Id}'");

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
            break;
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