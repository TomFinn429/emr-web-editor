using System;
using System.IO;
using DCSystem_Drawing;

namespace zzz;

public sealed class z0ZzZzrfh : z0ZzZzedh
{
	public delegate void z0dhj(z0ZzZzrfh bmp);

	private new byte[] z0iek;

	public new static z0dhj z0oek;

	private new byte[] z0pek;

	public z0ZzZzrfh(Stream p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("stream");
		}
		if (p0 is UnmanagedMemoryStream || p0 is MemoryStream || p0 is FileStream)
		{
			byte[] array = new byte[p0.Length];
			p0.Read(array, 0, array.Length);
			z0rek(array);
			return;
		}
		byte[] array2 = new byte[1024];
		MemoryStream memoryStream = new MemoryStream();
		while (true)
		{
			int num = p0.Read(array2, 0, array2.Length);
			if (num <= 0)
			{
				break;
			}
			memoryStream.Write(array2, 0, num);
		}
		z0rek(memoryStream.ToArray());
		memoryStream.Close();
	}

	public new byte[] z0eek()
	{
		base.z0rek();
		return z0pek;
	}

	private static void z0eek(byte[] p0)
	{
		if (p0 == null || p0.Length < 5)
		{
			throw new NotSupportedException("图片数据太少");
		}
		z0eek(p0, p1: false);
	}

	public static z0ZzZzrfh z0eek(string p0)
	{
		byte[] array = z0ZzZzpmk.ParseEmitImageSource(p0);
		if (array != null && array.Length != 0)
		{
			return new z0ZzZzrfh(array);
		}
		return null;
	}

	public void z0rek(byte[] p0)
	{
		z0pek = p0;
		if (z0pek == null || z0pek.Length == 0)
		{
			z0nek = 0;
			z0xek = 0;
			z0zek = z0ZzZzrdh.z0vek;
			return;
		}
		z0ZzZzcdh z0ZzZzcdh2 = z0ZzZzpmk.z0uek(z0pek);
		z0nek = z0ZzZzcdh2.z0rek();
		z0xek = z0ZzZzcdh2.z0tek();
		z0zek = z0ZzZzpmk.z0iek(z0pek);
		if ((z0nek == 0 || z0xek == 0) && z0oek != null)
		{
			z0oek(this);
		}
	}

	public z0ZzZzrfh(z0ZzZzrfh p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("b2");
		}
		z0pek = p0.z0pek;
		z0iek = p0.z0iek;
		z0xek = p0.z0xek;
		z0zek = p0.z0zek;
		z0nek = p0.z0nek;
	}

	public override byte[] z0gd()
	{
		return z0pek;
	}

	public override void z0hd(Stream p0, z0ZzZzrdh p1)
	{
		if (z0pek != null && z0pek.Length != 0)
		{
			p0.Write(z0pek, 0, z0pek.Length);
		}
		else if (z0iek != null && z0iek.Length != 0)
		{
			p0.Write(z0iek, 0, z0iek.Length);
		}
	}

	public void z0eek(float p0, float p1)
	{
	}

	public new byte[] z0rek()
	{
		return z0iek;
	}

	public void z0tek(byte[] p0)
	{
		z0iek = p0;
	}

	internal void z0eek(int p0, int p1)
	{
		z0nek = p0;
		z0xek = p1;
		z0zek = z0ZzZzrdh.z0vek;
	}

	public z0ZzZzrfh(int p0, int p1)
	{
		z0nek = p0;
		z0xek = p1;
	}

	public new void z0tek()
	{
	}

	public void z0eek(Color p0)
	{
	}

	public override void Dispose()
	{
		if (base.z0uek() >= 0)
		{
			throw new NotSupportedException("StandardImageIndex.Dispose");
		}
		base.Dispose();
		z0pek = null;
		z0iek = null;
	}

	public static bool z0eek(byte[] p0, bool p1)
	{
		if (p0 != null && p0.Length != 0)
		{
			bool num = z0ZzZzpuk.z0uek(p0) || z0ZzZzpuk.z0yek(p0) || z0ZzZzpuk.z0tek(p0) || z0ZzZzpuk.z0eek(p0);
			if (!num && p1)
			{
				throw new NotSupportedException("只支持PNG/BMP/JPG/GIF图片格式");
			}
			return num;
		}
		return false;
	}

	public new string z0yek()
	{
		if (z0pek == null || z0pek.Length == 0)
		{
			return null;
		}
		return z0ZzZzpmk.StaticGetEmitImageSource(z0pek);
	}

	public z0ZzZzrfh(byte[] p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			throw new ArgumentNullException("bs");
		}
		z0eek(p0);
		z0rek(p0);
	}

	public new bool z0uek()
	{
		if (z0pek != null)
		{
			return z0pek.Length != 0;
		}
		return false;
	}
}
