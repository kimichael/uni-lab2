using System;
namespace Lab2
{
    public class SoftwareParser
    {
        public SoftwareParser()
        {
        }

        public Software parseSoftware(String line) {
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

        private FreeSoftware parseFreeSoftware(string[] tokens) {
            if (tokens.Length >= 2) {
                return new FreeSoftware(tokens[1], tokens[2]);
            }
            throw new FormatException("Wrong free software line format");
        }

        private FreemiumSoftware parseFreemiumSoftware(string[] tokens) {
            if (tokens.Length >= 5) {
                string name = tokens[1];
                string manufacturer = tokens[2];
                DateTime installationDate = DateTime.Parse(tokens[3]);
                TimeSpan freeUsageInterval = new TimeSpan(Int32.Parse(tokens[4]), 0, 0, 0);

                return new FreemiumSoftware(name, manufacturer, installationDate, freeUsageInterval);
            }
            throw new FormatException("Wrong freemium software line format");
        }

        private CommercialSoftware parseCommercialSoftware(string[] tokens) {
            if (tokens.Length >= 6)
            {
                string name = tokens[1];
                string manufacturer = tokens[2];
                double cost = Double.Parse(tokens[3]);
                DateTime installationDate = DateTime.Parse(tokens[4]);
                TimeSpan freeUsageInterval = new TimeSpan(Int32.Parse(tokens[5]), 0, 0, 0);

                return new CommercialSoftware(name, manufacturer, cost, installationDate, freeUsageInterval);
            }
            throw new FormatException("Wrong commercial software line format");
        }
    }
}
