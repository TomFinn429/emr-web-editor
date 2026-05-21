using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace zzz;

public abstract class z0ZzZzcmj : IDisposable
{
	private static readonly List<Type> z0yek = new List<Type>();

	private z0ZzZzvmj z0uek;

	private bool z0iek = true;

	public virtual void Dispose()
	{
	}

	public static void AddGlobalModuleType(Type t)
	{
		if (t == null)
		{
			throw new ArgumentNullException("t");
		}
		if (!t.IsSubclassOf(typeof(z0ZzZzcmj)))
		{
			throw new InvalidCastException(t.FullName + "=>WriterCommandModule");
		}
		if (!z0yek.Contains(t))
		{
			z0yek.Add(t);
		}
	}

	public void z0rek(bool p0)
	{
		z0iek = p0;
	}

	internal static void z0eek(List<z0ZzZzcmj> p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("list");
		}
		foreach (Type item in z0yek)
		{
			bool flag = false;
			foreach (z0ZzZzcmj item2 in p0)
			{
				if (item2.GetType() == item)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				p0.Add((z0ZzZzcmj)Activator.CreateInstance(item));
			}
		}
	}

	protected virtual z0ZzZzvmj z0qz()
	{
		throw new NotSupportedException();
	}

	public virtual z0ZzZzvmj z0rek()
	{
		if (z0uek == null)
		{
			z0uek = z0qz();
		}
		return z0uek;
	}

	public bool z0tek()
	{
		return z0iek;
	}

	protected static void z0rek(z0ZzZzvmj p0, string p1, z0ZzZzpmj p2, Keys p3 = Keys.None)
	{
		z0ZzZzumj z0ZzZzumj2 = new z0ZzZzumj();
		z0ZzZzumj2.z0tek = p1;
		z0ZzZzumj2.z0yek = p3;
		z0ZzZzumj2.z0eek = p2;
		p0.Add(z0ZzZzumj2);
	}
}
