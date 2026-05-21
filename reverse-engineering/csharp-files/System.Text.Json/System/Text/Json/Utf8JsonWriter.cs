using System.Buffers;
using System.Buffers.Text;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Text.Json;

public sealed class Utf8JsonWriter : IDisposable, IAsyncDisposable
{
	private static readonly int s_newLineLength = "\n".Length;

	private IBufferWriter<byte> _output;

	private Stream _stream;

	private ArrayBufferWriter<byte> _arrayBufferWriter;

	private Memory<byte> _memory;

	private bool _inObject;

	private JsonTokenType _tokenType;

	private BitStack _bitStack;

	private int _currentDepth;

	private JsonWriterOptions _options;

	[CompilerGenerated]
	private int _003CBytesPending_003Ek__BackingField;

	[CompilerGenerated]
	private long _003CBytesCommitted_003Ek__BackingField;

	private static readonly char[] s_singleLineCommentDelimiter = new char[2] { '*', '/' };

	public int BytesPending
	{
		[CompilerGenerated]
		get
		{
			return _003CBytesPending_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CBytesPending_003Ek__BackingField = num;
		}
	}

	public long BytesCommitted
	{
		[CompilerGenerated]
		get
		{
			return _003CBytesCommitted_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CBytesCommitted_003Ek__BackingField = num;
		}
	}

	private int Indentation => CurrentDepth * 2;

	internal JsonTokenType TokenType => _tokenType;

	public int CurrentDepth => _currentDepth & 0x7FFFFFFF;

	private Utf8JsonWriter()
	{
	}

