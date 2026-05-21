using DCSoft.Writer.Dom;
using DCSystem_Drawing;

namespace zzz;

public static class z0ZzZzsfh
{
	public static Color z0eek(Color p0)
	{
		return new z0ZzZzypk(p0).z0rek(0.5f);
	}

	public static byte[] z0eek(XTextImageElement p0, int p1)
	{
		if (p0.z0rek().A != 0)
		{
			return null;
		}
		if (p0.z0eek())
		{
			return null;
		}
		z0ZzZzpmk z0ZzZzpmk2 = null;
		if (p0.z0hrk() != null && p0.z0hrk().Count > 0)
		{
			z0ZzZzpmk2 = p0.z0hrk().z0rek(p1);
		}
		if (z0ZzZzpmk2 == null)
		{
			z0ZzZzpmk2 = p0.z0frk();
		}
		if (z0ZzZzpmk2 != null && z0ZzZzpmk2.z0eek())
		{
			return z0ZzZzpmk2.ImageData;
		}
		return null;
	}

	public static void z0eek(z0ZzZzcah p0, z0ZzZzpmk p1)
	{
		if (p0 is z0ZzZzihh)
		{
			((z0ZzZzihh)p0).z0eek(p1);
		}
		else
		{
			p1.ImageDataBase64String = p0.z0qa_jiejie20260327142557();
		}
	}

	public static string z0eek(string p0, XTextDocument p1)
	{
		string text = p0;
		if ((text == null || text.Length == 0) && p1 != null)
		{
			text = p1.z0amk();
			if (text == null || text.Length == 0)
			{
				text = p1.z0ipk().z0mek();
			}
			if (text == null || text.Length == 0)
			{
				text = p1.ID;
			}
		}
		if (text != null && text.Length > 0)
		{
			int num = text.LastIndexOfAny(new char[2] { '/', '\\' });
			if (num >= 0)
			{
				text = text.Substring(num + 1);
			}
			num = text.LastIndexOf('.');
			if (num > 0)
			{
				text = text.Substring(0, num);
			}
			text = z0ZzZzmuk.z0eek(text, '_');
			text = text.Replace(' ', '_');
		}
		if (text == null || text.Length == 0)
		{
			text = z0ZzZzdbj.z0pik().ToString("yyyyMMddHHmmss");
		}
		return text;
	}
}
