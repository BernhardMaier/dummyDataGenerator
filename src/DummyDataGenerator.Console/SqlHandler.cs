using System.Collections.Generic;
using System.IO;

namespace DummyDataGeneratorConsole
{
    public static class SqlHandler
    {
        public static string[] CreateScript(
            IEnumerable<Customer> customers,
            IEnumerable<Vehicle> vehicles,
            IEnumerable<Connection> connections)
        {
            var script = new List<string>();

            foreach (var customer in customers)
                script.Add(customer.AsInsertScript());
            
            foreach (var vehicle in vehicles)
                script.Add(vehicle.AsInsertScript());
            
            foreach (var connection in connections)
                script.Add(connection.AsInsertScript());
            
            return script.ToArray();
        }

        public static void SaveScript(string path, string[] content) => File.WriteAllLines(path, content);
    }
}