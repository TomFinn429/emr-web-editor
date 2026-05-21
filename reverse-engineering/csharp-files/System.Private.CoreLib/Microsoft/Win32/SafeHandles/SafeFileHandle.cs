using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Strategies;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace Microsoft.Win32.SafeHandles;

public sealed class SafeFileHandle : SafeHandleZeroOrMinusOneIsInvalid
{
	internal sealed class ThreadPoolValueTaskSource : IThreadPoolWorkItem, IValueTaskSource<int>, IValueTaskSource<long>, IValueTaskSource
	{
		private enum Operation : byte
		{
			None,
			Read,
			Write,
			ReadScatter,
			WriteGather
		}

		private readonly SafeFileHandle _fileHandle;

		private ManualResetValueTaskSourceCore<long> _source;

		private Operation _operation;

		private ExecutionContext _context;

		private OSFileStreamStrategy _strategy;

		private long _fileOffset;

		private CancellationToken _cancellationToken;

		private ReadOnlyMemory<byte> _singleSegment;

		private IReadOnlyList<Memory<byte>> _readScatterBuffers;

		private IReadOnlyList<ReadOnlyMemory<byte>> _writeGatherBuffers;

		internal ThreadPoolValueTaskSource(SafeFileHandle P_0)
		{
			_fileHandle = P_0;
		}

		public ValueTaskSourceStatus GetStatus(short P_0)
		{
			return _source.GetStatus(P_0);
		}

		public void OnCompleted(Action<object> P_0, object P_1, short P_2, ValueTaskSourceOnCompletedFlags P_3)
		{
			_source.OnCompleted(P_0, P_1, P_2, P_3);
		}

		void IValueTaskSource.GetResult(short P_0)
		{
			GetResult(P_0);
		}

		int IValueTaskSource<int>.GetResult(short P_0)
		{
			return (int)GetResult(P_0);
		}

		public long GetResult(short P_0)
		{
			try
			{
				return _source.GetResult(P_0);
			}
			finally
			{
				_source.Reset();
				Volatile.Write(ref _fileHandle._reusableThreadPoolValueTaskSource, this);
			}
		}

		private void ExecuteInternal()
		{
			long num = 0L;
			Exception ex = null;
			try
			{
				if (_cancellationToken.IsCancellationRequested)
				{
					ex = new OperationCanceledException(_cancellationToken);
				}
				else
				{
					switch (_operation)
					{
					case Operation.Read:
					{
						Memory<byte> memory = MemoryMarshal.AsMemory(_singleSegment);
						num = RandomAccess.ReadAtOffset(_fileHandle, memory.Span, _fileOffset);
						break;
					}
					case Operation.Write:
						RandomAccess.WriteAtOffset(_fileHandle, _singleSegment.Span, _fileOffset);
						break;
					case Operation.ReadScatter:
						num = RandomAccess.ReadScatterAtOffset(_fileHandle, _readScatterBuffers, _fileOffset);
						break;
					case Operation.WriteGather:
						RandomAccess.WriteGatherAtOffset(_fileHandle, _writeGatherBuffers, _fileOffset);
						break;
					}
				}
			}
			catch (Exception ex2)
			{
				ex = ex2;
			}
			finally
			{
				if (_strategy != null)
				{
					if (ex != null)
					{
						_strategy.OnIncompleteOperation(_singleSegment.Length, 0);
					}
					else if (_operation == Operation.Read && num != _singleSegment.Length)
					{
						_strategy.OnIncompleteOperation(_singleSegment.Length, (int)num);
					}
				}
				_operation = Operation.None;
				_context = null;
				_strategy = null;
				_cancellationToken = default(CancellationToken);
				_singleSegment = default(ReadOnlyMemory<byte>);
				_readScatterBuffers = null;
				_writeGatherBuffers = null;
			}
			if (ex == null)
			{
				_source.SetResult(num);
			}
			else
			{
				_source.SetException(ex);
			}
		}

		void IThreadPoolWorkItem.Execute()
		{
			if (_context == null || _context.IsDefault)
			{
				ExecuteInternal();
				return;
			}
			ExecutionContext.RunForThreadPoolUnsafe(_context, delegate(ThreadPoolValueTaskSource P_0)
			{
				P_0.ExecuteInternal();
			}, in this);
		}

		private void QueueToThreadPool()
		{
			_context = ExecutionContext.Capture();
			ThreadPool.UnsafeQueueUserWorkItem(this, true);
		}

		public ValueTask<int> QueueRead(Memory<byte> P_0, long P_1, CancellationToken P_2, OSFileStreamStrategy P_3)
		{
			_operation = Operation.Read;
			_singleSegment = P_0;
			_fileOffset = P_1;
			_cancellationToken = P_2;
			_strategy = P_3;
			QueueToThreadPool();
			return new ValueTask<int>(this, _source.Version);
		}

