namespace SpaceBattle.Lib;

public class Angle
{
    public int[] Degrees { get; set; }
    public Angle(int[] degrees)
    {
        Degrees = degrees;
    }

    public static Angle operator +(Angle a, Angle b)
    {
        var res = new int[]{(a.Degrees[0] + b.Degrees[0]) % 8, 8};
        return new Angle(res);
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;

        if (GetType() != obj.GetType()) return false;
        Angle a = (Angle)obj;

        return a.Degrees[0] % 8 == Degrees[0] % 8;
    }

    public static bool operator ==(Angle a, Angle b)
    {
        if (a.Degrees[0] % 8 != b.Degrees[0] % 8) return false;

        return true;
    }

    public static bool operator !=(Angle a, Angle b)
    {
        if (a.Degrees[0] % 8 == b.Degrees[0] % 8) return false;

        return true;
    }
}