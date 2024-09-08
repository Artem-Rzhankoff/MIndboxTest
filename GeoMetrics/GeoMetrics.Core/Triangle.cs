namespace GeoMetrics.Core;

/// <summary>
/// Represents triangle
/// </summary>
public class Triangle : Shape
{
    private readonly (double A, double B, double C) _sides;
    private const double Eps = 1e-10;
    
    /// <summary>
    /// Initializes a new instance of the Triangle class with specified sides.
    /// </summary>
    /// <param name="a">The length of the first side of the triangle.</param>
    /// <param name="b">The length of the second side of the triangle.</param>
    /// <param name="c">The length of the third side of the triangle.</param>
    /// <exception cref="ArgumentException">Thrown when at least one of the sides is not a positive number.</exception>
    /// <exception cref="ArgumentException">Thrown when the triangle inequality is not respected.</exception>
    public Triangle(double a, double b, double c)
    {
        CheckThatParameterIsPositive(a, nameof(a));
        CheckThatParameterIsPositive(b, nameof(b));
        CheckThatParameterIsPositive(c, nameof(c));
        CheckTriangleInequality(a, b, c);

        _sides = (a, b, c);
    }
    
    /// <summary>
    /// Gets true if the triangle is a right angled 
    /// </summary>
    public bool IsRightAngled =>
        SatisfiesPythagorasTheorem(_sides.A, _sides.B, _sides.C) || 
        SatisfiesPythagorasTheorem(_sides.B, _sides.A, _sides.C) ||
        SatisfiesPythagorasTheorem(_sides.C, _sides.A, _sides.B);
    
    public override double Area => 
        double.Sqrt(SemiPerimeter * (SemiPerimeter - _sides.A) * (SemiPerimeter - _sides.B) * (SemiPerimeter - _sides.C));
    
    private double SemiPerimeter => (_sides.A + _sides.B + _sides.C) / 2;

    private static bool SatisfiesPythagorasTheorem(double hypotenuse, double firstLeg, double secondLeg)
    {
        return Math.Abs(hypotenuse * hypotenuse - (firstLeg * firstLeg + secondLeg * secondLeg)) < Eps;
    }
    
    private static void CheckTriangleInequality(double a, double b, double c)
    {
        if (a + b < c || a + c < b || b + c < a)
        {
            throw new ArgumentException("Сумма длин двух сторон треугольника должна быть не меньше длины третьей.");
        }
    }
}