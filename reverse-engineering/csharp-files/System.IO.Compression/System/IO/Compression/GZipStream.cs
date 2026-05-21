using System.Threading;
using System.Threading.Tasks;

namespace System.IO.Compression;

public class GZipStream : Stream
{
	private DeflateStream _deflateStream;

	public override bool CanRead => _deflateStream?.CanRead ?? false;

	public override bool CanWrite => _deflateStream?.CanWrite ?? false;

	public override bool CanSeek => _deflateStream?.CanSeek ?? false;

	public override long Length
	{
		get
		{
			throw new NotSupportedException("NotSupported");
		}
	}

	public override long Position
	{
		get
		{
			throw new NotSupportedException("NotSupported");
		}
		set
		{
			throw new NotSupportedException("NotSupported");
		}
	}

	public GZipStream(Stream P_0, CompressionMode P_1)
		: this(P_0, P_1, false)
	{
	}

	public GZipStream(Stream P_0, CompressionMode P_1, bool P_2)
	{
		_deflateStream = new DeflateStream(P_0, P_1, P_2, 31, -1L);
	}

	public override void Flush()
	{
		CheckDeflateStream();
		_deflateStream.Flush();
	}

	public override long Seek(long P_0, SeekOrigin P_1)
	{
		throw new NotSupportedException("NotSupported");
	}

	public override void SetLength(long P_0)
	{
		throw new NotSupportedException("NotSupported");
	}

	public override int ReadByte()
	{
		CheckDeflateStream();
		return _deflateStream.ReadByte();
	}

	public override IAsyncResult BeginRead(byte[] P_0, int P_1, int P_2, AsyncCallback? P_3, object? P_4)
	{
		return System.Threading.Tasks.TaskToApm.Begin(ReadAsync(P_0, P_1, P_2, CancellationToken.None), P_3, P_4);
	}

	public override int EndRead(IAsyncResult P_0)
	{
		return _deflateStream.EndRead(P_0);
	}

	public override int Read(byte[] P_0, int P_1, int P_2)
	{
		CheckDeflateStream();
		return _deflateStream.Read(P_0, P_1, P_2);
	}

	public override int Read(Span<byte> P_0)
	{
		if (GetType() != typeof(GZipStream))
		{
			return base.Read(P_0);
		}
		CheckDeflateStream();
		return _deflateStream.ReadCore(P_0);
	}

	public override IAsyncResult BeginWrite(byte[] P_0, int P_1, int P_2, AsyncCallback? P_3, object? P_4)
	{
		return System.Threading.Tasks.TaskToApm.Begin(WriteAsync(P_0, P_1, P_2, CancellationToken.None), P_3, P_4);
	}

	public override void EndWrite(IAsyncResult P_0)
	{
		_deflateStream.EndWrite(P_0);
	}

	public override void Write(byte[] P_0, int P_1, int P_2)
	{
		CheckDeflateStream();
		_deflateStream.Write(P_0, P_1, P_2);
	}

	public override void WriteByte(byte P_0)
	{
		if (GetType() != typeof(GZipStream))
		{
			base.WriteByte(P_0);
			return;
		}
		CheckDeflateStream();
		_deflateStream.WriteCore(new ReadOnlySpan<byte>(in P_0));
	}

	public override void Write(ReadOnlySpan<byte> P_0)
	{
		if (GetType() != typeof(GZipStream))
		{
			base.Write(P_0);
			return;
		}
		CheckDeflateStream();
		_deflateStream.WriteCore(P_0);
	}

	public override void CopyTo(Stream P_0, int P_1)
	{
		CheckDeflateStream();
		_deflateStream.CopyTo(P_0, P_1);
	}

	protected override void Dispose(bool P_0)
	{
		try
		{
			if (P_0 && _deflateStream != null)
			{
				_deflateStream.Dispose();
			}
			_deflateStream = null;
		}
		finally
		{
			base.Dispose(P_0);
		}
	}

	public override Task<int> ReadAsync(byte[] P_0, int P_1, int P_2, CancellationToken P_3)
	{
		CheckDeflateStream();
		return _deflateStream.ReadAsync(P_0, P_1, P_2, P_3);
	}

	public override ValueTask<int> ReadAsync(Memory<byte> P_0, CancellationToken P_1 = default(CancellationToken))
	{
		if (GetType() != typeof(GZipStream))
		{
			return base.ReadAsync(P_0, P_1);
		}
		CheckDeflateStream();
		return _deflateStream.ReadAsyncMemory(P_0, P_1);
	}

	public override Task WriteAsync(byte[] P_0, int P_1, int P_2, CancellationToken P_3)
	{
		CheckDeflateStream();
		return _deflateStream.WriteAsync(P_0, P_1, P_2, P_3);
	}

	public override ValueTask WriteAsync(ReadOnlyMemory<byte> P_0, CancellationToken P_1 = default(CancellationToken))
	{
		if (GetType() != typeof(GZipStream))
		{
			return base.WriteAsync(P_0, P_1);
		}
		CheckDeflateStream();
		return _deflateStream.WriteAsyncMemory(P_0, P_1);
	}

	public override Task FlushAsync(CancellationToken P_0)
	{
		CheckDeflateStream();
		return _deflateStream.FlushAsync(P_0);
	}

	public override Task CopyToAsync(Stream P_0, int P_1, CancellationToken P_2)
	{
		CheckDeflateStream();
		return _deflateStream.CopyToAsync(P_0, P_1, P_2);
	}

	private void CheckDeflateStream()
	{
		if (_deflateStream == null)
		{
			ThrowStreamClosedException();
		}
	}

	private static void ThrowStreamClosedException()
	{
		throw new ObjectDisposedException("GZipStream", "ObjectDisposed_StreamClosed");
	}
}
