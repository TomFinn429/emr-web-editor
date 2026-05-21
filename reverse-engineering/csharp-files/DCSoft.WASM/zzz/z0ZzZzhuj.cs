using System;

namespace zzz;

public class z0ZzZzhuj : ICloneable, IDisposable
{
	private string z0bek;

	private z0ZzZzxyj z0vek;

	private int z0cek = -1;

	private z0ZzZzluj z0xek;

	private bool z0zek = true;

	private z0ZzZzcok z0lrk;

	public virtual void z0sjk(z0ZzZzjpk p0)
	{
	}

	public virtual z0ZzZzxyj z0ljk()
	{
		return z0vek;
	}

	public virtual int z0eek()
	{
		return z0cek;
	}

	public virtual z0ZzZzbdh z0vkk()
	{
		return z0ZzZzbdh.z0xek;
	}

	public virtual void z0fjk(z0ZzZztuj p0)
	{
	}

	public virtual z0ZzZzguj z0djk()
	{
		return null;
	}

	public virtual void z0hjk(z0ZzZzluj p0)
	{
		z0xek = p0;
	}

	public virtual bool z0eek(z0ZzZzbdh p0)
	{
		return true;
	}

	public bool z0rek_jiejie20260327142557()
	{
		return z0zek;
	}

	public void z0eek(string p0)
	{
		z0bek = p0;
	}

	private object z0tek()
	{
		return (z0ZzZzhuj)MemberwiseClone();
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0tek
		return this.z0tek();
	}

	public void z0eek(bool p0)
	{
		z0zek = p0;
	}

	public virtual void z0mkk(float p0, float p1)
	{
	}

	public virtual z0ZzZzluj z0jjk()
	{
		return z0xek;
	}

	public string z0yek()
	{
		return z0bek;
	}

	public virtual z0ZzZzbdh z0uek()
	{
		z0ZzZzbdh result = z0vkk();
		result.z0eek(z0nek());
		return result;
	}

	public virtual void z0kjk(z0ZzZzxyj p0)
	{
		z0vek = p0;
		if (z0vek != null)
		{
			z0hjk(z0vek.z0jjk());
		}
	}

	public virtual z0ZzZznfh z0ckk()
	{
		return null;
	}

	public virtual void Dispose()
	{
	}

	public void z0eek(z0ZzZzcok p0)
	{
		z0lrk = p0;
	}

	public z0ZzZzjuj z0iek()
	{
		for (z0ZzZzhuj z0ZzZzhuj2 = this; z0ZzZzhuj2 != null; z0ZzZzhuj2 = z0ZzZzhuj2.z0ljk())
		{
			if (z0ZzZzhuj2 is z0ZzZzjuj)
			{
				return (z0ZzZzjuj)z0ZzZzhuj2;
			}
		}
		return null;
	}

	public void z0rek_jiejie20260327142557(z0ZzZzcok p0)
	{
		z0eek(z0jjk().z0bek().GetStyleIndex(p0));
	}

	public virtual z0ZzZzcok z0oek()
	{
		if (z0pek() != null)
		{
			return z0pek();
		}
		if (z0jjk() == null)
		{
			return null;
		}
		return z0jjk().z0bek().z0eek(z0eek());
	}

	public z0ZzZzcok z0pek()
	{
		return z0lrk;
	}

	public virtual void z0nkk(z0ZzZztuj p0)
	{
		p0.z0eek().z0eek(this, p0);
	}

	public virtual z0ZzZzhuj z0gjk(bool p0)
	{
		return (z0ZzZzhuj)((ICloneable)this).Clone();
	}

	public virtual void z0eek(int p0)
	{
		z0cek = p0;
	}

	public virtual void z0bkk(z0ZzZzbdh p0)
	{
	}

	public z0ZzZzcok z0mek()
	{
		if (z0jjk() == null)
		{
			return null;
		}
		return z0jjk().z0bek().GetStyle(z0eek());
	}

	public virtual void z0qjk(z0ZzZzguj p0)
	{
	}

	public virtual z0ZzZzpdh z0nek()
	{
		z0ZzZzpdh result = z0vkk().z0eek();
		for (z0ZzZzxyj z0ZzZzxyj2 = z0ljk(); z0ZzZzxyj2 != null; z0ZzZzxyj2 = z0ZzZzxyj2.z0ljk())
		{
			z0ZzZzcok z0ZzZzcok2 = ((z0ZzZzhuj)z0ZzZzxyj2).z0oek();
			result.z0eek(result.z0rek() + z0ZzZzcok2.PaddingLeft + z0ZzZzxyj2.z0rek());
			result.z0rek(result.z0tek() + z0ZzZzcok2.PaddingTop + z0ZzZzxyj2.z0oek());
			if (z0ZzZzxyj2 is z0ZzZzjuj)
			{
				break;
			}
		}
		return result;
	}

	public virtual void z0ajk(z0ZzZzsuj p0)
	{
	}
}
