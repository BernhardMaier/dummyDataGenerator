using System;
using System.Collections.Generic;
using System.Text;

namespace DummyDataGeneratorConsole
{
    public record Customer
    {
        public Guid Id { get; }
        public int Gender { get; }
        public string Designation { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Street { get; }
        public string HouseNumber { get; }
        public string Zip { get; }
        public string City { get; }
        public string Phone { get; }
        public string Email { get; }

        public Customer(IDummyDataGenerator ddg)
        {
            Id = ddg.GenerateRandomGuid();
            Gender = ddg.GenerateRandomGender();
            Designation = ddg.GenerateRandomDesignation();
            FirstName = ddg.GenerateRandomFirstName();
            LastName = ddg.GenerateRandomLastName();
            Street = ddg.GenerateRandomStreet();
            HouseNumber = ddg.GenerateRandomHouseNumber();
            Zip = ddg.GenerateRandomZip();
            City = ddg.GenerateRandomCity();
            Phone = ddg.GenerateRandomPhone();
            Email = ddg.GenerateRandomEmail($"{FirstName}.{LastName}");
        }

        public static IEnumerable<Customer> CreateMany(int count, IDummyDataGenerator ddg)
        {
            var customers = new List<Customer>();
            
            for (var i = 0; i < count; i++)
                customers.Add(new Customer(ddg));

            return customers;
        }

        public string AsInsertScript()
        {
            var sb = new StringBuilder();
            sb.Append($"INSERT INTO [dbo].[Customers] ");
            sb.Append($"([Id],");
            sb.Append($"[Gender],");
            sb.Append($"[Designation],");
            sb.Append($"[FirstName],");
            sb.Append($"[LastName],");
            sb.Append($"[Street],");
            sb.Append($"[HouseNumber],");
            sb.Append($"[Zip],");
            sb.Append($"[City],");
            sb.Append($"[Phone],");
            sb.Append($"[Email])");
            sb.Append($" VALUES ");
            sb.Append($"({Id},");
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
            sb.Append($" GO");

            return sb.ToString();
        }
    }
}