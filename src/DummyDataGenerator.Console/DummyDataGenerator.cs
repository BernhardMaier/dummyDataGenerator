using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;
using System;
using System.Collections.Generic;

namespace DummyDataGeneratorConsole
{
    public partial class DummyDataGenerator : IDummyDataGenerator
    {
        private readonly string vinPattern = @"^[a-zA-Z]{3}[0-9a-zA-Z]{6}[0-9a-zA-Z]{1}[0-9a-zA-Z]{1}[0-9a-zA-Z]{3}[0-9]{3}$";
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
            _vinGenerator = RandomizerFactory.GetRandomizer(new FieldOptionsTextRegex { Pattern = vinPattern });
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
        public string GenerateRandomZip() => $"{RndInt(9)}{RndInt(9)}{RndInt(9)}{RndInt(9)}{RndInt(9)}";
        public string GenerateRandomCity() => _cityGenerator.Generate();
        public string GenerateRandomPhone() => $"{RndInt(9)}{RndInt(9)}{RndInt(9)}{RndInt(9)}{RndInt(9)}";
        public string GenerateRandomEmail(string name = null) => $"{name}@{RndString(RndInt(3,5)).ToLower()}.{RndElement(TopLevelDomains)}";
        public string GenerateRandomManufacturer() => RndElement(Manufacturers);
        public string GenerateRandomModel() => RndElement(Models);
        public string GenerateRandomLicensePlate() => $"{RndString(RndInt(1,3))}-{RndString(RndInt(1,2))} {RndInt(9999)}";
        public string GenerateRandomVin() => _vinGenerator.Generate();
        public string GenerateRandomHsn() => $"{RndInt(9)}{RndInt(9)}{RndInt(9)}{RndInt(9)}";
        public string GenerateRandomTsn() => $"{RndString(3)}{RndInt(9)}{RndInt(9)}{RndInt(9)}{RndInt(9)}{RndInt(9)}";
        public string GenerateRandomKTypeNumber() => "NULL";
        public int GenerateRandomMileage() => RndInt(1000000);

        private string RndString(int count)
        {
            var str = string.Empty;
            
            for (var i = 0; i < count; i++)
                str += RndChar();

            return str;
        }
        private string RndChar() => RndElement(Chars);
        private string RndElement(IReadOnlyList<string> array) => array[RndInt(array.Count - 1)];
        private int RndInt(int max) => RndInt(0, max);
        private int RndInt(int min, int max) => _random.Next() % (max+1)+min;
    }
}