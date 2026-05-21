using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http;

public abstract class HttpContent : IDisposable
{
	internal sealed class LimitMemoryStream : MemoryStream
	{
		private readonly int _maxSize;

		public LimitMemoryStream(int P_0, int P_1)
			: base(P_1)
		{
			_maxSize = P_0;
		}

		public override void Write(byte[] P_0, int P_1, int P_2)
		{
			CheckSize(P_2);
			base.Write(P_0, P_1, P_2);
		}

		public override void WriteByte(byte P_0)
		{
			CheckSize(1);
			base.WriteByte(P_0);
		}

		public override Task WriteAsync(byte[] P_0, int P_1, int P_2, CancellationToken P_3)
		{
			CheckSize(P_2);
			return base.WriteAsync(P_0, P_1, P_2, P_3);
		}

		public override ValueTask WriteAsync(ReadOnlyMemory<byte> P_0, CancellationToken P_1)
		{
			CheckSize(P_0.Length);
			return base.WriteAsync(P_0, P_1);
		}

		public override IAsyncResult BeginWrite(byte[] P_0, int P_1, int P_2, AsyncCallback P_3, object P_4)
		{
			CheckSize(P_2);
			return base.BeginWrite(P_0, P_1, P_2, P_3, P_4);
		}

		public override void EndWrite(IAsyncResult P_0)
		{
			base.EndWrite(P_0);
		}

		public override Task CopyToAsync(Stream P_0, int P_1, CancellationToken P_2)
		{
			if (TryGetBuffer(out var arraySegment))
			{
				Stream.ValidateCopyToArguments(P_0, P_1);
				long position = Position;
				long num = (Position = Length);
				long num2 = num - position;
				return P_0.WriteAsync(arraySegment.Array, (int)(arraySegment.Offset + position), (int)num2, P_2);
			}
			return base.CopyToAsync(P_0, P_1, P_2);
		}

		private void CheckSize(int P_0)
		{
			if (_maxSize - Length < P_0)
			{
				throw CreateOverCapacityException(_maxSize);
			}
		}
	}

	private HttpContentHeaders _headers;

	private MemoryStream _bufferedContent;

	private object _contentReadStream;

	private bool _disposed;

	private bool _canCalculateLength;

	internal static readonly Encoding DefaultStringEncoding = Encoding.UTF8;

	public HttpContentHeaders Headers => _headers ?? (_headers = new HttpContentHeaders(this));

	private bool IsBuffered => _bufferedContent != null;

	internal bool TryGetBuffer(out ArraySegment<byte> P_0)
	{
		if (_bufferedContent != null)
		{
			return _bufferedContent.TryGetBuffer(out P_0);
		}
		P_0 = default(ArraySegment<byte>);
		return false;
	}

	protected HttpContent()
	{
		if (NetEventSource.Log.IsEnabled())
		{
		}
		_canCalculateLength = true;
	}

	public Task<string> ReadAsStringAsync(CancellationToken P_0)
	{
		CheckDisposed();
		return WaitAndReturnAsync(LoadIntoBufferAsync(P_0), this, (HttpContent httpContent) => httpContent.ReadBufferedContentAsString());
	}

	private string ReadBufferedContentAsString()
	{
		if (_bufferedContent.Length == 0L)
		{
			return string.Empty;
		}
		if (!TryGetBuffer(out var arraySegment))
		{
			arraySegment = new ArraySegment<byte>(_bufferedContent.ToArray());
		}
		return ReadBufferAsString(arraySegment, Headers);
	}

	internal static string ReadBufferAsString(ArraySegment<byte> P_0, HttpContentHeaders P_1)
	{
		Encoding encoding = null;
		int num = -1;
		string text = P_1.ContentType?.CharSet;
		if (text != null)
		{
			try
			{
				encoding = ((text.Length <= 2 || !text.StartsWith('"') || !text.EndsWith('"')) ? Encoding.GetEncoding(text) : Encoding.GetEncoding(text.Substring(1, text.Length - 2)));
				num = GetPreambleLength(P_0, encoding);
			}
			catch (ArgumentException ex)
			{
				throw new InvalidOperationException("net_http_content_invalid_charset", ex);
			}
		}
		if (encoding == null && !TryDetectEncoding(P_0, out encoding, out num))
		{
			encoding = DefaultStringEncoding;
			num = 0;
		}
		return encoding.GetString(P_0.Array, P_0.Offset + num, P_0.Count - num);
	}

	public Task<byte[]> ReadAsByteArrayAsync(CancellationToken P_0)
	{
		CheckDisposed();
		return WaitAndReturnAsync(LoadIntoBufferAsync(P_0), this, (HttpContent httpContent) => httpContent.ReadBufferedContentAsByteArray());
	}

	internal byte[] ReadBufferedContentAsByteArray()
	{
		return _bufferedContent.ToArray();
	}

