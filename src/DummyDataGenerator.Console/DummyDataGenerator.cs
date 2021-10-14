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
            throw new NotImplementedException();
        }

        public int GenerateRandomGender()
        {
            throw new NotImplementedException();
        }

        public string GenerateRandomDesignation()
        {
            throw new NotImplementedException();
        }

        public string GenerateRandomFirstName()
        {
            throw new NotImplementedException();
        }

        public string GenerateRandomLastName()
        {
            throw new NotImplementedException();
        }

        public string GenerateRandomStreet()
        {
            throw new NotImplementedException();
        }

        public string GenerateRandomHouseNumber()
        {
            throw new NotImplementedException();
        }

        public string GenerateRandomZipCode()
        {
            throw new NotImplementedException();
        }

        public string GenerateRandomCity()
        {
            throw new NotImplementedException();
        }

        public string GenerateRandomPhone()
        {
            throw new NotImplementedException();
        }

        public string GenerateRandomEmail(string name = null)
        {
            throw new NotImplementedException();
        }

        public string GenerateRandomManufacturer()
        {
            throw new NotImplementedException();
        }

        public string GenerateRandomModel()
        {
            throw new NotImplementedException();
        }

        public string GenerateRandomLicensePlate()
        {
            throw new NotImplementedException();
        }

        public string GenerateRandomVin()
        {
            throw new NotImplementedException();
        }

        public string GenerateRandomHsn()
        {
            throw new NotImplementedException();
        }

        public string GenerateRandomTsn()
        {
            throw new NotImplementedException();
        }

        public int GenerateRandomMileage()
        {
            throw new NotImplementedException();
        }
    }
}