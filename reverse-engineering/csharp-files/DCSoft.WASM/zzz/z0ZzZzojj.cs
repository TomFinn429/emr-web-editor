using System;

namespace zzz;

internal class z0ZzZzojj
{
	private int z0eek;

	private WeakReference z0rek;

	public override int GetHashCode()
	{
		return z0eek;
	}

	internal z0ZzZzojj(object p0)
	{
		z0rek = new WeakReference(p0);
		z0eek = p0.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj == null || obj.GetType() != GetType())
		{
			return false;
		}
		object target = z0rek.Target;
		if (z0rek.IsAlive)
		{
			return target == ((z0ZzZzojj)obj).z0rek.Target;
		}
		return false;
	}
}
