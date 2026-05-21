using System;
using DCSystem_Drawing.Drawing2D;
using zzz;

namespace DCSoft.Writer.Dom;

[z0ZzZziqh("XLineBreak")]
public sealed class XTextLineBreakElement : XTextElement
{
	private static z0ZzZzedh z0rek;

	[NonSerialized]
	private new bool z0tek;

	public override void z0fy(z0ZzZzdxj p0)
	{
		p0.z0rek();
	}

	public override string z0ge()
	{
		return "LineBreak";
	}

	public override void z0tt(z0ZzZzvxj p0)
	{
		if (z0rek == null)
		{
			z0rek = z0ZzZzovj.z0iek.BmpLinebreak;
		}
		z0ZzZzbdh z0ZzZzbdh = z0qyk();
		if (z0iu().ShowParagraphFlag && p0.z0byk == (z0ZzZzcxj)0)
		{
			z0ZzZzcdh p1 = z0rek.z0oek();
			p1 = z0jr().z0vek(p1);
			p0.z0rek(InterpolationMode.NearestNeighbor);
			p0.z0gyk.z0eek(z0rek, z0ZzZzbdh.z0oek(), z0ZzZzbdh.z0nek() - (float)p1.z0tek());
		}
	}

	public void z0eek(bool p0)
	{
		z0tek = p0;
	}

	public bool z0eek()
	{
		return z0tek;
	}

	internal void z0eek(XTextElement p0)
	{
		float num = z0jr().z0dik().z0mek();
		if (p0 != null && p0.Height > 0f)
		{
			num = p0.Height;
		}
		num = Math.Max(num, z0jr().z0xek(10f));
		Height = num;
		Width = z0jr().z0xek(10f);
		z0xi(p0: false);
	}

	public override void z0mr(z0ZzZzvxj p0)
	{
		float height = z0jr().z0dik().z0mek();
		Height = height;
		Width = z0jr().z0xek(10f);
		z0xi(p0: false);
	}

	public override string ToString()
	{
		return Environment.NewLine;
	}
}