		public ValueTask QueueWrite(ReadOnlyMemory<byte> P_0, long P_1, CancellationToken P_2, OSFileStreamStrategy P_3)
		{
			_operation = Operation.Write;
			_singleSegment = P_0;
			_fileOffset = P_1;
			_cancellationToken = P_2;
			_strategy = P_3;
			QueueToThreadPool();
			return new ValueTask(this, _source.Version);
		}
	}

	private enum NullableBool
	{
		Undefined = 0,
		False = -1,
		True = 1
	}

	private string _path;

	private ThreadPoolValueTaskSource _reusableThreadPoolValueTaskSource;

	private volatile NullableBool _canSeek;

	private volatile NullableBool _supportsRandomAccess;

	private bool _deleteOnClose;

	private bool _isLocked;

	[CompilerGenerated]
	private bool _003CIsAsync_003Ek__BackingField;

	[ThreadStatic]
	internal static Interop.ErrorInfo? t_lastCloseErrorInfo;

	internal string? Path => _path;

	internal static bool DisableFileLocking { get; }

	public bool IsAsync
	{
		[CompilerGenerated]
		get
		{
			return _003CIsAsync_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CIsAsync_003Ek__BackingField = flag;
		}
	}

	internal bool CanSeek
	{
		get
		{
			if (!base.IsClosed)
			{
				return GetCanSeek();
			}
			return false;
		}
	}

	internal bool SupportsRandomAccess
	{
		get
		{
			NullableBool nullableBool = _supportsRandomAccess;
			if (nullableBool == NullableBool.Undefined)
			{
				nullableBool = (_supportsRandomAccess = (GetCanSeek() ? NullableBool.True : NullableBool.False));
			}
			return nullableBool == NullableBool.True;
		}
		set
		{
			_supportsRandomAccess = (flag ? NullableBool.True : NullableBool.False);
		}
	}

	internal ThreadPoolBoundHandle? ThreadPoolBinding => null;

	public override bool IsInvalid
	{
		get
		{
			long num = handle;
			if (num >= 0)
			{
				return num > 2147483647;
			}
			return true;
		}
	}

	internal ThreadPoolValueTaskSource GetThreadPoolValueTaskSource()
	{
		return Interlocked.Exchange(ref _reusableThreadPoolValueTaskSource, null) ?? new ThreadPoolValueTaskSource(this);
	}

	public SafeFileHandle()
		: this(true)
	{
	}

	private SafeFileHandle(bool P_0)
		: base(P_0)
	{
		SetHandle(new IntPtr(-1));
	}

	internal bool TryGetCachedLength(out long P_0)
	{
		P_0 = -1L;
		return false;
	}

	private static SafeFileHandle Open(string P_0, Interop.Sys.OpenFlags P_1, int P_2, Func<Interop.ErrorInfo, Interop.Sys.OpenFlags, string, Exception> P_3)
	{
		SafeFileHandle safeFileHandle = Interop.Sys.Open(P_0, P_1, P_2);
		safeFileHandle._path = P_0;
		if (safeFileHandle.IsInvalid)
		{
			Interop.ErrorInfo errorInfo = Interop.Sys.GetLastErrorInfo();
			safeFileHandle.Dispose();
			Exception ex = P_3?.Invoke(errorInfo, P_1, P_0);
			if (ex != null)
			{
				throw ex;
			}
			if (errorInfo.Error == Interop.Error.EISDIR)
			{
				errorInfo = Interop.Error.EACCES.Info();
			}
			Interop.CheckIo(errorInfo.Error, P_0);
		}
		return safeFileHandle;
	}

	protected override bool ReleaseHandle()
	{
		if (_deleteOnClose)
		{
			Interop.Sys.Unlink(_path);
		}
		if (_isLocked)
		{
			Interop.Sys.FLock(handle, Interop.Sys.LockOperations.LOCK_UN);
			_isLocked = false;
		}
		int num = Interop.Sys.Close(handle);
		if (num != 0)
		{
			t_lastCloseErrorInfo = Interop.Sys.GetLastErrorInfo();
		}
		return num == 0;
	}

	internal static SafeFileHandle Open(string P_0, FileMode P_1, FileAccess P_2, FileShare P_3, FileOptions P_4, long P_5, UnixFileMode? P_6 = null, Func<Interop.ErrorInfo, Interop.Sys.OpenFlags, string, Exception> P_7 = null)
	{
		long num;
		UnixFileMode unixFileMode;
		return Open(P_0, P_1, P_2, P_3, P_4, P_5, P_6 ?? (UnixFileMode.OtherWrite | UnixFileMode.OtherRead | UnixFileMode.GroupWrite | UnixFileMode.GroupRead | UnixFileMode.UserWrite | UnixFileMode.UserRead), out num, out unixFileMode, P_7);
	}

