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
    string GenerateRandomEngineNumber();
    string GenerateRandomColorNumber();
    string GenerateRandomNextMainInspection();
    string GenerateRandomInitialRegistration();
    int GenerateRandomMileage();

    string GenerateRandomNotice();

    int GenerateRandomTaxRateRate();
    string GenerateRandomTaxRateDescription();
    string GenerateRandomTaxRateAccountNumber();
    string GenerateRandomTaxRateTaxCode();

    string GenerateRandomCatalogArticleNumber();
    string GenerateRandomCatalogLabourNumber();
    string GenerateRandomCatalogTextBlockNumber();
    string GenerateRandomCatalogArticleTitle();
    string GenerateRandomCatalogLabourTitle();
    string GenerateRandomCatalogTextBlockTitle();
    string GenerateRandomCatalogItemDescription();
    int GenerateRandomCatalogItemQuantityAmount();
    int GenerateRandomCatalogArticleQuantityUnit();
    int GenerateRandomCatalogLabourQuantityUnit();
    int GenerateRandomCatalogItemPrice();

    bool RandomBoolean(byte probabilityForTrue = 50);
  }
}