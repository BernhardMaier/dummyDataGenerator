using System.Linq;
using FluentAssertions;
using Xunit;

namespace DummyDataGenerator.Backend.Test
{
  public class SqlScriptGeneratorTests
  {
    private const int Seed = 1;
    private const string FilePath = "testPath";
    
    public class WhenInstantiating
    {
      [Fact]
      public void TheNewObjectHoldsAnEmptyList()
      {
        var ssc = new SqlScriptCreator(FilePath);

        ssc.Script.Should().HaveCount(0);
      }

      [Fact]
      public void TheNewObjectHoldsTheCorrectPath()
      {
        var ssc = new SqlScriptCreator(FilePath);

        ssc.FilePath.Should().Be(FilePath);
      }
    }
    
    public class WhenCreatingTheScript
    {
      [Fact]
      public void TheScriptPropertyIsNotEmpty()
      {
        const int count = 100;
        var ddg = new DummyDataGenerator(Seed);
        var customers = Customer.CreateMany(count, ddg).ToArray();
        var vehicles = Vehicle.CreateMany(count, ddg).ToArray();
        var connections = Connection.CreateMany(customers, vehicles);
        var ssc = new SqlScriptCreator(FilePath);
        ssc.CreateScript(customers, vehicles, connections);

        ssc.Script.Should().HaveCount(290);
      }
    }
  }
}