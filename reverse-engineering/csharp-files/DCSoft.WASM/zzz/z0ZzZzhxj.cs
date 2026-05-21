using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzhxj
{
	private float z0vek;

	private float z0cek;

	private XTextElement z0xek;

	private z0ZzZznwh z0zek;

	private string z0lrk;

	private z0ZzZzedh z0krk;

	private int z0jrk;

	private readonly int z0hrk;

	private float z0grk;

	private float z0frk;

	public void z0eek(float p0)
	{
		z0grk = p0;
	}

	public void z0rek(float p0)
	{
		z0vek = p0;
	}

	public bool z0eek(float p0, float p1)
	{
		return z0yek().z0eek(p0, p1);
	}

	public virtual void z0dj(WriterMouseEventArgs p0)
	{
	}

	public void z0eek(int p0)
	{
		z0jrk = p0;
	}

	public int z0eek()
	{
		return z0jrk;
	}

	public string z0rek()
	{
		return z0lrk;
	}

	public z0ZzZzedh z0tek()
	{
		return z0krk;
	}

	public void z0eek(z0ZzZzedh p0)
	{
		z0krk = p0;
	}

	public z0ZzZzbdh z0yek()
	{
		return new z0ZzZzbdh(z0oek(), z0mek(), z0pek(), z0bek());
	}

	public void z0tek(float p0)
	{
		z0frk = p0;
	}

	public void z0eek(z0ZzZznwh p0)
	{
		z0zek = p0;
	}

	public void z0yek(float p0)
	{
		z0cek = p0;
	}

	internal int z0uek()
	{
		return z0hrk;
	}

	public z0ZzZznwh z0iek()
	{
		return z0zek;
	}

	public virtual void z0lj(z0ZzZzvxj p0)
	{
		z0ZzZzbdh z0ZzZzbdh2 = new z0ZzZzbdh(z0oek(), z0mek(), z0pek(), z0bek());
		if (p0.z0eek(z0ZzZzbdh2))
		{
			z0ZzZzdpk.z0eek(p0.z0gyk, z0tek(), z0ZzZzbdh2, ContentAlignment.MiddleCenter);
		}
	}

	public void z0eek(string p0)
	{
		z0lrk = p0;
	}

	public float z0oek()
	{
		return z0vek;
	}

	public float z0pek()
	{
		return z0frk;
	}

	public float z0mek()
	{
		return z0cek;
	}

	public void z0eek(XTextElement p0)
	{
		z0xek = p0;
	}

	public XTextElement z0nek()
	{
		return z0xek;
	}

	public float z0bek()
	{
		return z0grk;
	}
}
