using System.Collections;

namespace zzz;

internal sealed class z0ZzZzmuj
{
	private readonly string z0eek;

	public static readonly z0ZzZzmuj z0rek = new z0ZzZzmuj("EAN_8");

	public static readonly z0ZzZzmuj z0tek = new z0ZzZzmuj("EAN_13");

	public static readonly z0ZzZzmuj z0yek = new z0ZzZzmuj("QR_CODE");

	private static readonly Hashtable z0uek = Hashtable.Synchronized(new Hashtable());

	public override string ToString()
	{
		return z0eek;
	}

	private z0ZzZzmuj(string p0)
	{
		z0eek = p0;
		z0uek[p0] = this;
	}
}
