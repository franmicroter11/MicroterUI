using System.Collections.Generic;
using MicroterUI.Geometry.Primitives;

namespace MicroterUI.Geometry.Analysis;

/// <summary>
/// Analyzes geometry data and produces an immutable <see cref="GeometryAnalysis"/> result.
/// </summary>
public sealed class GeometryAnalyzer
{
    /// <summary>
    /// Creates an analysis from the supplied figures.
    /// </summary>
    /// <param name="figures">Figures discovered during geometry traversal.</param>
    /// <returns>An immutable geometry analysis.</returns>
    public GeometryAnalysis Analyze(IReadOnlyList<FigureInfo> figures)
    {
        ArgumentNullException.ThrowIfNull(figures);

        var bounds = CalculateBounds(figures);
        return new GeometryAnalysis(figures, bounds);
    }

    private static Rect CalculateBounds(IReadOnlyList<FigureInfo> figures)
    {
        if (figures.Count == 0)
            return Rect.Empty;

        var bounds = Rect.Empty;

        foreach (var figure in figures)
        {
            ArgumentNullException.ThrowIfNull(figure);
            bounds = Rect.Union(bounds, figure.Bounds);
        }

        return bounds;
    }
}
