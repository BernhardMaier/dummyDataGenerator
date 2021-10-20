using System;
using System.Collections.Generic;
using System.Text;
using DummyDataGenerator.Frontend.Interfaces;

namespace DummyDataGenerator.Frontend
{
  public record Customer : ISqlEntity
  {
    private Customer(IDummyDataGenerator ddg)
    {
      Id = ddg.GenerateRandomGuid();

      Gender = ddg.GenerateRandomGender();
      Designation = ddg.RandomBoolean(10) ? ddg.GenerateRandomDesignation() : string.Empty;
      FirstName = ddg.GenerateRandomFirstName();
      LastName = ddg.GenerateRandomLastName();

      if (ddg.RandomBoolean(75))
      {
        Street = ddg.GenerateRandomStreet();
        HouseNumber = ddg.GenerateRandomHouseNumber();
        Zip = ddg.GenerateRandomZip();
        City = ddg.GenerateRandomCity();
      }
      else
      {
        Street = string.Empty;
        HouseNumber = string.Empty;
        Zip = string.Empty;
        City = string.Empty;
      }

      Phone = ddg.RandomBoolean(75) ? ddg.GenerateRandomPhone() : string.Empty;
      Email = ddg.RandomBoolean(75) ? ddg.GenerateRandomEmail($"{FirstName}.{LastName}") : string.Empty;
    }

    public Guid Id { get; }
    private int Gender { get; }
    private string Designation { get; }
    private string FirstName { get; }
    private string LastName { get; }
    private string Street { get; }
    private string HouseNumber { get; }
    private string Zip { get; }
    private string City { get; }
    private string Phone { get; }
    private string Email { get; }

    public string AsInsertScript()
    {
      var sb = new StringBuilder();

      sb.Append("INSERT INTO [dbo].[Customers] ");
      sb.Append("([Id],");
      sb.Append("[Gender],");
      sb.Append("[Designation],");
      sb.Append("[FirstName],");
      sb.Append("[LastName],");
      sb.Append("[Street],");
      sb.Append("[HouseNumber],");
      sb.Append("[Zip],");
      sb.Append("[City],");
      sb.Append("[Phone],");
      sb.Append("[Email])");
      sb.Append(" VALUES ");
      sb.Append($"('{Id}',");
      sb.Append($"{Gender},");
      sb.Append($"'{Designation}',");
      sb.Append($"'{FirstName}',");
      sb.Append($"'{LastName}',");
      sb.Append($"'{Street}',");
      sb.Append($"'{HouseNumber}',");
      sb.Append($"'{Zip}',");
      sb.Append($"'{City}',");
      sb.Append($"'{Phone}',");
      sb.Append($"'{Email}')");
      sb.Append(Environment.NewLine);
      sb.Append("GO");

      return sb.ToString().Replace("''", "NULL");
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