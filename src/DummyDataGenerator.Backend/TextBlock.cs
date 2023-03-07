using System;
using System.Collections.Generic;
using System.Text;
using DummyDataGenerator.Backend.Extensions;
using DummyDataGenerator.Backend.Interfaces;

namespace DummyDataGenerator.Backend;

public class TextBlock : ISqlEntity
{
  internal TextBlock(IDummyDataGenerator ddg)
  {
    Id = ddg.GenerateRandomGuid();
    Number = ddg.GenerateRandomCatalogTextBlockNumber();
    Title = ddg.GenerateRandomCatalogTextBlockTitle();
    if (ddg.RandomBoolean()) Description = ddg.GenerateRandomCatalogItemDescription();
  }
  
  public Guid Id { get; }
  public string Number { get; }
  public string Title { get; }
  public string Description { get; } = string.Empty;
  
  public string AsInsertScript()
  {
    var sb = new StringBuilder();

    sb.Append("INSERT INTO [dbo].[CatalogTextBlocks] ");
    sb.Append("([Id],");
    sb.Append("[Number],");
    sb.Append("[Title],");
    sb.Append("[Description])");
    sb.Append(" VALUES ");
    sb.Append($"('{Id}',");
    sb.Append($"{Number.ToNullableSqlString()},");
    sb.Append($"{Title.ToNullableSqlString()},");
    sb.Append($"{Description.ToNullableSqlString()})");

    return sb.ToString();
  }
  
  public static IEnumerable<TextBlock> CreateMany(int count, IDummyDataGenerator ddg)
  {
    var list = new List<TextBlock>();
    for (var i = 0; i < count; i++)
      list.Add(new TextBlock(ddg));

    return list;
  }
}