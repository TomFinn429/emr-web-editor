namespace zzz;

public sealed class z0ZzZzrdh
{
	public static readonly z0ZzZzrdh z0eek = new z0ZzZzrdh(6, "PNG");

	public static readonly z0ZzZzrdh z0rek = new z0ZzZzrdh(1, "MBMP");

	public static readonly z0ZzZzrdh z0tek = new z0ZzZzrdh(4, "WMF");

	public readonly int z0yek;

	public static readonly z0ZzZzrdh z0uek = new z0ZzZzrdh(10, "ICON");

	public readonly string z0iek;

	public static readonly z0ZzZzrdh z0oek = new z0ZzZzrdh(8, "TIFF");

	public static readonly z0ZzZzrdh z0pek = new z0ZzZzrdh(3, "EMF");

	public static readonly z0ZzZzrdh z0mek = new z0ZzZzrdh(9, "EXIF");

	public static readonly z0ZzZzrdh z0nek = new z0ZzZzrdh(7, "GIF");

	public static readonly z0ZzZzrdh z0bek = new z0ZzZzrdh(5, "JPEG");

	public static readonly z0ZzZzrdh z0vek = new z0ZzZzrdh(2, "BMP");

	private z0ZzZzrdh(int p0, string p1)
	{
		z0yek = p0;
		z0iek = p1;
	}

	public override string ToString()
	{
		if (z0yek == z0rek.z0yek)
		{
			return "MemoryBMP";
		}
		if (z0yek == z0vek.z0yek)
		{
			return "Bmp";
		}
		if (z0yek == z0pek.z0yek)
		{
			return "Emf";
		}
		if (z0yek == z0tek.z0yek)
		{
			return "Wmf";
		}
		if (z0yek == z0nek.z0yek)
		{
			return "Gif";
		}
		if (z0yek == z0bek.z0yek)
		{
			return "Jpeg";
		}
		if (z0yek == z0eek.z0yek)
		{
			return "Png";
		}
		if (z0yek == z0oek.z0yek)
		{
			return "Tiff";
		}
		if (z0yek == z0mek.z0yek)
		{
			return "Exif";
		}
		if (z0yek == z0uek.z0yek)
		{
			return "Icon";
		}
		return "Unknow";
	}

	public override bool Equals(object o)
	{
		if (!(o is z0ZzZzrdh z0ZzZzrdh2))
		{
			return false;
		}
		return z0yek == z0ZzZzrdh2.z0yek;
	}

	public override int GetHashCode()
	{
		return z0yek.GetHashCode();
	}
}
