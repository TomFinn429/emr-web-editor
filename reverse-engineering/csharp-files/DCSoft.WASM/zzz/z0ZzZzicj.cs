using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using DCSoft.Writer.Dom;

namespace zzz;

[DebuggerTypeProxy(typeof(z0ZzZzkik))]
[DebuggerDisplay("Count={ Count }")]
public class z0ZzZzicj : List<z0ZzZzucj>
{
	private class z0cck : z0ZzZzoik
	{
		public override IEnumerable GetChildNodes(object instance)
		{
			return ((z0ZzZzucj)instance).z0eek();
		}

		public z0cck(z0ZzZzicj p0)
			: base(p0)
		{
		}
	}

	private XTextDocument z0rek;

	internal void z0eek(XTextParagraphFlagElement p0, string p1)
	{
		if (p0 == null)
		{
			return;
		}
		int num = 0;
		List<XTextParagraphFlagElement> list = p0.z0bek();
		if (list == null || list.Count == 0)
		{
			return;
		}
		foreach (XTextParagraphFlagElement item in list)
		{
			num++;
			z0ZzZzucj z0ZzZzucj2 = new z0ZzZzucj();
			z0ZzZzucj2.z0eek(item.z0xek());
			if (z0ZzZzucj2.z0yek() != null && z0ZzZzucj2.z0yek().Length > 15)
			{
				z0ZzZzucj2.z0eek(z0ZzZzucj2.z0yek().Substring(0, 15));
			}
			z0ZzZzucj2.z0rek(p1 + num + ".");
			z0ZzZzucj2.z0mek = item;
			Add(z0ZzZzucj2);
			if (item.z0nek())
			{
				z0ZzZzucj2.z0eek().z0eek(item, z0ZzZzucj2.z0oek());
			}
			foreach (z0ZzZzucj item2 in z0ZzZzucj2.z0eek())
			{
				item2.z0eek(z0ZzZzucj2);
			}
		}
	}

	public z0ZzZzicj(XTextDocument p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("document");
		}
		z0rek = p0;
		z0eek(p0.z0xyk().z0nek(), string.Empty);
	}

	public z0ZzZzicj()
	{
	}

	public z0ZzZzucj z0eek()
	{
		if (z0rek != null && z0rek.z0jrk() == z0rek.z0xyk() && z0rek.z0itk() != null)
		{
			z0ZzZzucj z0ZzZzucj2 = z0eek(z0rek.z0itk().z0jrk());
			if (z0ZzZzucj2 == null && base.Count > 0)
			{
				z0ZzZzucj2 = base[0];
			}
			return z0ZzZzucj2;
		}
		return null;
	}

	internal z0ZzZzucj z0eek(int p0)
	{
		if (base.Count == 0)
		{
			return null;
		}
		z0cck z0cck = new z0cck(this);
		z0ZzZzucj result = null;
		foreach (z0ZzZzucj item in z0cck)
		{
			if (item.z0pek().z0iek().z0jrk() > p0)
			{
				break;
			}
			result = item;
		}
		return result;
	}
}
