using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DummyDataGenerator.Console
{
    public static class SqlHandler
    {
        public static string[] CreateScript(
            IEnumerable<Customer> customers,
            IEnumerable<Vehicle> vehicles,
            IEnumerable<Connection> connections)
        {
            var script = new List<string>();

            AddSqlEntities(script, customers, nameof(customers).ToUpper());
            AddSqlEntities(script, vehicles, nameof(vehicles).ToUpper());
            AddSqlEntities(script, connections, nameof(connections).ToUpper());

            return script.ToArray();
        }

        private static void AddSqlEntities(ICollection<string> script, IEnumerable<ISqlEntity> list, string name)
        {
            list = list.ToList();
            script.Add($"-- {name} ({list.Count()})");
            foreach (var element in list)
                script.Add(element.AsInsertScript());
            script.Add(string.Empty);
        }

        public static void SaveScript(string path, string[] content) => File.WriteAllLines(path, content);
    }
}