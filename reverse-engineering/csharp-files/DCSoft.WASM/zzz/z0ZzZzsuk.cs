using System;

namespace zzz;

public class z0ZzZzsuk<T>
{
	private static readonly T[] z0iek = Array.Empty<T>();

	private int z0oek;

	private T[] z0pek = z0iek;

	public void z0yek()
	{
		if (z0oek > 0)
		{
			Array.Clear(z0pek, 0, z0oek);
			z0pek = z0iek;
			z0oek = 0;
		}
	}

	public void z0eek(T p0)
	{
		if (z0oek == z0pek.Length)
		{
			T[] array = new T[(int)((double)z0oek * 1.5) + 4];
			if (z0pek.Length != 0)
			{
				Array.Copy(z0pek, array, z0oek);
				Array.Clear(z0pek, 0, z0oek);
			}
			z0pek = array;
		}
		z0pek[z0oek++] = p0;
	}

	public int z0uek()
	{
		return z0oek;
	}

	public T z0rek()
	{
		if (z0oek == 0)
		{
			throw new Exception("Peek()没有数据");
		}
		return z0pek[z0oek - 1];
	}

	public T z0tek()
	{
		if (z0oek == 0)
		{
			throw new Exception("Pop()没有数据");
		}
		int num = --z0oek;
		T result = z0pek[num];
		z0pek[num] = default(T);
		return result;
	}
}
