using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace DummyDataGenerator.Backend.Test
{
  public class TextBlockTests
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
        var textBlock = new TextBlock(ddg);
        var script = textBlock.AsInsertScript();

        script.Should().StartWith("INSERT INTO [dbo].[CatalogTextBlocks] (");
        _testOutputHelper.WriteLine(script);
      }
      
      [Fact]
      public void TheCreatedScriptEndsWithTheCorrectLine()
      {
        var ddg = new DummyDataGenerator(Seed);
        var textBlock = new TextBlock(ddg);
        var script = textBlock.AsInsertScript();

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
        var textBlocks = TextBlock.CreateMany(count, ddg);

        textBlocks.Should().HaveCount(count);
      }
    }
  }
}