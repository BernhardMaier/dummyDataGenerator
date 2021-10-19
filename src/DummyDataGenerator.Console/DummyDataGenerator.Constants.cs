namespace DummyDataGeneratorConsole
{
    public partial class DummyDataGenerator
    {
        private static readonly string[] Designations =
        {
            null, null, null, null, null, null, null, null, "Dr.", "Prof."
        };

        private static readonly string[] Streets =
        {
            "Hauptstr.", "Mühlweg", "Am Graben", "Auf dem Kirchberg", "An der Mark", "Herrenberger Str.", "Kniebisweg",
            "Max-Eyth-Str.", "Kirchweg", "Brunnengasse", "Im Gässle"
        };

        private static readonly string[] TopLevelDomains =
        {
            "de", "com", "net", "org"
        };

        private static readonly string[] Manufacturers =
        {
            "Mercedes", "VW", "Opel", "BMW", "Audi", "Fiat", "Porsche", "Jaguar", "Volvo", "Ford"
        };

        private static readonly string[] Models =
        {
            "E-Klasse", "Passat", "Insignia", "Up", "Polo", "Golf"
        };

        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    }
}