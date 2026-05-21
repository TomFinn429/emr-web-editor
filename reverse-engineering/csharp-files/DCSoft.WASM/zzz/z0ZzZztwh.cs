using System.Text;

namespace zzz;

public static class z0ZzZztwh
{
	public static string z0eek(string p0)
	{
		return z0ZzZzuwh.z0eek(p0);
	}

	public static byte[] z0eek(string p0, Encoding p1)
	{
		if (p0 == null)
		{
			return null;
		}
		byte[] bytes = p1.GetBytes(p0);
		return z0ZzZzuwh.z0eek(bytes, 0, bytes.Length, p3: false);
	}

	public static string z0rek(string p0)
	{
		return z0ZzZzuwh.z0rek(p0);
	}

	public static string z0rek(string p0, Encoding p1)
	{
		return z0ZzZzuwh.z0eek(p0, p1);
	}

	public static string z0tek(string p0)
	{
		return z0tek(p0, Encoding.UTF8);
	}

	public static string z0yek(string p0)
	{
		return z0ZzZzuwh.z0tek(p0);
	}

	public static string z0uek(string p0)
	{
		return z0rek(p0, Encoding.UTF8);
	}

	public static string z0tek(string p0, Encoding p1)
	{
		if (p0 != null)
		{
			return Encoding.ASCII.GetString(z0eek(p0, p1));
		}
		return null;
	}
}
