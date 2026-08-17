using MicroterUI.Geometry.Primitives;

namespace MicroterUI.Geometry.Analysis;

/// <summary>
/// Immutable result produced by analyzing a geometry.
/// </summary>
public sealed class GeometryAnalysis
{
    public IReadOnlyList<FigureInfo> Figures { get; }
    public Rect Bounds { get; }

    public int FigureCount => Figures.Count;

    public int SegmentCount => Figures.Sum(static figure => figure.SegmentCount);

    public GeometryAnalysis(
        IReadOnlyList<FigureInfo> figures,
        Rect bounds)
    {
        ArgumentNullException.ThrowIfNull(figures);

        Figures = figures;
        Bounds = bounds;
    }
}
