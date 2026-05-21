using System;
using System.Collections.Generic;

namespace zzz;

internal abstract class z0ZzZzcgj : z0ZzZzvhj
{
	private readonly bool z0rek;

	private static readonly Dictionary<byte[], string> z0tek = new Dictionary<byte[], string>();

	private z0ZzZzdgj z0yek = new z0ZzZzdgj();

	public void z0mdk(IDictionary<int, string> p0)
	{
		z0yek.z0eek(p0);
	}

	protected z0ZzZzcgj(bool p0)
	{
		z0rek = p0;
	}

	protected abstract void z0udk(IDictionary<int, string> p0);

	public abstract bool z0pdk();

	public abstract z0ZzZzrqj z0odk();

	private z0ZzZziaj z0eek_jiejie20260327142557(IDictionary<int, string> p0)
	{
		if (p0.Count > 0)
		{
			KeyValuePair<int, string>[] array = z0ZzZzlxk.z0eek(p0);
			for (int i = 0; i < array.Length; i++)
			{
				KeyValuePair<int, string> keyValuePair = array[i];
				if (keyValuePair.Value != null && keyValuePair.Value.Length > 0)
				{
					z0tek.Add(BitConverter.GetBytes((short)keyValuePair.Key), keyValuePair.Value);
				}
			}
		}
		z0ZzZziaj result = new z0ZzZziaj(z0ZzZziaj.z0eek(p0, "DCSoft", z0rek), z0tek);
		z0tek.Clear();
		return result;
	}

	public void z0idk()
	{
		if (z0yek.z0tek())
		{
			z0odk().z0eek(z0eek_jiejie20260327142557(z0yek.z0rek()));
			z0udk(z0yek.z0rek());
			z0yek.z0rek(p0: false);
		}
	}
}
