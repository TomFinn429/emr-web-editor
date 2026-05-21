using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace zzz;

internal class z0ZzZzobj
{
	[CompilerGenerated]
	private sealed class z0eik
	{
		public z0ZzZzsck z0rek;

		public z0ZzZzobj z0tek;

		internal void z0eek(z0ZzZzdck p0)
		{
			if (p0.z0rek != null && p0.z0rek.Length != 0)
			{
				z0tek.z0rek[p0.z0tek] = p0.z0rek;
				z0rek(p0);
			}
			else
			{
				z0rek(p0);
			}
		}
	}

	private Dictionary<string, byte[]> z0rek = new Dictionary<string, byte[]>();

	public static readonly z0ZzZzobj z0tek = new z0ZzZzobj();

	private List<byte[]> z0yek = new List<byte[]>();

	public byte[] z0eek(string p0)
	{
		byte[] array = z0ZzZzpmk.ParseEmitImageSource(p0);
		if (array != null)
		{
			foreach (byte[] item in z0yek)
			{
				if (z0ZzZzeyk.z0rek(item, array))
				{
					return array;
				}
			}
			z0yek.Add(array);
			return array;
		}
		return null;
	}

	public void z0eek(string p0, z0ZzZzsck p1)
	{
		if (string.IsNullOrEmpty(p0))
		{
			throw new ArgumentNullException("strUrl");
		}
		if (z0rek.TryGetValue(p0, out var array))
		{
			z0ZzZzdck z0ZzZzdck2 = new z0ZzZzdck();
			z0ZzZzdck2.z0tek = p0;
			z0ZzZzdck2.z0rek = array;
			p1(z0ZzZzdck2);
			return;
		}
		z0ZzZzhbj.JSProvider.z0alk(p0, delegate(z0ZzZzdck z0ZzZzdck3)
		{
			if (z0ZzZzdck3.z0rek != null && z0ZzZzdck3.z0rek.Length != 0)
			{
				z0rek[z0ZzZzdck3.z0tek] = z0ZzZzdck3.z0rek;
				p1(z0ZzZzdck3);
			}
			else
			{
				p1(z0ZzZzdck3);
			}
		});
	}

	public void z0eek()
	{
		z0yek.Clear();
		z0rek.Clear();
	}
}
