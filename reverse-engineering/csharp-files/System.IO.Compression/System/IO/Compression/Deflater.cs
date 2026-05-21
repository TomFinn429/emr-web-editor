using System.Buffers;

namespace System.IO.Compression;

internal sealed class Deflater : IDisposable
{
	private readonly ZLibNative.ZLibStreamHandle _zlibStream;

	private MemoryHandle _inputBufferHandle;

	private bool _isDisposed;

	private object SyncLock => this;

	internal Deflater(CompressionLevel P_0, int P_1)
	{
		ZLibNative.CompressionLevel compressionLevel;
		int num;
		switch (P_0)
		{
		case CompressionLevel.Optimal:
			compressionLevel = ZLibNative.CompressionLevel.DefaultCompression;
			num = 8;
			break;
		case CompressionLevel.Fastest:
			compressionLevel = ZLibNative.CompressionLevel.BestSpeed;
			num = 8;
			break;
		case CompressionLevel.NoCompression:
			compressionLevel = ZLibNative.CompressionLevel.NoCompression;
			num = 7;
			break;
		case CompressionLevel.SmallestSize:
			compressionLevel = ZLibNative.CompressionLevel.BestCompression;
			num = 8;
			break;
		default:
			throw new ArgumentOutOfRangeException("compressionLevel");
		}
		ZLibNative.CompressionStrategy compressionStrategy = ZLibNative.CompressionStrategy.DefaultStrategy;
		ZLibNative.ErrorCode errorCode;
		try
		{
			errorCode = ZLibNative.CreateZLibStreamForDeflate(out _zlibStream, compressionLevel, P_1, num, compressionStrategy);
		}
		catch (Exception ex)
		{
			throw new ZLibException("ZLibErrorDLLLoadError", ex);
		}
		switch (errorCode)
		{
		case ZLibNative.ErrorCode.Ok:
			break;
		case ZLibNative.ErrorCode.MemError:
			throw new ZLibException("ZLibErrorNotEnoughMemory", "deflateInit2_", (int)errorCode, _zlibStream.GetErrorMessage());
		case ZLibNative.ErrorCode.VersionError:
			throw new ZLibException("ZLibErrorVersionMismatch", "deflateInit2_", (int)errorCode, _zlibStream.GetErrorMessage());
		case ZLibNative.ErrorCode.StreamError:
			throw new ZLibException("ZLibErrorIncorrectInitParameters", "deflateInit2_", (int)errorCode, _zlibStream.GetErrorMessage());
		default:
			throw new ZLibException("ZLibErrorUnexpected", "deflateInit2_", (int)errorCode, _zlibStream.GetErrorMessage());
		}
	}

	~Deflater()
	{
		Dispose(false);
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	private void Dispose(bool P_0)
	{
		if (!_isDisposed)
		{
			if (P_0)
			{
				_zlibStream.Dispose();
			}
			DeallocateInputBufferHandle();
			_isDisposed = true;
		}
	}

	public bool NeedsInput()
	{
		return _zlibStream.AvailIn == 0;
	}

	internal unsafe void SetInput(ReadOnlyMemory<byte> P_0)
	{
		if (P_0.Length == 0)
		{
			return;
		}
		lock (SyncLock)
		{
			_inputBufferHandle = P_0.Pin();
			_zlibStream.NextIn = (nint)_inputBufferHandle.Pointer;
			_zlibStream.AvailIn = (uint)P_0.Length;
		}
	}

	internal unsafe void SetInput(byte* P_0, int P_1)
	{
		if (P_1 == 0)
		{
			return;
		}
		lock (SyncLock)
		{
			_zlibStream.NextIn = (nint)P_0;
			_zlibStream.AvailIn = (uint)P_1;
		}
	}

	internal int GetDeflateOutput(byte[] P_0)
	{
		try
		{
			ReadDeflateOutput(P_0, ZLibNative.FlushCode.NoFlush, out var result);
			return result;
		}
		finally
		{
			if (_zlibStream.AvailIn == 0)
			{
				DeallocateInputBufferHandle();
			}
		}
	}

	private unsafe ZLibNative.ErrorCode ReadDeflateOutput(byte[] P_0, ZLibNative.FlushCode P_1, out int P_2)
	{
		lock (SyncLock)
		{
			fixed (byte* nextOut = &P_0[0])
			{
				_zlibStream.NextOut = (nint)nextOut;
				_zlibStream.AvailOut = (uint)P_0.Length;
				ZLibNative.ErrorCode result = Deflate(P_1);
				P_2 = P_0.Length - (int)_zlibStream.AvailOut;
				return result;
			}
		}
	}

	internal bool Finish(byte[] P_0, out int P_1)
	{
		ZLibNative.ErrorCode errorCode = ReadDeflateOutput(P_0, ZLibNative.FlushCode.Finish, out P_1);
		return errorCode == ZLibNative.ErrorCode.StreamEnd;
	}

	internal bool Flush(byte[] P_0, out int P_1)
	{
		return ReadDeflateOutput(P_0, ZLibNative.FlushCode.SyncFlush, out P_1) == ZLibNative.ErrorCode.Ok;
	}

	private void DeallocateInputBufferHandle()
	{
		lock (SyncLock)
		{
			_zlibStream.AvailIn = 0u;
			_zlibStream.NextIn = ZLibNative.ZNullPtr;
			_inputBufferHandle.Dispose();
		}
	}

	private ZLibNative.ErrorCode Deflate(ZLibNative.FlushCode P_0)
	{
		ZLibNative.ErrorCode errorCode;
		try
		{
			errorCode = _zlibStream.Deflate(P_0);
		}
		catch (Exception ex)
		{
			throw new ZLibException("ZLibErrorDLLLoadError", ex);
		}
		switch (errorCode)
		{
		case ZLibNative.ErrorCode.Ok:
		case ZLibNative.ErrorCode.StreamEnd:
			return errorCode;
		case ZLibNative.ErrorCode.BufError:
			return errorCode;
		case ZLibNative.ErrorCode.StreamError:
			throw new ZLibException("ZLibErrorInconsistentStream", "deflate", (int)errorCode, _zlibStream.GetErrorMessage());
		default:
			throw new ZLibException("ZLibErrorUnexpected", "deflate", (int)errorCode, _zlibStream.GetErrorMessage());
		}
	}
}
