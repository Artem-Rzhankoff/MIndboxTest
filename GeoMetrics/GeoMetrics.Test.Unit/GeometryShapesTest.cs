using GeoMetrics.Core;

namespace GeoMetrics.Test.Unit;

[TestFixture]
public class GeometryShapesTest
{
    private const double Eps = 1e-10;

    [TestCase( 0.3, 0.4, 0.5,ExpectedResult = true)]
    [TestCase(0.33333, 0.44444, 0.55555, ExpectedResult = true)]
    [TestCase(2.0, 3.0, 4.0, ExpectedResult = false)]
    public bool CheckThatTriangleIsRightAngled_ShouldReturnCorrectResult(double a, double b, double c)
    {
        var triangle = new Triangle(a, b, c);
        return triangle.IsRightAngled;
    }

    [Test]
    [TestCaseSource(nameof(AreaTestCases))]
    public void CalculateShapeArea_ShouldReturnCorrectResult(Shape shape, double area)
    {
        Assert.That(shape.Area - area, Is.LessThan(Eps));
    }

    [Test]
    public void InstantiateTriangleWithNegativeSide_WithThrownException()
    {
        Assert.Throws<ArgumentException>(() => new Triangle(-1.0, 5.0, 6.0));
    }
    
    private static IEnumerable<TestCaseData> AreaTestCases()
    {
        yield return new TestCaseData(new Triangle(3, 4, 5), 6);
        yield return new TestCaseData(new Triangle(3.333333, 4, 5), 6.666666);
        yield return new TestCaseData(new Circle(3), double.Pi * 9);
    }
}