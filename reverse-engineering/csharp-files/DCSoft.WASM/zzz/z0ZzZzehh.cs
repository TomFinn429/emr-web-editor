using System.Collections.Generic;
using DCSoft.Writer.Dom;

namespace zzz;

public sealed class z0ZzZzehh : z0ZzZzqhh
{
	protected override object z0lq(z0ZzZzlhh p0)
	{
		return ((z0ZzZzshh)p0).z0yek();
	}

	public override bool z0za(z0ZzZzcah p0)
	{
		return p0.z0eek("XTextDocument", string.Empty);
	}

	protected override void z0xa(object p0, z0ZzZzkhh p1)
	{
		XTextDocument xTextDocument = (XTextDocument)p0;
		xTextDocument.z0eck = new Dictionary<XTextElement, int>();
		try
		{
			xTextDocument.z0tik();
			xTextDocument.z0irk(XTextDocument.z0srk());
			if (!xTextDocument.z0vtk().BehaviorOptions.SpecifyDebugMode)
			{
				xTextDocument.z0prk();
			}
			xTextDocument.z0gnk().Styles.z0eek();
			if (xTextDocument.z0ptk())
			{
				XTextImageElement.z0ftk = new object();
				xTextDocument.z0pek(xTextDocument.z0ink());
			}
			else
			{
				XTextImageElement.z0ftk = null;
				xTextDocument.z0pek(null);
			}
			((z0ZzZzahh)p1).z0rek(p0);
		}
		finally
		{
			Dictionary<XTextElement, int> z0eck = xTextDocument.z0eck;
			xTextDocument.z0eck = null;
			if (z0eck != null && z0eck.Count > 0)
			{
				foreach (KeyValuePair<XTextElement, int> item in z0eck)
				{
					item.Key.z0oek(item.Value);
				}
				z0eck.Clear();
			}
		}
		if (xTextDocument.z0fyk() != null)
		{
			xTextDocument.z0fyk().Clear();
			xTextDocument.z0pek(null);
		}
	}
}
