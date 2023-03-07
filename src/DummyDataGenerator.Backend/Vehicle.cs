using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using DummyDataGenerator.Backend.Extensions;
using DummyDataGenerator.Backend.Interfaces;

[assembly: InternalsVisibleTo("DummyDataGenerator.Backend.Test")]
namespace DummyDataGenerator.Backend
{
  public record Vehicle : ISqlEntity
  {
    internal Vehicle(IDummyDataGenerator ddg)
    {
      Id = ddg.GenerateRandomGuid();
      LicensePlate = ddg.GenerateRandomLicensePlate();
      
      if (ddg.RandomBoolean(75)) Vin = ddg.GenerateRandomVin();
      if (ddg.RandomBoolean(75)) Manufacturer = ddg.GenerateRandomManufacturer();
      if (ddg.RandomBoolean(75)) Model = ddg.GenerateRandomModel();

      if (ddg.RandomBoolean(75))
      {
        Hsn = ddg.GenerateRandomHsn();
        Tsn = ddg.GenerateRandomTsn();
        KTypeNumber = ddg.GenerateRandomKTypeNumber();
      }

      if (ddg.RandomBoolean(25)) EngineCode = ddg.GenerateRandomEngineCode();
      if (ddg.RandomBoolean(25)) EngineNumber = ddg.GenerateRandomEngineNumber();
      if (ddg.RandomBoolean(25)) ColorNumber = ddg.GenerateRandomColorNumber();
      if (ddg.RandomBoolean(25)) Notice = ddg.GenerateRandomNotice();
      
      NextMainInspection = ddg.RandomBoolean(33) ? ddg.GenerateRandomNextMainInspection() : "NULL";
      InitialRegistration = ddg.RandomBoolean(33) ? ddg.GenerateRandomInitialRegistration() : "NULL";
      
      if (ddg.RandomBoolean(95)) Mileage = ddg.GenerateRandomMileage();
    }

    public Guid Id { get; }
    public string Manufacturer { get; } = string.Empty;
    public string Model { get; } = string.Empty;
    public string LicensePlate { get; } = string.Empty;
    public string Vin { get; } = string.Empty;
    public string Hsn { get; } = string.Empty;
    public string Tsn { get; } = string.Empty;
    public string KTypeNumber { get; } = string.Empty;
    public string EngineCode { get; } = string.Empty;
    public string EngineNumber { get; } = string.Empty;
    public string ColorNumber { get; } = string.Empty;
    public string Notice { get; } = string.Empty;
    public string NextMainInspection { get; } = string.Empty;
    public string InitialRegistration { get; } = string.Empty;
    public int Mileage { get; }

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
      sb.Append("[EngineCode],");
      sb.Append("[EngineNumber],");
      sb.Append("[ColorNumber],");
      sb.Append("[Notice],");
      sb.Append("[NextMainInspection],");
      sb.Append("[InitialRegistration],");
      sb.Append("[Mileage])");
      sb.Append(" VALUES ");
      sb.Append($"('{Id}',");
      sb.Append($"{LicensePlate.ToNullableSqlString()},");
      sb.Append($"{Vin.ToNullableSqlString()},");
      sb.Append($"{Manufacturer.ToNullableSqlString()},");
      sb.Append($"{Model.ToNullableSqlString()},");
      sb.Append($"{Hsn.ToNotNullableSqlString()},");
      sb.Append($"{Tsn.ToNotNullableSqlString()},");
      sb.Append($"{KTypeNumber.ToNullableSqlString()},");
      sb.Append($"{EngineCode.ToNullableSqlString()},");
      sb.Append($"{EngineNumber.ToNullableSqlString()},");
      sb.Append($"{ColorNumber.ToNullableSqlString()},");
      sb.Append($"{Notice.ToNullableSqlString()},");
      sb.Append($"{NextMainInspection.ToNullableSqlCommand()},");
      sb.Append($"{InitialRegistration.ToNullableSqlCommand()},");
      sb.Append($"{Mileage})");

      return sb.ToString();
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