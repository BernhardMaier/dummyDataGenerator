using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

            customers = customers.ToList();
            script.Add($"-- CUSTOMERS ({customers.Count()})");
            foreach (var customer in customers)
                script.Add(customer.AsInsertScript());
            script.Add(string.Empty);

            vehicles = vehicles.ToList();
            script.Add($"-- VEHICLES ({vehicles.Count()})");
            foreach (var vehicle in vehicles)
                script.Add(vehicle.AsInsertScript());
            script.Add(string.Empty);

            connections = connections.ToList();
            script.Add($"-- CONNECTIONS ({connections.Count()})");
            foreach (var connection in connections)
                script.Add(connection.AsInsertScript());
            script.Add(string.Empty);

            return script.ToArray();
        }

        public static void SaveScript(string path, string[] content) => File.WriteAllLines(path, content);
    }
}