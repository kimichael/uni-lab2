using System;
using System.Xml.Serialization;

/// <summary>
/// Класс бесплатного ПО</summary>
public class FreeSoftware : Software
{
    public String name { get; set; }

    public String manufacturer { get; set; }

    public FreeSoftware() { }

    public FreeSoftware(String name, String manufacturer)
    {
        this.name = name;
        this.manufacturer = manufacturer;
    }

    public override bool isAvailable(DateTime currentDate)
    {
        return true;
    }

    public override void printInfo()
    {
        Console.WriteLine(
            "Free software name {0}, manufacturer {1}",
            name,
            manufacturer
        );
    }
}
