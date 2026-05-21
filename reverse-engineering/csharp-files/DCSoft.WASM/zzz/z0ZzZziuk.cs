using System;
using System.IO;

namespace zzz;

public class z0ZzZziuk : Stream
{
	private byte[] z0rek;

	private long z0tek;

	private long z0yek;

	public override bool CanRead => true;

	public override long Position
	{
		get
		{
			return z0tek;
		}
		set
		{
			z0tek = value;
		}
	}

	public override bool CanSeek => true;

	public override bool CanWrite => false;

	public override long Length => z0yek;

	public byte[] z0eek()
	{
		return z0rek;
	}

	public z0ZzZziuk(byte[] p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("bs");
		}
		z0rek = p0;
		z0yek = p0.Length;
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		long num = 0L;
		num = origin switch
		{
			SeekOrigin.Begin => offset, 
			SeekOrigin.Current => z0tek + offset, 
			SeekOrigin.End => z0yek + offset, 
			_ => z0tek + offset, 
		};
		if (num < 0)
		{
			num = 0L;
		}
		if (num >= z0yek)
		{
			num = z0yek - 1;
		}
		z0tek = num;
		return num;
	}

	public override void Flush()
	{
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		throw new NotImplementedException();
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		int num = (int)Math.Min(count, z0yek - z0tek);
		if (num > 0)
		{
			Buffer.BlockCopy(z0rek, (int)z0tek, buffer, offset, num);
			z0tek += num;
			return num;
		}
		return num;
	}

	public override int ReadByte()
	{
		if (z0tek < z0yek - 1)
		{
			byte result = z0rek[z0tek];
			z0tek++;
			return result;
		}
		return -1;
	}

	public override void Close()
	{
		z0rek = null;
		z0yek = 0L;
		z0tek = 0L;
	}

	public override void SetLength(long value)
	{
		throw new NotImplementedException();
	}
}
