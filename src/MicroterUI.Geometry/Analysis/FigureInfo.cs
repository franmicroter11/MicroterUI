using MicroterUI.Geometry.Primitives;

namespace MicroterUI.Geometry.Analysis;

/// <summary>
/// Describes one complete figure discovered during geometry analysis.
/// </summary>
public sealed class FigureInfo
{
    public IReadOnlyList<SegmentInfo> Segments { get; }
    public bool IsClosed { get; }
    public Rect Bounds { get; }

    public int SegmentCount => Segments.Count;

    public FigureInfo(
        IReadOnlyList<SegmentInfo> segments,
        bool isClosed,
        Rect bounds)
    {
        ArgumentNullException.ThrowIfNull(segments);

        Segments = segments;
        IsClosed = isClosed;
        Bounds = bounds;
    }
}
