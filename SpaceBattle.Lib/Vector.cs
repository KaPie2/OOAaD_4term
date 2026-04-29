namespace Vector;

public class NVector
{
    public int[] coords { get; set; }
    public int dim { get; set; }

    public NVector(int[] coords)
    {
        this.coords = coords;
        this.dim = coords.Length;
    }

    public static NVector operator +(NVector a, NVector b)
    {
        if (a.dim != b.dim)
        {
            throw new ArgumentException("dimensions not compatible");
        }

        int[] res = new int[a.dim];
        for (int i = 0; i < a.dim; i++)
        {
            res[i] = a.coords[i] + b.coords[i];
        }

        return new NVector(res);
    }

    public static bool operator ==(NVector a, NVector b)
    {

        if (a.dim != b.dim) return false;
        if (!a.coords.SequenceEqual(b.coords)) return false;

        return true;
    }

    public static bool operator !=(NVector a, NVector b)
    {

        if (a.coords.SequenceEqual(b.coords)) return false;

        return true;
    }




    public override bool Equals(object? obj)
    {
        if (obj == null) return false;

        if (GetType() != obj.GetType()) return false;
        NVector other = (NVector)obj;

        if (this.dim != other.dim) return false;
        if (!this.coords.SequenceEqual(other.coords)) return false;

        return true;
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}
