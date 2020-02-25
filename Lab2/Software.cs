using System;

/// <summary>
/// Интерфейс программного обеспечения</summary>
public abstract class Software
{
    /// <summary>
    /// Метод, который выводит в консоль информацию о ПО</summary>
    public abstract void printInfo();

    /// <summary>
    /// Используется для определения возможности использовать ПО</summary>
    /// <param name="currentDate">Дата, относительно которой нужно проверить возможность использовать ПО</param>
    /// <returns>true, если ПО можно использовать в данный момент. Иначе - false</returns>
    public abstract Boolean isAvailable(DateTime currentDate);
}
