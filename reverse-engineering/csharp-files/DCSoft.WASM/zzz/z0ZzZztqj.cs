using System;

namespace zzz;

internal class z0ZzZztqj : z0ZzZzfsj
{
	private readonly z0ZzZzyqj z0uek;

	private readonly double z0iek;

	private readonly double z0oek;

	private readonly double z0pek;

	private z0ZzZzrqj z0vek;

	private readonly double z0cek;

	private string z0lrk;

	private readonly int z0krk = 400;

	private readonly double z0hrk;

	private readonly byte[] z0frk;

	private readonly double z0srk;

	private string z0qrk;

	private readonly double z0wrk;

	private readonly z0ZzZziwj z0rrk;

	private readonly double z0trk;

	private readonly z0ZzZzuqj z0irk;

	private readonly double z0nrk;

	private readonly double z0vrk;

	protected internal override object z0ngk(z0ZzZzdsj p0)
	{
		return z0eek(p0);
	}

	internal z0ZzZztqj(z0ZzZzvfj p0)
	{
		z0lrk = p0.z0nek();
		z0uek = p0.z0eek();
		z0nrk = p0.z0uek();
		z0krk = (p0.z0bek() ? 700 : 400);
		z0wrk = p0.z0rek();
		z0irk = (z0ZzZzuqj)4;
		z0hrk = Math.Round(p0.z0oek());
		z0pek = Math.Round(p0.z0yek());
		z0oek = p0.z0mek();
		z0cek = p0.z0pek();
		z0vrk = p0.z0vek();
		z0ZzZziwj z0ZzZziwj2 = p0.z0iek_jiejie20260327142557();
		z0rrk = new z0ZzZziwj(Math.Round(z0ZzZziwj2.z0oek()), Math.Round(z0ZzZziwj2.z0yek()), Math.Round(z0ZzZziwj2.z0iek()), Math.Round(z0ZzZziwj2.z0mek()));
		int num = p0.z0tek();
		int num2 = (int)Math.Ceiling((double)num / 8.0);
		z0frk = new byte[num2];
		int num3 = num % 8;
		int num4 = num2 - ((num3 > 0) ? 1 : 0);
		for (int i = 0; i < num4; i++)
		{
			z0frk[i] = 255;
		}
		int num5 = num2 - 1;
		byte b = 128;
		for (int j = 0; j < num3; j++)
		{
			z0frk[num5] |= b;
			b >>= 1;
		}
	}

	protected virtual z0ZzZzeaj z0eek(z0ZzZzdsj p0)
	{
		z0ZzZzeaj z0ZzZzeaj2 = new z0ZzZzeaj(p0);
		z0ZzZzeaj2.z0yek("Type", "FontDescriptor");
		z0ZzZzeaj2.z0yek("FontName", z0qrk);
		z0ZzZzeaj2.z0tek_jiejie20260327142557("FontFamily", z0lrk, null);
		switch (z0irk)
		{
		case (z0ZzZzuqj)2:
			z0ZzZzeaj2.z0yek("FontStretch", "Condensed");
			break;
		case (z0ZzZzuqj)6:
			z0ZzZzeaj2.z0yek("FontStretch", "Expanded");
			break;
		case (z0ZzZzuqj)1:
			z0ZzZzeaj2.z0yek("FontStretch", "ExtraCondensed");
			break;
		case (z0ZzZzuqj)7:
			z0ZzZzeaj2.z0yek("FontStretch", "ExtraExpanded");
			break;
		case (z0ZzZzuqj)3:
			z0ZzZzeaj2.z0yek("FontStretch", "SemiCondensed");
			break;
		case (z0ZzZzuqj)5:
			z0ZzZzeaj2.z0yek("FontStretch", "SemiExpanded");
			break;
		case (z0ZzZzuqj)0:
			z0ZzZzeaj2.z0yek("FontStretch", "UltraCondensed");
			break;
		case (z0ZzZzuqj)8:
			z0ZzZzeaj2.z0yek("FontStretch", "UltraExpanded");
			break;
		}
		z0ZzZzeaj2.z0tek_jiejie20260327142557("FontWeight", z0krk, 400);
		z0ZzZzeaj2.Add("Flags", (int)z0uek);
		z0ZzZzeaj2.Add("ItalicAngle", z0nrk);
		z0ZzZzeaj2.z0tek_jiejie20260327142557("XHeight", z0oek, 0.0);
		z0ZzZzeaj2.z0tek_jiejie20260327142557("StemH", z0vrk, 0.0);
		z0ZzZzeaj2.z0tek_jiejie20260327142557("AvgWidth", z0trk, 0.0);
		z0ZzZzeaj2.z0tek_jiejie20260327142557("MaxWidth", z0iek, 0.0);
		z0ZzZzeaj2.z0tek_jiejie20260327142557("MissingWidth", z0srk, 0.0);
		if (z0vek.z0tek())
		{
			z0ZzZzeaj2.z0tek_jiejie20260327142557("FontBBox", z0rrk);
			z0ZzZzeaj2.Add("Ascent", z0hrk);
			z0ZzZzeaj2.Add("Descent", z0pek);
			z0ZzZzeaj2.Add("CapHeight", z0wrk);
			z0ZzZzeaj2.Add("StemV", z0cek);
		}
		if (z0frk != null)
		{
			z0ZzZzeaj2.Add("CIDSet", p0.z0uek(z0frk));
		}
		z0vek.z0bdk(z0ZzZzeaj2);
		return z0ZzZzeaj2;
	}

	internal void z0eek(z0ZzZzrqj p0)
	{
		z0vek = p0;
		if (string.IsNullOrEmpty(z0qrk))
		{
			z0qrk = p0.z0rek();
		}
	}
}
