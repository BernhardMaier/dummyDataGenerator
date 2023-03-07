using System;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace DummyDataGenerator.Backend.Test
{
  public class LabourTests
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
        var taxRateId = new Guid();
        var labour = new Labour(ddg, taxRateId);
        var script = labour.AsInsertScript();

        script.Should().StartWith("INSERT INTO [dbo].[CatalogLabours] (");
        _testOutputHelper.WriteLine(script);
      }
      
      [Fact]
      public void TheCreatedScriptEndsWithTheCorrectLine()
      {
        var ddg = new DummyDataGenerator(Seed);
        var taxRateId = new Guid();
        var labour = new Labour(ddg, taxRateId);
        var script = labour.AsInsertScript();

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
        var taxRateId = new Guid();
        var labours = Labour.CreateMany(count, ddg, taxRateId);

        labours.Should().HaveCount(count);
      }
    }
  }
}