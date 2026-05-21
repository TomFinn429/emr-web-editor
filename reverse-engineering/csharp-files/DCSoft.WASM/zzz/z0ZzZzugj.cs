using System;
using System.Globalization;

namespace zzz;

internal class z0ZzZzugj : z0ZzZzfsj
{
	private readonly z0ZzZzysj z0iek;

	private z0ZzZzdsj z0oek;

	private z0ZzZzdwj z0mek;

	private z0ZzZzjwj z0nek;

	private readonly z0ZzZzfwj z0cek;

	private readonly z0ZzZzxaj z0zek;

	private int z0lrk;

	private readonly CultureInfo z0krk;

	internal z0ZzZzgwj z0eek(int p0, z0ZzZziwj p1, z0ZzZziwj p2, int p3)
	{
		int num = p0 - 1;
		int count = z0iek.Count;
		if (num < 0 || num > count)
		{
			throw new ArgumentOutOfRangeException("position", "IncorrectInsertingPageNumber");
		}
		if (num != count)
		{
			z0ZzZzysj obj = z0iek;
			z0ZzZzgwj obj2 = new z0ZzZzgwj(this, p1, p2, p3);
			z0ZzZzdsj obj3 = z0oek;
			int p4 = obj3.z0uek() + 1;
			obj3.z0uek(p4);
			((z0ZzZzogj)obj2).z0eek(p4);
			return obj.z0rek(num, obj2);
		}
		return z0eek(p1, p2, p3);
	}

	internal new int z0eek()
	{
		return z0lrk;
	}

	internal z0ZzZzgwj z0eek(z0ZzZziwj p0, z0ZzZziwj p1, int p2)
	{
		z0ZzZzysj obj = z0iek;
		z0ZzZzgwj obj2 = new z0ZzZzgwj(this, p0, p1, p2);
		z0ZzZzdsj obj3 = z0oek;
		int p3 = obj3.z0uek() + 1;
		obj3.z0uek(p3);
		((z0ZzZzogj)obj2).z0eek(p3);
		return obj.z0uek(obj2);
	}

	internal new void z0eek(int p0)
	{
		z0lrk = Math.Max(z0lrk, p0);
	}

	protected internal override object z0ngk(z0ZzZzdsj p0)
	{
		z0ZzZzeaj z0ZzZzeaj2 = new z0ZzZzeaj(p0);
		z0ZzZzeaj2.Add("Type", new z0ZzZzhwj("Catalog"));
		z0ZzZzeaj2.z0tek_jiejie20260327142557("Pages", z0iek.z0eek(p0, p1: true));
		switch (z0cek)
		{
		case (z0ZzZzfwj)1:
			z0ZzZzeaj2.z0yek("PageLayout", "OneColumn");
			break;
		case (z0ZzZzfwj)2:
			z0ZzZzeaj2.z0yek("PageLayout", "TwoColumnLeft");
			break;
		case (z0ZzZzfwj)3:
			z0ZzZzeaj2.z0yek("PageLayout", "TwoColumnRight");
			break;
		case (z0ZzZzfwj)4:
			z0ZzZzeaj2.z0yek("PageLayout", "TwoPageLeft");
			break;
		case (z0ZzZzfwj)5:
			z0ZzZzeaj2.z0yek("PageLayout", "TwoPageRight");
			break;
		}
		switch (z0mek)
		{
		case (z0ZzZzdwj)3:
			z0ZzZzeaj2.Add("PageMode", "FullScreen");
			break;
		case (z0ZzZzdwj)5:
			z0ZzZzeaj2.Add("PageMode", "UseAttachments");
			break;
		case (z0ZzZzdwj)4:
			z0ZzZzeaj2.Add("PageMode", "UseOC");
			break;
		case (z0ZzZzdwj)1:
			z0ZzZzeaj2.Add("PageMode", "UseOutlines");
			break;
		case (z0ZzZzdwj)2:
			z0ZzZzeaj2.Add("PageMode", "UseThumbs");
			break;
		}
		z0ZzZzeaj2.z0tek_jiejie20260327142557("Metadata", z0nek);
		z0ZzZzeaj2.z0tek_jiejie20260327142557(z0krk);
		return z0ZzZzeaj2;
	}

	internal z0ZzZzugj(z0ZzZzdsj p0, z0ZzZzxaj p1)
	{
		z0oek = p0;
		z0zek = p1 ?? new z0ZzZzxaj();
		p0.z0uek(this);
		z0iek = new z0ZzZzysj(this);
		z0krk = CultureInfo.InvariantCulture;
	}

	internal void z0eek(z0ZzZzjwj p0)
	{
		z0nek = p0;
	}

	internal new z0ZzZzysj z0rek()
	{
		return z0iek;
	}

	internal z0ZzZzjwj z0tek()
	{
		return z0nek;
	}

	internal z0ZzZzxaj z0yek()
	{
		return z0zek;
	}

	internal z0ZzZzdsj z0uek()
	{
		return z0oek;
	}
}
