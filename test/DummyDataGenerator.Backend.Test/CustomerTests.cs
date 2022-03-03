using FluentAssertions;
using Xunit;

namespace DummyDataGenerator.Backend.Test
{
  public class CustomerTests
  {
    private const int Seed = 1;
    
    public class WhenCreatingInsertScript
    {
      [Fact]
      public void TheCreatedScriptStartsWithTheCorrectLine()
      {
        var ddg = new DummyDataGenerator(Seed);
        var customer = new Customer(ddg);
        var script = customer.AsInsertScript();

        script.Should().StartWith("INSERT INTO [dbo].[Customers] (");
      }
      
      [Fact]
      public void TheCreatedScriptEndsWithTheCorrectLine()
      {
        var ddg = new DummyDataGenerator(Seed);
        var customer = new Customer(ddg);
        var script = customer.AsInsertScript();

        script.Should().EndWith(")");
        script.Should().NotEndWith(",)");
      }
    }

    public class WhenCreatingMany
    {
      [Fact]
      public void TheReturnedListContainsCorrectAmountOfInstances()
      {
        const int count = 10;
        var ddg = new DummyDataGenerator(Seed);
        var customers = Customer.CreateMany(count, ddg);

        customers.Should().HaveCount(count);
      }
    }
  }
}