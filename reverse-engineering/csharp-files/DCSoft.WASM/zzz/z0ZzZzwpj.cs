using System;
using System.Collections.Generic;

namespace zzz;

public class z0ZzZzwpj
{
	private class z0xok
	{
		public int z0eek;

		public int z0rek;

		public int z0tek;
	}

	private readonly List<z0xok> z0yek = new List<z0xok>();

	private static readonly z0ZzZzwpj z0uek = new z0ZzZzwpj();

	public void z0eek()
	{
		z0yek.Clear();
	}

	public static z0ZzZzwpj z0rek()
	{
		return z0uek;
	}

	public int z0eek(int p0, int p1, int p2)
	{
		z0xok z0xok = new z0xok();
		z0xok.z0tek = p0;
		z0xok.z0rek = p1;
		z0xok.z0eek = Environment.TickCount;
		if (z0yek.Count == 0)
		{
			z0yek.Add(z0xok);
		}
		else
		{
			z0xok z0xok2 = z0yek[z0yek.Count - 1];
			z0ZzZzcdh z0ZzZzcdh2 = z0ZzZzyeh.z0tek();
			if (Math.Abs(z0xok.z0tek - z0xok2.z0tek) <= z0ZzZzcdh2.z0rek() && Math.Abs(z0xok.z0rek - z0xok2.z0rek) <= z0ZzZzcdh2.z0tek() && Math.Abs(z0xok.z0eek - z0xok2.z0eek) <= z0ZzZzyeh.z0eek())
			{
				z0yek.Add(z0xok);
				return z0yek.Count;
			}
			z0yek.Clear();
			z0yek.Add(z0xok);
		}
		return z0yek.Count;
	}

	public int z0eek(int p0, int p1)
	{
		return z0eek(p0, p1, Environment.TickCount);
	}

	public int z0tek()
	{
		return z0yek.Count;
	}
}
