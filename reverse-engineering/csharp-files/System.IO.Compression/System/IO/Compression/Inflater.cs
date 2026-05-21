using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace System.IO.Compression;

internal sealed class Inflater : IDisposable
{
	private bool _finished;

	private bool _isDisposed;

	private readonly int _windowBits;

	private ZLibNative.ZLibStreamHandle _zlibStream;

	private MemoryHandle _inputBufferHandle;

	private readonly long _uncompressedSize;

	private long _currentInflatedCount;

	private object SyncLock => this;

	private unsafe bool IsInputBufferHandleAllocated => _inputBufferHandle.Pointer != null;

	internal Inflater(int P_0, long P_1 = -1L)
	{
		_finished = false;
		_isDisposed = false;
		_windowBits = P_0;
		InflateInit(P_0);
		_uncompressedSize = P_1;
	}

	public bool Finished()
	{
		return _finished;
	}

	public unsafe bool Inflate(out byte P_0)
	{
		fixed (byte* ptr = &P_0)
		{
			int num = InflateVerified(ptr, 1);
			return num != 0;
		}
	}

	public unsafe int Inflate(byte[] P_0, int P_1, int P_2)
	{
		if (P_2 == 0)
		{
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return InflateVerified(ptr + P_1, P_2);
		}
	}

	public unsafe int Inflate(Span<byte> P_0)
	{
		if (P_0.Length == 0)
		{
			return 0;
		}
		fixed (byte* reference = &MemoryMarshal.GetReference(P_0))
		{
			return InflateVerified(reference, P_0.Length);
		}
	}

	public unsafe int InflateVerified(byte* P_0, int P_1)
	{
		try
		{
			int num = 0;
			if (_uncompressedSize == -1)
			{
				ReadOutput(P_0, P_1, out num);
			}
			else if (_uncompressedSize > _currentInflatedCount)
			{
				P_1 = (int)Math.Min(P_1, _uncompressedSize - _currentInflatedCount);
				ReadOutput(P_0, P_1, out num);
				_currentInflatedCount += num;
			}
			else
			{
				_finished = true;
				_zlibStream.AvailIn = 0u;
			}
			return num;
		}
		finally
		{
			if (_zlibStream.AvailIn == 0 && IsInputBufferHandleAllocated)
			{
				DeallocateInputBufferHandle();
			}
		}
	}

	private unsafe void ReadOutput(byte* P_0, int P_1, out int P_2)
	{
		if (ReadInflateOutput(P_0, P_1, ZLibNative.FlushCode.NoFlush, out P_2) == ZLibNative.ErrorCode.StreamEnd)
		{
			if (!NeedsInput() && IsGzipStream() && IsInputBufferHandleAllocated)
			{
				_finished = ResetStreamForLeftoverInput();
			}
			else
			{
				_finished = true;
			}
		}
	}

	private unsafe bool ResetStreamForLeftoverInput()
	{
		lock (SyncLock)
		{
			nint nextIn = _zlibStream.NextIn;
			byte* ptr = (byte*)((IntPtr)nextIn).ToPointer();
			uint availIn = _zlibStream.AvailIn;
			if (*ptr != 31 || (availIn > 1 && ptr[1] != 139))
			{
				return true;
			}
			_zlibStream.Dispose();
			InflateInit(_windowBits);
			_zlibStream.NextIn = nextIn;
			_zlibStream.AvailIn = availIn;
			_finished = false;
		}
		return false;
	}

	internal bool IsGzipStream()
	{
		if (_windowBits >= 24)
		{
			return _windowBits <= 31;
		}
		return false;
	}

	public bool NeedsInput()
	{
		return _zlibStream.AvailIn == 0;
	}

	public void SetInput(byte[] P_0, int P_1, int P_2)
	{
		SetInput(P_0.AsMemory(P_1, P_2));
	}

	public unsafe void SetInput(ReadOnlyMemory<byte> P_0)
	{
		if (P_0.IsEmpty)
		{
			return;
		}
		lock (SyncLock)
		{
			_inputBufferHandle = P_0.Pin();
			_zlibStream.NextIn = (nint)_inputBufferHandle.Pointer;
			_zlibStream.AvailIn = (uint)P_0.Length;
			_finished = false;
		}
	}

	private void Dispose(bool P_0)
	{
		if (!_isDisposed)
		{
			if (P_0)
			{
				_zlibStream.Dispose();
			}
			if (IsInputBufferHandleAllocated)
			{
				DeallocateInputBufferHandle();
			}
			_isDisposed = true;
		}
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	~Inflater()
	{
		Dispose(false);
	}

	[MemberNotNull("_zlibStream")]
	private void InflateInit(int P_0)
	{
		ZLibNative.ErrorCode errorCode;
		try
		{
			errorCode = ZLibNative.CreateZLibStreamForInflate(out _zlibStream, P_0);
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
			throw new ZLibException("ZLibErrorNotEnoughMemory", "inflateInit2_", (int)errorCode, _zlibStream.GetErrorMessage());
		case ZLibNative.ErrorCode.VersionError:
			throw new ZLibException("ZLibErrorVersionMismatch", "inflateInit2_", (int)errorCode, _zlibStream.GetErrorMessage());
		case ZLibNative.ErrorCode.StreamError:
			throw new ZLibException("ZLibErrorIncorrectInitParameters", "inflateInit2_", (int)errorCode, _zlibStream.GetErrorMessage());
		default:
			throw new ZLibException("ZLibErrorUnexpected", "inflateInit2_", (int)errorCode, _zlibStream.GetErrorMessage());
		}
	}

	private unsafe ZLibNative.ErrorCode ReadInflateOutput(byte* P_0, int P_1, ZLibNative.FlushCode P_2, out int P_3)
	{
		lock (SyncLock)
		{
			_zlibStream.NextOut = (nint)P_0;
			_zlibStream.AvailOut = (uint)P_1;
			ZLibNative.ErrorCode result = Inflate(P_2);
			P_3 = P_1 - (int)_zlibStream.AvailOut;
			return result;
		}
	}

	private ZLibNative.ErrorCode Inflate(ZLibNative.FlushCode P_0)
	{
		ZLibNative.ErrorCode errorCode;
		try
		{
			errorCode = _zlibStream.Inflate(P_0);
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
		case ZLibNative.ErrorCode.MemError:
			throw new ZLibException("ZLibErrorNotEnoughMemory", "inflate_", (int)errorCode, _zlibStream.GetErrorMessage());
		case ZLibNative.ErrorCode.DataError:
			throw new InvalidDataException("UnsupportedCompression");
		case ZLibNative.ErrorCode.StreamError:
			throw new ZLibException("ZLibErrorInconsistentStream", "inflate_", (int)errorCode, _zlibStream.GetErrorMessage());
		default:
			throw new ZLibException("ZLibErrorUnexpected", "inflate_", (int)errorCode, _zlibStream.GetErrorMessage());
		}
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
}
