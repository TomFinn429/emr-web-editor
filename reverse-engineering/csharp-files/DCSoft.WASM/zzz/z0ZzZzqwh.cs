using System;

namespace zzz;

internal class z0ZzZzqwh
{
	private static readonly char[] z0yek_jiejie20260327142557 = Array.Empty<char>();

	private char[] z0uek;

	private int z0iek;

	public void z0eek()
	{
		z0uek = z0yek_jiejie20260327142557;
		z0iek = 0;
	}

	public char[] z0rek()
	{
		return z0uek;
	}

	public z0ZzZzqwh(int p0)
	{
		z0uek = new char[p0];
	}

	private void z0eek(int p0)
	{
		char[] array = new char[(z0iek + p0) * 2];
		Array.Copy(z0uek, array, z0iek);
		z0uek = array;
	}

	public override string ToString()
	{
		return z0eek(0, z0iek);
	}

	public int z0tek()
	{
		return z0iek;
	}

	public void z0eek(char[] p0, int p1, int p2)
	{
		if (z0iek + p2 >= z0uek.Length)
		{
			z0eek(p2);
		}
		Array.Copy(p0, p1, z0uek, z0iek, p2);
		z0iek += p2;
	}

	public string z0eek(int p0, int p1)
	{
		return new string(z0uek, p0, p1);
	}

	public void z0rek(int p0)
	{
		z0iek = p0;
	}

	public void z0eek(char p0)
	{
		if (z0iek == z0uek.Length)
		{
			z0eek(1);
		}
		z0uek[z0iek++] = p0;
	}
}
