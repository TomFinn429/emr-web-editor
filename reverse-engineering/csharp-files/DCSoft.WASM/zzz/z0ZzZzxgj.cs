using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzxgj : z0ZzZzcgj
{
	private static int z0eek;

	private readonly z0ZzZzbhj z0rek;

	private readonly z0ZzZzwgj z0tek;

	private readonly bool z0yek;

	private readonly z0ZzZzbfj z0uek;

	protected override void z0udk(IDictionary<int, string> p0)
	{
		z0tek.z0eek(z0uek.z0jdk(p0));
		Dictionary<int, double> dictionary = new Dictionary<int, double>();
		foreach (int key in p0.Keys)
		{
			dictionary.Add(key, z0uek.z0gdk(key));
		}
		z0tek.z0eek(dictionary);
		if (z0rek != null)
		{
			z0rek.z0eek(z0tek);
		}
	}

	internal z0ZzZzxgj(z0ZzZzbhj p0, z0ZzZzbfj p1, bool p2)
		: base(p0: true)
	{
		z0rek = p0;
		z0uek = p1;
		z0yek = p2;
		z0tek = new z0ZzZzwgj("DCSoft_" + z0eek++, new z0ZzZzvaj(p1.z0hdk()));
	}

	public override z0ZzZzrqj z0odk()
	{
		return z0tek;
	}

	public override bool z0pdk()
	{
		return z0yek;
	}
}
