using System;
using System.Collections.Generic;
using System.Text;

namespace DummyDataGenerator.Frontend
{
  public record Vehicle : ISqlEntity
  {
    private Vehicle(IDummyDataGenerator ddg)
    {
      Id = ddg.GenerateRandomGuid();

      LicensePlate = ddg.GenerateRandomLicensePlate();
      Vin = ddg.GenerateRandomVin();

      Manufacturer = ddg.RandomBoolean(75) ? ddg.GenerateRandomManufacturer() : string.Empty;
      Model = ddg.RandomBoolean(75) ? ddg.GenerateRandomModel() : string.Empty;
      Mileage = ddg.RandomBoolean(95) ? ddg.GenerateRandomMileage() : 0;

      if (ddg.RandomBoolean(75))
      {
        Hsn = ddg.GenerateRandomHsn();
        Tsn = ddg.GenerateRandomTsn();
        KTypeNumber = ddg.GenerateRandomKTypeNumber();
      }
      else
      {
        Hsn = string.Empty;
        Tsn = string.Empty;
        KTypeNumber = string.Empty;
      }
    }

    public Guid Id { get; }
    private string Manufacturer { get; }
    private string Model { get; }
    private int Mileage { get; }
    private string LicensePlate { get; }
    private string Vin { get; }
    private string Hsn { get; }
    private string Tsn { get; }
    private string KTypeNumber { get; }

    public string AsInsertScript()
    {
      var sb = new StringBuilder();

      sb.Append("INSERT INTO [dbo].[Vehicles] ");
      sb.Append("([Id],");
      sb.Append("[LicensePlate],");
      sb.Append("[Vin],");
      sb.Append("[Manufacturer],");
      sb.Append("[Model],");
      sb.Append("[Hsn],");
      sb.Append("[Tsn],");
      sb.Append("[KTypeNumber],");
      sb.Append("[Mileage])");
      sb.Append(" VALUES ");
      sb.Append($"('{Id}',");
      sb.Append($"'{LicensePlate}',");
      sb.Append($"'{Vin}',");
      sb.Append($"'{Manufacturer}',");
      sb.Append($"'{Model}',");
      sb.Append($"'{Hsn}',");
      sb.Append($"'{Tsn}',");
      sb.Append($"'{KTypeNumber}',");
      sb.Append($"{Mileage})");
      sb.Append(Environment.NewLine);
      sb.Append("GO");

      return sb.ToString().Replace("''", "NULL");
    }

    public static IEnumerable<Vehicle> CreateMany(int count, IDummyDataGenerator ddg)
    {
      var vehicles = new List<Vehicle>();
      for (var i = 0; i < count; i++)
        vehicles.Add(new Vehicle(ddg));

      return vehicles;
    }
  }
}