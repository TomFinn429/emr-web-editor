using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzumk
{
	public readonly float z0uek;

	public readonly GraphicsUnit z0iek;

	private int z0oek;

	public readonly string z0pek;

	public readonly FontStyle z0mek;

	public override bool Equals(object obj)
	{
		if (obj == this)
		{
			return true;
		}
		z0ZzZzumk z0ZzZzumk2 = (z0ZzZzumk)obj;
		if (z0pek == z0ZzZzumk2.z0pek && z0uek == z0ZzZzumk2.z0uek && z0mek == z0ZzZzumk2.z0mek)
		{
			return z0iek == z0ZzZzumk2.z0iek;
		}
		return false;
	}

	public z0ZzZzumk(string p0, float p1, FontStyle p2, GraphicsUnit p3)
	{
		z0pek = p0;
		z0uek = p1;
		z0mek = p2;
		z0iek = p3;
		z0oek = z0pek.GetHashCode();
		z0oek += z0uek.GetHashCode();
		z0oek += (int)z0mek;
		z0oek += 10 * (int)z0iek;
	}

	public z0ZzZzumk(z0ZzZzsdh p0)
		: this(p0.z0pek(), p0.z0yek(), p0.z0mek(), p0.z0rek())
	{
	}

	public bool z0eek()
	{
		return (z0mek & FontStyle.Underline) == FontStyle.Underline;
	}

	public bool z0rek()
	{
		return (z0mek & FontStyle.Italic) == FontStyle.Italic;
	}

	public bool z0tek()
	{
		return (z0mek & FontStyle.Bold) == FontStyle.Bold;
	}

	public bool z0yek()
	{
		return (z0mek & FontStyle.Strikeout) == FontStyle.Strikeout;
	}

	public override int GetHashCode()
	{
		return z0oek;
	}

	public z0ZzZzumk(string p0, float p1, FontStyle p2)
	{
		z0pek = p0;
		z0uek = p1;
		z0mek = p2;
		z0iek = GraphicsUnit.Point;
		z0oek = z0pek.GetHashCode();
		z0oek += z0uek.GetHashCode();
		z0oek += (int)z0mek;
		z0oek += 10 * (int)z0iek;
	}
}