	public Task<Stream> ReadAsStreamAsync(CancellationToken P_0)
	{
		CheckDisposed();
		ArraySegment<byte> arraySegment;
		if (_contentReadStream == null)
		{
			return (Task<Stream>)(_contentReadStream = (TryGetBuffer(out arraySegment) ? ((Task)Task.FromResult((Stream)new MemoryStream(arraySegment.Array, arraySegment.Offset, arraySegment.Count, false))) : ((Task)CreateContentReadStreamAsync(P_0))));
		}
		if (_contentReadStream is Task<Stream> result)
		{
			return result;
		}
		return (Task<Stream>)(_contentReadStream = Task.FromResult((Stream)_contentReadStream));
	}

	internal Stream TryReadAsStream()
	{
		CheckDisposed();
		ArraySegment<byte> arraySegment;
		if (_contentReadStream == null)
		{
			return (Stream)(_contentReadStream = (TryGetBuffer(out arraySegment) ? new MemoryStream(arraySegment.Array, arraySegment.Offset, arraySegment.Count, false) : TryCreateContentReadStream()));
		}
		if (_contentReadStream is Stream result)
		{
			return result;
		}
		Task<Stream> task = (Task<Stream>)_contentReadStream;
		if (task.Status != TaskStatus.RanToCompletion)
		{
			return null;
		}
		return task.Result;
	}

	protected abstract Task SerializeToStreamAsync(Stream P_0, TransportContext? P_1);

	protected virtual Task SerializeToStreamAsync(Stream P_0, TransportContext? P_1, CancellationToken P_2)
	{
		return SerializeToStreamAsync(P_0, P_1);
	}

	public Task LoadIntoBufferAsync()
	{
		return LoadIntoBufferAsync(2147483647L);
	}

	public Task LoadIntoBufferAsync(long P_0)
	{
		return LoadIntoBufferAsync(P_0, CancellationToken.None);
	}

	internal Task LoadIntoBufferAsync(CancellationToken P_0)
	{
		return LoadIntoBufferAsync(2147483647L, P_0);
	}

	internal Task LoadIntoBufferAsync(long P_0, CancellationToken P_1)
	{
		CheckDisposed();
		if (!CreateTemporaryBuffer(P_0, out var memoryStream, out var ex))
		{
			return Task.CompletedTask;
		}
		if (memoryStream == null)
		{
			return Task.FromException(ex);
		}
		try
		{
			Task task = SerializeToStreamAsync(memoryStream, null, P_1);
			CheckTaskNotNull(task);
			return LoadIntoBufferAsyncCore(task, memoryStream);
		}
		catch (Exception ex2) when (StreamCopyExceptionNeedsWrapping(ex2))
		{
			return Task.FromException(GetStreamCopyException(ex2));
		}
	}

	private async Task LoadIntoBufferAsyncCore(Task P_0, MemoryStream P_1)
	{
		try
		{
			await P_0.ConfigureAwait(false);
		}
		catch (Exception ex)
		{
			P_1.Dispose();
			Exception streamCopyException = GetStreamCopyException(ex);
			if (streamCopyException != ex)
			{
				throw streamCopyException;
			}
			throw;
		}
		try
		{
			P_1.Seek(0L, SeekOrigin.Begin);
			_bufferedContent = P_1;
		}
		catch (Exception)
		{
			if (NetEventSource.Log.IsEnabled())
			{
			}
			throw;
		}
	}

	protected virtual Task<Stream> CreateContentReadStreamAsync()
	{
		return WaitAndReturnAsync(LoadIntoBufferAsync(), this, (Func<HttpContent, Stream>)((HttpContent P_0) => P_0._bufferedContent));
	}

	protected virtual Task<Stream> CreateContentReadStreamAsync(CancellationToken P_0)
	{
		return CreateContentReadStreamAsync();
	}

	internal virtual Stream TryCreateContentReadStream()
	{
		return null;
	}

	protected internal abstract bool TryComputeLength(out long P_0);

	internal long? GetComputedOrBufferLength()
	{
		CheckDisposed();
		if (IsBuffered)
		{
			return _bufferedContent.Length;
		}
		if (_canCalculateLength)
		{
			if (TryComputeLength(out var value))
			{
				return value;
			}
			_canCalculateLength = false;
		}
		return null;
	}

	private bool CreateTemporaryBuffer(long P_0, out MemoryStream P_1, out Exception P_2)
	{
		if (P_0 > 2147483647)
		{
			throw new ArgumentOutOfRangeException("maxBufferSize", P_0, System.SR.Format(CultureInfo.InvariantCulture, "net_http_content_buffersize_limit", 2147483647));
		}
		if (IsBuffered)
		{
			P_1 = null;
			P_2 = null;
			return false;
		}
		P_1 = CreateMemoryStream(P_0, out P_2);
		return true;
	}

