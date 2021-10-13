using System;

namespace DummyDataGeneratorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Customer
    {

    }

    public class Vehicle
    {

    }

    public class Connection
    {
        
    }

    public interface IDummyDataGenerator
    {
        string GenerateRandomGuid();
        int GenerateRandomGender();
        string GenerateRandomDesignation();
        string GenerateRandomFirstName();
        string GenerateRandomLastName();
        string GenerateRandomStreet();
        string GenerateRandomHouseNumber();
        string GenerateRandomZipCode();
        string GenerateRandomCity();
        string GenerateRandomPhone();
        string GenerateRandomEmail();
        string GenerateRandomManufacturer();
        string GenerateRandomModel();
        string GenerateRandomLicensePlate();
        string GenerateRandomVin();
        string GenerateRandomHsn();
        string GenerateRandomTsn();
        int GenerateRandomMilage();
    }

    public class DummyDataGenerator : IDummyDataGenerator
    {

    }
}
