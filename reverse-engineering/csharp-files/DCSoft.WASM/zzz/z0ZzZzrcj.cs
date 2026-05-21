using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzrcj
{
	private z0ZzZzclh z0uek;

	private z0ZzZzbdh z0iek = z0ZzZzbdh.z0xek;

	protected bool z0oek;

	public void z0eek(z0ZzZzbdh p0)
	{
		z0iek = p0;
	}

	public void z0eek(XTextDocument p0)
	{
		z0uek = new z0ZzZzclh(p0);
	}

	public void z0eek(z0ZzZzclh p0)
	{
		z0uek = p0;
	}

	public void z0eek(XTextElementList p0)
	{
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextElement current = z0bpk.Current;
			if (!z0eek(current))
			{
				continue;
			}
			if (!z0rek().z0bek())
			{
				if (z0ZzZzbdh.z0tek(z0rek(), current.z0qyk()).z0iek() >= 2f)
				{
					z0ys(current);
				}
			}
			else
			{
				z0ys(current);
			}
		}
	}

	public virtual void z0ys(XTextElement p0)
	{
	}

	public virtual void z0gs(bool p0)
	{
		z0oek = p0;
	}

	public XTextDocument z0eek()
	{
		if (z0uek == null)
		{
			return null;
		}
		return z0uek.z0rek();
	}

	public z0ZzZzbdh z0rek()
	{
		return z0iek;
	}

	public virtual bool z0fs()
	{
		return z0oek;
	}

	public z0ZzZzclh z0tek()
	{
		return z0uek;
	}

	public virtual bool z0eek(XTextElement p0)
	{
		return true;
	}

	public XTextDocument z0yek()
	{
		if (z0uek == null)
		{
			return null;
		}
		return z0uek.z0rek();
	}
}
