using System;

namespace DummyDataGeneratorConsole
{
    public interface IDummyDataGenerator
    {
        Guid GenerateRandomGuid();

        int GenerateRandomGender();
        string GenerateRandomDesignation();
        string GenerateRandomFirstName();
        string GenerateRandomLastName();
        string GenerateRandomStreet();
        string GenerateRandomHouseNumber();
        string GenerateRandomZipCode();
        string GenerateRandomCity();
        string GenerateRandomPhone();
        string GenerateRandomEmail(string name = null);

        string GenerateRandomManufacturer();
        string GenerateRandomModel();
        string GenerateRandomLicensePlate();
        string GenerateRandomVin();
        string GenerateRandomHsn();
        string GenerateRandomTsn();
        int GenerateRandomMileage();
    }
}