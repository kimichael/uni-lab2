using System;
using System.Collections.Generic;
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
            Console.WriteLine("Welcome to Lab2");
            Console.WriteLine("Write path to input file: ");
            string inputFilePath = Console.ReadLine();
            SoftwareParser parser = new SoftwareParser();
            string[] inputLines;

            try
            {
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
                    softwares.Add(parser.parseSoftware(inputLine));
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
                switch (command.Key) {
                    case ConsoleKey.Escape:
                        done = true;
                        break;
                    case ConsoleKey.D1:
                        Console.WriteLine("Listing all software");
                        foreach (Software software in softwares) {
                            software.printInfo();
                        }
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("Listing available software");
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
        }
    }
}
