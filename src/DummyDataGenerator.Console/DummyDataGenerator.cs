﻿using System;
using System.Collections.Generic;

namespace DummyDataGeneratorConsole
{
    public partial class DummyDataGenerator : IDummyDataGenerator
    {
        private readonly Random _random;
        public int Seed { get; }

        public DummyDataGenerator(int seed)
        {
            Seed = seed;
            _random = new Random(Seed);
        }

        public Guid GenerateRandomGuid() => Guid.NewGuid();
        public int GenerateRandomGender() => RndInt(2);
        public string GenerateRandomDesignation() => RndElement(Designations);
        public string GenerateRandomFirstName() => RndElement(FirstNames);
        public string GenerateRandomLastName() => RndElement(LastNames);
        public string GenerateRandomStreet() => RndElement(Streets);
        public string GenerateRandomHouseNumber() => RndInt(100).ToString();
        public string GenerateRandomZip() => $"{RndInt(9)}{RndInt(9)}{RndInt(9)}{RndInt(9)}{RndInt(9)}";
        public string GenerateRandomCity() => RndElement(Cities);
        public string GenerateRandomPhone() => $"{RndInt(9)}{RndInt(9)}{RndInt(9)}{RndInt(9)}{RndInt(9)}";
        public string GenerateRandomEmail(string name = null) => $"{name}@{RndString(RndInt(3,5)).ToLower()}.{RndElement(TopLevelDomains)}";
        public string GenerateRandomManufacturer() => RndElement(Manufacturers);
        public string GenerateRandomModel() => RndElement(Models);
        public string GenerateRandomLicensePlate() => $"{RndString(RndInt(1,3))}-{RndString(RndInt(1,2))} {RndInt(9999)}";
        public string GenerateRandomVin() => "NULL";
        public string GenerateRandomHsn() => "NULL";
        public string GenerateRandomTsn() => "NULL";
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