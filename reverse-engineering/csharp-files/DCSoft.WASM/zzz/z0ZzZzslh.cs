using System.Collections.Generic;
using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzslh : z0ZzZzxzj
{
	private Dictionary<XTextElement, int> z0tek = new Dictionary<XTextElement, int>();

	private new Dictionary<XTextElement, int> z0yek = new Dictionary<XTextElement, int>();

	private bool z0uek;

	private bool z0iek = true;

	private string z0oek;

	public void z0eek(bool p0)
	{
		z0iek = p0;
	}

	public void z0eek(string p0)
	{
		z0oek = p0;
	}

	public override void z0yo(z0ZzZzpgh p0)
	{
		if (z0tek.Count > 0)
		{
			if (z0rek())
			{
				base.z0rek().z0eek(z0tek, p1: false);
			}
			else
			{
				base.z0rek().z0rek(z0tek, p1: false, z0eek(), z0oek);
			}
		}
	}

	public override void z0to(z0ZzZzpgh p0)
	{
		if (z0yek.Count > 0)
		{
			if (z0rek())
			{
				base.z0rek().z0eek(z0yek, p1: false);
			}
			else
			{
				base.z0rek().z0rek(z0yek, p1: false, z0eek(), z0oek);
			}
		}
	}

	public void z0rek(bool p0)
	{
		z0uek = p0;
	}

	public new bool z0eek()
	{
		return z0iek;
	}

	public new bool z0rek()
	{
		return z0uek;
	}

	public override void Dispose()
	{
		base.Dispose();
		if (z0yek != null)
		{
			z0yek.Clear();
			z0yek = null;
		}
		if (z0tek != null)
		{
			z0tek.Clear();
			z0tek = null;
		}
	}

	public void z0eek(XTextElement p0, int p1, int p2)
	{
		z0yek[p0] = p1;
		z0tek[p0] = p2;
	}
}
