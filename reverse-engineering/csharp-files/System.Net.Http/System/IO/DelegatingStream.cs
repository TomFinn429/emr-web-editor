using System.Threading;
using System.Threading.Tasks;

namespace System.IO;

internal abstract class DelegatingStream : Stream
{
	private readonly Stream _innerStream;

	public override bool CanRead => _innerStream.CanRead;

	public override bool CanSeek => _innerStream.CanSeek;

	public override bool CanWrite => _innerStream.CanWrite;

	public override long Length => _innerStream.Length;

	public override long Position
	{
		get
		{
			return _innerStream.Position;
		}
		set
		{
			_innerStream.Position = position;
		}
	}

	protected DelegatingStream(Stream P_0)
	{
		_innerStream = P_0;
	}

	protected override void Dispose(bool P_0)
	{
		if (P_0)
		{
			_innerStream.Dispose();
		}
		base.Dispose(P_0);
	}

	public override long Seek(long P_0, SeekOrigin P_1)
	{
		return _innerStream.Seek(P_0, P_1);
	}

	public override int Read(byte[] P_0, int P_1, int P_2)
	{
		return _innerStream.Read(P_0, P_1, P_2);
	}

	public override int Read(Span<byte> P_0)
	{
		return _innerStream.Read(P_0);
	}

	public override int ReadByte()
	{
		return _innerStream.ReadByte();
	}

	public override Task<int> ReadAsync(byte[] P_0, int P_1, int P_2, CancellationToken P_3)
	{
		return _innerStream.ReadAsync(P_0, P_1, P_2, P_3);
	}

	public override ValueTask<int> ReadAsync(Memory<byte> P_0, CancellationToken P_1 = default(CancellationToken))
	{
		return _innerStream.ReadAsync(P_0, P_1);
	}

	public override IAsyncResult BeginRead(byte[] P_0, int P_1, int P_2, AsyncCallback P_3, object P_4)
	{
		return _innerStream.BeginRead(P_0, P_1, P_2, P_3, P_4);
	}

	public override int EndRead(IAsyncResult P_0)
	{
		return _innerStream.EndRead(P_0);
	}

	public override void CopyTo(Stream P_0, int P_1)
	{
		_innerStream.CopyTo(P_0, P_1);
	}

	public override Task CopyToAsync(Stream P_0, int P_1, CancellationToken P_2)
	{
		return _innerStream.CopyToAsync(P_0, P_1, P_2);
	}

	public override void Flush()
	{
		_innerStream.Flush();
	}

	public override Task FlushAsync(CancellationToken P_0)
	{
		return _innerStream.FlushAsync(P_0);
	}

	public override void SetLength(long P_0)
	{
		_innerStream.SetLength(P_0);
	}

	public override void Write(byte[] P_0, int P_1, int P_2)
	{
		_innerStream.Write(P_0, P_1, P_2);
	}

	public override void Write(ReadOnlySpan<byte> P_0)
	{
		_innerStream.Write(P_0);
	}

	public override void WriteByte(byte P_0)
	{
		_innerStream.WriteByte(P_0);
	}

	public override Task WriteAsync(byte[] P_0, int P_1, int P_2, CancellationToken P_3)
	{
		return _innerStream.WriteAsync(P_0, P_1, P_2, P_3);
	}

	public override ValueTask WriteAsync(ReadOnlyMemory<byte> P_0, CancellationToken P_1 = default(CancellationToken))
	{
		return _innerStream.WriteAsync(P_0, P_1);
	}

	public override IAsyncResult BeginWrite(byte[] P_0, int P_1, int P_2, AsyncCallback P_3, object P_4)
	{
		return _innerStream.BeginWrite(P_0, P_1, P_2, P_3, P_4);
	}

	public override void EndWrite(IAsyncResult P_0)
	{
		_innerStream.EndWrite(P_0);
	}
}
