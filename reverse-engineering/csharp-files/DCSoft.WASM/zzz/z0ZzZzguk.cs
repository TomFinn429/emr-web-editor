using System;
using System.Collections.Generic;

namespace zzz;

internal static class z0ZzZzguk<T>
{
	public static Action<T> z0oek = null;

	private static T[] z0pek = Array.Empty<T>();

	private static int z0mek = 0;

	public static void z0eek(Action<T> p0)
	{
		for (int i = 0; i < z0mek; i++)
		{
			p0(z0pek[i]);
		}
	}

	public static T z0rek()
	{
		if (z0mek > 0)
		{
			z0mek--;
			T result = z0pek[z0mek];
			z0pek[z0mek] = default(T);
			return result;
		}
		return default(T);
	}

	public static void z0tek(T p0)
	{
		if (p0 == null)
		{
			ArgumentNullException.ThrowIfNull(p0, "item");
		}
		if (z0pek.Length < z0mek + 1)
		{
			T[] array = new T[z0mek + 5];
			Array.Copy(z0pek, array, z0mek);
			Array.Clear(z0pek);
			z0pek = array;
		}
		z0pek[z0mek++] = p0;
		if (z0oek != null)
		{
			z0oek(p0);
		}
	}

	public static void z0iek(int p0 = 0)
	{
		if (z0mek < p0)
		{
			return;
		}
		for (int i = 0; i < z0mek; i++)
		{
			T val = z0pek[i];
			if (val is IDisposable)
			{
				((IDisposable)(object)val).Dispose();
			}
		}
		Array.Clear(z0pek);
		z0pek = Array.Empty<T>();
		z0mek = 0;
	}

	public static int z0iek()
	{
		return z0mek;
	}

	public static void z0yek(Action<T> p0)
	{
		if (p0 != null)
		{
			for (int i = 0; i < z0mek; i++)
			{
				T val = z0pek[i];
				p0(val);
			}
		}
		Array.Clear(z0pek);
		z0pek = Array.Empty<T>();
		z0mek = 0;
	}

	public static void z0uek(IList<T> p0)
	{
		if (p0 == null)
		{
			ArgumentNullException.ThrowIfNull(p0, "items");
		}
		if (z0pek.Length < z0mek + p0.Count)
		{
			T[] array = new T[z0mek + p0.Count + 10];
			Array.Copy(z0pek, array, z0mek);
			Array.Clear(z0pek);
			z0pek = array;
		}
		for (int i = 0; i < p0.Count; i++)
		{
			z0pek[z0mek + i] = p0[i];
			if (z0oek != null)
			{
				z0oek(p0[i]);
			}
		}
		z0mek += p0.Count;
	}
}
