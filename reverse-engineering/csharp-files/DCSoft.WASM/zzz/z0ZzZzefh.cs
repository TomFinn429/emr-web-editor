using System;
using System.Buffers;

namespace zzz;

internal ref struct z0ZzZzefh
{
	private char[] z0uek;

	private Span<char> z0iek;

	private int z0oek;

	public z0ZzZzefh(Span<char> p0)
	{
		z0uek = null;
		z0iek = p0;
		z0oek = 0;
	}

	public z0ZzZzefh(int p0)
	{
		z0uek = ArrayPool<char>.Shared.Rent(p0);
		z0iek = z0uek;
		z0oek = 0;
	}

	public int z0rek()
	{
		return z0oek;
	}

	public void z0rek(int p0)
	{
		z0oek = p0;
	}

	public override string ToString()
	{
		string result = z0iek.Slice(0, z0oek).ToString();
		z0tek();
		return result;
	}

	public void z0rek(char p0)
	{
		int num = z0oek;
		if ((uint)num < (uint)z0iek.Length)
		{
			z0iek[num] = p0;
			z0oek = num + 1;
		}
		else
		{
			z0tek(p0);
		}
	}

	public void z0rek(string p0)
	{
		if (p0 != null)
		{
			int num = z0oek;
			if (p0.Length == 1 && (uint)num < (uint)z0iek.Length)
			{
				z0iek[num] = p0[0];
				z0oek = num + 1;
			}
			else
			{
				z0tek(p0);
			}
		}
	}

	private void z0tek(string p0)
	{
		int num = z0oek;
		if (num > z0iek.Length - p0.Length)
		{
			z0yek(p0.Length);
		}
		p0.CopyTo(z0iek.Slice(num));
		z0oek += p0.Length;
	}

	public void z0eek(ReadOnlySpan<char> p0)
	{
		if (z0oek > z0iek.Length - p0.Length)
		{
			z0yek(p0.Length);
		}
		p0.CopyTo(z0iek.Slice(z0oek));
		z0oek += p0.Length;
	}

	public Span<char> z0tek(int p0)
	{
		int num = z0oek;
		if (num > z0iek.Length - p0)
		{
			z0yek(p0);
		}
		z0oek = num + p0;
		return z0iek.Slice(num, p0);
	}

	private void z0tek(char p0)
	{
		z0yek(1);
		z0rek(p0);
	}

	private void z0yek(int p0)
	{
		char[] array = ArrayPool<char>.Shared.Rent((int)Math.Max((uint)(z0oek + p0), (uint)(z0iek.Length * 2)));
		z0iek.Slice(0, z0oek).CopyTo(array);
		char[] array2 = z0uek;
		z0iek = (z0uek = array);
		if (array2 != null)
		{
			ArrayPool<char>.Shared.Return(array2);
		}
	}

	public void z0tek()
	{
		char[] array = z0uek;
		this = default(z0ZzZzefh);
		if (array != null)
		{
			ArrayPool<char>.Shared.Return(array);
		}
	}
}
