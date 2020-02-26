using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

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

            foreach (string inputLine in inputLines)
            {
                try
                {
                    Trace.WriteLine("Parsing software from line %s", inputLine);
                    softwares.Add(parser.parseSoftware(inputLine));
                    Trace.WriteLine("Successfully parsed software from line %s", inputLine);
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"An error occured while parsing input file {inputFilePath}: {e.Message}.");
                }
            }

            Console.WriteLine("Parsing completed.");
            Console.WriteLine("Press 1 to list all software, 2 to list available software, 3 to write to xml file");
            Console.WriteLine("Press ESC to stop");

            bool done = false;
            while (!done)
            {
                ConsoleKeyInfo command = Console.ReadKey(true);
                Trace.WriteLine("User pressed %s key", command.Key.ToString());
                switch (command.Key)
                {
                    case ConsoleKey.Escape:
                        done = true;
                        break;
                    case ConsoleKey.D1:
                        Console.WriteLine("Listing all software");
                        Trace.WriteLine("Listing software");
                        foreach (Software software in softwares)
                        {
                            software.printInfo();
                        }
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("Listing available software");
                        Trace.WriteLine("Listing available software");
                        foreach (Software software in softwares)
                        {
                            if (software.isAvailable(DateTime.Now))
                            {
                                software.printInfo();
                            }
                        }
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("Enter output file: ");
                        string output = Console.ReadLine();
                        WriteToFile(output, softwares);
                        break;
                }
                Console.WriteLine("--------------------");
            }

            Console.WriteLine("End");
            Trace.WriteLine("End of tracing Lab2");
        }

        /// <summary>
        /// Записывает xml документацию в файлы
        /// </summary>
        /// <param name="file">Файл, в который нужно записать документацию</param>
        public static void WriteToFile(string file, List<Software> softwares)
        {
            var serializer = new XmlSerializer(typeof(Software), FindAllDerivedTypes<Software>().ToArray());
            using (var writer = new StreamWriter(File.OpenWrite(file)))
            {
                foreach (Software software in softwares)
                {
                    serializer.Serialize(writer, software);
                }
            }
        }

        /// <summary>
        /// Возвращает все подкласса данного класса
        /// </summary>
        /// <typeparam name="T">Класс, подклассы которого нужно найти</typeparam>
        /// <returns>Подклассы данного класса</returns>
        private static List<Type> FindAllDerivedTypes<T>()
        {
            var baseType = typeof(T);
            return Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(type => type != baseType && baseType.IsAssignableFrom(type))
                .ToList();
        }
    }
}
