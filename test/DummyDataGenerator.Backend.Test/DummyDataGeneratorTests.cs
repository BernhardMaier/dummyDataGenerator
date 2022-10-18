using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace DummyDataGenerator.Backend.Test
{
  public class DummyDataGeneratorTests
  {
    private const int Seed = 1;
    
    public class WhenGeneratingEngineCodes
    {
      private const int AmountOfEngineCodesToGenerate = 1000;
      private readonly ITestOutputHelper _testOutputHelper;
      private readonly DummyDataGenerator _dummyDataGenerator;
      private readonly List<string> _generatedEngineCodes;

      public WhenGeneratingEngineCodes(ITestOutputHelper testOutputHelper)
      {
        _testOutputHelper = testOutputHelper;
        _dummyDataGenerator = new DummyDataGenerator(Seed);
        _generatedEngineCodes = new List<string>();
      }

      [Fact]
      public void AllEnginesCodesAreAtLeastFiveCharsLong()
      {
        for (var i = 0; i < AmountOfEngineCodesToGenerate; i++)
          _generatedEngineCodes.Add(_dummyDataGenerator.GenerateRandomEngineCode());
        
        var engineCodesWithLessThanFiveChars = _generatedEngineCodes
          .Where(engineCode => engineCode.Length < 5)
          .ToList();

        foreach (var engineCode in engineCodesWithLessThanFiveChars)
          _testOutputHelper.WriteLine(engineCode.Length.ToString());

        engineCodesWithLessThanFiveChars.Should().HaveCount(0);
      }

      [Fact]
      public void AllEnginesCodesAreAtMaximumTenCharsLong()
      {
        for (var i = 0; i < AmountOfEngineCodesToGenerate; i++)
          _generatedEngineCodes.Add(_dummyDataGenerator.GenerateRandomEngineCode());
        
        var engineCodesWithMoreThanTenChars = _generatedEngineCodes
          .Where(engineCode => engineCode.Length > 10)
          .ToList();

        foreach (var engineCode in engineCodesWithMoreThanTenChars)
          _testOutputHelper.WriteLine(engineCode.Length.ToString());

        engineCodesWithMoreThanTenChars.Should().HaveCount(0);
      }
    }
    
    public class WhenGeneratingColorNumbers
    {
      private const int AmountOfColorNumbersToGenerate = 1000;
      private readonly ITestOutputHelper _testOutputHelper;
      private readonly DummyDataGenerator _dummyDataGenerator;
      private readonly List<string> _generatedColorNumbers;

      public WhenGeneratingColorNumbers(ITestOutputHelper testOutputHelper)
      {
        _testOutputHelper = testOutputHelper;
        _dummyDataGenerator = new DummyDataGenerator(Seed);
        _generatedColorNumbers = new List<string>();
      }

      [Fact]
      public void AllColorNumbersAreAtLeastFiveCharsLong()
      {
        for (var i = 0; i < AmountOfColorNumbersToGenerate; i++)
          _generatedColorNumbers.Add(_dummyDataGenerator.GenerateRandomColorNumber());
        
        var colorNumbersWithLessThanFiveChars = _generatedColorNumbers
          .Where(engineCode => engineCode.Length < 5)
          .ToList();

        foreach (var colorNumber in colorNumbersWithLessThanFiveChars)
          _testOutputHelper.WriteLine(colorNumber.Length.ToString());

        colorNumbersWithLessThanFiveChars.Should().HaveCount(0);
      }

      [Fact]
      public void AllColorNumbersAreAtMaximumTenCharsLong()
      {
        for (var i = 0; i < AmountOfColorNumbersToGenerate; i++)
          _generatedColorNumbers.Add(_dummyDataGenerator.GenerateRandomColorNumber());
        
        var colorNumbersWithMoreThanTenChars = _generatedColorNumbers
          .Where(engineCode => engineCode.Length > 10)
          .ToList();

        foreach (var colorNumber in colorNumbersWithMoreThanTenChars)
          _testOutputHelper.WriteLine(colorNumber.Length.ToString());

        colorNumbersWithMoreThanTenChars.Should().HaveCount(0);
      }
    }
  }
}