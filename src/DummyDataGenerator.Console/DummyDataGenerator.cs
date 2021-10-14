using System;

namespace DummyDataGeneratorConsole
{
    public class DummyDataGenerator : IDummyDataGenerator
    {
        private readonly Random _random;
        public int Seed { get; }

        public DummyDataGenerator(int seed)
        {
            Seed = seed;
            _random = new Random(Seed);
        }

        public Guid GenerateRandomGuid()
        {
            return new Guid(_random.Next().ToString());
        }

        public int GenerateRandomGender()
        {
            return _random.Next() % 3;
        }

        public string GenerateRandomDesignation()
        {
            var values = new[] { null, "Dr.", "Prof." };
            return values[_random.Next() % 3];
        }

        public string GenerateRandomFirstName()
        {
            var values = new[] { "Ben", "Peter", "Jens" };
            return values[_random.Next() % 3];
        }

        public string GenerateRandomLastName()
        {
            var values = new[] { "Müller", "Maier", "Schuster" };
            return values[_random.Next() % 3];
        }

        public string GenerateRandomStreet()
        {
            var values = new[] { "Hauptstr.", "Mühlweg", "Am Graben" };
            return values[_random.Next() % 3];
        }

        public string GenerateRandomHouseNumber()
        {
            return (_random.Next() % 100).ToString();
        }

        public string GenerateRandomZipCode()
        {
            return $"{_random.Next() % 10}{_random.Next() % 10}{_random.Next() % 10}{_random.Next() % 10}{_random.Next() % 10}";
        }

        public string GenerateRandomCity()
        {
            var values = new[] { "Stuttgart", "Holzgerlingen", "Calw" };
            return values[_random.Next() % 3];
        }

        public string GenerateRandomPhone()
        {
            return $"{_random.Next() % 10}{_random.Next() % 10}{_random.Next() % 10}{_random.Next() % 10}{_random.Next() % 10}";
        }

        public string GenerateRandomEmail(string name = null)
        {
            var values = new[] { "de", "com", "net" };
            return $"{name}@xyz.{values[_random.Next() % 3]}";
        }

        public string GenerateRandomManufacturer()
        {
            var values = new[] { "Mercedes", "VW", "Opel" };
            return values[_random.Next() % 3];
        }

        public string GenerateRandomModel()
        {
            var values = new[] { "E-Klasse", "Passat", "Insignia" };
            return values[_random.Next() % 3];
        }

        public string GenerateRandomLicensePlate()
        {
            var values1 = new[] { "S", "BB", "CW" };
            var values2 = new[] { "AM", "XX", "SB" };
            return $"{values1[_random.Next() % 3]}-{values2[_random.Next() % 3]} {(_random.Next() % 9999)+1}";
        }

        public string GenerateRandomVin()
        {
            return "sample-vin";
        }

        public string GenerateRandomHsn()
        {
            return "sample-hsn";
        }

        public string GenerateRandomTsn()
        {
            return "sample-tsn";
        }

        public int GenerateRandomMileage()
        {
            return _random.Next();
        }
    }
}