using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace zzz;

internal class z0ZzZzmgj : z0ZzZzrsj
{
	private readonly z0ZzZzdsj z0pek;

	private readonly z0ZzZzgqj z0mek;

	private Dictionary<int, long> z0nek = new Dictionary<int, long>();

	private static byte[] z0bek = new byte[7] { 37, 162, 163, 143, 147, 13, 10 };

	private long z0rek_jiejie20260327142557()
	{
		long result = z0eek().z0iek();
		CultureInfo invariantCulture = CultureInfo.InvariantCulture;
		z0eek().z0eek("xref\r\n");
		IEnumerator enumerator = z0ZzZzlxk.z0eek(z0nek).GetEnumerator();
		int num = 0;
		int p = 0;
		List<string> list = new List<string> { "0000000000 00000 f\r\n" };
		while (enumerator.MoveNext())
		{
			KeyValuePair<int, long> keyValuePair = (KeyValuePair<int, long>)enumerator.Current;
			if (++num != keyValuePair.Key)
			{
				z0eek(p, list);
				num = keyValuePair.Key;
				p = keyValuePair.Key;
				list.Clear();
			}
			list.Add(string.Format(invariantCulture, "{0:0000000000} 00000 n\r\n", keyValuePair.Value));
		}
		z0eek(p, list);
		return result;
	}

	internal z0ZzZzmgj(z0ZzZzuxk p0, z0ZzZzgqj p1, z0ZzZzsqj p2)
		: base(p0)
	{
		z0mek = p1;
		z0pek = new z0ZzZzdsj(z0eek(), z0ndk);
		z0pek.z0iek(p1.z0uek());
		z0pek.z0uek(0, 65535);
		z0eek().z0eek(z0rek_jiejie20260327142557(p2) + "\r\n");
		z0eek().z0eek(z0bek);
	}

	internal void z0tek()
	{
		if (z0pek != null)
		{
			z0pek.z0pek();
			if (z0nek != null)
			{
				z0nek.Clear();
				z0nek = null;
			}
		}
	}

	private void z0yek()
	{
		using IEnumerator<z0ZzZzssj> enumerator = z0pek.z0nek();
		while (enumerator.MoveNext())
		{
			z0ndk(enumerator.Current);
		}
	}

	internal z0ZzZzdsj z0uek()
	{
		z0ZzZzwsj[] array = z0mek.z0eek(z0pek);
		z0pek.z0oek();
		z0yek();
		long num = z0rek_jiejie20260327142557();
		z0rek_jiejie20260327142557(array[0], array[1]);
		z0eek().z0eek("\r\nstartxref\r\n");
		z0eek().z0eek(num.ToString(CultureInfo.InvariantCulture));
		z0rek();
		z0eek().z0oek();
		return z0pek;
	}

	private static string z0rek_jiejie20260327142557(z0ZzZzsqj p0)
	{
		return p0 switch
		{
			(z0ZzZzsqj)0 => "%PDF-1.0", 
			(z0ZzZzsqj)1 => "%PDF-1.1", 
			(z0ZzZzsqj)2 => "%PDF-1.2", 
			(z0ZzZzsqj)3 => "%PDF-1.3", 
			(z0ZzZzsqj)4 => "%PDF-1.4", 
			(z0ZzZzsqj)5 => "%PDF-1.5", 
			(z0ZzZzsqj)6 => "%PDF-1.6", 
			_ => "%PDF-1.7", 
		};
	}

	private void z0rek_jiejie20260327142557(z0ZzZzwsj p0, z0ZzZzwsj p1)
	{
		z0eek().z0eek("trailer\r\n");
		z0ZzZzeaj z0ZzZzeaj2 = new z0ZzZzeaj(null);
		z0ZzZzeaj2.Add("Size", z0nek.Count);
		if (p0 != null)
		{
			z0ZzZzeaj2.Add("Info", p0);
		}
		z0ZzZzeaj2.Add("ID", z0mek.z0pek());
		z0ZzZzeaj2.Add("Root", p1);
		z0eek().z0eek(z0ZzZzeaj2, -1);
	}

	internal void z0iek()
	{
		z0pek.z0vek();
	}

	internal z0ZzZzdsj z0oek()
	{
		return z0pek;
	}

	internal override z0ZzZzqsj z0ndk(z0ZzZzssj p0)
	{
		z0ZzZzqsj z0ZzZzqsj2 = base.z0ndk(p0);
		z0nek.Add(z0ZzZzqsj2.z0rek(), z0ZzZzqsj2.z0eek());
		z0pek.z0uek(z0ZzZzqsj2, p1: true);
		return z0ZzZzqsj2;
	}

	private void z0eek(int p0, List<string> p1)
	{
		z0eek().z0eek("{0} {1}\r\n", p0, p1.Count);
		foreach (string item in p1)
		{
			z0eek().z0eek(item);
		}
	}
}
