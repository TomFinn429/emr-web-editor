using System.Collections.Generic;
using System.Windows.Forms;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZztmj
{
	private class z0dpk : IComparer<z0ZzZzrmj>
	{
		public int Compare(z0ZzZzrmj x, z0ZzZzrmj y)
		{
			return string.Compare(x.z0tek, y.z0tek, true);
		}
	}

	private readonly z0ZzZzvmj z0yek = new z0ZzZzvmj();

	public z0ZzZzvmj z0eek()
	{
		return z0yek;
	}

	public z0ZzZzrmj z0eek(z0ZzZzdbj p0, XTextDocument p1, z0ZzZzheh p2)
	{
		z0ZzZzomj z0ZzZzomj2 = new z0ZzZzomj(p0, p1, (z0ZzZzmmj)3, null);
		z0ZzZzomj2.AltKey = p2.z0oek();
		z0ZzZzomj2.ShiftKey = p2.z0yek();
		z0ZzZzomj2.CtlKey = p2.z0iek();
		z0ZzZzomj2.KeyCode = p2.z0uek();
		foreach (z0ZzZzrmj item in z0eek())
		{
			if (!item.z0iek)
			{
				continue;
			}
			z0ZzZzomj2.Parameter = null;
			if (item.z0yek != Keys.None)
			{
				z0ZzZzcnj z0ZzZzcnj2 = new z0ZzZzcnj(item.z0yek);
				if (z0ZzZzcnj2.z0rek() == p2.z0oek() && z0ZzZzcnj2.z0tek() == p2.z0yek() && z0ZzZzcnj2.z0eek() == p2.z0iek() && z0ZzZzcnj2.z0uek() == p2.z0uek())
				{
					z0ZzZzomj2.Enabled = true;
					z0ZzZzomj2.Actived = true;
					item.z0iz(z0ZzZzomj2);
					if (z0ZzZzomj2.Actived && z0ZzZzomj2.Enabled)
					{
						return item;
					}
				}
			}
			z0ZzZzomj2.Actived = false;
			item.z0iz(z0ZzZzomj2);
			if (z0ZzZzomj2.Enabled && z0ZzZzomj2.Actived)
			{
				return item;
			}
		}
		foreach (z0ZzZzcmj item2 in z0rek())
		{
			z0ZzZzvmj z0ZzZzvmj2 = item2.z0rek();
			for (int i = 0; i < z0ZzZzvmj2.Count; i++)
			{
				z0ZzZzrmj z0ZzZzrmj2 = z0ZzZzvmj2[i];
				if (!z0ZzZzrmj2.z0iek)
				{
					continue;
				}
				z0ZzZzomj2.Parameter = null;
				if (z0ZzZzrmj2.z0yek != Keys.None)
				{
					z0ZzZzcnj z0ZzZzcnj3 = new z0ZzZzcnj(z0ZzZzrmj2.z0yek);
					if (z0ZzZzcnj3.z0rek() == p2.z0oek() && z0ZzZzcnj3.z0tek() == p2.z0yek() && z0ZzZzcnj3.z0eek() == p2.z0iek() && z0ZzZzcnj3.z0uek() == p2.z0uek())
					{
						z0ZzZzomj2.Enabled = true;
						z0ZzZzomj2.Actived = true;
						z0ZzZzrmj2.z0iz(z0ZzZzomj2);
						if (z0ZzZzomj2.Enabled && z0ZzZzomj2.Actived)
						{
							return z0ZzZzrmj2;
						}
					}
				}
				z0ZzZzomj2.Actived = false;
				z0ZzZzomj2.Enabled = true;
				z0ZzZzrmj2.z0iz(z0ZzZzomj2);
				if (z0ZzZzomj2.Enabled && z0ZzZzomj2.Actived)
				{
					return z0ZzZzrmj2;
				}
			}
		}
		return null;
	}

	public z0ZzZzrmj z0eek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return null;
		}
		z0ZzZzrmj z0ZzZzrmj2 = null;
		foreach (z0ZzZzrmj item in z0eek())
		{
			if (string.Compare(item.z0tek, p0, true) == 0 && (z0ZzZzrmj2 == null || z0ZzZzrmj2.z0rek > item.z0rek))
			{
				z0ZzZzrmj2 = item;
			}
		}
		z0ZzZzrmj z0ZzZzrmj3 = z0rek().z0eek(p0);
		if (z0ZzZzrmj2 == null || z0ZzZzrmj2.z0rek > z0ZzZzrmj3.z0rek)
		{
			z0ZzZzrmj2 = z0ZzZzrmj3;
		}
		return z0ZzZzrmj2;
	}

	public z0ZzZzrmj z0rek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return null;
		}
		foreach (z0ZzZzrmj item in z0eek())
		{
			if (string.Compare(item.z0tek, p0, true) == 0)
			{
				return item;
			}
		}
		foreach (z0ZzZzcmj item2 in z0rek())
		{
			foreach (z0ZzZzrmj item3 in item2.z0rek())
			{
				if (string.Compare(item3.z0tek, p0, true) == 0)
				{
					return item3;
				}
			}
		}
		return null;
	}

	public z0ZzZzemj z0rek()
	{
		return z0ZzZzemj.z0eek();
	}

	public z0ZzZzvmj z0tek()
	{
		z0ZzZzvmj z0ZzZzvmj2 = new z0ZzZzvmj();
		if (z0rek() != null)
		{
			foreach (z0ZzZzcmj item in z0rek())
			{
				foreach (z0ZzZzrmj item2 in item.z0rek())
				{
					z0ZzZzvmj2.z0eek(item2);
				}
			}
		}
		if (z0yek != null && z0yek.Count > 0)
		{
			foreach (z0ZzZzrmj item3 in z0yek)
			{
				z0ZzZzvmj2.z0eek(item3);
			}
		}
		z0ZzZzvmj2.Sort(new z0dpk());
		return z0ZzZzvmj2;
	}
}
