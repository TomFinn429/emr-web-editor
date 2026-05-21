using System;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;
using zzz;

namespace DCSoft.Writer.Dom;

[z0ZzZziqh("XPageBreak")]
public sealed class XTextPageBreakElement : XTextElement
{
	[NonSerialized]
	internal new bool z0eek;

	public XTextPageBreakElement()
	{
		Height = 50f;
		XTextDocument.z0pbk = true;
	}

	public override void z0tt(z0ZzZzvxj p0)
	{
		if (!z0iu().ShowPageBreak || p0.z0byk != 0 || p0.z0gyk == null)
		{
			return;
		}
		z0ZzZzbdh z0ZzZzbdh = p0.z0gtk;
		using z0ZzZzlsh z0ZzZzlsh = new z0ZzZzlsh();
		z0ZzZzimk p1 = z0ZzZzimk.z0eek();
		string text = z0ZzZziok.z0rek("PageBreak");
		if (string.IsNullOrEmpty(text))
		{
			using (z0ZzZzudh p2 = new z0ZzZzudh(Color.Black, 1f, DashStyle.Dot))
			{
				p0.z0gyk.z0eek(p2, z0ZzZzbdh.z0oek(), z0ZzZzbdh.z0pek() + z0ZzZzbdh.z0iek() / 2f, z0ZzZzbdh.z0mek(), z0ZzZzbdh.z0pek() + z0ZzZzbdh.z0iek() / 2f);
				return;
			}
		}
		z0ZzZzxdh z0ZzZzxdh = p0.z0eek(text, p1, 10000, z0ZzZzlsh);
		using (z0ZzZzudh p3 = new z0ZzZzudh(Color.Black, 1f, DashStyle.Dot))
		{
			p0.z0gyk.z0eek(p3, z0ZzZzbdh.z0oek(), z0ZzZzbdh.z0pek() + z0ZzZzbdh.z0iek() / 2f, z0ZzZzbdh.z0oek() + z0ZzZzbdh.z0uek() / 2f - z0ZzZzxdh.z0rek() / 2f - 6f, z0ZzZzbdh.z0pek() + z0ZzZzbdh.z0iek() / 2f);
			p0.z0gyk.z0eek(p3, z0ZzZzbdh.z0oek() + z0ZzZzbdh.z0uek() / 2f + z0ZzZzxdh.z0rek() / 2f + 6f, z0ZzZzbdh.z0pek() + z0ZzZzbdh.z0iek() / 2f, z0ZzZzbdh.z0mek(), z0ZzZzbdh.z0pek() + z0ZzZzbdh.z0iek() / 2f);
		}
		z0ZzZzlsh.z0rek(StringAlignment.Center);
		z0ZzZzlsh.z0eek(StringAlignment.Center);
		z0ZzZzlsh.z0eek((z0ZzZzksh)4096);
		p0.z0gyk.z0eek(text, p1, Color.Black, z0ZzZzbdh.z0oek() + z0ZzZzbdh.z0uek() / 2f - z0ZzZzxdh.z0rek() / 2f, z0ZzZzbdh.z0pek() + 3f + z0ZzZzxdh.z0tek() * 0.5f);
	}

	public override string z0ge()
	{
		return "PageBreak";
	}
}
