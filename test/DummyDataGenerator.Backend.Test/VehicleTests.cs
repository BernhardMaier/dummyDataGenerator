using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace DummyDataGenerator.Backend.Test
{
  public class VehicleTests
  {
    private const int Seed = 1;
    
    public class WhenCreatingInsertScript
    {
      private readonly ITestOutputHelper _testOutputHelper;

      public WhenCreatingInsertScript(ITestOutputHelper testOutputHelper) =>
        _testOutputHelper = testOutputHelper;

      [Fact]
      public void TheCreatedScriptStartsWithTheCorrectLine()
      {
        var ddg = new DummyDataGenerator(Seed);
        var vehicle = new Vehicle(ddg);
        var script = vehicle.AsInsertScript();

        script.Should().StartWith("INSERT INTO [dbo].[Vehicles] ");
        _testOutputHelper.WriteLine(script);
      }
      
      [Fact]
      public void TheCreatedScriptEndsWithTheCorrectLine()
      {
        var ddg = new DummyDataGenerator(Seed);
        var vehicle = new Vehicle(ddg);
        var script = vehicle.AsInsertScript();

        script.Should().EndWith(")");
        script.Should().NotEndWith(",)");
        _testOutputHelper.WriteLine(script);
      }
    }

    public class WhenCreatingMany
    {
      [Fact]
      public void TheReturnedListContainsCorrectAmountOfInstances()
      {
        const int count = 10;
        var ddg = new DummyDataGenerator(Seed);
        var vehicles = Vehicle.CreateMany(count, ddg);

        vehicles.Should().HaveCount(count);
      }
    }
  }
}