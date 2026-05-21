using System.Diagnostics;

namespace zzz;

[DebuggerDisplay("Count={ Count }")]
[DebuggerTypeProxy(typeof(z0ZzZzkik))]
public class z0ZzZzzok : zzz.z0ZzZzkuk<z0ZzZzcok>
{
	public void z0eek(bool p0)
	{
	}

	public int z0eek(z0ZzZzcok p0)
	{
		int num = z0cek(p0);
		if (num >= 0)
		{
			return num;
		}
		int count = base.Count;
		for (int i = 0; i < count; i++)
		{
			if (base[i].z0tek(p0))
			{
				return i;
			}
		}
		return -1;
	}

	public void z0eek()
	{
		int count = base.Count;
		for (int i = 0; i < count; i++)
		{
			base[i].Index = i;
		}
	}

	public z0ZzZzcok z0eek(int p0, z0ZzZzcok p1)
	{
		if (p0 >= 0 && p0 < z0wtk)
		{
			return z0atk[p0];
		}
		return p1;
	}
}
