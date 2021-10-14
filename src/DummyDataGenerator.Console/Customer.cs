using System;
using System.Collections.Generic;

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
        public string ZipCode { get; }
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
            ZipCode = ddg.GenerateRandomZipCode();
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
    }
}