using System;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzymk : ICloneable
{
	private Color z0rek = Color.Empty;

	public string StringValue
	{
		get
		{
			return z0ZzZzlok.z0eek(z0rek, Color.Empty);
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				z0rek = Color.Empty;
			}
			else
			{
				z0rek = z0ZzZzlok.z0eek(value, Color.Empty);
			}
		}
	}

	[z0ZzZzuqh]
	public Color Value
	{
		get
		{
			return z0rek;
		}
		set
		{
			z0rek = value;
		}
	}

	private object z0eek()
	{
		return new z0ZzZzymk
		{
			z0rek = z0rek
		};
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0eek
		return this.z0eek();
	}

	public z0ZzZzymk()
	{
	}

	public z0ZzZzymk(Color p0)
	{
		z0rek = p0;
	}

	public z0ZzZzymk Clone()
	{
		return (z0ZzZzymk)((ICloneable)this).Clone();
	}

	public z0ZzZzymk(string p0)
	{
		StringValue = p0;
	}
}
