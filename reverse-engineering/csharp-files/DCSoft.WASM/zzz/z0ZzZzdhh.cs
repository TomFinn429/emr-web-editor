using System.Collections.Generic;
using DCSoft.Writer.Dom;

namespace zzz;

internal static class z0ZzZzdhh
{
	public static void z0eek(XTextDocument p0)
	{
		p0.z0tik();
		p0.z0irk(XTextDocument.z0srk());
		if (!p0.z0vtk().BehaviorOptions.SpecifyDebugMode)
		{
			p0.z0prk();
		}
		p0.z0gnk().Styles.z0eek();
		if (p0.z0ptk())
		{
			XTextImageElement.z0ftk = new object();
			p0.z0pek(p0.z0ink());
		}
		else
		{
			XTextImageElement.z0ftk = null;
			p0.z0pek(null);
		}
	}

	public static void z0rek(XTextDocument p0)
	{
		XTextElementList.z0qrk = false;
		XTextImageElement.z0ftk = null;
		if (p0.z0ptk() && p0.z0fyk() != null && p0.z0fyk().Count > 0)
		{
			List<byte[]> list = p0.z0fyk();
			XTextElementList xTextElementList = p0.z0rek<XTextImageElement>();
			if (xTextElementList != null)
			{
				foreach (XTextImageElement item in xTextElementList.z0xrk())
				{
					if (item.z0iek() >= 0 && item.z0iek() < list.Count)
					{
						item.z0rek(list[item.z0iek()]);
					}
					item.z0eek(-1);
				}
			}
		}
		p0.z0pek(null);
	}
}
