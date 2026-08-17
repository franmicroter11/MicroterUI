namespace MicroterUI.Geometry.Primitives;

/// <summary>
/// Represents an axis-aligned rectangle using double-precision coordinates.
/// </summary>
public readonly record struct Rect(double X, double Y, double Width, double Height)
{
    public double Left => X;
    public double Top => Y;
    public double Right => X + Width;
    public double Bottom => Y + Height;

    public static Rect Empty => new(0, 0, 0, 0);

    public static Rect FromPoints(Point first, Point second)
    {
        var left = Math.Min(first.X, second.X);
        var top = Math.Min(first.Y, second.Y);
        var right = Math.Max(first.X, second.X);
        var bottom = Math.Max(first.Y, second.Y);

        return new(left, top, right - left, bottom - top);
    }

    public Rect Include(Point point)
    {
        if (Width == 0 && Height == 0 && X == 0 && Y == 0)
            return new(point.X, point.Y, 0, 0);

        var left = Math.Min(Left, point.X);
        var top = Math.Min(Top, point.Y);
        var right = Math.Max(Right, point.X);
        var bottom = Math.Max(Bottom, point.Y);

        return new(left, top, right - left, bottom - top);
    }
}
