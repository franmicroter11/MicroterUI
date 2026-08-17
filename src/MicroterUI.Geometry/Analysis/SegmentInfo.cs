using MicroterUI.Geometry.Primitives;

namespace MicroterUI.Geometry.Analysis;

/// <summary>
/// Identifies the kind of segment represented by a <see cref="SegmentInfo"/>.
/// </summary>
public enum SegmentKind
{
    Line,
    QuadraticBezier,
    CubicBezier,
    Arc
}

/// <summary>
/// Describes one segment discovered while analyzing a geometry.
/// </summary>
public sealed class SegmentInfo
{
    public int Index { get; }
    public SegmentKind Kind { get; }
    public Point StartPoint { get; }
    public Point EndPoint { get; }

    public SegmentInfo(
        int index,
        SegmentKind kind,
        Point startPoint,
        Point endPoint)
    {
        if (index < 0)
            throw new ArgumentOutOfRangeException(nameof(index));

        Index = index;
        Kind = kind;
        StartPoint = startPoint;
        EndPoint = endPoint;
    }
}
