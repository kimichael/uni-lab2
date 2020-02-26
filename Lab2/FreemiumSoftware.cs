using System;
using System.Xml.Serialization;

/// <summary>
/// Класс условно-бесплатного ПО</summary>
public class FreemiumSoftware : Software
{
    public String name { get; set; }

    public String manufacturer { get; set; }

    public DateTime installationDate { get; set; }

    public TimeSpan freeUsageInterval { get; set; }

    public FreemiumSoftware() { }

    public FreemiumSoftware(
        String name,
        String manufacturer,
        DateTime installationDate,
        TimeSpan freeUsageInterval)
    {
        this.name = name;
        this.manufacturer = manufacturer;
        this.installationDate = installationDate;
        this.freeUsageInterval = freeUsageInterval;
    }

    public override bool isAvailable(DateTime currentDate)
    {
        DateTime expirationDate = installationDate + freeUsageInterval;
        return currentDate <= expirationDate && currentDate >= installationDate;
    }

    public override void printInfo()
    {
        Console.WriteLine(
            "Freemium software name {0}, manufacturer {1}, installationDate {2}, freeUsageInterval {3} days",
            name, manufacturer, installationDate.ToString("MM/dd/yyyy"), freeUsageInterval.Days
        );
    }
}