	private static SafeFileHandle Open(string P_0, FileMode P_1, FileAccess P_2, FileShare P_3, FileOptions P_4, long P_5, UnixFileMode P_6, out long P_7, out UnixFileMode P_8, Func<Interop.ErrorInfo, Interop.Sys.OpenFlags, string, Exception> P_9 = null)
	{
		Interop.Sys.OpenFlags openFlags = PreOpenConfigurationFromOptions(P_1, P_2, P_3, P_4);
		SafeFileHandle safeFileHandle = null;
		try
		{
			while (true)
			{
				safeFileHandle = Open(P_0, openFlags, (int)P_6, P_9);
				if (safeFileHandle.Init(P_0, P_1, P_2, P_3, P_4, P_5, out P_7, out P_8))
				{
					break;
				}
				safeFileHandle.Dispose();
			}
			return safeFileHandle;
		}
		catch (Exception)
		{
			safeFileHandle?.Dispose();
			throw;
		}
	}

	private static Interop.Sys.OpenFlags PreOpenConfigurationFromOptions(FileMode P_0, FileAccess P_1, FileShare P_2, FileOptions P_3)
	{
		Interop.Sys.OpenFlags openFlags = Interop.Sys.OpenFlags.O_RDONLY;
		switch (P_0)
		{
		case FileMode.Truncate:
			if (DisableFileLocking)
			{
				openFlags |= Interop.Sys.OpenFlags.O_TRUNC;
			}
			break;
		case FileMode.OpenOrCreate:
		case FileMode.Append:
			openFlags |= Interop.Sys.OpenFlags.O_CREAT;
			break;
		case FileMode.Create:
			openFlags |= Interop.Sys.OpenFlags.O_CREAT;
			if (DisableFileLocking)
			{
				openFlags |= Interop.Sys.OpenFlags.O_TRUNC;
			}
			break;
		case FileMode.CreateNew:
			openFlags |= Interop.Sys.OpenFlags.O_CREAT | Interop.Sys.OpenFlags.O_EXCL;
			break;
		}
		switch (P_1)
		{
		case FileAccess.Read:
			openFlags |= Interop.Sys.OpenFlags.O_RDONLY;
			break;
		case FileAccess.ReadWrite:
			openFlags |= Interop.Sys.OpenFlags.O_RDWR;
			break;
		case FileAccess.Write:
			openFlags |= Interop.Sys.OpenFlags.O_WRONLY;
			break;
		}
		if ((P_2 & FileShare.Inheritable) == 0)
		{
			openFlags |= Interop.Sys.OpenFlags.O_CLOEXEC;
		}
		if ((P_3 & FileOptions.WriteThrough) != FileOptions.None)
		{
			openFlags |= Interop.Sys.OpenFlags.O_SYNC;
		}
		return openFlags;
	}

