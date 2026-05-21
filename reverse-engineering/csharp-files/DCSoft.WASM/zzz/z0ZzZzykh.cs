using System;

namespace zzz;

public class z0ZzZzykh : ICloneable
{
	private z0ZzZzikh z0pek;

	private string z0mek;

	private string z0nek = "ContentChanged";

	private string z0bek = "VISIBLE";

	private string z0vek;

	public void z0eek(string p0)
	{
		z0mek = p0;
	}

	public void z0rek(string p0)
	{
		z0vek = p0;
	}

	private object z0eek()
	{
		return (z0ZzZzykh)MemberwiseClone();
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0eek
		return this.z0eek();
	}

	public void z0tek(string p0)
	{
		z0bek = p0;
	}

	public void z0eek(z0ZzZzikh p0)
	{
		z0pek = p0;
	}

	public z0ZzZzikh z0rek()
	{
		return z0pek;
	}

	public string z0tek()
	{
		return z0vek;
	}

	public string z0yek()
	{
		return z0mek;
	}

	public string z0uek()
	{
		return z0bek;
	}

	public string z0iek()
	{
		return z0nek;
	}

	public z0ZzZzykh z0oek()
	{
		return (z0ZzZzykh)((ICloneable)this).Clone();
	}

	public void z0yek(string p0)
	{
		z0nek = p0;
	}
}
