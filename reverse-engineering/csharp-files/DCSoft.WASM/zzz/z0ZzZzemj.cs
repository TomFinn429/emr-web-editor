using System;
using System.Collections;
using System.Collections.Generic;

namespace zzz;

public class z0ZzZzemj : IEnumerable
{
	private Dictionary<string, z0ZzZzrmj> z0tek_jiejie20260327142557;

	private readonly List<z0ZzZzcmj> z0yek = new List<z0ZzZzcmj>();

	private static readonly z0ZzZzemj z0uek = new z0ZzZzemj();

	internal z0ZzZzrmj z0eek(string p0)
	{
		if (z0tek_jiejie20260327142557 == null)
		{
			z0tek_jiejie20260327142557 = new Dictionary<string, z0ZzZzrmj>();
			{
				IEnumerator enumerator = GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						foreach (z0ZzZzrmj item in ((z0ZzZzcmj)enumerator.Current).z0rek())
						{
							string z0tek = item.z0tek;
							if (!string.IsNullOrEmpty(z0tek))
							{
								z0tek_jiejie20260327142557[z0tek.ToLower()] = item;
							}
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
			}
		}
		if (!string.IsNullOrEmpty(p0))
		{
			z0ZzZzrmj result = null;
			if (z0tek_jiejie20260327142557.TryGetValue(p0.ToLower(), out result))
			{
				return result;
			}
		}
		return null;
	}

	public static z0ZzZzemj z0eek()
	{
		return z0uek;
	}

	public void z0rek()
	{
		z0ZzZzcmj.z0eek(z0yek);
	}

	public void z0eek(z0ZzZzcmj p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("mdl");
		}
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				if (((z0ZzZzcmj)enumerator.Current).GetType().Equals(p0.GetType()))
				{
					return;
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
		z0yek.Add(p0);
		z0tek_jiejie20260327142557 = null;
	}

	public IEnumerator GetEnumerator()
	{
		return z0yek.GetEnumerator();
	}
}
