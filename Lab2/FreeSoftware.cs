using System;

public class FreeSoftware : Software
{
    private String name;

    private String manufacturer;

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
