using System;

namespace zzz;

public class z0ZzZzgik<T>
{
	public delegate T z0rpk();

	private z0rpk z0uek;

	public static zzz.z0ZzZzgik<T> z0iek = new zzz.z0ZzZzgik<T>();

	private int z0oek;

	private T[] z0pek = Array.Empty<T>();

	public void z0eek(Action<T> p0)
	{
		if (z0pek.Length == 0)
		{
			return;
		}
		if (p0 != null)
		{
			T[] array = z0pek;
			foreach (T val in array)
			{
				if (val != null)
				{
					p0(val);
				}
			}
		}
		else if (z0pek[0] is Array)
		{
			T[] array = z0pek;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] is Array { Length: >0 } array2)
				{
					Array.Clear(array2, 0, array2.Length);
				}
			}
		}
		Array.Clear(z0pek, 0, z0oek);
		z0pek = Array.Empty<T>();
		z0oek = 0;
	}

	public void z0rek(z0rpk p0)
	{
		z0uek = p0;
	}

	public void z0tek(T p0)
	{
		if (z0oek >= z0pek.Length)
		{
			T[] array = new T[z0pek.Length + 4];
			if (z0oek > 0)
			{
				Array.Copy(z0pek, 0, array, 0, z0oek);
				Array.Clear(z0pek, 0, z0oek);
			}
			z0pek = array;
		}
		z0pek[z0oek++] = p0;
	}

	public T z0yek()
	{
		if (z0oek > 0)
		{
			T result = z0pek[z0oek - 1];
			z0oek--;
			return result;
		}
		return z0uek();
	}
}
