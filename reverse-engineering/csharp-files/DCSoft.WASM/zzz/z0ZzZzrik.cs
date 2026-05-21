using System;

namespace zzz;

public class z0ZzZzrik : zzz.z0ZzZztik<byte[], byte[]>
{
	protected override byte[] z0uwk(int p0, int p1)
	{
		byte[] array = new byte[p1];
		Buffer.BlockCopy(z0tek, p0, array, 0, p1);
		return array;
	}

	protected override bool z0ywk(int p0, int p1, int p2)
	{
		byte[] array = z0tek;
		for (int i = 0; i < p2; i++)
		{
			if (array[i + p0] != array[i + p1])
			{
				return false;
			}
		}
		return true;
	}

	protected override int z0twk(int p0, int p1)
	{
		byte[] array = z0tek;
		int num = 314;
		int num2 = 159;
		int num3 = 0;
		for (int i = 0; i < p1; i++)
		{
			num3 = num3 * num + array[i];
			num *= num2;
		}
		return num3;
	}

	public z0ZzZzrik(byte[] p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			throw new ArgumentNullException("bs");
		}
		z0tek = p0;
	}
}
