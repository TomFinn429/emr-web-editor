using System.Collections.Generic;

namespace zzz;

public class z0ZzZzwyk : IEqualityComparer<byte[]>
{
	private bool z0eek;

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
		if (x.Length != 0)
		{
			for (int num = x.Length - 1; num >= 0; num--)
			{
				if (x[num] != y[num])
				{
					return false;
				}
			}
		}
		return true;
	}

	public unsafe int GetHashCode(byte[] obj)
	{
		if (obj == null || obj.Length == 0)
		{
			return 0;
		}
		if (z0eek)
		{
			return obj.GetHashCode();
		}
		fixed (byte* ptr = obj)
		{
			byte* ptr2 = ptr + obj.Length - 1;
			int num = 5381;
			while (ptr2 >= ptr)
			{
				num = ((num << 5) + num) ^ *ptr2;
				ptr2--;
			}
			return num;
		}
	}

	public z0ZzZzwyk(bool p0)
	{
		z0eek = p0;
	}

	public z0ZzZzwyk()
	{
	}
}
