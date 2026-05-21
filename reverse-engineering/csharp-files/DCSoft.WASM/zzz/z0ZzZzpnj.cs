using System.Collections.Generic;
using System.Reflection;
using DCSoft.Writer.Dom;

namespace zzz;

[DefaultMember("Item")]
internal class z0ZzZzpnj
{
	private int z0yek;

	private Dictionary<XTextElement, z0ZzZzonj> z0uek = new Dictionary<XTextElement, z0ZzZzonj>();

	public void z0eek()
	{
		z0uek.Clear();
		z0rek();
	}

	public z0ZzZzonj z0eek(XTextElement p0)
	{
		if (p0 == null)
		{
			return null;
		}
		z0ZzZzonj result = null;
		if (z0uek.TryGetValue(p0, out result))
		{
			return result;
		}
		return null;
	}

	public void z0rek()
	{
		z0yek++;
	}

	public int z0tek()
	{
		return z0yek;
	}

	public void z0eek(int p0)
	{
		z0yek = p0;
	}
}