	private MemoryStream CreateMemoryStream(long P_0, out Exception P_1)
	{
		P_1 = null;
		long? contentLength = Headers.ContentLength;
		if (contentLength.HasValue)
		{
			if (contentLength > P_0)
			{
				P_1 = new HttpRequestException(System.SR.Format(CultureInfo.InvariantCulture, "net_http_content_buffersize_exceeded", P_0));
				return null;
			}
			return new LimitMemoryStream((int)P_0, (int)contentLength.Value);
		}
		return new LimitMemoryStream((int)P_0, 0);
	}

	protected virtual void Dispose(bool P_0)
	{
		if (P_0 && !_disposed)
		{
			_disposed = true;
			if (_contentReadStream != null)
			{
				((_contentReadStream as Stream) ?? ((_contentReadStream is Task<Stream> { Status: TaskStatus.RanToCompletion } task) ? task.Result : null))?.Dispose();
				_contentReadStream = null;
			}
			if (IsBuffered)
			{
				_bufferedContent.Dispose();
			}
		}
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	private void CheckDisposed()
	{
		ObjectDisposedException.ThrowIf(_disposed, this);
	}

	private void CheckTaskNotNull(Task P_0)
	{
		if (P_0 == null)
		{
			InvalidOperationException ex = new InvalidOperationException("net_http_content_no_task_returned");
			if (NetEventSource.Log.IsEnabled())
			{
			}
			throw ex;
		}
	}

	internal static bool StreamCopyExceptionNeedsWrapping(Exception P_0)
	{
		if (!(P_0 is IOException))
		{
			return P_0 is ObjectDisposedException;
		}
		return true;
	}

	private static Exception GetStreamCopyException(Exception P_0)
	{
		if (!StreamCopyExceptionNeedsWrapping(P_0))
		{
			return P_0;
		}
		return WrapStreamCopyException(P_0);
	}

	internal static Exception WrapStreamCopyException(Exception P_0)
	{
		return new HttpRequestException("net_http_content_stream_copy_error", P_0);
	}

	private static int GetPreambleLength(ArraySegment<byte> P_0, Encoding P_1)
	{
		byte[] array = P_0.Array;
		int offset = P_0.Offset;
		int count = P_0.Count;
		switch (P_1.CodePage)
		{
		case 65001:
			if (count < 3 || array[offset] != 239 || array[offset + 1] != 187 || array[offset + 2] != 191)
			{
				return 0;
			}
			return 3;
		case 12000:
			if (count < 4 || array[offset] != 255 || array[offset + 1] != 254 || array[offset + 2] != 0 || array[offset + 3] != 0)
			{
				return 0;
			}
			return 4;
		case 1200:
			if (count < 2 || array[offset] != 255 || array[offset + 1] != 254)
			{
				return 0;
			}
			return 2;
		case 1201:
			if (count < 2 || array[offset] != 254 || array[offset + 1] != 255)
			{
				return 0;
			}
			return 2;
		default:
		{
			byte[] preamble = P_1.GetPreamble();
			if (!BufferHasPrefix(P_0, preamble))
			{
				return 0;
			}
			return preamble.Length;
		}
		}
	}

	private static bool TryDetectEncoding(ArraySegment<byte> P_0, [NotNullWhen(true)] out Encoding P_1, out int P_2)
	{
		byte[] array = P_0.Array;
		int offset = P_0.Offset;
		int count = P_0.Count;
		if (count >= 2)
		{
			switch ((array[offset] << 8) | array[offset + 1])
			{
			case 61371:
				if (count >= 3 && array[offset + 2] == 191)
				{
					P_1 = Encoding.UTF8;
					P_2 = 3;
					return true;
				}
				break;
			case 65534:
				if (count >= 4 && array[offset + 2] == 0 && array[offset + 3] == 0)
				{
					P_1 = Encoding.UTF32;
					P_2 = 4;
				}
				else
				{
					P_1 = Encoding.Unicode;
					P_2 = 2;
				}
				return true;
			case 65279:
				P_1 = Encoding.BigEndianUnicode;
				P_2 = 2;
				return true;
			}
		}
		P_1 = null;
		P_2 = 0;
		return false;
	}

	private static bool BufferHasPrefix(ArraySegment<byte> P_0, byte[] P_1)
	{
		byte[] array = P_0.Array;
		if (P_1 == null || array == null || P_1.Length > P_0.Count || P_1.Length == 0)
		{
			return false;
		}
		int num = 0;
		int num2 = P_0.Offset;
		while (num < P_1.Length)
		{
			if (P_1[num] != array[num2])
			{
				return false;
			}
			num++;
			num2++;
		}
		return true;
	}

	private static async Task<TResult> WaitAndReturnAsync<TState, TResult>(Task P_0, TState P_1, Func<TState, TResult> P_2)
	{
		await P_0.ConfigureAwait(false);
		return P_2(P_1);
	}

	private static Exception CreateOverCapacityException(int P_0)
	{
		return new HttpRequestException(System.SR.Format("net_http_content_buffersize_exceeded", P_0));
	}
}
