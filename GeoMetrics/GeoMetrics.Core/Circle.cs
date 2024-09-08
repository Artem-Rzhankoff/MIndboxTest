namespace GeoMetrics.Core;

/// <summary>
/// Represents circle
/// </summary>
public class Circle : Shape
{
    private readonly double _radius;
    
    /// <summary>
    /// Initializes a new instance of the Circle class with specified radius.
    /// </summary>
    /// <param name="radius">The length of the radius of the circle.</param>
    /// <exception cref="ArgumentException">Thrown when radius is not a positive number.</exception>
    public Circle(double radius)
    {
        CheckThatParameterIsPositive(radius, nameof(radius));
        _radius = radius;
    }
    
    public override double Area => double.Pi * _radius * _radius;
}