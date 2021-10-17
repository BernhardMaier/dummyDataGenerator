﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DummyDataGeneratorConsole
{
    public record Vehicle
    {
        public Guid Id { get; }
        public string Manufacturer { get; }
        public string Model { get; }
        public int Mileage { get; }
        public string LicensePlate { get; }
        public string Vin { get; }
        public string Hsn { get; }
        public string Tsn { get; }
        public string KTypeNumber { get; }

        public Vehicle(IDummyDataGenerator ddg)
        {
            Id = ddg.GenerateRandomGuid();
            Manufacturer = ddg.GenerateRandomManufacturer();
            Model = ddg.GenerateRandomModel();
            Mileage = ddg.GenerateRandomMileage();
            LicensePlate = ddg.GenerateRandomLicensePlate();
            Vin = ddg.GenerateRandomVin();
            Hsn = ddg.GenerateRandomHsn();
            Tsn = ddg.GenerateRandomTsn();
            KTypeNumber = ddg.GenerateRandomKTypeNumber();
        }

        public static IEnumerable<Vehicle> CreateMany(int count, IDummyDataGenerator ddg)
        {
            var vehicles = new List<Vehicle>();
            
            for (var i = 0; i < count; i++)
                vehicles.Add(new Vehicle(ddg));

            return vehicles;
        }
        
        public string AsInsertScript()
        {
            var sb = new StringBuilder();
            sb.Append($"INSERT INTO [dbo].[Vehicles]");
            sb.Append($" ( [Id]");
            sb.Append($" , [LicensePlate]");
            sb.Append($" , [Vin]");
            sb.Append($" , [Mileage]");
            sb.Append($" , [Tsn]");
            sb.Append($" , [Hsn]");
            sb.Append($" , [KTypeNumber]");
            sb.Append($" , [Model]");
            sb.Append($" , [Manufacturer])");
            sb.Append($"VALUES");
            sb.Append($" ( {Id}");
            sb.Append($" , {LicensePlate}");
            sb.Append($" , '{Vin}'");
            sb.Append($" , '{Mileage}'");
            sb.Append($" , '{Tsn}'");
            sb.Append($" , '{Hsn}'");
            sb.Append($" , '{KTypeNumber}'");
            sb.Append($" , '{Model}'");
            sb.Append($" , '{Manufacturer}')");
            sb.Append($"GO");
            sb.Append($"");

            return sb.ToString();
        }
    }
}