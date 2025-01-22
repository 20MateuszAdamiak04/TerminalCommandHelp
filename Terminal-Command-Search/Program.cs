using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;


namespace TerminalCommandSearch
{
    class Program
    {
        static void Main()
        {
            //Read the information from JSON File
            var json = File.ReadAllText("D:\\Programmierung\\C#\\VIsual STudio Console Dokumentation search\\Terminal-Command-Search\\JSON-Files\\Test.json");
            var commands = JsonConvert.DeserializeObject<List<Command>>(json);

            while (true)
            {
                Console.WriteLine("Enter a phrase to find a command:");
                string query = Console.ReadLine();

                // Search in Data Base and its change it to List
                var results = commands.Where(c => c.description.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();

                // Search if results have anything found
                if (!results.Any())
                {
                    Console.WriteLine("Command not Found");
                }
                else
                {
                    Console.WriteLine("Commands found:");
                    foreach (var result in results)
                    {
                        Console.WriteLine($"Commands: {result.command}");
                        Console.WriteLine($"Description: {result.description}");
                        Console.WriteLine($"Example: {result.example}");
                        Console.WriteLine();
                    }
                }
            }
        }
    }


    class Command
    {
        public string command { get; set; }
        public string description { get; set; }
        public string example { get; set; }
    }
}
 