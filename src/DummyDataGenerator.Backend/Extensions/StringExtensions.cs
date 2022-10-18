namespace DummyDataGenerator.Backend.Extensions
{
  public static class StringExtensions
  {
    public static string ToNullableSqlString(this string value) =>
      string.IsNullOrWhiteSpace(value) ? "NULL" : $"'{value}'";
    
    public static string ToNotNullableSqlString(this string value) =>
      string.IsNullOrWhiteSpace(value) ? "''" : $"'{value}'";
    
    public static string ToNullableSqlCommand(this string value) =>
      string.IsNullOrWhiteSpace(value) ? "NULL" : value;
  }
}