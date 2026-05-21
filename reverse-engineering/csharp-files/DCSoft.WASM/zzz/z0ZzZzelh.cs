using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzelh : z0ZzZzxzj
{
	private new z0ZzZzmzj z0yek;

	private z0ZzZzmzj z0uek;

	public override void z0yo(z0ZzZzpgh p0)
	{
		z0yek.z0yek().z0pek(z0rek());
	}

	internal void z0eek(z0ZzZzmzj p0)
	{
		z0uek = p0;
	}

	public override void Dispose()
	{
		base.Dispose();
		if (z0uek != null)
		{
			z0uek.Dispose();
			z0uek = null;
		}
		if (z0yek != null)
		{
			z0yek.Dispose();
			z0yek = null;
		}
	}

	public override void z0to(z0ZzZzpgh p0)
	{
		z0tek().z0yek().z0pek(z0tek());
	}

	internal void z0rek(z0ZzZzmzj p0)
	{
		z0yek = p0;
	}

	internal new void z0eek()
	{
		if (z0uek == null || z0yek == null)
		{
			return;
		}
		z0ZzZzpzj[] array = z0uek.z0oek();
		for (int i = 0; i < array.Length; i++)
		{
			z0ZzZzizj[] z0oek = array[i].z0oek;
			foreach (z0ZzZzizj z0ZzZzizj2 in z0oek)
			{
				z0ZzZzpzj[] array2 = z0yek.z0oek();
				for (int k = 0; k < array2.Length; k++)
				{
					z0ZzZzizj[] z0oek2 = array2[k].z0oek;
					int num = 0;
					z0ZzZzizj z0ZzZzizj3;
					while (num < z0oek2.Length)
					{
						z0ZzZzizj3 = z0oek2[num];
						if (z0ZzZzizj2.z0yek() != z0ZzZzizj3.z0yek())
						{
							num++;
							continue;
						}
						goto IL_007b;
					}
					continue;
					IL_007b:
					XTextElement[] array3 = z0ZzZzizj2.z0pek();
					XTextElement[] array4 = z0ZzZzizj3.z0pek();
					if (array3 == null || array4 == null || array3.Length != array4.Length)
					{
						break;
					}
					bool flag = true;
					for (int l = 0; l < array3.Length; l++)
					{
						if (array3[l] != array4[l])
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						z0ZzZzizj2.z0eek(null);
						z0ZzZzizj3.z0eek(null);
					}
					break;
				}
			}
		}
	}

	internal new z0ZzZzmzj z0rek()
	{
		return z0yek;
	}

	internal z0ZzZzmzj z0tek()
	{
		return z0uek;
	}
}
