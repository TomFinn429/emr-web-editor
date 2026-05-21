using System.Threading;
using System.Threading.Tasks;

namespace System.IO.Compression;

internal sealed class PositionPreservingWriteOnlyStreamWrapper : Stream
{
	private readonly Stream _stream;

	private long _position;

	public override bool CanRead => false;

	public override bool CanSeek => false;

	public override bool CanWrite => true;

	public override long Position
	{
		get
		{
			return _position;
		}
		set
		{
			throw new NotSupportedException("NotSupported");
		}
	}

	public override long Length
	{
		get
		{
			throw new NotSupportedException("NotSupported");
		}
	}

	public PositionPreservingWriteOnlyStreamWrapper(Stream P_0)
	{
		_stream = P_0;
	}

	public override void Write(byte[] P_0, int P_1, int P_2)
	{
		_position += P_2;
		_stream.Write(P_0, P_1, P_2);
	}

	public override void Write(ReadOnlySpan<byte> P_0)
	{
		_position += P_0.Length;
		_stream.Write(P_0);
	}

	public override IAsyncResult BeginWrite(byte[] P_0, int P_1, int P_2, AsyncCallback P_3, object P_4)
	{
		_position += P_2;
		return _stream.BeginWrite(P_0, P_1, P_2, P_3, P_4);
	}

	public override void EndWrite(IAsyncResult P_0)
	{
		_stream.EndWrite(P_0);
	}

	public override void WriteByte(byte P_0)
	{
		_position++;
		_stream.WriteByte(P_0);
	}

	public override Task WriteAsync(byte[] P_0, int P_1, int P_2, CancellationToken P_3)
	{
		_position += P_2;
		return _stream.WriteAsync(P_0, P_1, P_2, P_3);
	}

	public override ValueTask WriteAsync(ReadOnlyMemory<byte> P_0, CancellationToken P_1 = default(CancellationToken))
	{
		_position += P_0.Length;
		return _stream.WriteAsync(P_0, P_1);
	}

	public override void Flush()
	{
		_stream.Flush();
	}

	public override Task FlushAsync(CancellationToken P_0)
	{
		return _stream.FlushAsync(P_0);
	}

	public override void Close()
	{
		_stream.Close();
	}

	protected override void Dispose(bool P_0)
	{
		if (P_0)
		{
			_stream.Dispose();
		}
	}

	public override long Seek(long P_0, SeekOrigin P_1)
	{
		throw new NotSupportedException("NotSupported");
	}

	public override void SetLength(long P_0)
	{
		throw new NotSupportedException("NotSupported");
	}

	public override int Read(byte[] P_0, int P_1, int P_2)
	{
		throw new NotSupportedException("NotSupported");
	}
}
