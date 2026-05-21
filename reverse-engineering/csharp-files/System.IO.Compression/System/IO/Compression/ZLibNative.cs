using System.Runtime.InteropServices;

namespace System.IO.Compression;

internal static class ZLibNative
{
	public enum FlushCode
	{
		NoFlush = 0,
		SyncFlush = 2,
		Finish = 4,
		Block = 5
	}

	public enum ErrorCode
	{
		Ok = 0,
		StreamEnd = 1,
		StreamError = -2,
		DataError = -3,
		MemError = -4,
		BufError = -5,
		VersionError = -6
	}

	public enum CompressionLevel
	{
		NoCompression = 0,
		BestSpeed = 1,
		DefaultCompression = -1,
		BestCompression = 9
	}

	public enum CompressionStrategy
	{
		DefaultStrategy
	}

	public enum CompressionMethod
	{
		Deflated = 8
	}

	public sealed class ZLibStreamHandle : SafeHandle
	{
		public enum State
		{
			NotInitialized,
			InitializedForDeflate,
			InitializedForInflate,
			Disposed
		}

		private ZStream _zStream;

		private volatile State _initializationState;

		public override bool IsInvalid => handle == new IntPtr(-1);

		public State InitializationState => _initializationState;

		public nint NextIn
		{
			get
			{
				return _zStream.nextIn;
			}
			set
			{
				_zStream.nextIn = nextIn;
			}
		}

		public uint AvailIn
		{
			get
			{
				return _zStream.availIn;
			}
			set
			{
				_zStream.availIn = availIn;
			}
		}

		public nint NextOut
		{
			set
			{
				_zStream.nextOut = nextOut;
			}
		}

		public uint AvailOut
		{
			get
			{
				return _zStream.availOut;
			}
			set
			{
				_zStream.availOut = availOut;
			}
		}

		public ZLibStreamHandle()
			: base(new IntPtr(-1), true)
		{
			_initializationState = State.NotInitialized;
			SetHandle(IntPtr.Zero);
		}

		protected override bool ReleaseHandle()
		{
			return InitializationState switch
			{
				State.NotInitialized => true, 
				State.InitializedForDeflate => DeflateEnd() == ErrorCode.Ok, 
				State.InitializedForInflate => InflateEnd() == ErrorCode.Ok, 
				State.Disposed => true, 
				_ => false, 
			};
		}

		private void EnsureNotDisposed()
		{
			ObjectDisposedException.ThrowIf(InitializationState == State.Disposed, this);
		}

		private void EnsureState(State P_0)
		{
			if (InitializationState != P_0)
			{
				throw new InvalidOperationException("InitializationState != " + P_0);
			}
		}

		public unsafe ErrorCode DeflateInit2_(CompressionLevel P_0, int P_1, int P_2, CompressionStrategy P_3)
		{
			EnsureNotDisposed();
			EnsureState(State.NotInitialized);
			fixed (ZStream* zStream = &_zStream)
			{
				ErrorCode result = global::Interop.ZLib.DeflateInit2_(zStream, P_0, CompressionMethod.Deflated, P_1, P_2, P_3);
				_initializationState = State.InitializedForDeflate;
				return result;
			}
		}

		public unsafe ErrorCode Deflate(FlushCode P_0)
		{
			EnsureNotDisposed();
			EnsureState(State.InitializedForDeflate);
			fixed (ZStream* zStream = &_zStream)
			{
				return global::Interop.ZLib.Deflate(zStream, P_0);
			}
		}

		public unsafe ErrorCode DeflateEnd()
		{
			EnsureNotDisposed();
			EnsureState(State.InitializedForDeflate);
			fixed (ZStream* zStream = &_zStream)
			{
				ErrorCode result = global::Interop.ZLib.DeflateEnd(zStream);
				_initializationState = State.Disposed;
				return result;
			}
		}

		public unsafe ErrorCode InflateInit2_(int P_0)
		{
			EnsureNotDisposed();
			EnsureState(State.NotInitialized);
			fixed (ZStream* zStream = &_zStream)
			{
				ErrorCode result = global::Interop.ZLib.InflateInit2_(zStream, P_0);
				_initializationState = State.InitializedForInflate;
				return result;
			}
		}

		public unsafe ErrorCode Inflate(FlushCode P_0)
		{
			EnsureNotDisposed();
			EnsureState(State.InitializedForInflate);
			fixed (ZStream* zStream = &_zStream)
			{
				return global::Interop.ZLib.Inflate(zStream, P_0);
			}
		}

		public unsafe ErrorCode InflateEnd()
		{
			EnsureNotDisposed();
			EnsureState(State.InitializedForInflate);
			fixed (ZStream* zStream = &_zStream)
			{
				ErrorCode result = global::Interop.ZLib.InflateEnd(zStream);
				_initializationState = State.Disposed;
				return result;
			}
		}

		public string GetErrorMessage()
		{
			if (_zStream.msg == ZNullPtr)
			{
				return string.Empty;
			}
			return Marshal.PtrToStringUTF8(_zStream.msg);
		}
	}

	internal struct ZStream
	{
		internal nint nextIn;

		internal nint nextOut;

		internal nint msg;

		private readonly nint internalState;

		internal uint availIn;

		internal uint availOut;
	}

	internal static readonly nint ZNullPtr = IntPtr.Zero;

	public static ErrorCode CreateZLibStreamForDeflate(out ZLibStreamHandle P_0, CompressionLevel P_1, int P_2, int P_3, CompressionStrategy P_4)
	{
		P_0 = new ZLibStreamHandle();
		return P_0.DeflateInit2_(P_1, P_2, P_3, P_4);
	}

	public static ErrorCode CreateZLibStreamForInflate(out ZLibStreamHandle P_0, int P_1)
	{
		P_0 = new ZLibStreamHandle();
		return P_0.InflateInit2_(P_1);
	}
}
