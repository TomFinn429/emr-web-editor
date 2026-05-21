using System.Collections.Generic;

namespace zzz;

internal abstract class z0ZzZzrqj : z0ZzZzfsj
{
	private z0ZzZziaj z0pek;

	private readonly string z0nek = string.Empty;

	private readonly string z0bek;

	private readonly string z0vek_jiejie20260327142557;

	private readonly z0ZzZztqj z0cek;

	protected virtual z0ZzZzeaj z0lsk(z0ZzZzdsj p0)
	{
		z0ZzZzeaj z0ZzZzeaj2 = new z0ZzZzeaj(p0);
		z0ZzZzeaj2.z0yek("Type", "Font");
		z0ZzZzeaj2.Add("Subtype", new z0ZzZzhwj(z0cdk()));
		if (z0vek_jiejie20260327142557 != null)
		{
			z0ZzZzeaj2.Add("BaseFont", new z0ZzZzhwj(z0vek_jiejie20260327142557));
		}
		object obj = z0zdk_jiejie20260327142557().z0jfk(p0);
		if (obj != null)
		{
			z0ZzZzeaj2.Add("Encoding", obj);
		}
		if (z0pek != null)
		{
			z0ZzZzeaj2.Add("ToUnicode", p0.z0uek(z0pek.z0rek()));
		}
		return z0ZzZzeaj2;
	}

	internal new z0ZzZziaj z0eek()
	{
		return z0pek;
	}

	protected internal abstract z0ZzZzfqj z0zdk_jiejie20260327142557();

	protected internal override object z0ngk(z0ZzZzdsj p0)
	{
		return z0lsk(p0);
	}

	internal new string z0rek()
	{
		return z0vek_jiejie20260327142557;
	}

	protected internal abstract string z0cdk();

	protected internal virtual bool z0tek()
	{
		return true;
	}

	internal virtual z0ZzZztqj z0yek()
	{
		return z0cek;
	}

	protected internal virtual void z0bdk(z0ZzZzeaj p0)
	{
	}

	private z0ZzZzrqj(int p0, string p1)
		: base(p0)
	{
		z0vek_jiejie20260327142557 = p1;
		if (p1.Length >= 7 && p1[6] == '+')
		{
			z0nek = p1.Substring(0, 6);
			string text = z0nek;
			for (int i = 0; i < text.Length; i++)
			{
				if (!char.IsUpper(text[i]))
				{
					z0nek = string.Empty;
					break;
				}
			}
		}
		z0bek = (string.IsNullOrEmpty(z0nek) ? p1 : p1.Substring(7));
	}

	protected internal abstract IEnumerable<double> z0vdk();

	internal void z0eek(z0ZzZziaj p0)
	{
		z0pek = p0;
	}

	protected z0ZzZzrqj(string p0, z0ZzZztqj p1)
		: this(-1, p0)
	{
		z0cek = p1;
		p1.z0eek(this);
	}
}
