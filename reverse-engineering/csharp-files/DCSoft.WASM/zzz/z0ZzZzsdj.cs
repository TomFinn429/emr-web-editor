using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzsdj : z0ZzZzodj
{
	private new Dictionary<int, short> z0rek = new Dictionary<int, short>();

	internal new static readonly string z0tek = "kern";

	internal z0ZzZzsdj(z0ZzZzjgj p0)
		: base(z0tek, p0)
	{
		int num = p0.z0mek();
		z0ZzZzjgj z0ZzZzjgj2 = z0uek();
		z0ZzZzjgj2.z0rek();
		int num2 = z0ZzZzjgj2.z0rek();
		int i = 0;
		int num3 = 6;
		for (; i < num2; i++)
		{
			if (num3 >= num)
			{
				break;
			}
			z0ZzZzjgj2.z0eek((long)num3);
			num3 += z0ZzZzjgj2.z0rek();
			if ((z0ZzZzjgj2.z0rek() & 0xFFF7) != 1)
			{
				continue;
			}
			int num4 = z0ZzZzjgj2.z0rek();
			z0ZzZzjgj2.z0rek(6);
			for (int j = 0; j < num4; j++)
			{
				int num5 = z0ZzZzjgj2.z0nek();
				short num6 = z0ZzZzjgj2.z0yek();
				if (!z0rek.ContainsKey(num5))
				{
					z0rek[num5] = num6;
				}
			}
		}
	}

	internal short z0eek(int p0, int p1)
	{
		if (!z0rek.TryGetValue((p0 << 16) + p1, out var result))
		{
			return 0;
		}
		return result;
	}
}
