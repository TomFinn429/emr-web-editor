using System.Collections.Generic;

namespace zzz;

public class z0ZzZzbij : IEqualityComparer<byte[]>
{
	public static readonly z0ZzZzbij z0eek = new z0ZzZzbij();

	public int GetHashCode(byte[] obj)
	{
		if (obj == null || obj.Length == 0)
		{
			return 0;
		}
		int num = obj.Length;
		for (int num2 = obj.Length - 1; num2 >= 0; num2--)
		{
			byte b = obj[num2];
			num += b;
			num += b << 3;
		}
		return num;
	}

	public bool Equals(byte[] x, byte[] y)
	{
		if (x == y)
		{
			return true;
		}
		if (x == null || y == null)
		{
			return false;
		}
		if (x.Length != y.Length)
		{
			return false;
		}
		for (int num = x.Length - 1; num >= 0; num--)
		{
			if (x[num] != y[num])
			{
				return false;
			}
		}
		return true;
	}
}
