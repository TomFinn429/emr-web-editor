using System;

namespace zzz;

public class z0ZzZzuik : zzz.z0ZzZztik<string, string>
{
	protected override string z0uwk(int p0, int p1)
	{
		return z0tek.Substring(p0, p1);
	}

	protected unsafe override int z0twk(int p0, int p1)
	{
		fixed (char* ptr = z0tek)
		{
			char* ptr2 = ptr + p0 + p1;
			char* ptr3 = ptr2 - p1;
			int num = 5381;
			for (; ptr3 < ptr2; ptr3++)
			{
				num = ((num << 5) + num) ^ *ptr3;
			}
			return num;
		}
	}

	protected override bool z0ywk(int p0, int p1, int p2)
	{
		return string.CompareOrdinal(z0tek, p0, z0tek, p1, p2) == 0;
	}

	public z0ZzZzuik(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			throw new ArgumentNullException("txt");
		}
		z0tek = p0;
	}
}
