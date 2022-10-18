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
    string GenerateRandomOrganizationName();
    string GenerateRandomStreet();
    string GenerateRandomHouseNumber();
    string GenerateRandomZip();
    string GenerateRandomCity();
    string GenerateRandomPhone();
    string GenerateRandomEmail(string name);
    int GenerateRandomTimeForPaymentInDays();

    string GenerateRandomManufacturer();
    string GenerateRandomModel();
    string GenerateRandomLicensePlate();
    string GenerateRandomVin();
    string GenerateRandomHsn();
    string GenerateRandomTsn();
    string GenerateRandomKTypeNumber();
    string GenerateRandomEngineCode();
    string GenerateRandomColorNumber();
    string GenerateRandomNextMainInspection();
    string GenerateRandomInitialRegistration();
    int GenerateRandomMileage();

    string GenerateRandomNotice();

    bool RandomBoolean(byte probabilityForTrue = 50);
  }
}