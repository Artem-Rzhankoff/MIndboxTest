namespace GeoMetrics.Core;

/// <summary>
/// Base class for geometric shapes. Defines common properties and methods for all shapes.
/// </summary>
public abstract class Shape
{
    /// <summary>
    /// Returns the area of the shape.
    /// </summary>
    public abstract double Area { get; }

    protected static void CheckThatParameterIsPositive(double value, string name)
    {
        if (value <= 0)
            throw new ArgumentException($"Параметр {name} должен быть положительным числом.");
    }
}