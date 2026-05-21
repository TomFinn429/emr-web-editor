using System;
using DCSystem_Drawing;

namespace zzz;

public sealed class z0ZzZzlsh : IDisposable
{
	private StringAlignment z0mek;

	private StringAlignment z0nek;

	private bool z0bek;

	private z0ZzZzksh z0vek;

	private static readonly z0ZzZzlsh z0cek;

	private bool z0xek;

	private static readonly z0ZzZzlsh z0zek;

	public void Dispose()
	{
		if (z0xek)
		{
			throw new InvalidOperationException("对象是永恒的");
		}
		z0bek = true;
	}

	public z0ZzZzlsh z0eek()
	{
		z0ZzZzlsh obj = (z0ZzZzlsh)MemberwiseClone();
		obj.z0xek = false;
		return obj;
	}

	public void z0eek(StringAlignment p0)
	{
		z0iek();
		z0nek = p0;
	}

	public void z0eek(ContentAlignment p0)
	{
		z0iek();
		switch (p0)
		{
		case ContentAlignment.BottomCenter:
			z0rek(StringAlignment.Center);
			z0eek(StringAlignment.Far);
			break;
		case ContentAlignment.BottomLeft:
			z0rek(StringAlignment.Near);
			z0eek(StringAlignment.Far);
			break;
		case ContentAlignment.BottomRight:
			z0rek(StringAlignment.Far);
			z0eek(StringAlignment.Far);
			break;
		case ContentAlignment.MiddleCenter:
			z0rek(StringAlignment.Center);
			z0eek(StringAlignment.Center);
			break;
		case ContentAlignment.MiddleLeft:
			z0rek(StringAlignment.Near);
			z0eek(StringAlignment.Center);
			break;
		case ContentAlignment.MiddleRight:
			z0rek(StringAlignment.Far);
			z0eek(StringAlignment.Center);
			break;
		case ContentAlignment.TopCenter:
			z0rek(StringAlignment.Center);
			z0eek(StringAlignment.Near);
			break;
		case ContentAlignment.TopLeft:
			z0rek(StringAlignment.Near);
			z0eek(StringAlignment.Near);
			break;
		case ContentAlignment.TopRight:
			z0rek(StringAlignment.Far);
			z0eek(StringAlignment.Near);
			break;
		}
	}

	public static z0ZzZzlsh z0rek()
	{
		return z0zek;
	}

	public void z0rek(StringAlignment p0)
	{
		z0iek();
		z0mek = p0;
	}

	public StringAlignment z0tek()
	{
		z0oek();
		return z0nek;
	}

	public z0ZzZzksh z0yek()
	{
		return z0vek;
	}

	public z0ZzZzlsh()
		: this((z0ZzZzksh)0, 0)
	{
	}

	public override string ToString()
	{
		return "[StringFormat, FormatFlags=" + z0yek().ToString() + "]";
	}

	public static z0ZzZzlsh z0uek()
	{
		return z0cek;
	}

	public z0ZzZzlsh(z0ZzZzksh p0, int p1)
	{
		z0vek = p0;
	}

	private void z0iek()
	{
		if (z0xek)
		{
			throw new InvalidOperationException("对象是永恒的");
		}
		z0oek();
	}

	private void z0oek()
	{
		if (z0bek)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
	}

	public void z0eek(z0ZzZzksh p0)
	{
		z0iek();
		z0vek = p0;
	}

	public z0ZzZzlsh(z0ZzZzlsh p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("format");
		}
		p0.z0oek();
		z0mek = p0.z0mek;
		z0nek = p0.z0nek;
		z0vek = p0.z0vek;
	}

	public StringAlignment z0pek()
	{
		z0oek();
		return z0mek;
	}

	static z0ZzZzlsh()
	{
		z0zek = new z0ZzZzlsh();
		z0zek.z0mek = StringAlignment.Near;
		z0zek.z0vek = (z0ZzZzksh)0;
		z0zek.z0nek = StringAlignment.Near;
		z0zek.z0xek = true;
		z0cek = new z0ZzZzlsh();
		z0cek.z0mek = StringAlignment.Near;
		z0cek.z0nek = StringAlignment.Near;
		z0cek.z0xek = true;
	}
}
