namespace DummyDataGenerator.Backend
{
  internal static class Constants
  {
    internal static readonly string[] Designations =
    {
      "Dr.", "Prof."
    };

    internal static readonly string[] Streets =
    {
      "Hauptstr.", "Mühlweg", "Am Graben", "Auf dem Kirchberg", "An der Mark", "Herrenberger Str.", "Kniebisweg",
      "Max-Eyth-Str.", "Kirchweg", "Brunnengasse", "Im Gässle"
    };

    internal static readonly string[] TopLevelDomains =
    {
      "de", "com", "net", "org"
    };

    internal static readonly string[] Manufacturers =
    {
      "Mercedes", "VW", "Opel", "BMW", "Audi", "Fiat", "Porsche", "Jaguar", "Volvo", "Ford", "KIA", "Seat", "Tesla"
    };

    internal static readonly string[] Models =
    {
      "E-Klasse", "Passat", "Insignia", "Up", "Polo", "Golf", "Punto", "Escort", "Mondeo", "Fiesta", "A-Klasse",
      "Ibiza", "Kadett", "Viano", "Model S", "Leon", "A1", "A2", "A3", "A4"
    };

    internal static readonly string[] CompanyTypes =
    {
      "GmbH", "GbR", "AG", "GmbH & Co. KG"
    };

    internal static readonly int[] TaxRates =
    {
      7, 19
    };

    internal static readonly string[] TitleForArticles =
    {
      "Filter", "Luftfilter", "Ölfilter", "Reifen", "Bremsscheibe", "Bremssattel", "Achse (Vorne)", "Achse (Hinten)",
      "Motor", "Windschutzscheibe", "Hechscheibe", "Motorhaube", "Lenkrad", "Schraube", "Mutter", "Öl", "Auspuff"
    };

    internal static readonly string[] TitleForLabours =
    {
      "Reifenwechsel", "Luftfilterwechsel", "Ölfilterwechsel", "Bremsenprüfung", "Achsewechsel", "Motortausch",
      "Bremsflüssigkeitwechsel", "Ölwechsel", "Vollwäsche", "Innenreinigung", "Scheibentönung", "Auspufftausch" 
    };

    internal static readonly string[] TitleForTextBlocks =
    {
      "Danke", "Vertrauen", "Garantie", "Nächste HU", "Nächste AU", "Service fällig"
    };

    internal static readonly int[] QuantityUnitsForArticles =
    {
      1, 5, 6, 7, 8
    };

    internal static readonly int[] QuantityUnitsForLabours =
    {
      2, 3, 4
    };

    internal const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
  }
}