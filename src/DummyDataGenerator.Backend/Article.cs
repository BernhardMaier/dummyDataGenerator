using System;
using System.Collections.Generic;
using System.Text;
using DummyDataGenerator.Backend.Extensions;
using DummyDataGenerator.Backend.Interfaces;

namespace DummyDataGenerator.Backend;

public class Article : ISqlEntity
{
  internal Article(IDummyDataGenerator ddg, Guid taxRateId)
  {
    Id = ddg.GenerateRandomGuid();
    Number = ddg.GenerateRandomCatalogArticleNumber();
    if (ddg.RandomBoolean(25)) OrderNumber = ddg.GenerateRandomCatalogArticleNumber();
    Title = ddg.GenerateRandomCatalogArticleTitle();
    if (ddg.RandomBoolean()) Description = ddg.GenerateRandomCatalogItemDescription();
    QuantityAmount = ddg.GenerateRandomCatalogItemQuantityAmount();
    QuantityUnit = ddg.GenerateRandomCatalogArticleQuantityUnit();
    NetPurchasePrice = ddg.GenerateRandomCatalogItemPrice();
    NetSellingPrice = NetPurchasePrice*2;
    TaxRateId = taxRateId;
  }
  
  public Guid Id { get; }
  public string Number { get; }
  public string OrderNumber { get; } = string.Empty;
  public string Title { get; }
  public string Description { get; } = string.Empty;
  public float QuantityAmount { get; }
  public int QuantityUnit { get; }
  public decimal NetPurchasePrice { get; }
  public decimal NetSellingPrice { get; }
  public Guid TaxRateId { get; }
  
  public string AsInsertScript()
  {
    var sb = new StringBuilder();

    sb.Append("INSERT INTO [dbo].[CatalogArticles] ");
    sb.Append("([Id],");
    sb.Append("[Number],");
    sb.Append("[OrderNumber],");
    sb.Append("[Title],");
    sb.Append("[Description],");
    sb.Append("[QuantityAmount],");
    sb.Append("[QuantityUnit],");
    sb.Append("[NetPurchasePrice],");
    sb.Append("[NetSellingPrice],");
    sb.Append("[TaxRateId])");
    sb.Append(" VALUES ");
    sb.Append($"('{Id}',");
    sb.Append($"{Number.ToNullableSqlString()},");
    sb.Append($"{OrderNumber.ToNullableSqlString()},");
    sb.Append($"{Title.ToNullableSqlString()},");
    sb.Append($"{Description.ToNullableSqlString()},");
    sb.Append($"{QuantityAmount},");
    sb.Append($"{QuantityUnit},");
    sb.Append($"{NetPurchasePrice},");
    sb.Append($"{NetSellingPrice},");
    sb.Append($"'{TaxRateId}')");

    return sb.ToString();
  }
  
  public static IEnumerable<Article> CreateMany(int count, IDummyDataGenerator ddg, Guid taxRateId)
  {
    var list = new List<Article>();
    for (var i = 0; i < count; i++)
      list.Add(new Article(ddg, taxRateId));

    return list;
  }
}