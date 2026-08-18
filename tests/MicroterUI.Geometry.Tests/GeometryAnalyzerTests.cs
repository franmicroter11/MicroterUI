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
        Assert.Equal(0, result.SegmentCount);
        Assert.Equal(Rect.Empty, result.Bounds);
    }

    [Fact]
    public void Analyze_NullFigures_Throws()
    {
        var analyzer = new GeometryAnalyzer();

        Assert.Throws<ArgumentNullException>(() => analyzer.Analyze(null!));
    }

    [Fact]
    public void Analyze_NullFigure_Throws()
    {
        var figures = new FigureInfo[] { null! };
        var analyzer = new GeometryAnalyzer();

        Assert.Throws<ArgumentNullException>(() => analyzer.Analyze(figures));
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
        Assert.Equal(0, result.SegmentCount);
    }

    [Fact]
    public void Analyze_CalculatesTotalSegmentCount()
    {
        var segments = new[]
        {
            new SegmentInfo(0, SegmentKind.Line, new Point(0, 0), new Point(10, 0)),
            new SegmentInfo(1, SegmentKind.Line, new Point(10, 0), new Point(10, 10)),
            new SegmentInfo(2, SegmentKind.Line, new Point(10, 10), new Point(0, 10))
        };

        var figures = new[]
        {
            new FigureInfo(segments, true, new Rect(0, 0, 10, 10)),
            new FigureInfo(
                new[]
                {
                    new SegmentInfo(0, SegmentKind.Line, new Point(20, 20), new Point(30, 20))
                },
                false,
                new Rect(20, 20, 10, 1))
        };

        var result = new GeometryAnalyzer().Analyze(figures);

        Assert.Equal(2, result.FigureCount);
        Assert.Equal(4, result.SegmentCount);
    }

    [Fact]
    public void Analyze_ResultDoesNotShareFigureCollectionWithInput()
    {
        var figures = new List<FigureInfo>
        {
            new FigureInfo(Array.Empty<SegmentInfo>(), false, Rect.Empty)
        };

        var result = new GeometryAnalyzer().Analyze(figures);

        figures.Clear();

        Assert.Single(result.Figures);
        Assert.Equal(1, result.FigureCount);
    }
}
