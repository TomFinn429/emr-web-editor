using System.Runtime.CompilerServices;
using DCSoft;

namespace zzz;

internal class z0ZzZzmhj : zzz.z0ZzZzujj<z0ZzZzohj>
{
	[CompilerGenerated]
	private sealed class z0zyk
	{
		public z0ZzZzedh z0rek;

		public byte[] z0tek;

		public z0ZzZzmhj z0yek;

		internal z0ZzZzdkj z0eek()
		{
			return z0ZzZzdkj.z0rek((z0ZzZzrfh)z0rek, z0yek.z0oek, z0yek.z0tek, z0yek.z0iek, z0tek);
		}
	}

	[CompilerGenerated]
	private sealed class z0kuk
	{
		public byte[] z0rek;

		public z0ZzZzmhj z0tek;

		public z0ZzZzedh z0yek;

		internal z0ZzZzdkj z0eek()
		{
			return z0ZzZzdkj.z0rek((z0ZzZzrfh)z0yek, z0tek.z0oek, z0tek.z0tek, z0tek.z0iek, z0rek);
		}
	}

	[CompilerGenerated]
	private sealed class z0juk
	{
		public DCFunc<z0ZzZzdkj> z0rek;

		public z0ZzZzmhj z0tek;

		internal z0ZzZzohj z0eek()
		{
			return z0tek.z0rek(z0rek());
		}
	}

	private long z0tek = 100L;

	private readonly z0ZzZzblj z0yek_jiejie20260327142557;

	private readonly bool z0iek;

	private bool z0oek;

	internal z0ZzZzohj z0rek(z0ZzZzedh p0, int p1, byte[] p2 = null)
	{
		return z0eek(new z0ZzZzijj(p0, p1), () => z0ZzZzdkj.z0rek((z0ZzZzrfh)p0, z0oek, z0tek, z0iek, p2));
	}

	internal void z0rek(long p0)
	{
		z0tek = p0;
	}

	internal z0ZzZzohj z0rek(z0ZzZzedh p0, byte[] p1 = null)
	{
		return z0eek(new z0ZzZzojj(p0), () => z0ZzZzdkj.z0rek((z0ZzZzrfh)p0, z0oek, z0tek, z0iek, p1));
	}

	private z0ZzZzohj z0eek(z0ZzZzojj p0, DCFunc<z0ZzZzdkj> p1)
	{
		return z0eek(p0, () => z0rek(p1()));
	}

	internal void z0rek(bool p0)
	{
		z0oek = p0;
	}

	internal z0ZzZzmhj(z0ZzZzblj p0)
	{
		z0yek_jiejie20260327142557 = p0;
		z0ZzZzugj z0ZzZzugj2 = p0.z0oek();
		z0iek = z0ZzZzugj2.z0yek() == null || z0ZzZzugj2.z0yek().z0rek() != (z0ZzZzbaj)1;
	}

	private z0ZzZzohj z0rek(z0ZzZzdkj p0)
	{
		return new z0ZzZzphj(p0.z0tek(), p0.z0rek(), z0yek_jiejie20260327142557.z0oek().z0uek().z0uek(p0.z0aak()));
	}

	internal bool z0rek()
	{
		return z0oek;
	}
}
