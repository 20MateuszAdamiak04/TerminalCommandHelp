using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        // Wczytanie danych z pliku JSON
        var json = File.ReadAllText("/Users/mateuszadamiak/Documents/IT-Lernen/Programmierung /C#/Terminal-Command-Search/Terminal-Command-Search/JSON-Files/Test.json");
        var commands = JsonConvert.DeserializeObject<List<Command>>(json);

        Console.WriteLine("Wpisz frazę, aby znaleźć komendę:");
        string query = Console.ReadLine();

        // Wyszukiwanie w bazie komend
        var results = commands.Where(c => c.description.Contains(query, StringComparison.OrdinalIgnoreCase) 
                                          || c.command.Contains(query, StringComparison.OrdinalIgnoreCase));

        Console.WriteLine("Znalezione komendy:");
        foreach (var result in results)
        {
            Console.WriteLine($"Komenda: {result.command}");
            Console.WriteLine($"Opis: {result.description}");
            Console.WriteLine($"Przykład: {result.example}");
            Console.WriteLine();
        }
    }
}

class Command
{
    public string command { get; set; }
    public string description { get; set; }
    public string example { get; }
}    