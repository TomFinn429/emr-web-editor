using DCSystem_Drawing;
using zzz;

namespace DCSoft.Writer.Dom;

[z0ZzZziqh("XTextLock")]
public sealed class XTextSignElement : XTextElement
{
	internal new static bool z0eek;

	private static z0ZzZzrfh z0rek;

	public override string z0pe()
	{
		return "sign";
	}

	public override string z0ge()
	{
		return "Sign" + ID;
	}

	public XTextSignElement()
	{
		z0eek = true;
	}

	public override void z0mr(z0ZzZzvxj p0)
	{
		z0ZzZzcdh z0ZzZzcdh = z0ZzZzrpk.z0eek(((z0ZzZzedh)StandardIcon()).z0oek(), GraphicsUnit.Pixel, GraphicsUnit.Document);
		Width = z0ZzZzcdh.z0rek();
		Height = z0ZzZzcdh.z0tek();
		z0xi(p0: false);
	}

	public override void z0vw(z0ZzZzvxj p0)
	{
		if (p0.z0byk == (z0ZzZzcxj)0)
		{
			z0ZzZzbdh z0ZzZzbdh = z0qyk();
			p0.z0gyk.z0eek(StandardIcon(), z0ZzZzbdh.z0oek(), z0ZzZzbdh.z0pek());
		}
	}

	public static z0ZzZzrfh StandardIcon()
	{
		if (z0rek == null)
		{
			z0rek = z0ZzZzpmk.z0eek((object)z0ZzZzgfh.z0mek);
			z0rek.z0tek();
		}
		return z0rek;
	}
}
