using System;
using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzagj : z0ZzZzzdj
{
	internal override byte[] z0dsk()
	{
		IList<z0ZzZzndj> list = z0eek();
		int count = list.Count;
		if (count < 1)
		{
			return Array.Empty<byte>();
		}
		int num = z0fsk();
		byte[] array = new byte[count * num];
		int i = 0;
		int num2 = 0;
		for (; i < count; i++)
		{
			int num3 = list[i].z0eek();
			for (int num4 = num - 1; num4 >= 0; num4--)
			{
				array[num2++] = (byte)((num3 >> 8 * num4) & 0xFF);
			}
		}
		return array;
	}

	internal z0ZzZzagj(IList<z0ZzZzndj> p0)
		: base(p0)
	{
	}

	internal z0ZzZzagj()
	{
	}

	protected override int z0fsk()
	{
		return 2;
	}
}
