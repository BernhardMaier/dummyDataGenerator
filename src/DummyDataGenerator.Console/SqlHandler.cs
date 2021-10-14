using System;
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
            return new [] { string.Empty };
        }

        public static void SaveScript(string path, string[] content) => File.WriteAllLines(path, content);
    }
}