using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Lab2
{
    /// <summary>
    /// Класс, отвечающий за вторую лабораторную работу по ТРПО
    /// </summary>
    class Program
    {
        /// <summary>
        /// Точка входа для приложения.
        /// </summary>
        /// <param name="args"> Список аргументов командной строки</param>
        static void Main(string[] args)
        {
            Trace.WriteLine("Start tracing Lab2");
            Console.WriteLine("Welcome to Lab2");
            Console.WriteLine("Write path to input file: ");
            string inputFilePath = Console.ReadLine();
            SoftwareParser parser = new SoftwareParser();
            string[] inputLines;

            try
            {
                Trace.WriteLine("Reading input file %s", inputFilePath);
                inputLines = File.ReadAllLines(inputFilePath);
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured while reading input file {inputFilePath}: {e.Message}.");
                return;
            }

            List<Software> softwares = new List<Software> { };

            foreach (string inputLine in inputLines) {
                try
                {
                    Trace.WriteLine("Parsing software from line %s", inputLine);
                    softwares.Add(parser.parseSoftware(inputLine));
                    Trace.WriteLine("Successfully parsed software from line %s", inputLine);
                } catch (FormatException e) {
                    Console.WriteLine($"An error occured while parsing input file {inputFilePath}: {e.Message}.");
                }
            }

            Console.WriteLine("Parsing completed.");
            Console.WriteLine("Press 1 to list all software, 2 to list available software");
            Console.WriteLine("Press ESC to stop");

            bool done = false;
            while (!done) {
                ConsoleKeyInfo command = Console.ReadKey(true);
                Trace.WriteLine("User pressed %s key", command.Key.ToString());
                switch (command.Key) {
                    case ConsoleKey.Escape:
                        done = true;
                        break;
                    case ConsoleKey.D1:
                        Console.WriteLine("Listing all software");
                        Trace.WriteLine("Listing software");
                        foreach (Software software in softwares) {
                            software.printInfo();
                        }
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("Listing available software");
                        Trace.WriteLine("Listing available software");
                        foreach (Software software in softwares) {
                            if (software.isAvailable(DateTime.Now)) {
                                software.printInfo();
                            }
                        }
                        break;
                }
                Console.WriteLine("--------------------");
            }

            Console.WriteLine("End");
            Trace.WriteLine("End of tracing Lab2");
        }
    }
}
