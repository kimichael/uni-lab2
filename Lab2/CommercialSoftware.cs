using System;

/// <summary>
/// Класс коммерческого ПО</summary>
public class CommercialSoftware : Software
{
    String name;

    String manufacturer;

    double cost;

    DateTime installationDate;

    TimeSpan usageInterval;

    public CommercialSoftware(
        String name,
        String manufacturer,
        double cost,
        DateTime installationDate,
        TimeSpan usageInterval)
    {
        this.name = name;
        this.manufacturer = manufacturer;
        this.cost = cost;
        this.installationDate = installationDate;
        this.usageInterval = usageInterval;
    }

    public override bool isAvailable(DateTime currentDate)
    {
        DateTime expirationDate = installationDate + usageInterval;
        return expirationDate <= currentDate && currentDate >= installationDate;
    }

    public override void printInfo()
    {
        Console.WriteLine(
            "Commercial software name {0}, manufacturer {1}, cost {2}, installationDate {3}, usageInterval {4} days",
            name,
            manufacturer,
            cost,
            installationDate.ToString("MM/dd/yyyy"),
            usageInterval.Days
        );
    }
}
