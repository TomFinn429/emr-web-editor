using System;
using System.IO;

namespace zzz;

public class z0ZzZzouk : Stream
{
	private long z0rek;

	private long z0tek;

	private byte[] z0yek;

	private long z0uek;

	public override bool CanWrite => true;

	public override bool CanRead => false;

	public override bool CanSeek => true;

	public override long Position
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

	public override long Length => z0uek;

	public override long Seek(long offset, SeekOrigin origin)
	{
		long num = 0L;
		num = origin switch
		{
			SeekOrigin.Begin => offset, 
			SeekOrigin.Current => z0rek + offset, 
			SeekOrigin.End => z0uek + offset, 
			_ => z0rek + offset, 
		};
		if (num < 0)
		{
			num = 0L;
		}
		if (num > z0uek)
		{
			num = z0uek;
		}
		z0rek = num;
		return num;
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		throw new NotImplementedException();
	}

	public override void SetLength(long value)
	{
		throw new NotImplementedException();
	}

	public override void Flush()
	{
	}

	public override void WriteByte(byte value)
	{
		z0eek(z0rek + 1);
		z0yek[z0rek] = value;
		z0rek++;
		if (z0uek < z0rek)
		{
			z0uek = z0rek;
		}
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
		z0yek = null;
		z0rek = 0L;
		z0uek = 0L;
		z0tek = 0L;
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		z0eek(z0rek + count);
		Buffer.BlockCopy(buffer, offset, z0yek, (int)z0rek, count);
		z0rek += count;
		if (z0uek < z0rek)
		{
			z0uek = z0rek;
		}
	}

	public z0ZzZzouk(int p0)
	{
		if (p0 <= 0)
		{
			throw new ArgumentOutOfRangeException("capacity=" + p0);
		}
		z0yek = new byte[p0];
		z0tek = p0;
	}

	public override void Close()
	{
	}

	public void z0eek(long p0)
	{
		if (p0 > z0tek)
		{
			byte[] array = new byte[(int)((double)p0 * 1.5)];
			if (z0uek > 0)
			{
				Buffer.BlockCopy(z0yek, 0, array, 0, (int)z0uek);
			}
			z0yek = array;
			z0tek = array.Length;
		}
	}

	public z0ZzZzouk()
	{
		z0yek = new byte[1024];
		z0tek = z0yek.Length;
	}
}
