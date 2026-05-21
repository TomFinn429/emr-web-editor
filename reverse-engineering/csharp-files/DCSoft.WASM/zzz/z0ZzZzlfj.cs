using System.IO;
using System.IO.Compression;

namespace zzz;

internal class z0ZzZzlfj : z0ZzZzygj
{
	private readonly DeflateStream z0uek;

	private readonly MemoryStream z0iek;

	internal DeflateStream z0eek()
	{
		return z0uek;
	}

	internal void z0rek()
	{
		z0uek.Dispose();
	}

	internal z0ZzZzlfj()
	{
		z0iek = new MemoryStream();
		z0iek.WriteByte(88);
		z0iek.WriteByte(133);
		z0uek = new DeflateStream(z0iek, CompressionMode.Compress, true);
	}

	protected override void z0ygk(bool p0)
	{
		if (p0)
		{
			z0uek.Dispose();
			z0iek.Dispose();
		}
	}

	internal MemoryStream z0tek()
	{
		return z0iek;
	}

	internal byte[] z0yek()
	{
		return z0iek.ToArray();
	}

	internal static byte[] z0eek(byte[] p0)
	{
		using z0ZzZzlfj z0ZzZzlfj2 = new z0ZzZzlfj();
		z0ZzZzlfj2.z0eek().Write(p0, 0, p0.Length);
		z0ZzZzlfj2.z0rek();
		z0ZzZzoej obj = new z0ZzZzoej();
		obj.z0eek(p0);
		obj.z0eek(z0ZzZzlfj2.z0tek());
		return z0ZzZzlfj2.z0yek();
	}
}
