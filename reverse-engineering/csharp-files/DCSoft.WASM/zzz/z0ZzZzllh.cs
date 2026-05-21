using System.Collections.Generic;
using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzllh : z0ZzZzxzj
{
	private new Dictionary<XTextTableRowElement, bool> z0yek = new Dictionary<XTextTableRowElement, bool>();

	private Dictionary<XTextTableRowElement, bool> z0uek = new Dictionary<XTextTableRowElement, bool>();

	private XTextTableElement z0iek;

	public new Dictionary<XTextTableRowElement, bool> z0eek()
	{
		return z0yek;
	}

	public override void Dispose()
	{
		base.Dispose();
		z0iek = null;
		if (z0yek != null)
		{
			z0yek.Clear();
			z0yek = null;
		}
		if (z0uek != null)
		{
			z0uek.Clear();
			z0uek = null;
		}
	}

	public override void z0yo(z0ZzZzpgh p0)
	{
		z0tek().z0tek(z0rek(), p1: false);
	}

	public new Dictionary<XTextTableRowElement, bool> z0rek()
	{
		return z0uek;
	}

	public XTextTableElement z0tek()
	{
		return z0iek;
	}

	public void z0eek(XTextTableElement p0)
	{
		z0iek = p0;
	}

	public override void z0to(z0ZzZzpgh p0)
	{
		z0tek().z0tek(z0eek(), p1: false);
	}
}