	private bool Init(string P_0, FileMode P_1, FileAccess P_2, FileShare P_3, FileOptions P_4, long P_5, out long P_6, out UnixFileMode P_7)
	{
		Interop.Sys.FileStatus fileStatus = default(Interop.Sys.FileStatus);
		bool flag = false;
		P_6 = -1L;
		P_7 = UnixFileMode.None;
		if ((P_2 & FileAccess.Write) == 0)
		{
			FStatCheckIO(P_0, ref fileStatus, ref flag);
			if ((fileStatus.Mode & 0xF000) == 16384)
			{
				throw Interop.GetExceptionForIoErrno(Interop.Error.EACCES.Info(), P_0);
			}
			if ((fileStatus.Mode & 0xF000) == 32768)
			{
				_canSeek = NullableBool.True;
			}
			P_6 = fileStatus.Size;
			P_7 = (UnixFileMode)(fileStatus.Mode & 0x1FF);
		}
		IsAsync = (P_4 & FileOptions.Asynchronous) != 0;
		Interop.Sys.LockOperations lockOperations = ((P_3 != FileShare.None) ? Interop.Sys.LockOperations.LOCK_SH : Interop.Sys.LockOperations.LOCK_EX);
		if (CanLockTheFile(lockOperations, P_2) && !(_isLocked = Interop.Sys.FLock(this, lockOperations | Interop.Sys.LockOperations.LOCK_NB) >= 0))
		{
			Interop.ErrorInfo lastErrorInfo = Interop.Sys.GetLastErrorInfo();
			if (lastErrorInfo.Error == Interop.Error.EAGAIN)
			{
				throw Interop.GetExceptionForIoErrno(lastErrorInfo, P_0);
			}
		}
		if (_isLocked && (P_4 & FileOptions.DeleteOnClose) != FileOptions.None && P_3 == FileShare.None && P_1 == FileMode.OpenOrCreate)
		{
			FStatCheckIO(P_0, ref fileStatus, ref flag);
			if (Interop.Sys.Stat(P_0, out var fileStatus2) < 0)
			{
				Interop.ErrorInfo lastErrorInfo2 = Interop.Sys.GetLastErrorInfo();
				if (lastErrorInfo2.Error == Interop.Error.ENOENT)
				{
					return false;
				}
				throw Interop.GetExceptionForIoErrno(lastErrorInfo2, P_0);
			}
			if (fileStatus2.Ino != fileStatus.Ino || fileStatus2.Dev != fileStatus.Dev)
			{
				return false;
			}
		}
		_deleteOnClose = (P_4 & FileOptions.DeleteOnClose) != 0;
		Interop.Sys.FileAdvice fileAdvice = (((P_4 & FileOptions.RandomAccess) != FileOptions.None) ? Interop.Sys.FileAdvice.POSIX_FADV_RANDOM : (((P_4 & FileOptions.SequentialScan) != FileOptions.None) ? Interop.Sys.FileAdvice.POSIX_FADV_SEQUENTIAL : Interop.Sys.FileAdvice.POSIX_FADV_NORMAL));
		if (fileAdvice != Interop.Sys.FileAdvice.POSIX_FADV_NORMAL)
		{
			FileStreamHelpers.CheckFileCall(Interop.Sys.PosixFAdvise(this, 0L, 0L, fileAdvice), P_0, true);
		}
		if ((P_1 == FileMode.Create || P_1 == FileMode.Truncate) && !DisableFileLocking && Interop.Sys.FTruncate(this, 0L) < 0)
		{
			Interop.ErrorInfo lastErrorInfo3 = Interop.Sys.GetLastErrorInfo();
			if (lastErrorInfo3.Error != Interop.Error.EBADF && lastErrorInfo3.Error != Interop.Error.EINVAL)
			{
				throw Interop.GetExceptionForIoErrno(lastErrorInfo3, P_0);
			}
		}
		if (P_5 > 0 && Interop.Sys.FAllocate(this, 0L, P_5) < 0)
		{
			Interop.ErrorInfo lastErrorInfo4 = Interop.Sys.GetLastErrorInfo();
			if (lastErrorInfo4.Error == Interop.Error.EFBIG || lastErrorInfo4.Error == Interop.Error.ENOSPC)
			{
				Dispose();
				Interop.Sys.Unlink(P_0);
				throw new IOException(SR.Format((lastErrorInfo4.Error == Interop.Error.EFBIG) ? "IO_FileTooLarge_Path_AllocationSize" : "IO_DiskFull_Path_AllocationSize", P_0, P_5));
			}
		}
		return true;
	}

	private bool CanLockTheFile(Interop.Sys.LockOperations P_0, FileAccess P_1)
	{
		if (DisableFileLocking)
		{
			return false;
		}
		if (P_0 == Interop.Sys.LockOperations.LOCK_EX)
		{
			return true;
		}
		if ((P_1 & FileAccess.Write) == 0)
		{
			return true;
		}
		if (!Interop.Sys.TryGetFileSystemType(this, out var unixFileSystemTypes))
		{
			return false;
		}
		switch (unixFileSystemTypes)
		{
		case Interop.Sys.UnixFileSystemTypes.smb2:
		case Interop.Sys.UnixFileSystemTypes.cifs:
		case Interop.Sys.UnixFileSystemTypes.samba:
		case Interop.Sys.UnixFileSystemTypes.nfs:
			return false;
		default:
			return true;
		}
	}

	private void FStatCheckIO(string P_0, ref Interop.Sys.FileStatus P_1, ref bool P_2)
	{
		if (!P_2)
		{
			if (Interop.Sys.FStat(this, out P_1) != 0)
			{
				Interop.ErrorInfo lastErrorInfo = Interop.Sys.GetLastErrorInfo();
				throw Interop.GetExceptionForIoErrno(lastErrorInfo, P_0);
			}
			P_2 = true;
		}
	}

	private bool GetCanSeek()
	{
		NullableBool nullableBool = _canSeek;
		if (nullableBool == NullableBool.Undefined)
		{
			nullableBool = (_canSeek = ((Interop.Sys.LSeek(this, 0L, Interop.Sys.SeekWhence.SEEK_CUR) >= 0) ? NullableBool.True : NullableBool.False));
		}
		return nullableBool == NullableBool.True;
	}

	internal long GetFileLength()
	{
		Interop.Sys.FileStatus fileStatus;
		int num = Interop.Sys.FStat(this, out fileStatus);
		FileStreamHelpers.CheckFileCall(num, Path);
		return fileStatus.Size;
	}

	static SafeFileHandle()
	{
		if (1 == 0)
		{
		}
		DisableFileLocking = true;
	}
}
