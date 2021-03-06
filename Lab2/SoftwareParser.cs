﻿using System;
using System.Diagnostics;

namespace Lab2
{
    /// <summary>
    /// Парсер, который используется для парсинга ПО
    /// </summary>
    public class SoftwareParser
    {
        public SoftwareParser()
        {
        }

        /// <summary>
        /// Метод для парсинга строки с информацией о ПО</summary>
        /// <returns>Объект ПО, который был распарсен</returns>
        public Software parseSoftware(String line) {
            Trace.WriteLine("Parsing software line = %s", line);
            string[] tokens = line.Split();

            switch (tokens[0]) {
                case "Free":
                    return parseFreeSoftware(tokens);
                case "Freemium":
                    return parseFreemiumSoftware(tokens);
                case "Commercial":
                    return parseCommercialSoftware(tokens);
                default:
                    throw new FormatException("Unknown software type");
            }
        }

        /// <summary>
        /// Метод для парсинга строки с бесплатным ПО</summary>
        /// <param name="tokens">Набор токенов для парсинга</param>
        /// <returns>Объект ПО, который был распарсен</returns>
        private FreeSoftware parseFreeSoftware(string[] tokens) {
            if (tokens.Length >= 2) {
                Trace.WriteLine("Parsing free software = %s", tokens.ToString());
                return new FreeSoftware(tokens[1], tokens[2]);
            }
            throw new FormatException("Wrong free software line format");
        }

        /// <summary>
        /// Метод для парсинга строки с условно-бесплатным ПО</summary>
        /// <param name="tokens">Набор токенов для парсинга</param>
        /// <returns>Объект ПО, который был распарсен</returns>
        private FreemiumSoftware parseFreemiumSoftware(string[] tokens) {
            if (tokens.Length >= 5) {
                string name = tokens[1];
                string manufacturer = tokens[2];
                DateTime installationDate = DateTime.Parse(tokens[3]);
                TimeSpan freeUsageInterval = new TimeSpan(Int32.Parse(tokens[4]), 0, 0, 0);

                Trace.WriteLine("Parsing freemium software = %s", tokens.ToString());
                return new FreemiumSoftware(name, manufacturer, installationDate, freeUsageInterval);
            }
            throw new FormatException("Wrong freemium software line format");
        }

        /// <summary>
        /// Метод для парсинга строки с коммерческим ПО</summary>
        /// <param name="tokens">Набор токенов для парсинга</param>
        /// <returns>Объект ПО, который был распарсен</returns>
        private CommercialSoftware parseCommercialSoftware(string[] tokens) {
            if (tokens.Length >= 6)
            {
                string name = tokens[1];
                string manufacturer = tokens[2];
                double cost = Double.Parse(tokens[3]);
                DateTime installationDate = DateTime.Parse(tokens[4]);
                TimeSpan freeUsageInterval = new TimeSpan(Int32.Parse(tokens[5]), 0, 0, 0);

                Trace.WriteLine("Parsing commercial software = %s", tokens.ToString());
                return new CommercialSoftware(name, manufacturer, cost, installationDate, freeUsageInterval);
            }
            throw new FormatException("Wrong commercial software line format");
        }
    }
}
