using System;

namespace zzz;

internal class z0ZzZzydj : z0ZzZzodj
{
	private enum z0ggj
	{
		z0eek
	}

	[Flags]
	private enum z0hhj
	{
		z0eek = 0x80
	}

	[Flags]
	private enum z0kpk : uint
	{
		z0eek = 0u,
		z0rek = 0x80000000u
	}

	private short z0mek;

	private short z0nek;

	private z0hhj z0bek;

	private z0kpk z0vek;

	private short z0cek;

	private z0ZzZzawj z0xek;

	internal static readonly string z0zek = "OS/2";

	private short z0lrk;

	private short z0krk;

	internal new short z0eek()
	{
		return z0mek;
	}

	internal new z0ZzZzawj z0rek()
	{
		return z0xek;
	}

	internal new short z0tek()
	{
		return z0cek;
	}

	internal z0ZzZzydj(z0ZzZzjgj p0)
		: base(z0zek, p0)
	{
		z0ZzZzjgj z0ZzZzjgj2 = base.z0uek();
		short num = z0ZzZzjgj2.z0yek();
		z0ZzZzjgj2.z0yek();
		z0ZzZzjgj2.z0yek();
		z0ZzZzjgj2.z0yek();
		z0ZzZzjgj2.z0yek();
		z0ZzZzjgj2.z0yek();
		z0ZzZzjgj2.z0yek();
		z0ZzZzjgj2.z0yek();
		z0ZzZzjgj2.z0yek();
		z0ZzZzjgj2.z0yek();
		z0ZzZzjgj2.z0yek();
		z0ZzZzjgj2.z0yek();
		z0ZzZzjgj2.z0yek();
		z0ZzZzjgj2.z0yek();
		z0ZzZzjgj2.z0yek();
		z0ZzZzjgj2.z0yek();
		z0xek = new z0ZzZzawj(z0ZzZzjgj2);
		z0ZzZzjgj2.z0nek();
		z0ZzZzjgj2.z0nek();
		z0ZzZzjgj2.z0nek();
		z0ZzZzjgj2.z0nek();
		z0ZzZzjgj2.z0iek(4);
		z0bek = (z0hhj)z0ZzZzjgj2.z0yek();
		z0ZzZzjgj2.z0rek();
		z0ZzZzjgj2.z0rek();
		z0krk = z0ZzZzjgj2.z0yek();
		z0lrk = z0ZzZzjgj2.z0yek();
		z0mek = z0ZzZzjgj2.z0yek();
		z0nek = z0ZzZzjgj2.z0yek();
		z0cek = z0ZzZzjgj2.z0yek();
		if (num > 0)
		{
			z0vek = (z0kpk)z0ZzZzjgj2.z0nek();
			z0ZzZzjgj2.z0nek();
		}
		else
		{
			z0vek = z0kpk.z0eek;
		}
	}

	internal new bool z0yek()
	{
		return (z0bek & z0hhj.z0eek) != 0;
	}

	internal new bool z0uek()
	{
		return z0ZzZzlxk.z0yek(z0vek, z0kpk.z0rek);
	}

	internal new short z0iek()
	{
		return z0nek;
	}

	internal short z0oek()
	{
		return z0lrk;
	}

	internal short z0pek()
	{
		return z0krk;
	}
}
