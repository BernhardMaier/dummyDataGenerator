using System;
using System.Collections.Generic;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;

namespace DummyDataGenerator.Console
{
    public partial class DummyDataGenerator : IDummyDataGenerator
    {
        private const string VinPattern = @"^[A-Z]{3}[0-9A-Z]{6}[0-9A-Z]{1}[0-9A-Z]{1}[0-9A-Z]{3}[0-9]{3}$";
        private readonly Random _random;
        private readonly IRandomizerString _vinGenerator;
        private readonly IRandomizerString _firstNameGenerator;
        private readonly IRandomizerString _lastNameGenerator;
        private readonly IRandomizerString _cityGenerator;
        public int Seed { get; }

        public DummyDataGenerator(int seed)
        {
            Seed = seed;
            _random = new Random(Seed);
            _vinGenerator = RandomizerFactory.GetRandomizer(new FieldOptionsTextRegex { Pattern = VinPattern });
            _firstNameGenerator = RandomizerFactory.GetRandomizer(new FieldOptionsFirstName());
            _lastNameGenerator = RandomizerFactory.GetRandomizer(new FieldOptionsLastName());
            _cityGenerator = RandomizerFactory.GetRandomizer(new FieldOptionsCity());
        }

        public Guid GenerateRandomGuid() => Guid.NewGuid();
        public int GenerateRandomGender() => RndInt(2);
        public string GenerateRandomDesignation() => RndElement(Designations);
        public string GenerateRandomFirstName() => _firstNameGenerator.Generate();
        public string GenerateRandomLastName() => _lastNameGenerator.Generate();
        public string GenerateRandomStreet() => RndElement(Streets);
        public string GenerateRandomHouseNumber() => RndInt(100).ToString();
        public string GenerateRandomZip() => $"{RndIntString(5)}";
        public string GenerateRandomCity() => _cityGenerator.Generate();
        public string GenerateRandomPhone() => $"{RndIntString(5)}/{RndIntString(5)}";
        public string GenerateRandomEmail(string name = null) => $"{name}@{RndCharString(RndInt(3,5)).ToLower()}.{RndElement(TopLevelDomains)}";
        public string GenerateRandomManufacturer() => RndElement(Manufacturers);
        public string GenerateRandomModel() => RndElement(Models);
        public string GenerateRandomLicensePlate() => $"{RndCharString(RndInt(1,2))}-{RndCharString(RndInt(1,2))} {RndInt(999)}";
        public string GenerateRandomVin() => _vinGenerator.Generate();
        public string GenerateRandomHsn() => $"{RndIntString(4)}";
        public string GenerateRandomTsn() => $"{RndCharString(3)}{RndIntString(5)}";
        public string GenerateRandomKTypeNumber() => $"{RndIntString(5)}";
        public int GenerateRandomMileage() => RndInt(200000);
        private string RndCharString(int count)
        {
            var str = string.Empty;
            
            for (var i = 0; i < count; i++)
                str += RndChar();

            return str;
        }
        private string RndIntString(int count)
        {
            var str = string.Empty;
            
            for (var i = 0; i < count; i++)
                str += RndInt(9);

            return str;
        }
        private char RndChar() => Chars[RndInt(0, Chars.Length-1)];
        private string RndElement(IReadOnlyList<string> array) => array[RndInt(array.Count - 1)];
        private int RndInt(int max) => RndInt(0, max);
        private int RndInt(int min, int max) => _random.Next() % max + min;
    }
}