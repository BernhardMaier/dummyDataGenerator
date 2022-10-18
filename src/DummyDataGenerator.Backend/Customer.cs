using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using DummyDataGenerator.Backend.Extensions;
using DummyDataGenerator.Backend.Interfaces;

[assembly: InternalsVisibleTo("DummyDataGenerator.Backend.Test")]
namespace DummyDataGenerator.Backend
{
  public record Customer : ISqlEntity
  {
    internal Customer(IDummyDataGenerator ddg)
    {
      Id = ddg.GenerateRandomGuid();

      string nameForEmail;
      if (ddg.RandomBoolean(90))
      {
        Gender = ddg.GenerateRandomGender();
        Designation = ddg.RandomBoolean(10) ? ddg.GenerateRandomDesignation() : string.Empty;
        FirstName = ddg.GenerateRandomFirstName();
        LastName = ddg.GenerateRandomLastName();
        nameForEmail = $"{FirstName}.{LastName}";
      }
      else
      {
        OrganizationName = ddg.GenerateRandomOrganizationName();
        nameForEmail = Regex.Replace(OrganizationName, "[ .&]", "");
      }
      
      if (ddg.RandomBoolean(75))
      {
        Street = ddg.GenerateRandomStreet();
        HouseNumber = ddg.GenerateRandomHouseNumber();
        Zip = ddg.GenerateRandomZip();
        City = ddg.GenerateRandomCity();
      }

      if (ddg.RandomBoolean(75)) Phone = ddg.GenerateRandomPhone();
      if (ddg.RandomBoolean(75)) Email = ddg.GenerateRandomEmail(nameForEmail);

      TimeForPaymentInDays = ddg.GenerateRandomTimeForPaymentInDays();

      if (ddg.RandomBoolean(25)) Notice = ddg.GenerateRandomNotice();
    }

    public Guid Id { get; }
    public int Gender { get; }
    public string Designation { get; } = string.Empty;
    public string FirstName { get; } = string.Empty;
    public string LastName { get; } = string.Empty;
    public string OrganizationName { get; } = string.Empty;
    public string Street { get; } = string.Empty;
    public string HouseNumber { get; } = string.Empty;
    public string Zip { get; } = string.Empty;
    public string City { get; } = string.Empty;
    public string Phone { get; } = string.Empty;
    public string Email { get; } = string.Empty;
    public int TimeForPaymentInDays { get; }
    public string Notice { get; } = string.Empty;

    public string AsInsertScript()
    {
      var sb = new StringBuilder();

      sb.Append("INSERT INTO [dbo].[Customers] ");
      sb.Append("([Id],");
      sb.Append("[Gender],");
      sb.Append("[Designation],");
      sb.Append("[FirstName],");
      sb.Append("[LastName],");
      sb.Append("[OrganizationName],");
      sb.Append("[Street],");
      sb.Append("[HouseNumber],");
      sb.Append("[Zip],");
      sb.Append("[City],");
      sb.Append("[Phone],");
      sb.Append("[Email],");
      sb.Append("[TimeForPaymentInDays],");
      sb.Append("[Notice])");
      sb.Append(" VALUES ");
      sb.Append($"('{Id}',");
      sb.Append($"{Gender},");
      sb.Append($"{Designation.ToNullableSqlString()},");
      sb.Append($"{FirstName.ToNullableSqlString()},");
      sb.Append($"{LastName.ToNullableSqlString()},");
      sb.Append($"{OrganizationName.ToNullableSqlString()},");
      sb.Append($"{Street.ToNullableSqlString()},");
      sb.Append($"{HouseNumber.ToNullableSqlString()},");
      sb.Append($"{Zip.ToNullableSqlString()},");
      sb.Append($"{City.ToNullableSqlString()},");
      sb.Append($"{Phone.ToNullableSqlString()},");
      sb.Append($"{Email.ToNullableSqlString()},");
      sb.Append($"{TimeForPaymentInDays},");
      sb.Append($"{Notice.ToNullableSqlString()})");

      return sb.ToString();
    }

    public static IEnumerable<Customer> CreateMany(int count, IDummyDataGenerator ddg)
    {
      var customers = new List<Customer>();
      for (var i = 0; i < count; i++)
        customers.Add(new Customer(ddg));

      return customers;
    }
  }
}