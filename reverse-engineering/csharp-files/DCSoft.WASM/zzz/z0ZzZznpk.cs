using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;

namespace zzz;

[DebuggerTypeProxy(typeof(z0ZzZzkik))]
[DebuggerDisplay("Count={ Count }")]
[DefaultMember("Item")]
public class z0ZzZznpk : z0ZzZzqmk, IEnumerable
{
	private double z0uek = 1.0;

	protected z0ZzZzsmk z0iek;

	protected z0ZzZzodh z0oek = z0ZzZzodh.z0yek;

	internal zzz.z0ZzZzkuk<z0ZzZzsmk> z0pek = new zzz.z0ZzZzkuk<z0ZzZzsmk>();

	public void z0eek(double p0)
	{
		z0uek = p0;
	}

	public void z0eek(int p0, int p1, bool p2)
	{
		if (p0 == 0 && p1 == 0)
		{
			return;
		}
		if (p2)
		{
			z0oek.z0eek(p0, p1);
		}
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				z0ZzZzsmk obj = (z0ZzZzsmk)enumerator.Current;
				obj.z0eek(p0, p1);
				obj.z0drk.z0rek(p0, p1);
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	public z0ZzZzsmk z0eek(int p0)
	{
		return z0pek[p0];
	}

	public z0ZzZzsmk z0eek(float p0, float p1, bool p2, bool p3, bool p4)
	{
		if (z0yek() == 0)
		{
			return null;
		}
		using (zzz.z0ZzZzkuk<z0ZzZzsmk>.z0bpk z0bpk = z0pek.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				z0ZzZzsmk current = z0bpk.Current;
				if (p4 && !current.z0oek())
				{
					continue;
				}
				if (p2)
				{
					if (current.z0grk.z0eek(p0, p1))
					{
						return current;
					}
				}
				else if (current.z0srk.z0eek(p0, p1))
				{
					return current;
				}
			}
		}
		if (p3)
		{
			float num = 0f;
			int index = 0;
			int count = z0pek.Count;
			for (int i = 0; i < count; i++)
			{
				z0ZzZzsmk z0ZzZzsmk2 = z0pek[i];
				if (!p4 || z0ZzZzsmk2.z0oek())
				{
					z0ZzZzbdh p5 = (p2 ? z0ZzZzsmk2.z0grk : z0ZzZzsmk2.z0srk);
					if (p5.z0eek(p0, p1))
					{
						return z0pek[i];
					}
					float num2 = z0ZzZzjmk.z0eek(p0, p1, p5);
					if (i == 0 || num2 < num)
					{
						num = num2;
						index = i;
					}
				}
			}
			return z0pek[index];
		}
		return null;
	}

	public override bool z0hwk(int p0, int p1)
	{
		return z0eek(p0, p1) != null;
	}

