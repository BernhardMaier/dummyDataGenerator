using System;
using System.Collections.Generic;
using System.Text;

namespace DummyDataGenerator.Console
{
    public record Vehicle : ISqlEntity
    {
        public Guid Id { get; }
        private string Manufacturer { get; }
        private string Model { get; }
        private int Mileage { get; }
        private string LicensePlate { get; }
        private string Vin { get; }
        private string Hsn { get; }
        private string Tsn { get; }
        private string KTypeNumber { get; }

        private Vehicle(IDummyDataGenerator ddg)
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

            sb.Append($"INSERT INTO [dbo].[Vehicles] ");
            sb.Append($"([Id],");
            sb.Append($"[LicensePlate],");
            sb.Append($"[Vin],");
            sb.Append($"[Manufacturer],");
            sb.Append($"[Model],");
            sb.Append($"[Hsn],");
            sb.Append($"[Tsn],");
            sb.Append($"[KTypeNumber],");
            sb.Append($"[Mileage])");
            sb.Append($" VALUES ");
            sb.Append($"({Id},");
            sb.Append($"'{LicensePlate}',");
            sb.Append($"'{Vin}',");
            sb.Append($"'{Manufacturer}',");
            sb.Append($"'{Model}',");
            sb.Append($"'{Hsn}',");
            sb.Append($"'{Tsn}',");
            sb.Append($"'{KTypeNumber}',");
            sb.Append($"{Mileage})");
            sb.Append($" GO");

            return sb.ToString();
        }
    }
}