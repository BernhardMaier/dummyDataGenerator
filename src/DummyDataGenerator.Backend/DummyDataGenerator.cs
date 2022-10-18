using System;
using System.Collections.Generic;
using DummyDataGenerator.Backend.Interfaces;
using NLipsum.Core;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;

namespace DummyDataGenerator.Backend
{
  public class DummyDataGenerator : IDummyDataGenerator
  {
    private readonly Random _random;
    private const string VinPattern = @"^[A-Z]{3}[0-9A-Z]{6}[0-9A-Z]{1}[0-9A-Z]{1}[0-9A-Z]{3}[0-9]{3}$";
    private readonly IRandomizerString _vinGenerator;
    private readonly IRandomizerString _firstNameGenerator;
    private readonly IRandomizerString _lastNameGenerator;
    private readonly IRandomizerString _cityGenerator;
    private readonly LipsumGenerator _textGenerator;

    public DummyDataGenerator(int seed)
    {
      Seed = seed;
      _random = new Random(Seed);
      _vinGenerator = RandomizerFactory.GetRandomizer(new FieldOptionsTextRegex { Pattern = VinPattern });
      _firstNameGenerator = RandomizerFactory.GetRandomizer(new FieldOptionsFirstName());
      _lastNameGenerator = RandomizerFactory.GetRandomizer(new FieldOptionsLastName());
      _cityGenerator = RandomizerFactory.GetRandomizer(new FieldOptionsCity());
      _textGenerator = new LipsumGenerator();
    }

    public int Seed { get; }

    public Guid GenerateRandomGuid() => Guid.NewGuid();
    public int GenerateRandomGender() => RndInt(2);
    public string GenerateRandomDesignation() => RndElement(Constants.Designations);
    public string GenerateRandomFirstName() => _firstNameGenerator.Generate();
    public string GenerateRandomLastName() => _lastNameGenerator.Generate().Replace("'", "");
    public string GenerateRandomOrganizationName() => $"{_lastNameGenerator.Generate().Replace("'", "")} {RndElement(Constants.CompanyTypes)}";
    public string GenerateRandomStreet() => RndElement(Constants.Streets);
    public string GenerateRandomHouseNumber() => RndInt(100).ToString();
    public string GenerateRandomZip() => $"{RndIntString(5)}";
    public string GenerateRandomCity() => _cityGenerator.Generate();
    public string GenerateRandomPhone() => $"{RndIntString(5)} / {RndIntString(5)}";
    public string GenerateRandomEmail(string name) => $"{name}@{RndCharString(3, 5).ToLower()}.{RndElement(Constants.TopLevelDomains)}";
    public int GenerateRandomTimeForPaymentInDays() => RndInt(0, 30);
    public string GenerateRandomManufacturer() => RndElement(Constants.Manufacturers);
    public string GenerateRandomModel() => RndElement(Constants.Models);
    public string GenerateRandomLicensePlate() => $"{RndCharString(1, 2)}-{RndCharString(1, 2)} {RndInt(999)}";
    public string GenerateRandomVin() => _vinGenerator.Generate();
    public string GenerateRandomHsn() => $"{RndIntString(4)}";
    public string GenerateRandomTsn() => $"{RndCharString(3)}{RndIntString(5)}";
    public string GenerateRandomKTypeNumber() => $"{RndIntString(5)}";
    public string GenerateRandomEngineCode() => RndString(RndInt(5, 10));
    public string GenerateRandomColorNumber() => RndString(RndInt(5, 10));
    public string GenerateRandomNextMainInspection() => RndDateInFuture(RndInt(0, 265));
    public string GenerateRandomInitialRegistration() => RndDateInPast(RndInt(0, 3650));
    public int GenerateRandomMileage() => RndInt(200000);
    
    public string GenerateRandomNotice() => RndText(RndInt(20, 255));
    public bool RandomBoolean(byte probabilityForTrue = 50) => RndInt(100) >= 100 - probabilityForTrue;

    private string RndText(int maxLength)
    {
      var words = _textGenerator.GenerateWords(100);
      var text = string.Join(' ', words);
      return text[..Math.Min(text.Length, maxLength)];
    }
    
    private string RndString(int length)
    {
      var str = string.Empty;
      for (var i = 0; i < length; i++)
        str += RandomBoolean() ? RndChar() : RndInt(9).ToString();
      return str;
    }

    private string RndCharString(int min, int max) => RndCharString(RndInt(min, max));
    private string RndCharString(int length)
    {
      var str = string.Empty;
      for (var i = 0; i < length; i++)
        str += RndChar();
      return str;
    }

    private string RndIntString(int length)
    {
      var str = string.Empty;
      for (var i = 0; i < length; i++)
        str += RndInt(9);
      return str;
    }

    private static string RndDateInFuture(int daysToAdd) => $"GETDATE()+{daysToAdd}"; 
    private static string RndDateInPast(int daysToSubtract) => $"GETDATE()-{daysToSubtract}"; 
    private char RndChar() => Constants.Chars[RndInt(Constants.Chars.Length-1)];
    private string RndElement(IReadOnlyList<string> array) => array[RndInt(array.Count-1)];
    private int RndInt(int max) => RndInt(0, max);
    private int RndInt(int min, int max) => _random.Next(min, max+1);
  }
}