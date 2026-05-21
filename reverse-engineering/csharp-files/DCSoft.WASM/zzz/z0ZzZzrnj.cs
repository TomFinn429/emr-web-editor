using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzrnj : WriterEventArgs
{
	private z0ZzZzgcj z0yek;

	private int z0uek = 100;

	private XTextElementList z0iek;

	public z0ZzZzrnj(z0ZzZzdbj p0, XTextDocument p1, XTextElementList p2, z0ZzZzgcj p3)
		: base(p0, p1, null)
	{
		z0iek = p2;
		z0yek = p3;
	}

	public int z0eek()
	{
		return z0uek;
	}

	public void z0eek(int p0)
	{
		z0uek = p0;
	}

	public XTextElementList z0rek()
	{
		if (z0iek == null)
		{
			z0iek = new XTextElementList();
		}
		return z0iek;
	}

	public void z0eek(z0ZzZzgcj p0)
	{
		z0yek = p0;
	}

	public z0ZzZzgcj z0tek()
	{
		if (z0yek == null)
		{
			z0yek = new z0ZzZzgcj();
		}
		return z0yek;
	}
}
