using System.Collections.Generic;

namespace DummyDataGeneratorConsole
{
    public static class SqlHandler
    {
        public static string CreateScript(
            IEnumerable<Customer> customers,
            IEnumerable<Vehicle> vehicles,
            IEnumerable<Connection> connections)
        {
            return "";
        }

        public static void SaveScript(string path, string content)
        {
            
        }
    }
}