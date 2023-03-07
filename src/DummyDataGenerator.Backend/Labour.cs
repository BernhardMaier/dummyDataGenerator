using System;
using System.Collections.Generic;
using System.Text;
using DummyDataGenerator.Backend.Extensions;
using DummyDataGenerator.Backend.Interfaces;

namespace DummyDataGenerator.Backend;

public class Labour : ISqlEntity
{
  internal Labour(IDummyDataGenerator ddg, Guid taxRateId)
  {
    Id = ddg.GenerateRandomGuid();
    Number = ddg.GenerateRandomCatalogLabourNumber();
    Title = ddg.GenerateRandomCatalogLabourTitle();
    if (ddg.RandomBoolean()) Description = ddg.GenerateRandomCatalogItemDescription();
    QuantityAmount = ddg.GenerateRandomCatalogItemQuantityAmount();
    QuantityUnit = ddg.GenerateRandomCatalogLabourQuantityUnit();
    NetPrice = ddg.GenerateRandomCatalogItemPrice();
    TaxRateId = taxRateId;
  }
  
  public Guid Id { get; }
  public string Number { get; }
  public string Title { get; }
  public string Description { get; } = string.Empty;
  public float QuantityAmount { get; }
  public int QuantityUnit { get; }
  public decimal NetPrice { get; }
  public Guid TaxRateId { get; }
  
  public string AsInsertScript()
  {
    var sb = new StringBuilder();

    sb.Append("INSERT INTO [dbo].[CatalogLabours] ");
    sb.Append("([Id],");
    sb.Append("[Number],");
    sb.Append("[Title],");
    sb.Append("[Description],");
    sb.Append("[QuantityAmount],");
    sb.Append("[QuantityUnit],");
    sb.Append("[NetPrice],");
    sb.Append("[TaxRateId])");
    sb.Append(" VALUES ");
    sb.Append($"('{Id}',");
    sb.Append($"{Number.ToNullableSqlString()},");
    sb.Append($"{Title.ToNullableSqlString()},");
    sb.Append($"{Description.ToNullableSqlString()},");
    sb.Append($"{QuantityAmount},");
    sb.Append($"{QuantityUnit},");
    sb.Append($"{NetPrice},");
    sb.Append($"'{TaxRateId}')");

    return sb.ToString();
  }
  
  public static IEnumerable<Labour> CreateMany(int count, IDummyDataGenerator ddg, Guid taxRateId)
  {
    var list = new List<Labour>();
    for (var i = 0; i < count; i++)
      list.Add(new Labour(ddg, taxRateId));

    return list;
  }
}