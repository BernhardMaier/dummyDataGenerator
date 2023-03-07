using System;
using System.Collections.Generic;
using System.Text;
using DummyDataGenerator.Backend.Extensions;
using DummyDataGenerator.Backend.Interfaces;

namespace DummyDataGenerator.Backend;

public class TaxRate : ISqlEntity
{
  internal TaxRate(IDummyDataGenerator ddg)
  {
    Id = ddg.GenerateRandomGuid();
    Rate = ddg.GenerateRandomTaxRateRate();
    if (ddg.RandomBoolean(15)) Description = ddg.GenerateRandomTaxRateDescription();
    if (ddg.RandomBoolean(5)) AccountNumber = ddg.GenerateRandomTaxRateAccountNumber();
    if (ddg.RandomBoolean(5)) TaxCode = ddg.GenerateRandomTaxRateTaxCode();
  }
  
  public Guid Id { get; }
  public decimal Rate { get; }
  public string Description { get; } = string.Empty;
  public string AccountNumber { get; } = string.Empty;
  public string TaxCode { get; } = string.Empty;
  
  public string AsInsertScript()
  {
    var sb = new StringBuilder();

    sb.Append("INSERT INTO [dbo].[TaxRates] ");
    sb.Append("([Id],");
    sb.Append("[Rate],");
    sb.Append("[Description],");
    sb.Append("[AccountNumber],");
    sb.Append("[TaxCode])");
    sb.Append(" VALUES ");
    sb.Append($"('{Id}',");
    sb.Append($"{Rate},");
    sb.Append($"{Description.ToNullableSqlString()},");
    sb.Append($"{AccountNumber.ToNullableSqlString()},");
    sb.Append($"{TaxCode.ToNullableSqlString()})");

    return sb.ToString();
  }
  
  public static IEnumerable<TaxRate> CreateMany(int count, IDummyDataGenerator ddg)
  {
    var list = new List<TaxRate>();
    for (var i = 0; i < count; i++)
      list.Add(new TaxRate(ddg));

    return list;
  }
}