	public z0ZzZzsmk z0eek(float p0, float p1, bool p2, z0ZzZzepk p3, bool p4)
	{
		if (z0yek() == 0)
		{
			return null;
		}
		using (zzz.z0ZzZzkuk<z0ZzZzsmk>.z0bpk z0bpk = z0pek.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				z0ZzZzsmk current = z0bpk.Current;
				if (p4 && !current.z0oek())
				{
					continue;
				}
				if (p2)
				{
					if (current.z0mek().z0eek(p0, p1))
					{
						return current;
					}
				}
				else if (current.z0rek().z0eek(p0, p1))
				{
					return current;
				}
			}
		}
		switch (p3)
		{
		case (z0ZzZzepk)0:
			return null;
		case (z0ZzZzepk)1:
		{
			float num3 = 0f;
			int index2 = 0;
			for (int j = 0; j < z0pek.Count; j++)
			{
				z0ZzZzsmk z0ZzZzsmk3 = z0pek[j];
				if (!p4 || z0ZzZzsmk3.z0oek())
				{
					z0ZzZzbdh p5 = (p2 ? z0ZzZzsmk3.z0mek() : z0ZzZzsmk3.z0rek());
					if (p5.z0eek(p0, p1))
					{
						return z0pek[j];
					}
					float num4 = z0ZzZzjmk.z0eek(p0, p1, p5);
					if (j == 0 || num4 < num3)
					{
						num3 = num4;
						index2 = j;
					}
				}
			}
			return z0pek[index2];
		}
		case (z0ZzZzepk)2:
		case (z0ZzZzepk)3:
		{
			float num = 3.4028235E+38f;
			int index = 0;
			for (int i = 0; i < z0pek.Count; i++)
			{
				z0ZzZzsmk z0ZzZzsmk2 = z0pek[i];
				if (p4 && !z0ZzZzsmk2.z0oek())
				{
					continue;
				}
				z0ZzZzbdh z0ZzZzbdh2 = (p2 ? z0ZzZzsmk2.z0mek() : z0ZzZzsmk2.z0rek());
				if (z0ZzZzbdh2.z0eek(p0, p1))
				{
					return z0pek[i];
				}
				float num2 = 3.4028235E+38f;
				switch (p3)
				{
				case (z0ZzZzepk)2:
					num2 = p1 - z0ZzZzbdh2.z0nek();
					if (num2 < num && num2 >= 0f)
					{
						num = num2;
						index = i;
					}
					break;
				case (z0ZzZzepk)3:
					num2 = z0ZzZzbdh2.z0pek() - p1;
					if (num2 < num && num2 >= 0f)
					{
						num = num2;
						index = i;
					}
					break;
				}
			}
			return z0pek[index];
		}
		default:
			return null;
		}
	}

	public void z0eek(z0ZzZzsmk p0)
	{
		z0pek.Add(p0);
	}

	public void z0eek()
	{
		z0pek.Clear();
	}

	public override z0ZzZzodh z0jwk(int p0, int p1)
	{
		z0ZzZzodh result = z0ZzZzodh.z0yek;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				z0ZzZzsmk z0ZzZzsmk2 = (z0ZzZzsmk)enumerator.Current;
				if (z0ZzZzsmk2.z0oek() && z0ZzZzsmk2.z0uek().z0eek(p0, p1))
				{
					return z0ZzZzsmk2.z0jwk(p0, p1);
				}
			}
			return result;
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	public override z0ZzZzodh z0gwk(int p0, int p1)
	{
		return z0eek(p0, p1)?.z0gwk(p0, p1) ?? z0ZzZzodh.z0yek;
	}

	public override z0ZzZzcdh z0kwk(int p0, int p1)
	{
		_ = z0ZzZzpdh.z0yek;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				z0ZzZzsmk z0ZzZzsmk2 = (z0ZzZzsmk)enumerator.Current;
				if (z0ZzZzsmk2.z0oek())
				{
					z0ZzZzsmk2.z0kwk(p0, p1);
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return new z0ZzZzcdh((int)((double)p0 / z0uek), (int)((double)p1 / z0uek));
	}

	public override z0ZzZzxdh z0dwk(z0ZzZzxdh p0)
	{
		return z0lwk(p0.z0rek(), p0.z0tek());
	}

	public override z0ZzZzxdh z0zqk(float p0, float p1)
	{
		return new z0ZzZzxdh((float)((double)p0 * z0uek), (float)((double)p1 * z0uek));
	}

	public IEnumerator GetEnumerator()
	{
		return z0pek.z0ltk();
	}

	public z0ZzZzsmk z0rek(int p0)
	{
		return z0pek[p0];
	}

	public z0ZzZzsmk z0eek(int p0, int p1)
	{
		Span<z0ZzZzsmk> span = z0pek.z0urk();
		for (int num = span.Length - 1; num >= 0; num--)
		{
			z0ZzZzsmk z0ZzZzsmk2 = span[num];
			if (z0ZzZzsmk2.z0oek() && z0ZzZzsmk2.z0grk.z0eek(p0, p1))
			{
				return z0ZzZzsmk2;
			}
		}
		return null;
	}

	public double z0rek()
	{
		return z0uek;
	}

	public Span<z0ZzZzsmk> z0tek()
	{
		return z0pek.z0urk();
	}

	public int z0yek()
	{
		return z0pek.Count;
	}

	public override void z0vqk()
	{
		if (z0pek != null)
		{
			using (zzz.z0ZzZzkuk<z0ZzZzsmk>.z0bpk z0bpk = z0pek.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					z0bpk.Current.z0vqk();
				}
			}
			z0pek.Clear();
			z0pek = null;
		}
		z0iek = null;
		base.z0vqk();
	}

	public override z0ZzZzxdh z0lwk(float p0, float p1)
	{
		_ = z0ZzZzpdh.z0yek;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				z0ZzZzsmk z0ZzZzsmk2 = (z0ZzZzsmk)enumerator.Current;
				if (z0ZzZzsmk2.z0oek())
				{
					return z0ZzZzsmk2.z0lwk(p0, p1);
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return new z0ZzZzxdh((float)((double)p0 / z0uek), (float)((double)p1 / z0uek));
	}

	public override z0ZzZzcdh z0fwk(z0ZzZzcdh p0)
	{
		return z0kwk(p0.z0rek(), p0.z0tek());
	}

	public override z0ZzZzpdh z0bqk(float p0, float p1)
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				z0ZzZzsmk z0ZzZzsmk2 = (z0ZzZzsmk)enumerator.Current;
				if (z0ZzZzsmk2.z0mek().z0eek(p0, p1) && z0ZzZzsmk2.z0oek())
				{
					return z0ZzZzsmk2.z0bqk(p0, p1);
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return new z0ZzZzpdh(p0, p1);
	}

	public override z0ZzZzpdh z0xqk(float p0, float p1)
	{
		z0ZzZzpdh result = z0ZzZzpdh.z0yek;
		z0ZzZzsmk z0ZzZzsmk2 = null;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				z0ZzZzsmk z0ZzZzsmk3 = (z0ZzZzsmk)enumerator.Current;
				if (z0ZzZzsmk3.z0oek() && z0ZzZzsmk3.z0rek().z0eek(p0, p1))
				{
					if (!((double)Math.Abs(p1 - z0ZzZzsmk3.z0rek().z0nek()) < 0.5))
					{
						result = z0ZzZzsmk3.z0xqk(p0, p1);
						break;
					}
					z0ZzZzsmk2 = z0ZzZzsmk3;
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		if (z0ZzZzsmk2 != null)
		{
			result = z0ZzZzsmk2.z0xqk(p0, p1);
		}
		return result;
	}

	public z0ZzZzsmk z0eek(float p0, float p1)
	{
		return z0eek(p0, p1, p2: false, p3: false, p4: false);
	}
}