	public Utf8JsonWriter(IBufferWriter<byte> P_0, JsonWriterOptions P_1 = default(JsonWriterOptions))
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException("bufferWriter");
		}
		_output = P_0;
		_options = P_1;
		if (_options.MaxDepth == 0)
		{
			_options.MaxDepth = 1000;
		}
	}

	internal void ResetAllStateForCacheReuse()
	{
		ResetHelper();
		_stream = null;
		_arrayBufferWriter = null;
		_output = null;
	}

	internal void Reset(IBufferWriter<byte> P_0, JsonWriterOptions P_1)
	{
		_output = P_0;
		_options = P_1;
		if (_options.MaxDepth == 0)
		{
			_options.MaxDepth = 1000;
		}
	}

	internal static Utf8JsonWriter CreateEmptyInstanceForCaching()
	{
		return new Utf8JsonWriter();
	}

	private void ResetHelper()
	{
		BytesPending = 0;
		BytesCommitted = 0L;
		_memory = default(Memory<byte>);
		_inObject = false;
		_tokenType = JsonTokenType.None;
		_currentDepth = 0;
		_bitStack = default(BitStack);
	}

	private void CheckNotDisposed()
	{
		if (_stream == null && _output == null)
		{
			ThrowHelper.ThrowObjectDisposedException_Utf8JsonWriter();
		}
	}

	public void Flush()
	{
		CheckNotDisposed();
		_memory = default(Memory<byte>);
		if (_stream != null)
		{
			if (BytesPending != 0)
			{
				_arrayBufferWriter.Advance(BytesPending);
				BytesPending = 0;
				_stream.Write(_arrayBufferWriter.WrittenSpan);
				BytesCommitted += _arrayBufferWriter.WrittenCount;
				_arrayBufferWriter.Clear();
			}
			_stream.Flush();
		}
		else if (BytesPending != 0)
		{
			_output.Advance(BytesPending);
			BytesCommitted += BytesPending;
			BytesPending = 0;
		}
	}

	public void Dispose()
	{
		if (_stream != null || _output != null)
		{
			Flush();
			ResetHelper();
			_stream = null;
			_arrayBufferWriter = null;
			_output = null;
		}
	}

	public void WriteStartArray()
	{
		WriteStart(91);
		_tokenType = JsonTokenType.StartArray;
	}

	public void WriteStartObject()
	{
		WriteStart(123);
		_tokenType = JsonTokenType.StartObject;
	}

	private void WriteStart(byte P_0)
	{
		if (CurrentDepth >= _options.MaxDepth)
		{
			ThrowHelper.ThrowInvalidOperationException(ExceptionResource.DepthTooLarge, _currentDepth, _options.MaxDepth, 0, JsonTokenType.None);
		}
		if (_options.IndentedOrNotSkipValidation)
		{
			WriteStartSlow(P_0);
		}
		else
		{
			WriteStartMinimized(P_0);
		}
		_currentDepth &= 2147483647;
		_currentDepth++;
	}

	private void WriteStartMinimized(byte P_0)
	{
		if (_memory.Length - BytesPending < 2)
		{
			Grow(2);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		span[BytesPending++] = P_0;
	}

	private void WriteStartSlow(byte P_0)
	{
		if (_options.Indented)
		{
			if (!_options.SkipValidation)
			{
				ValidateStart();
				UpdateBitStackOnStart(P_0);
			}
			WriteStartIndented(P_0);
		}
		else
		{
			ValidateStart();
			UpdateBitStackOnStart(P_0);
			WriteStartMinimized(P_0);
		}
	}

	private void ValidateStart()
	{
		if (_inObject)
		{
			if (_tokenType != JsonTokenType.PropertyName)
			{
				ThrowHelper.ThrowInvalidOperationException(ExceptionResource.CannotStartObjectArrayWithoutProperty, 0, _options.MaxDepth, 0, _tokenType);
			}
		}
		else if (CurrentDepth == 0 && _tokenType != JsonTokenType.None)
		{
			ThrowHelper.ThrowInvalidOperationException(ExceptionResource.CannotStartObjectArrayAfterPrimitiveOrClose, 0, _options.MaxDepth, 0, _tokenType);
		}
	}

	private void WriteStartIndented(byte P_0)
	{
		int indentation = Indentation;
		int num = indentation + 1;
		int num2 = num + 3;
		if (_memory.Length - BytesPending < num2)
		{
			Grow(num2);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.PropertyName)
		{
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
		}
		span[BytesPending++] = P_0;
	}

	public void WriteEndArray()
	{
		WriteEnd(93);
		_tokenType = JsonTokenType.EndArray;
	}

	public void WriteEndObject()
	{
		WriteEnd(125);
		_tokenType = JsonTokenType.EndObject;
	}

	private void WriteEnd(byte P_0)
	{
		if (_options.IndentedOrNotSkipValidation)
		{
			WriteEndSlow(P_0);
		}
		else
		{
			WriteEndMinimized(P_0);
		}
		SetFlagToAddListSeparatorBeforeNextItem();
		if (CurrentDepth != 0)
		{
			_currentDepth--;
		}
	}

	private void WriteEndMinimized(byte P_0)
	{
		if (_memory.Length - BytesPending < 1)
		{
			Grow(1);
		}
		_memory.Span[BytesPending++] = P_0;
	}

	private void WriteEndSlow(byte P_0)
	{
		if (_options.Indented)
		{
			if (!_options.SkipValidation)
			{
				ValidateEnd(P_0);
			}
			WriteEndIndented(P_0);
		}
		else
		{
			ValidateEnd(P_0);
			WriteEndMinimized(P_0);
		}
	}

	private void ValidateEnd(byte P_0)
	{
		if (_bitStack.CurrentDepth <= 0 || _tokenType == JsonTokenType.PropertyName)
		{
			ThrowHelper.ThrowInvalidOperationException(ExceptionResource.MismatchedObjectArray, 0, _options.MaxDepth, P_0, _tokenType);
		}
		if (P_0 == 93)
		{
			if (_inObject)
			{
				ThrowHelper.ThrowInvalidOperationException(ExceptionResource.MismatchedObjectArray, 0, _options.MaxDepth, P_0, _tokenType);
			}
		}
		else if (!_inObject)
		{
			ThrowHelper.ThrowInvalidOperationException(ExceptionResource.MismatchedObjectArray, 0, _options.MaxDepth, P_0, _tokenType);
		}
		_inObject = _bitStack.Pop();
	}

	private void WriteEndIndented(byte P_0)
	{
		if (_tokenType == JsonTokenType.StartObject || _tokenType == JsonTokenType.StartArray)
		{
			WriteEndMinimized(P_0);
			return;
		}
		int num = Indentation;
		if (num != 0)
		{
			num -= 2;
		}
		int num2 = num + 3;
		if (_memory.Length - BytesPending < num2)
		{
			Grow(num2);
		}
		Span<byte> span = _memory.Span;
		WriteNewLine(span);
		JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), num);
		BytesPending += num;
		span[BytesPending++] = P_0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void WriteNewLine(Span<byte> P_0)
	{
		if (s_newLineLength == 2)
		{
			P_0[BytesPending++] = 13;
		}
		P_0[BytesPending++] = 10;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void UpdateBitStackOnStart(byte P_0)
	{
		if (P_0 == 91)
		{
			_bitStack.PushFalse();
			_inObject = false;
		}
		else
		{
			_bitStack.PushTrue();
			_inObject = true;
		}
	}

	private void Grow(int P_0)
	{
		if (_memory.Length == 0)
		{
			FirstCallToGetMemory(P_0);
			return;
		}
		int num = Math.Max(4096, P_0);
		if (_stream != null)
		{
			int num2 = BytesPending + num;
			JsonHelpers.ValidateInt32MaxArrayLength((uint)num2);
			_memory = _arrayBufferWriter.GetMemory(num2);
			return;
		}
		_output.Advance(BytesPending);
		BytesCommitted += BytesPending;
		BytesPending = 0;
		_memory = _output.GetMemory(num);
		if (_memory.Length < num)
		{
			ThrowHelper.ThrowInvalidOperationException_NeedLargerSpan();
		}
	}

	private void FirstCallToGetMemory(int P_0)
	{
		int num = Math.Max(256, P_0);
		if (_stream != null)
		{
			_memory = _arrayBufferWriter.GetMemory(num);
			return;
		}
		_memory = _output.GetMemory(num);
		if (_memory.Length < num)
		{
			ThrowHelper.ThrowInvalidOperationException_NeedLargerSpan();
		}
	}

	private void SetFlagToAddListSeparatorBeforeNextItem()
	{
		_currentDepth |= -2147483648;
	}

	internal void WritePropertyName(DateTime P_0)
	{
		Span<byte> span = stackalloc byte[33];
		JsonWriterHelper.WriteDateTimeTrimmed(span, P_0, out var num);
		WritePropertyNameUnescaped(span.Slice(0, num));
	}

	internal void WritePropertyName(DateTimeOffset P_0)
	{
		Span<byte> span = stackalloc byte[33];
		JsonWriterHelper.WriteDateTimeOffsetTrimmed(span, P_0, out var num);
		WritePropertyNameUnescaped(span.Slice(0, num));
	}

	internal void WritePropertyName(decimal P_0)
	{
		Span<byte> span = stackalloc byte[31];
		int num;
		bool flag = Utf8Formatter.TryFormat(P_0, span, out num);
		WritePropertyNameUnescaped(span.Slice(0, num));
	}

	public void WriteNumber(string P_0, double P_1)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException("propertyName");
		}
		WriteNumber(P_0.AsSpan(), P_1);
	}

	public void WriteNumber(ReadOnlySpan<char> P_0, double P_1)
	{
		JsonWriterHelper.ValidateProperty(P_0);
		JsonWriterHelper.ValidateDouble(P_1);
		WriteNumberEscape(P_0, P_1);
		SetFlagToAddListSeparatorBeforeNextItem();
		_tokenType = JsonTokenType.Number;
	}

	private void WriteNumberEscape(ReadOnlySpan<char> P_0, double P_1)
	{
		int num = JsonWriterHelper.NeedsEscaping(P_0, _options.Encoder);
		if (num != -1)
		{
			WriteNumberEscapeProperty(P_0, P_1, num);
		}
		else
		{
			WriteNumberByOptions(P_0, P_1);
		}
	}

	private void WriteNumberEscapeProperty(ReadOnlySpan<char> P_0, double P_1, int P_2)
	{
		char[] array = null;
		int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(P_0.Length, P_2);
		Span<char> span = ((maxEscapedLength > 128) ? ((Span<char>)(array = ArrayPool<char>.Shared.Rent(maxEscapedLength))) : stackalloc char[128]);
		Span<char> span2 = span;
		JsonWriterHelper.EscapeString(P_0, span2, P_2, _options.Encoder, out var num);
		WriteNumberByOptions(span2.Slice(0, num), P_1);
		if (array != null)
		{
			ArrayPool<char>.Shared.Return(array);
		}
	}

	private void WriteNumberByOptions(ReadOnlySpan<char> P_0, double P_1)
	{
		ValidateWritingProperty();
		if (_options.Indented)
		{
			WriteNumberIndented(P_0, P_1);
		}
		else
		{
			WriteNumberMinimized(P_0, P_1);
		}
	}

	private void WriteNumberMinimized(ReadOnlySpan<char> P_0, double P_1)
	{
		int num = P_0.Length * 3 + 128 + 4;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		span[BytesPending++] = 34;
		TranscodeAndWrite(P_0, span);
		span[BytesPending++] = 34;
		span[BytesPending++] = 58;
		int num2;
		bool flag = TryFormatDouble(P_1, span.Slice(BytesPending), out num2);
		BytesPending += num2;
	}

	private void WriteNumberIndented(ReadOnlySpan<char> P_0, double P_1)
	{
		int indentation = Indentation;
		int num = indentation + P_0.Length * 3 + 128 + 5 + s_newLineLength;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.None)
		{
			WriteNewLine(span);
		}
		JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
		BytesPending += indentation;
		span[BytesPending++] = 34;
		TranscodeAndWrite(P_0, span);
		span[BytesPending++] = 34;
		span[BytesPending++] = 58;
		span[BytesPending++] = 32;
		int num2;
		bool flag = TryFormatDouble(P_1, span.Slice(BytesPending), out num2);
		BytesPending += num2;
	}

	internal void WritePropertyName(double P_0)
	{
		JsonWriterHelper.ValidateDouble(P_0);
		Span<byte> span = stackalloc byte[128];
		int num;
		bool flag = TryFormatDouble(P_0, span, out num);
		WritePropertyNameUnescaped(span.Slice(0, num));
	}

	public void WriteNumber(string P_0, float P_1)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException("propertyName");
		}
		WriteNumber(P_0.AsSpan(), P_1);
	}

	public void WriteNumber(ReadOnlySpan<char> P_0, float P_1)
	{
		JsonWriterHelper.ValidateProperty(P_0);
		JsonWriterHelper.ValidateSingle(P_1);
		WriteNumberEscape(P_0, P_1);
		SetFlagToAddListSeparatorBeforeNextItem();
		_tokenType = JsonTokenType.Number;
	}

	private void WriteNumberEscape(ReadOnlySpan<char> P_0, float P_1)
	{
		int num = JsonWriterHelper.NeedsEscaping(P_0, _options.Encoder);
		if (num != -1)
		{
			WriteNumberEscapeProperty(P_0, P_1, num);
		}
		else
		{
			WriteNumberByOptions(P_0, P_1);
		}
	}

	private void WriteNumberEscapeProperty(ReadOnlySpan<char> P_0, float P_1, int P_2)
	{
		char[] array = null;
		int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(P_0.Length, P_2);
		Span<char> span = ((maxEscapedLength > 128) ? ((Span<char>)(array = ArrayPool<char>.Shared.Rent(maxEscapedLength))) : stackalloc char[128]);
		Span<char> span2 = span;
		JsonWriterHelper.EscapeString(P_0, span2, P_2, _options.Encoder, out var num);
		WriteNumberByOptions(span2.Slice(0, num), P_1);
		if (array != null)
		{
			ArrayPool<char>.Shared.Return(array);
		}
	}

	private void WriteNumberByOptions(ReadOnlySpan<char> P_0, float P_1)
	{
		ValidateWritingProperty();
		if (_options.Indented)
		{
			WriteNumberIndented(P_0, P_1);
		}
		else
		{
			WriteNumberMinimized(P_0, P_1);
		}
	}

	private void WriteNumberMinimized(ReadOnlySpan<char> P_0, float P_1)
	{
		int num = P_0.Length * 3 + 128 + 4;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		span[BytesPending++] = 34;
		TranscodeAndWrite(P_0, span);
		span[BytesPending++] = 34;
		span[BytesPending++] = 58;
		int num2;
		bool flag = TryFormatSingle(P_1, span.Slice(BytesPending), out num2);
		BytesPending += num2;
	}

	private void WriteNumberIndented(ReadOnlySpan<char> P_0, float P_1)
	{
		int indentation = Indentation;
		int num = indentation + P_0.Length * 3 + 128 + 5 + s_newLineLength;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.None)
		{
			WriteNewLine(span);
		}
		JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
		BytesPending += indentation;
		span[BytesPending++] = 34;
		TranscodeAndWrite(P_0, span);
		span[BytesPending++] = 34;
		span[BytesPending++] = 58;
		span[BytesPending++] = 32;
		int num2;
		bool flag = TryFormatSingle(P_1, span.Slice(BytesPending), out num2);
		BytesPending += num2;
	}

	internal void WritePropertyName(float P_0)
	{
		Span<byte> span = stackalloc byte[128];
		int num;
		bool flag = TryFormatSingle(P_0, span, out num);
		WritePropertyNameUnescaped(span.Slice(0, num));
	}

	internal void WritePropertyName(Guid P_0)
	{
		Span<byte> span = stackalloc byte[36];
		int num;
		bool flag = Utf8Formatter.TryFormat(P_0, span, out num);
		WritePropertyNameUnescaped(span.Slice(0, num));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void ValidateWritingProperty()
	{
		if (!_options.SkipValidation && (!_inObject || _tokenType == JsonTokenType.PropertyName))
		{
			ThrowHelper.ThrowInvalidOperationException(ExceptionResource.CannotWritePropertyWithinArray, 0, _options.MaxDepth, 0, _tokenType);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void TranscodeAndWrite(ReadOnlySpan<char> P_0, Span<byte> P_1)
	{
		ReadOnlySpan<byte> readOnlySpan = MemoryMarshal.AsBytes(P_0);
		int num;
		int num2;
		OperationStatus operationStatus = JsonWriterHelper.ToUtf8(readOnlySpan, P_1.Slice(BytesPending), out num, out num2);
		BytesPending += num2;
	}

	public void WriteNull(JsonEncodedText P_0)
	{
		WriteLiteralHelper(P_0.EncodedUtf8Bytes, JsonConstants.NullValue);
		_tokenType = JsonTokenType.Null;
	}

	internal void WriteNullSection(ReadOnlySpan<byte> P_0)
	{
		if (_options.Indented)
		{
			ReadOnlySpan<byte> readOnlySpan = P_0.Slice(1, P_0.Length - 3);
			WriteLiteralHelper(readOnlySpan, JsonConstants.NullValue);
			_tokenType = JsonTokenType.Null;
		}
		else
		{
			ReadOnlySpan<byte> nullValue = JsonConstants.NullValue;
			WriteLiteralSection(P_0, nullValue);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.Null;
		}
	}

	private void WriteLiteralHelper(ReadOnlySpan<byte> P_0, ReadOnlySpan<byte> P_1)
	{
		WriteLiteralByOptions(P_0, P_1);
		SetFlagToAddListSeparatorBeforeNextItem();
	}

	public void WriteNull(ReadOnlySpan<char> P_0)
	{
		JsonWriterHelper.ValidateProperty(P_0);
		ReadOnlySpan<byte> nullValue = JsonConstants.NullValue;
		WriteLiteralEscape(P_0, nullValue);
		SetFlagToAddListSeparatorBeforeNextItem();
		_tokenType = JsonTokenType.Null;
	}

	public void WriteBoolean(string P_0, bool P_1)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException("propertyName");
		}
		WriteBoolean(P_0.AsSpan(), P_1);
	}

	public void WriteBoolean(ReadOnlySpan<char> P_0, bool P_1)
	{
		JsonWriterHelper.ValidateProperty(P_0);
		ReadOnlySpan<byte> readOnlySpan = (P_1 ? JsonConstants.TrueValue : JsonConstants.FalseValue);
		WriteLiteralEscape(P_0, readOnlySpan);
		SetFlagToAddListSeparatorBeforeNextItem();
		_tokenType = (P_1 ? JsonTokenType.True : JsonTokenType.False);
	}

	private void WriteLiteralEscape(ReadOnlySpan<char> P_0, ReadOnlySpan<byte> P_1)
	{
		int num = JsonWriterHelper.NeedsEscaping(P_0, _options.Encoder);
		if (num != -1)
		{
			WriteLiteralEscapeProperty(P_0, P_1, num);
		}
		else
		{
			WriteLiteralByOptions(P_0, P_1);
		}
	}

	private void WriteLiteralEscapeProperty(ReadOnlySpan<char> P_0, ReadOnlySpan<byte> P_1, int P_2)
	{
		char[] array = null;
		int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(P_0.Length, P_2);
		Span<char> span = ((maxEscapedLength > 128) ? ((Span<char>)(array = ArrayPool<char>.Shared.Rent(maxEscapedLength))) : stackalloc char[128]);
		Span<char> span2 = span;
		JsonWriterHelper.EscapeString(P_0, span2, P_2, _options.Encoder, out var num);
		WriteLiteralByOptions(span2.Slice(0, num), P_1);
		if (array != null)
		{
			ArrayPool<char>.Shared.Return(array);
		}
	}

	private void WriteLiteralByOptions(ReadOnlySpan<char> P_0, ReadOnlySpan<byte> P_1)
	{
		ValidateWritingProperty();
		if (_options.Indented)
		{
			WriteLiteralIndented(P_0, P_1);
		}
		else
		{
			WriteLiteralMinimized(P_0, P_1);
		}
	}

	private void WriteLiteralByOptions(ReadOnlySpan<byte> P_0, ReadOnlySpan<byte> P_1)
	{
		ValidateWritingProperty();
		if (_options.Indented)
		{
			WriteLiteralIndented(P_0, P_1);
		}
		else
		{
			WriteLiteralMinimized(P_0, P_1);
		}
	}

	private void WriteLiteralMinimized(ReadOnlySpan<char> P_0, ReadOnlySpan<byte> P_1)
	{
		int num = P_0.Length * 3 + P_1.Length + 4;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		span[BytesPending++] = 34;
		TranscodeAndWrite(P_0, span);
		span[BytesPending++] = 34;
		span[BytesPending++] = 58;
		P_1.CopyTo(span.Slice(BytesPending));
		BytesPending += P_1.Length;
	}

	private void WriteLiteralMinimized(ReadOnlySpan<byte> P_0, ReadOnlySpan<byte> P_1)
	{
		int num = P_0.Length + P_1.Length + 3;
		int num2 = num + 1;
		if (_memory.Length - BytesPending < num2)
		{
			Grow(num2);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		span[BytesPending++] = 34;
		P_0.CopyTo(span.Slice(BytesPending));
		BytesPending += P_0.Length;
		span[BytesPending++] = 34;
		span[BytesPending++] = 58;
		P_1.CopyTo(span.Slice(BytesPending));
		BytesPending += P_1.Length;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void WriteLiteralSection(ReadOnlySpan<byte> P_0, ReadOnlySpan<byte> P_1)
	{
		int num = P_0.Length + P_1.Length;
		int num2 = num + 1;
		if (_memory.Length - BytesPending < num2)
		{
			Grow(num2);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		P_0.CopyTo(span.Slice(BytesPending));
		BytesPending += P_0.Length;
		P_1.CopyTo(span.Slice(BytesPending));
		BytesPending += P_1.Length;
	}

	private void WriteLiteralIndented(ReadOnlySpan<char> P_0, ReadOnlySpan<byte> P_1)
	{
		int indentation = Indentation;
		int num = indentation + P_0.Length * 3 + P_1.Length + 5 + s_newLineLength;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.None)
		{
			WriteNewLine(span);
		}
		JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
		BytesPending += indentation;
		span[BytesPending++] = 34;
		TranscodeAndWrite(P_0, span);
		span[BytesPending++] = 34;
		span[BytesPending++] = 58;
		span[BytesPending++] = 32;
		P_1.CopyTo(span.Slice(BytesPending));
		BytesPending += P_1.Length;
	}

	private void WriteLiteralIndented(ReadOnlySpan<byte> P_0, ReadOnlySpan<byte> P_1)
	{
		int indentation = Indentation;
		int num = indentation + P_0.Length + P_1.Length + 4;
		int num2 = num + 1 + s_newLineLength;
		if (_memory.Length - BytesPending < num2)
		{
			Grow(num2);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.None)
		{
			WriteNewLine(span);
		}
		JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
		BytesPending += indentation;
		span[BytesPending++] = 34;
		P_0.CopyTo(span.Slice(BytesPending));
		BytesPending += P_0.Length;
		span[BytesPending++] = 34;
		span[BytesPending++] = 58;
		span[BytesPending++] = 32;
		P_1.CopyTo(span.Slice(BytesPending));
		BytesPending += P_1.Length;
	}

	internal void WritePropertyName(bool P_0)
	{
		Span<byte> span = stackalloc byte[5];
		int num;
		bool flag = Utf8Formatter.TryFormat(P_0, span, out num);
		WritePropertyNameUnescaped(span.Slice(0, num));
	}

	public void WriteNumber(JsonEncodedText P_0, long P_1)
	{
		ReadOnlySpan<byte> encodedUtf8Bytes = P_0.EncodedUtf8Bytes;
		WriteNumberByOptions(encodedUtf8Bytes, P_1);
		SetFlagToAddListSeparatorBeforeNextItem();
		_tokenType = JsonTokenType.Number;
	}

	public void WriteNumber(ReadOnlySpan<char> P_0, long P_1)
	{
		JsonWriterHelper.ValidateProperty(P_0);
		WriteNumberEscape(P_0, P_1);
		SetFlagToAddListSeparatorBeforeNextItem();
		_tokenType = JsonTokenType.Number;
	}

	public void WriteNumber(JsonEncodedText P_0, int P_1)
	{
		WriteNumber(P_0, (long)P_1);
	}

	public void WriteNumber(string P_0, int P_1)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException("propertyName");
		}
		WriteNumber(P_0.AsSpan(), P_1);
	}

	private void WriteNumberEscape(ReadOnlySpan<char> P_0, long P_1)
	{
		int num = JsonWriterHelper.NeedsEscaping(P_0, _options.Encoder);
		if (num != -1)
		{
			WriteNumberEscapeProperty(P_0, P_1, num);
		}
		else
		{
			WriteNumberByOptions(P_0, P_1);
		}
	}

	private void WriteNumberEscapeProperty(ReadOnlySpan<char> P_0, long P_1, int P_2)
	{
		char[] array = null;
		int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(P_0.Length, P_2);
		Span<char> span = ((maxEscapedLength > 128) ? ((Span<char>)(array = ArrayPool<char>.Shared.Rent(maxEscapedLength))) : stackalloc char[128]);
		Span<char> span2 = span;
		JsonWriterHelper.EscapeString(P_0, span2, P_2, _options.Encoder, out var num);
		WriteNumberByOptions(span2.Slice(0, num), P_1);
		if (array != null)
		{
			ArrayPool<char>.Shared.Return(array);
		}
	}

	private void WriteNumberByOptions(ReadOnlySpan<char> P_0, long P_1)
	{
		ValidateWritingProperty();
		if (_options.Indented)
		{
			WriteNumberIndented(P_0, P_1);
		}
		else
		{
			WriteNumberMinimized(P_0, P_1);
		}
	}

	private void WriteNumberByOptions(ReadOnlySpan<byte> P_0, long P_1)
	{
		ValidateWritingProperty();
		if (_options.Indented)
		{
			WriteNumberIndented(P_0, P_1);
		}
		else
		{
			WriteNumberMinimized(P_0, P_1);
		}
	}

	private void WriteNumberMinimized(ReadOnlySpan<char> P_0, long P_1)
	{
		int num = P_0.Length * 3 + 20 + 4;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		span[BytesPending++] = 34;
		TranscodeAndWrite(P_0, span);
		span[BytesPending++] = 34;
		span[BytesPending++] = 58;
		int num2;
		bool flag = Utf8Formatter.TryFormat(P_1, span.Slice(BytesPending), out num2);
		BytesPending += num2;
	}

	private void WriteNumberMinimized(ReadOnlySpan<byte> P_0, long P_1)
	{
		int num = P_0.Length + 20 + 3;
		int num2 = num + 1;
		if (_memory.Length - BytesPending < num2)
		{
			Grow(num2);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		span[BytesPending++] = 34;
		P_0.CopyTo(span.Slice(BytesPending));
		BytesPending += P_0.Length;
		span[BytesPending++] = 34;
		span[BytesPending++] = 58;
		int num3;
		bool flag = Utf8Formatter.TryFormat(P_1, span.Slice(BytesPending), out num3);
		BytesPending += num3;
	}

	private void WriteNumberIndented(ReadOnlySpan<char> P_0, long P_1)
	{
		int indentation = Indentation;
		int num = indentation + P_0.Length * 3 + 20 + 5 + s_newLineLength;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.None)
		{
			WriteNewLine(span);
		}
		JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
		BytesPending += indentation;
		span[BytesPending++] = 34;
		TranscodeAndWrite(P_0, span);
		span[BytesPending++] = 34;
		span[BytesPending++] = 58;
		span[BytesPending++] = 32;
		int num2;
		bool flag = Utf8Formatter.TryFormat(P_1, span.Slice(BytesPending), out num2);
		BytesPending += num2;
	}

	private void WriteNumberIndented(ReadOnlySpan<byte> P_0, long P_1)
	{
		int indentation = Indentation;
		int num = indentation + P_0.Length + 20 + 4;
		int num2 = num + 1 + s_newLineLength;
		if (_memory.Length - BytesPending < num2)
		{
			Grow(num2);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.None)
		{
			WriteNewLine(span);
		}
		JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
		BytesPending += indentation;
		span[BytesPending++] = 34;
		P_0.CopyTo(span.Slice(BytesPending));
		BytesPending += P_0.Length;
		span[BytesPending++] = 34;
		span[BytesPending++] = 58;
		span[BytesPending++] = 32;
		int num3;
		bool flag = Utf8Formatter.TryFormat(P_1, span.Slice(BytesPending), out num3);
		BytesPending += num3;
	}

	internal void WritePropertyName(int P_0)
	{
		WritePropertyName((long)P_0);
	}

	internal void WritePropertyName(long P_0)
	{
		Span<byte> span = stackalloc byte[20];
		int num;
		bool flag = Utf8Formatter.TryFormat(P_0, span, out num);
		WritePropertyNameUnescaped(span.Slice(0, num));
	}

	public void WritePropertyName(JsonEncodedText P_0)
	{
		WritePropertyNameHelper(P_0.EncodedUtf8Bytes);
	}

	internal void WritePropertyNameSection(ReadOnlySpan<byte> P_0)
	{
		if (_options.Indented)
		{
			ReadOnlySpan<byte> readOnlySpan = P_0.Slice(1, P_0.Length - 3);
			WritePropertyNameHelper(readOnlySpan);
		}
		else
		{
			WriteStringPropertyNameSection(P_0);
			_currentDepth &= 2147483647;
			_tokenType = JsonTokenType.PropertyName;
		}
	}

	private void WritePropertyNameHelper(ReadOnlySpan<byte> P_0)
	{
		WriteStringByOptionsPropertyName(P_0);
		_currentDepth &= 2147483647;
		_tokenType = JsonTokenType.PropertyName;
	}

	public void WritePropertyName(string P_0)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException("propertyName");
		}
		WritePropertyName(P_0.AsSpan());
	}

	public void WritePropertyName(ReadOnlySpan<char> P_0)
	{
		JsonWriterHelper.ValidateProperty(P_0);
		int num = JsonWriterHelper.NeedsEscaping(P_0, _options.Encoder);
		if (num != -1)
		{
			WriteStringEscapeProperty(P_0, num);
		}
		else
		{
			WriteStringByOptionsPropertyName(P_0);
		}
		_currentDepth &= 2147483647;
		_tokenType = JsonTokenType.PropertyName;
	}

	private void WriteStringEscapeProperty(scoped ReadOnlySpan<char> P_0, int P_1)
	{
		char[] array = null;
		if (P_1 != -1)
		{
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(P_0.Length, P_1);
			Span<char> span;
			if (maxEscapedLength > 128)
			{
				array = ArrayPool<char>.Shared.Rent(maxEscapedLength);
				span = array;
			}
			else
			{
				span = stackalloc char[128];
			}
			JsonWriterHelper.EscapeString(P_0, span, P_1, _options.Encoder, out var num);
			P_0 = span.Slice(0, num);
		}
		WriteStringByOptionsPropertyName(P_0);
		if (array != null)
		{
			ArrayPool<char>.Shared.Return(array);
		}
	}

	private void WriteStringByOptionsPropertyName(ReadOnlySpan<char> P_0)
	{
		ValidateWritingProperty();
		if (_options.Indented)
		{
			WriteStringIndentedPropertyName(P_0);
		}
		else
		{
			WriteStringMinimizedPropertyName(P_0);
		}
	}

	private void WriteStringMinimizedPropertyName(ReadOnlySpan<char> P_0)
	{
		int num = P_0.Length * 3 + 4;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		span[BytesPending++] = 34;
		TranscodeAndWrite(P_0, span);
		span[BytesPending++] = 34;
		span[BytesPending++] = 58;
	}

	private void WriteStringIndentedPropertyName(ReadOnlySpan<char> P_0)
	{
		int indentation = Indentation;
		int num = indentation + P_0.Length * 3 + 5 + s_newLineLength;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.None)
		{
			WriteNewLine(span);
		}
		JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
		BytesPending += indentation;
		span[BytesPending++] = 34;
		TranscodeAndWrite(P_0, span);
		span[BytesPending++] = 34;
		span[BytesPending++] = 58;
		span[BytesPending++] = 32;
	}

	public void WritePropertyName(ReadOnlySpan<byte> P_0)
	{
		JsonWriterHelper.ValidateProperty(P_0);
		int num = JsonWriterHelper.NeedsEscaping(P_0, _options.Encoder);
		if (num != -1)
		{
			WriteStringEscapeProperty(P_0, num);
		}
		else
		{
			WriteStringByOptionsPropertyName(P_0);
		}
		_currentDepth &= 2147483647;
		_tokenType = JsonTokenType.PropertyName;
	}

	private void WritePropertyNameUnescaped(ReadOnlySpan<byte> P_0)
	{
		JsonWriterHelper.ValidateProperty(P_0);
		WriteStringByOptionsPropertyName(P_0);
		_currentDepth &= 2147483647;
		_tokenType = JsonTokenType.PropertyName;
	}

	private void WriteStringEscapeProperty(scoped ReadOnlySpan<byte> P_0, int P_1)
	{
		byte[] array = null;
		if (P_1 != -1)
		{
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(P_0.Length, P_1);
			Span<byte> span;
			if (maxEscapedLength > 256)
			{
				array = ArrayPool<byte>.Shared.Rent(maxEscapedLength);
				span = array;
			}
			else
			{
				span = stackalloc byte[256];
			}
			JsonWriterHelper.EscapeString(P_0, span, P_1, _options.Encoder, out var num);
			P_0 = span.Slice(0, num);
		}
		WriteStringByOptionsPropertyName(P_0);
		if (array != null)
		{
			ArrayPool<byte>.Shared.Return(array);
		}
	}

	private void WriteStringByOptionsPropertyName(ReadOnlySpan<byte> P_0)
	{
		ValidateWritingProperty();
		if (_options.Indented)
		{
			WriteStringIndentedPropertyName(P_0);
		}
		else
		{
			WriteStringMinimizedPropertyName(P_0);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void WriteStringMinimizedPropertyName(ReadOnlySpan<byte> P_0)
	{
		int num = P_0.Length + 3;
		int num2 = num + 1;
		if (_memory.Length - BytesPending < num2)
		{
			Grow(num2);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		span[BytesPending++] = 34;
		P_0.CopyTo(span.Slice(BytesPending));
		BytesPending += P_0.Length;
		span[BytesPending++] = 34;
		span[BytesPending++] = 58;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void WriteStringPropertyNameSection(ReadOnlySpan<byte> P_0)
	{
		int num = P_0.Length + 1;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		P_0.CopyTo(span.Slice(BytesPending));
		BytesPending += P_0.Length;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void WriteStringIndentedPropertyName(ReadOnlySpan<byte> P_0)
	{
		int indentation = Indentation;
		int num = indentation + P_0.Length + 4;
		int num2 = num + 1 + s_newLineLength;
		if (_memory.Length - BytesPending < num2)
		{
			Grow(num2);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.None)
		{
			WriteNewLine(span);
		}
		JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
		BytesPending += indentation;
		span[BytesPending++] = 34;
		P_0.CopyTo(span.Slice(BytesPending));
		BytesPending += P_0.Length;
		span[BytesPending++] = 34;
		span[BytesPending++] = 58;
		span[BytesPending++] = 32;
	}

	public void WriteString(string P_0, string? P_1)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException("propertyName");
		}
		if (P_1 == null)
		{
			WriteNull(P_0.AsSpan());
		}
		else
		{
			WriteString(P_0.AsSpan(), P_1.AsSpan());
		}
	}

	public void WriteString(ReadOnlySpan<char> P_0, ReadOnlySpan<char> P_1)
	{
		JsonWriterHelper.ValidatePropertyAndValue(P_0, P_1);
		WriteStringEscape(P_0, P_1);
		SetFlagToAddListSeparatorBeforeNextItem();
		_tokenType = JsonTokenType.String;
	}

	public void WriteString(JsonEncodedText P_0, string? P_1)
	{
		if (P_1 == null)
		{
			WriteNull(P_0);
		}
		else
		{
			WriteString(P_0, P_1.AsSpan());
		}
	}

	public void WriteString(JsonEncodedText P_0, ReadOnlySpan<char> P_1)
	{
		WriteStringHelperEscapeValue(P_0.EncodedUtf8Bytes, P_1);
	}

	private void WriteStringHelperEscapeValue(ReadOnlySpan<byte> P_0, ReadOnlySpan<char> P_1)
	{
		JsonWriterHelper.ValidateValue(P_1);
		int num = JsonWriterHelper.NeedsEscaping(P_1, _options.Encoder);
		if (num != -1)
		{
			WriteStringEscapeValueOnly(P_0, P_1, num);
		}
		else
		{
			WriteStringByOptions(P_0, P_1);
		}
		SetFlagToAddListSeparatorBeforeNextItem();
		_tokenType = JsonTokenType.String;
	}

	private void WriteStringEscapeValueOnly(ReadOnlySpan<byte> P_0, ReadOnlySpan<char> P_1, int P_2)
	{
		char[] array = null;
		int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(P_1.Length, P_2);
		Span<char> span = ((maxEscapedLength > 128) ? ((Span<char>)(array = ArrayPool<char>.Shared.Rent(maxEscapedLength))) : stackalloc char[128]);
		Span<char> span2 = span;
		JsonWriterHelper.EscapeString(P_1, span2, P_2, _options.Encoder, out var num);
		WriteStringByOptions(P_0, span2.Slice(0, num));
		if (array != null)
		{
			ArrayPool<char>.Shared.Return(array);
		}
	}

	private void WriteStringEscape(ReadOnlySpan<char> P_0, ReadOnlySpan<char> P_1)
	{
		int num = JsonWriterHelper.NeedsEscaping(P_1, _options.Encoder);
		int num2 = JsonWriterHelper.NeedsEscaping(P_0, _options.Encoder);
		if (num + num2 != -2)
		{
			WriteStringEscapePropertyOrValue(P_0, P_1, num2, num);
		}
		else
		{
			WriteStringByOptions(P_0, P_1);
		}
	}

	private void WriteStringEscapePropertyOrValue(scoped ReadOnlySpan<char> P_0, scoped ReadOnlySpan<char> P_1, int P_2, int P_3)
	{
		char[] array = null;
		char[] array2 = null;
		if (P_3 != -1)
		{
			int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(P_1.Length, P_3);
			Span<char> span;
			if (maxEscapedLength > 128)
			{
				array = ArrayPool<char>.Shared.Rent(maxEscapedLength);
				span = array;
			}
			else
			{
				span = stackalloc char[128];
			}
			JsonWriterHelper.EscapeString(P_1, span, P_3, _options.Encoder, out var num);
			P_1 = span.Slice(0, num);
		}
		if (P_2 != -1)
		{
			int maxEscapedLength2 = JsonWriterHelper.GetMaxEscapedLength(P_0.Length, P_2);
			Span<char> span2;
			if (maxEscapedLength2 > 128)
			{
				array2 = ArrayPool<char>.Shared.Rent(maxEscapedLength2);
				span2 = array2;
			}
			else
			{
				span2 = stackalloc char[128];
			}
			JsonWriterHelper.EscapeString(P_0, span2, P_2, _options.Encoder, out var num2);
			P_0 = span2.Slice(0, num2);
		}
		WriteStringByOptions(P_0, P_1);
		if (array != null)
		{
			ArrayPool<char>.Shared.Return(array);
		}
		if (array2 != null)
		{
			ArrayPool<char>.Shared.Return(array2);
		}
	}

	private void WriteStringByOptions(ReadOnlySpan<char> P_0, ReadOnlySpan<char> P_1)
	{
		ValidateWritingProperty();
		if (_options.Indented)
		{
			WriteStringIndented(P_0, P_1);
		}
		else
		{
			WriteStringMinimized(P_0, P_1);
		}
	}

	private void WriteStringByOptions(ReadOnlySpan<byte> P_0, ReadOnlySpan<char> P_1)
	{
		ValidateWritingProperty();
		if (_options.Indented)
		{
			WriteStringIndented(P_0, P_1);
		}
		else
		{
			WriteStringMinimized(P_0, P_1);
		}
	}

	private void WriteStringMinimized(ReadOnlySpan<char> P_0, ReadOnlySpan<char> P_1)
	{
		int num = (P_0.Length + P_1.Length) * 3 + 6;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		span[BytesPending++] = 34;
		TranscodeAndWrite(P_0, span);
		span[BytesPending++] = 34;
		span[BytesPending++] = 58;
		span[BytesPending++] = 34;
		TranscodeAndWrite(P_1, span);
		span[BytesPending++] = 34;
	}

	private void WriteStringMinimized(ReadOnlySpan<byte> P_0, ReadOnlySpan<char> P_1)
	{
		int num = P_1.Length * 3 + P_0.Length + 6;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		span[BytesPending++] = 34;
		P_0.CopyTo(span.Slice(BytesPending));
		BytesPending += P_0.Length;
		span[BytesPending++] = 34;
		span[BytesPending++] = 58;
		span[BytesPending++] = 34;
		TranscodeAndWrite(P_1, span);
		span[BytesPending++] = 34;
	}

	private void WriteStringIndented(ReadOnlySpan<char> P_0, ReadOnlySpan<char> P_1)
	{
		int indentation = Indentation;
		int num = indentation + (P_0.Length + P_1.Length) * 3 + 7 + s_newLineLength;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.None)
		{
			WriteNewLine(span);
		}
		JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
		BytesPending += indentation;
		span[BytesPending++] = 34;
		TranscodeAndWrite(P_0, span);
		span[BytesPending++] = 34;
		span[BytesPending++] = 58;
		span[BytesPending++] = 32;
		span[BytesPending++] = 34;
		TranscodeAndWrite(P_1, span);
		span[BytesPending++] = 34;
	}

	private void WriteStringIndented(ReadOnlySpan<byte> P_0, ReadOnlySpan<char> P_1)
	{
		int indentation = Indentation;
		int num = indentation + P_1.Length * 3 + P_0.Length + 7 + s_newLineLength;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.None)
		{
			WriteNewLine(span);
		}
		JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
		BytesPending += indentation;
		span[BytesPending++] = 34;
		P_0.CopyTo(span.Slice(BytesPending));
		BytesPending += P_0.Length;
		span[BytesPending++] = 34;
		span[BytesPending++] = 58;
		span[BytesPending++] = 32;
		span[BytesPending++] = 34;
		TranscodeAndWrite(P_1, span);
		span[BytesPending++] = 34;
	}

	internal void WritePropertyName(uint P_0)
	{
		WritePropertyName((ulong)P_0);
	}

	internal void WritePropertyName(ulong P_0)
	{
		Span<byte> span = stackalloc byte[20];
		int num;
		bool flag = Utf8Formatter.TryFormat(P_0, span, out num);
		WritePropertyNameUnescaped(span.Slice(0, num));
	}

	public void WriteBase64StringValue(ReadOnlySpan<byte> P_0)
	{
		JsonWriterHelper.ValidateBytes(P_0);
		WriteBase64ByOptions(P_0);
		SetFlagToAddListSeparatorBeforeNextItem();
		_tokenType = JsonTokenType.String;
	}

	private void WriteBase64ByOptions(ReadOnlySpan<byte> P_0)
	{
		if (!_options.SkipValidation)
		{
			ValidateWritingValue();
		}
		if (_options.Indented)
		{
			WriteBase64Indented(P_0);
		}
		else
		{
			WriteBase64Minimized(P_0);
		}
	}

	private void WriteBase64Minimized(ReadOnlySpan<byte> P_0)
	{
		int maxEncodedToUtf8Length = Base64.GetMaxEncodedToUtf8Length(P_0.Length);
		int num = maxEncodedToUtf8Length + 3;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		span[BytesPending++] = 34;
		Base64EncodeAndWrite(P_0, span, maxEncodedToUtf8Length);
		span[BytesPending++] = 34;
	}

	private void WriteBase64Indented(ReadOnlySpan<byte> P_0)
	{
		int indentation = Indentation;
		int maxEncodedToUtf8Length = Base64.GetMaxEncodedToUtf8Length(P_0.Length);
		int num = indentation + maxEncodedToUtf8Length + 3 + s_newLineLength;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.PropertyName)
		{
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
		}
		span[BytesPending++] = 34;
		Base64EncodeAndWrite(P_0, span, maxEncodedToUtf8Length);
		span[BytesPending++] = 34;
	}

	public void WriteStringValue(DateTime P_0)
	{
		if (!_options.SkipValidation)
		{
			ValidateWritingValue();
		}
		if (_options.Indented)
		{
			WriteStringValueIndented(P_0);
		}
		else
		{
			WriteStringValueMinimized(P_0);
		}
		SetFlagToAddListSeparatorBeforeNextItem();
		_tokenType = JsonTokenType.String;
	}

	private void WriteStringValueMinimized(DateTime P_0)
	{
		int num = 36;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		span[BytesPending++] = 34;
		JsonWriterHelper.WriteDateTimeTrimmed(span.Slice(BytesPending), P_0, out var num2);
		BytesPending += num2;
		span[BytesPending++] = 34;
	}

	private void WriteStringValueIndented(DateTime P_0)
	{
		int indentation = Indentation;
		int num = indentation + 33 + 3 + s_newLineLength;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.PropertyName)
		{
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
		}
		span[BytesPending++] = 34;
		JsonWriterHelper.WriteDateTimeTrimmed(span.Slice(BytesPending), P_0, out var num2);
		BytesPending += num2;
		span[BytesPending++] = 34;
	}

	public void WriteStringValue(DateTimeOffset P_0)
	{
		if (!_options.SkipValidation)
		{
			ValidateWritingValue();
		}
		if (_options.Indented)
		{
			WriteStringValueIndented(P_0);
		}
		else
		{
			WriteStringValueMinimized(P_0);
		}
		SetFlagToAddListSeparatorBeforeNextItem();
		_tokenType = JsonTokenType.String;
	}

	private void WriteStringValueMinimized(DateTimeOffset P_0)
	{
		int num = 36;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		span[BytesPending++] = 34;
		JsonWriterHelper.WriteDateTimeOffsetTrimmed(span.Slice(BytesPending), P_0, out var num2);
		BytesPending += num2;
		span[BytesPending++] = 34;
	}

	private void WriteStringValueIndented(DateTimeOffset P_0)
	{
		int indentation = Indentation;
		int num = indentation + 33 + 3 + s_newLineLength;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.PropertyName)
		{
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
		}
		span[BytesPending++] = 34;
		JsonWriterHelper.WriteDateTimeOffsetTrimmed(span.Slice(BytesPending), P_0, out var num2);
		BytesPending += num2;
		span[BytesPending++] = 34;
	}

	public void WriteNumberValue(decimal P_0)
	{
		if (!_options.SkipValidation)
		{
			ValidateWritingValue();
		}
		if (_options.Indented)
		{
			WriteNumberValueIndented(P_0);
		}
		else
		{
			WriteNumberValueMinimized(P_0);
		}
		SetFlagToAddListSeparatorBeforeNextItem();
		_tokenType = JsonTokenType.Number;
	}

	private void WriteNumberValueMinimized(decimal P_0)
	{
		int num = 32;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		int num2;
		bool flag = Utf8Formatter.TryFormat(P_0, span.Slice(BytesPending), out num2);
		BytesPending += num2;
	}

	private void WriteNumberValueIndented(decimal P_0)
	{
		int indentation = Indentation;
		int num = indentation + 31 + 1 + s_newLineLength;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.PropertyName)
		{
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
		}
		int num2;
		bool flag = Utf8Formatter.TryFormat(P_0, span.Slice(BytesPending), out num2);
		BytesPending += num2;
	}

	internal void WriteNumberValueAsString(decimal P_0)
	{
		Span<byte> span = stackalloc byte[31];
		int num;
		bool flag = Utf8Formatter.TryFormat(P_0, span, out num);
		WriteNumberValueAsStringUnescaped(span.Slice(0, num));
	}

	public void WriteNumberValue(double P_0)
	{
		JsonWriterHelper.ValidateDouble(P_0);
		if (!_options.SkipValidation)
		{
			ValidateWritingValue();
		}
		if (_options.Indented)
		{
			WriteNumberValueIndented(P_0);
		}
		else
		{
			WriteNumberValueMinimized(P_0);
		}
		SetFlagToAddListSeparatorBeforeNextItem();
		_tokenType = JsonTokenType.Number;
	}

	private void WriteNumberValueMinimized(double P_0)
	{
		int num = 129;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		int num2;
		bool flag = TryFormatDouble(P_0, span.Slice(BytesPending), out num2);
		BytesPending += num2;
	}

	private void WriteNumberValueIndented(double P_0)
	{
		int indentation = Indentation;
		int num = indentation + 128 + 1 + s_newLineLength;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.PropertyName)
		{
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
		}
		int num2;
		bool flag = TryFormatDouble(P_0, span.Slice(BytesPending), out num2);
		BytesPending += num2;
	}

	private static bool TryFormatDouble(double P_0, Span<byte> P_1, out int P_2)
	{
		return Utf8Formatter.TryFormat(P_0, P_1, out P_2);
	}

	internal void WriteNumberValueAsString(double P_0)
	{
		Span<byte> span = stackalloc byte[128];
		int num;
		bool flag = TryFormatDouble(P_0, span, out num);
		WriteNumberValueAsStringUnescaped(span.Slice(0, num));
	}

	internal void WriteFloatingPointConstant(double P_0)
	{
		if (double.IsNaN(P_0))
		{
			WriteNumberValueAsStringUnescaped(JsonConstants.NaNValue);
		}
		else if (double.IsPositiveInfinity(P_0))
		{
			WriteNumberValueAsStringUnescaped(JsonConstants.PositiveInfinityValue);
		}
		else if (double.IsNegativeInfinity(P_0))
		{
			WriteNumberValueAsStringUnescaped(JsonConstants.NegativeInfinityValue);
		}
		else
		{
			WriteNumberValue(P_0);
		}
	}

	public void WriteNumberValue(float P_0)
	{
		JsonWriterHelper.ValidateSingle(P_0);
		if (!_options.SkipValidation)
		{
			ValidateWritingValue();
		}
		if (_options.Indented)
		{
			WriteNumberValueIndented(P_0);
		}
		else
		{
			WriteNumberValueMinimized(P_0);
		}
		SetFlagToAddListSeparatorBeforeNextItem();
		_tokenType = JsonTokenType.Number;
	}

	private void WriteNumberValueMinimized(float P_0)
	{
		int num = 129;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		int num2;
		bool flag = TryFormatSingle(P_0, span.Slice(BytesPending), out num2);
		BytesPending += num2;
	}

	private void WriteNumberValueIndented(float P_0)
	{
		int indentation = Indentation;
		int num = indentation + 128 + 1 + s_newLineLength;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.PropertyName)
		{
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
		}
		int num2;
		bool flag = TryFormatSingle(P_0, span.Slice(BytesPending), out num2);
		BytesPending += num2;
	}

	private static bool TryFormatSingle(float P_0, Span<byte> P_1, out int P_2)
	{
		return Utf8Formatter.TryFormat(P_0, P_1, out P_2);
	}

	internal void WriteNumberValueAsString(float P_0)
	{
		Span<byte> span = stackalloc byte[128];
		int num;
		bool flag = TryFormatSingle(P_0, span, out num);
		WriteNumberValueAsStringUnescaped(span.Slice(0, num));
	}

	internal void WriteFloatingPointConstant(float P_0)
	{
		if (float.IsNaN(P_0))
		{
			WriteNumberValueAsStringUnescaped(JsonConstants.NaNValue);
		}
		else if (float.IsPositiveInfinity(P_0))
		{
			WriteNumberValueAsStringUnescaped(JsonConstants.PositiveInfinityValue);
		}
		else if (float.IsNegativeInfinity(P_0))
		{
			WriteNumberValueAsStringUnescaped(JsonConstants.NegativeInfinityValue);
		}
		else
		{
			WriteNumberValue(P_0);
		}
	}

	internal void WriteNumberValue(ReadOnlySpan<byte> P_0)
	{
		JsonWriterHelper.ValidateValue(P_0);
		JsonWriterHelper.ValidateNumber(P_0);
		if (!_options.SkipValidation)
		{
			ValidateWritingValue();
		}
		if (_options.Indented)
		{
			WriteNumberValueIndented(P_0);
		}
		else
		{
			WriteNumberValueMinimized(P_0);
		}
		SetFlagToAddListSeparatorBeforeNextItem();
		_tokenType = JsonTokenType.Number;
	}

	private void WriteNumberValueMinimized(ReadOnlySpan<byte> P_0)
	{
		int num = P_0.Length + 1;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		P_0.CopyTo(span.Slice(BytesPending));
		BytesPending += P_0.Length;
	}

	private void WriteNumberValueIndented(ReadOnlySpan<byte> P_0)
	{
		int indentation = Indentation;
		int num = indentation + P_0.Length + 1 + s_newLineLength;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.PropertyName)
		{
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
		}
		P_0.CopyTo(span.Slice(BytesPending));
		BytesPending += P_0.Length;
	}

	public void WriteStringValue(Guid P_0)
	{
		if (!_options.SkipValidation)
		{
			ValidateWritingValue();
		}
		if (_options.Indented)
		{
			WriteStringValueIndented(P_0);
		}
		else
		{
			WriteStringValueMinimized(P_0);
		}
		SetFlagToAddListSeparatorBeforeNextItem();
		_tokenType = JsonTokenType.String;
	}

	private void WriteStringValueMinimized(Guid P_0)
	{
		int num = 39;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		span[BytesPending++] = 34;
		int num2;
		bool flag = Utf8Formatter.TryFormat(P_0, span.Slice(BytesPending), out num2);
		BytesPending += num2;
		span[BytesPending++] = 34;
	}

	private void WriteStringValueIndented(Guid P_0)
	{
		int indentation = Indentation;
		int num = indentation + 36 + 3 + s_newLineLength;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.PropertyName)
		{
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
		}
		span[BytesPending++] = 34;
		int num2;
		bool flag = Utf8Formatter.TryFormat(P_0, span.Slice(BytesPending), out num2);
		BytesPending += num2;
		span[BytesPending++] = 34;
	}

	private void ValidateWritingValue()
	{
		if (_inObject)
		{
			if (_tokenType != JsonTokenType.PropertyName)
			{
				ThrowHelper.ThrowInvalidOperationException(ExceptionResource.CannotWriteValueWithinObject, 0, _options.MaxDepth, 0, _tokenType);
			}
		}
		else if (CurrentDepth == 0 && _tokenType != JsonTokenType.None)
		{
			ThrowHelper.ThrowInvalidOperationException(ExceptionResource.CannotWriteValueAfterPrimitiveOrClose, 0, _options.MaxDepth, 0, _tokenType);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void Base64EncodeAndWrite(ReadOnlySpan<byte> P_0, Span<byte> P_1, int P_2)
	{
		byte[] array = null;
		Span<byte> span = ((P_2 > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(P_2))) : stackalloc byte[256]);
		Span<byte> span2 = span;
		int num;
		int num2;
		OperationStatus operationStatus = Base64.EncodeToUtf8(P_0, span2, out num, out num2);
		span2 = span2.Slice(0, num2);
		Span<byte> span3 = P_1.Slice(BytesPending);
		span2.Slice(0, num2).CopyTo(span3);
		BytesPending += num2;
		if (array != null)
		{
			ArrayPool<byte>.Shared.Return(array);
		}
	}

	public void WriteNullValue()
	{
		WriteLiteralByOptions(JsonConstants.NullValue);
		SetFlagToAddListSeparatorBeforeNextItem();
		_tokenType = JsonTokenType.Null;
	}

	public void WriteBooleanValue(bool P_0)
	{
		if (P_0)
		{
			WriteLiteralByOptions(JsonConstants.TrueValue);
			_tokenType = JsonTokenType.True;
		}
		else
		{
			WriteLiteralByOptions(JsonConstants.FalseValue);
			_tokenType = JsonTokenType.False;
		}
		SetFlagToAddListSeparatorBeforeNextItem();
	}

	private void WriteLiteralByOptions(ReadOnlySpan<byte> P_0)
	{
		if (!_options.SkipValidation)
		{
			ValidateWritingValue();
		}
		if (_options.Indented)
		{
			WriteLiteralIndented(P_0);
		}
		else
		{
			WriteLiteralMinimized(P_0);
		}
	}

	private void WriteLiteralMinimized(ReadOnlySpan<byte> P_0)
	{
		int num = P_0.Length + 1;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		P_0.CopyTo(span.Slice(BytesPending));
		BytesPending += P_0.Length;
	}

	private void WriteLiteralIndented(ReadOnlySpan<byte> P_0)
	{
		int indentation = Indentation;
		int num = indentation + P_0.Length + 1 + s_newLineLength;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.PropertyName)
		{
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
		}
		P_0.CopyTo(span.Slice(BytesPending));
		BytesPending += P_0.Length;
	}

	public void WriteNumberValue(int P_0)
	{
		WriteNumberValue((long)P_0);
	}

	public void WriteNumberValue(long P_0)
	{
		if (!_options.SkipValidation)
		{
			ValidateWritingValue();
		}
		if (_options.Indented)
		{
			WriteNumberValueIndented(P_0);
		}
		else
		{
			WriteNumberValueMinimized(P_0);
		}
		SetFlagToAddListSeparatorBeforeNextItem();
		_tokenType = JsonTokenType.Number;
	}

	private void WriteNumberValueMinimized(long P_0)
	{
		int num = 21;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		int num2;
		bool flag = Utf8Formatter.TryFormat(P_0, span.Slice(BytesPending), out num2);
		BytesPending += num2;
	}

	private void WriteNumberValueIndented(long P_0)
	{
		int indentation = Indentation;
		int num = indentation + 20 + 1 + s_newLineLength;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.PropertyName)
		{
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
		}
		int num2;
		bool flag = Utf8Formatter.TryFormat(P_0, span.Slice(BytesPending), out num2);
		BytesPending += num2;
	}

	internal void WriteNumberValueAsString(long P_0)
	{
		Span<byte> span = stackalloc byte[20];
		int num;
		bool flag = Utf8Formatter.TryFormat(P_0, span, out num);
		WriteNumberValueAsStringUnescaped(span.Slice(0, num));
	}

	public void WriteStringValue(JsonEncodedText P_0)
	{
		ReadOnlySpan<byte> encodedUtf8Bytes = P_0.EncodedUtf8Bytes;
		WriteStringByOptions(encodedUtf8Bytes);
		SetFlagToAddListSeparatorBeforeNextItem();
		_tokenType = JsonTokenType.String;
	}

	public void WriteStringValue(string? P_0)
	{
		if (P_0 == null)
		{
			WriteNullValue();
		}
		else
		{
			WriteStringValue(P_0.AsSpan());
		}
	}

	public void WriteStringValue(ReadOnlySpan<char> P_0)
	{
		JsonWriterHelper.ValidateValue(P_0);
		WriteStringEscape(P_0);
		SetFlagToAddListSeparatorBeforeNextItem();
		_tokenType = JsonTokenType.String;
	}

	private void WriteStringEscape(ReadOnlySpan<char> P_0)
	{
		int num = JsonWriterHelper.NeedsEscaping(P_0, _options.Encoder);
		if (num != -1)
		{
			WriteStringEscapeValue(P_0, num);
		}
		else
		{
			WriteStringByOptions(P_0);
		}
	}

	private void WriteStringByOptions(ReadOnlySpan<char> P_0)
	{
		if (!_options.SkipValidation)
		{
			ValidateWritingValue();
		}
		if (_options.Indented)
		{
			WriteStringIndented(P_0);
		}
		else
		{
			WriteStringMinimized(P_0);
		}
	}

	private void WriteStringMinimized(ReadOnlySpan<char> P_0)
	{
		int num = P_0.Length * 3 + 3;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		span[BytesPending++] = 34;
		TranscodeAndWrite(P_0, span);
		span[BytesPending++] = 34;
	}

	private void WriteStringIndented(ReadOnlySpan<char> P_0)
	{
		int indentation = Indentation;
		int num = indentation + P_0.Length * 3 + 3 + s_newLineLength;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.PropertyName)
		{
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
		}
		span[BytesPending++] = 34;
		TranscodeAndWrite(P_0, span);
		span[BytesPending++] = 34;
	}

	private void WriteStringEscapeValue(ReadOnlySpan<char> P_0, int P_1)
	{
		char[] array = null;
		int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(P_0.Length, P_1);
		Span<char> span = ((maxEscapedLength > 128) ? ((Span<char>)(array = ArrayPool<char>.Shared.Rent(maxEscapedLength))) : stackalloc char[128]);
		Span<char> span2 = span;
		JsonWriterHelper.EscapeString(P_0, span2, P_1, _options.Encoder, out var num);
		WriteStringByOptions(span2.Slice(0, num));
		if (array != null)
		{
			ArrayPool<char>.Shared.Return(array);
		}
	}

	public void WriteStringValue(ReadOnlySpan<byte> P_0)
	{
		JsonWriterHelper.ValidateValue(P_0);
		WriteStringEscape(P_0);
		SetFlagToAddListSeparatorBeforeNextItem();
		_tokenType = JsonTokenType.String;
	}

	private void WriteStringEscape(ReadOnlySpan<byte> P_0)
	{
		int num = JsonWriterHelper.NeedsEscaping(P_0, _options.Encoder);
		if (num != -1)
		{
			WriteStringEscapeValue(P_0, num);
		}
		else
		{
			WriteStringByOptions(P_0);
		}
	}

	private void WriteStringByOptions(ReadOnlySpan<byte> P_0)
	{
		if (!_options.SkipValidation)
		{
			ValidateWritingValue();
		}
		if (_options.Indented)
		{
			WriteStringIndented(P_0);
		}
		else
		{
			WriteStringMinimized(P_0);
		}
	}

	private void WriteStringMinimized(ReadOnlySpan<byte> P_0)
	{
		int num = P_0.Length + 2;
		int num2 = num + 1;
		if (_memory.Length - BytesPending < num2)
		{
			Grow(num2);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		span[BytesPending++] = 34;
		P_0.CopyTo(span.Slice(BytesPending));
		BytesPending += P_0.Length;
		span[BytesPending++] = 34;
	}

	private void WriteStringIndented(ReadOnlySpan<byte> P_0)
	{
		int indentation = Indentation;
		int num = indentation + P_0.Length + 2;
		int num2 = num + 1 + s_newLineLength;
		if (_memory.Length - BytesPending < num2)
		{
			Grow(num2);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.PropertyName)
		{
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
		}
		span[BytesPending++] = 34;
		P_0.CopyTo(span.Slice(BytesPending));
		BytesPending += P_0.Length;
		span[BytesPending++] = 34;
	}

	private void WriteStringEscapeValue(ReadOnlySpan<byte> P_0, int P_1)
	{
		byte[] array = null;
		int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(P_0.Length, P_1);
		Span<byte> span = ((maxEscapedLength > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(maxEscapedLength))) : stackalloc byte[256]);
		Span<byte> span2 = span;
		JsonWriterHelper.EscapeString(P_0, span2, P_1, _options.Encoder, out var num);
		WriteStringByOptions(span2.Slice(0, num));
		if (array != null)
		{
			ArrayPool<byte>.Shared.Return(array);
		}
	}

	internal void WriteNumberValueAsStringUnescaped(ReadOnlySpan<byte> P_0)
	{
		WriteStringByOptions(P_0);
		SetFlagToAddListSeparatorBeforeNextItem();
		_tokenType = JsonTokenType.String;
	}

	[CLSCompliant(false)]
	public void WriteNumberValue(uint P_0)
	{
		WriteNumberValue((ulong)P_0);
	}

	[CLSCompliant(false)]
	public void WriteNumberValue(ulong P_0)
	{
		if (!_options.SkipValidation)
		{
			ValidateWritingValue();
		}
		if (_options.Indented)
		{
			WriteNumberValueIndented(P_0);
		}
		else
		{
			WriteNumberValueMinimized(P_0);
		}
		SetFlagToAddListSeparatorBeforeNextItem();
		_tokenType = JsonTokenType.Number;
	}

	private void WriteNumberValueMinimized(ulong P_0)
	{
		int num = 21;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		int num2;
		bool flag = Utf8Formatter.TryFormat(P_0, span.Slice(BytesPending), out num2);
		BytesPending += num2;
	}

	private void WriteNumberValueIndented(ulong P_0)
	{
		int indentation = Indentation;
		int num = indentation + 20 + 1 + s_newLineLength;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.PropertyName)
		{
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			JsonWriterHelper.WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
		}
		int num2;
		bool flag = Utf8Formatter.TryFormat(P_0, span.Slice(BytesPending), out num2);
		BytesPending += num2;
	}

	internal void WriteNumberValueAsString(ulong P_0)
	{
		Span<byte> span = stackalloc byte[20];
		int num;
		bool flag = Utf8Formatter.TryFormat(P_0, span, out num);
		WriteNumberValueAsStringUnescaped(span.Slice(0, num));
	}
}
