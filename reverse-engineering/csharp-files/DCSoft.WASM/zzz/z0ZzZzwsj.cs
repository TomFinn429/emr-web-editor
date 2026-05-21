using System.Globalization;

namespace zzz;

internal class z0ZzZzwsj : z0ZzZzlgj
{
	private readonly int z0rek;

	private void z0eek(z0ZzZzpgj p0, int p1)
	{
		p0.z0eek(string.Format(CultureInfo.InvariantCulture, "{0} 0 R", z0rek));
	}

	void z0ZzZzlgj.z0nfk(z0ZzZzpgj p0, int p1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0eek
		this.z0eek(p0, p1);
	}

	internal int z0eek()
	{
		return z0rek;
	}

	internal z0ZzZzwsj(int p0)
		: this(p0, 0)
	{
	}

	internal z0ZzZzwsj(int p0, int p1)
	{
		z0rek = p0;
	}
}
