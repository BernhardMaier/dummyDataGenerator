using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace DummyDataGenerator.Backend.Test
{
  public class ConnectionTests
  {
    private const int Seed = 1;
    
    public class WhenCreatingInsertScript
    {
      [Fact]
      public void TheCreatedScriptStartsWithTheCorrectLine()
      {
        var ddg = new DummyDataGenerator(Seed);
        var customer = new Customer(ddg);
        var vehicle = new Vehicle(ddg);
        var connection = new Connection(customer, vehicle);
        var script = connection.AsInsertScript();

        script.Should().StartWith("INSERT INTO [dbo].[CustomerVehicleConnections] ");
      }
      
      [Fact]
      public void TheCreatedScriptEndsWithTheCorrectLine()
      {
        var ddg = new DummyDataGenerator(Seed);
        var customer = new Customer(ddg);
        var vehicle = new Vehicle(ddg);
        var connection = new Connection(customer, vehicle);
        var script = connection.AsInsertScript();

        script.Should().EndWith(")");
        script.Should().NotEndWith(",)");
      }
    }

    public class WhenCreatingMany
    {
      [Fact]
      public void TheReturnedListContainsCorrectAmountOfInstances()
      {
        const int count = 100;
        var ddg = new DummyDataGenerator(Seed);
        var customers = Customer.CreateMany(count, ddg).ToArray();
        var vehicles = Vehicle.CreateMany(count, ddg).ToArray();
        var connections = Connection.CreateMany(customers, vehicles);

        connections.Should().HaveCount(75);
      }
    }
  }
}