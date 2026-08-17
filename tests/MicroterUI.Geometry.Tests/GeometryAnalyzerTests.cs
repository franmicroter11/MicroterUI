using MicroterUI.Geometry.Analysis;
using MicroterUI.Geometry.Primitives;
using Xunit;

namespace MicroterUI.Geometry.Tests;

public sealed class GeometryAnalyzerTests
{
    [Fact]
    public void Analyze_EmptyFigures_ReturnsEmptyBounds()
    {
        var analyzer = new GeometryAnalyzer();

        var result = analyzer.Analyze(Array.Empty<FigureInfo>());

        Assert.Empty(result.Figures);
        Assert.Equal(0, result.FigureCount);
        Assert.Equal(Rect.Empty, result.Bounds);
    }

    [Fact]
    public void Analyze_Figures_UsesUnionOfFigureBounds()
    {
        var figures = new[]
        {
            new FigureInfo(
                Array.Empty<SegmentInfo>(),
                false,
                new Rect(0, 0, 10, 10)),
            new FigureInfo(
                Array.Empty<SegmentInfo>(),
                true,
                new Rect(20, 5, 10, 15))
        };

        var analyzer = new GeometryAnalyzer();

        var result = analyzer.Analyze(figures);

        Assert.Equal(new Rect(0, 0, 30, 20), result.Bounds);
        Assert.Equal(2, result.FigureCount);
    }
}
