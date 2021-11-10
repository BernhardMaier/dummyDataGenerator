using System;

namespace DummyDataGenerator.Backend.Interfaces
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
    string GenerateRandomZip();
    string GenerateRandomCity();
    string GenerateRandomPhone();
    string GenerateRandomEmail(string name = null);
    int GenerateRandomTimeForPaymentInDays();

    string GenerateRandomManufacturer();
    string GenerateRandomModel();
    string GenerateRandomLicensePlate();
    string GenerateRandomVin();
    string GenerateRandomHsn();
    string GenerateRandomTsn();
    string GenerateRandomKTypeNumber();
    int GenerateRandomMileage();

    bool RandomBoolean(byte probabilityForTrue = 50);
  }
}