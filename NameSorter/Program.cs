using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NameSorter.Interfaces;
using NameSorter.Models;
using NameSorter.Services;
using System;
using System.IO;
using System.Linq;

namespace NameSorter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide the file name.\nExample: name-sorter <input-file-path>");
                return;
            }

            var inputFile = args[0];

            if (!File.Exists(inputFile))
            {
                Console.WriteLine($"Error: File '{inputFile}' not found.");
                return;
            }

            var host = CreateHostBuilder(args).Build();
            var app = host.Services.GetRequiredService<App>();
            try
            {
                app.Run(inputFile);
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"Error: File error - {ioEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: An error occurred - {ex.Message}");
            }
        }

        // Configures dependency injection for the application.
        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                {
                    services.AddSingleton<INamesParser, NamesParser>();
                    services.AddSingleton<INamesSorter, NamesSorter>();
                    services.AddSingleton<IFileService, FileService>();
                    services.AddTransient<App>();
                });
    }


    /**
     * Logic :
     * 1- Read names from the input file.
     * 2- Parse each line into a Name object using INamesParser.
     * 3- Persist warnings for invalid lines.
     * 4- Sort the list of Name objects using INamesSorter.
     * 5- Write the sorted names to "sorted-names-list.txt".
     * **/
    public class App
    {
        private readonly IFileService _fileService;
        private readonly INamesParser _parser;
        private readonly INamesSorter _sorter;

        public App(IFileService fileService, INamesParser parser, INamesSorter sorter)
        {
            _fileService = fileService;
            _parser = parser;
            _sorter = sorter;
        }

        public void Run(string inputFile)
        {
            try
            {
                var lines = _fileService.ReadLines(inputFile);
                var names = new List<Name>();
                int lineNumber = 1;
                foreach (var line in lines)
                {
                    var name = _parser.Parse(line);
                    if (name != null)
                    {
                        names.Add(name);
                    }
                    else
                    {
                        Console.WriteLine($"Warning: Invalid line at {lineNumber} - {line}");
                    }
                    lineNumber++;
                }

                var sorted = _sorter.Sort(names);

                _fileService.WriteLines("sorted-names-list.txt", sorted.Select(n => n.FullName));

                Console.WriteLine($"Success: File created with sorted names list.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: An error has occurred - {e.Message}");
                throw;
            }
        }
    }
}
