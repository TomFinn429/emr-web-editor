using System.Buffers;
using System.Buffers.Text;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace System.Text.Json;

public sealed class JsonDocument : IDisposable
{
	internal readonly struct DbRow
	{
		private readonly int _location;

		private readonly int _sizeOrLengthUnion;

		private readonly int _numberOfRowsAndTypeUnion;

		internal int Location => _location;

		internal int SizeOrLength => _sizeOrLengthUnion & 0x7FFFFFFF;

		internal bool IsUnknownSize => _sizeOrLengthUnion == -1;

		internal bool HasComplexChildren => _sizeOrLengthUnion < 0;

		internal int NumberOfRows => _numberOfRowsAndTypeUnion & 0xFFFFFFF;

		internal JsonTokenType TokenType => (JsonTokenType)((uint)_numberOfRowsAndTypeUnion >> 28);

		internal bool IsSimpleValue => (int)TokenType >= 5;

		internal DbRow(JsonTokenType P_0, int P_1, int P_2)
		{
			_location = P_1;
			_sizeOrLengthUnion = P_2;
			_numberOfRowsAndTypeUnion = (int)((uint)P_0 << 28);
		}
	}

	private struct MetadataDb : IDisposable
	{
		[CompilerGenerated]
		private int _003CLength_003Ek__BackingField;

		private byte[] _data;

		private bool _convertToAlloc;

		private bool _isLocked;

		internal int Length
		{
			[CompilerGenerated]
			readonly get
			{
				return _003CLength_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CLength_003Ek__BackingField = num;
			}
		}

		private MetadataDb(byte[] P_0, bool P_1, bool P_2)
		{
			_data = P_0;
			_isLocked = P_1;
			_convertToAlloc = P_2;
			Length = 0;
		}

		internal static MetadataDb CreateRented(int P_0, bool P_1)
		{
			int num = P_0 + 12;
			if (num > 1048576 && num <= 4194304)
			{
				num = 1048576;
			}
			byte[] array = ArrayPool<byte>.Shared.Rent(num);
			return new MetadataDb(array, false, P_1);
		}

		internal static MetadataDb CreateLocked(int P_0)
		{
			int num = P_0 + 12;
			byte[] array = new byte[num];
			return new MetadataDb(array, true, false);
		}

		public void Dispose()
		{
			byte[] array = Interlocked.Exchange(ref _data, null);
			if (array != null)
			{
				ArrayPool<byte>.Shared.Return(array);
				Length = 0;
			}
		}

		internal void CompleteAllocations()
		{
			if (_isLocked)
			{
				return;
			}
			if (_convertToAlloc)
			{
				byte[] data = _data;
				_data = _data.AsSpan(0, Length).ToArray();
				_isLocked = true;
				_convertToAlloc = false;
				ArrayPool<byte>.Shared.Return(data);
			}
			else if (Length <= _data.Length / 2)
			{
				byte[] array = ArrayPool<byte>.Shared.Rent(Length);
				byte[] array2 = array;
				if (array.Length < _data.Length)
				{
					Buffer.BlockCopy(_data, 0, array, 0, Length);
					array2 = _data;
					_data = array;
				}
				ArrayPool<byte>.Shared.Return(array2);
			}
		}

		internal void Append(JsonTokenType P_0, int P_1, int P_2)
		{
			if (Length >= _data.Length - 12)
			{
				Enlarge();
			}
			DbRow dbRow = new DbRow(P_0, P_1, P_2);
			MemoryMarshal.Write(_data.AsSpan(Length), ref dbRow);
			Length += 12;
		}

		private void Enlarge()
		{
			byte[] data = _data;
			_data = ArrayPool<byte>.Shared.Rent(data.Length * 2);
			Buffer.BlockCopy(data, 0, _data, 0, data.Length);
			ArrayPool<byte>.Shared.Return(data);
		}

		internal void SetLength(int P_0, int P_1)
		{
			Span<byte> span = _data.AsSpan(P_0 + 4);
			MemoryMarshal.Write(span, ref P_1);
		}

		internal void SetNumberOfRows(int P_0, int P_1)
		{
			Span<byte> span = _data.AsSpan(P_0 + 8);
			int num = MemoryMarshal.Read<int>(span);
			int num2 = (num & -268435456) | P_1;
			MemoryMarshal.Write(span, ref num2);
		}

		internal void SetHasComplexChildren(int P_0)
		{
			Span<byte> span = _data.AsSpan(P_0 + 4);
			int num = MemoryMarshal.Read<int>(span);
			int num2 = num | -2147483648;
			MemoryMarshal.Write(span, ref num2);
		}

		internal int FindIndexOfFirstUnsetSizeOrLength(JsonTokenType P_0)
		{
			return FindOpenElement(P_0);
		}

		private int FindOpenElement(JsonTokenType P_0)
		{
			Span<byte> span = _data.AsSpan(0, Length);
			for (int num = Length - 12; num >= 0; num -= 12)
			{
				DbRow dbRow = MemoryMarshal.Read<DbRow>(span.Slice(num));
				if (dbRow.IsUnknownSize && dbRow.TokenType == P_0)
				{
					return num;
				}
			}
			return -1;
		}

		internal DbRow Get(int P_0)
		{
			return MemoryMarshal.Read<DbRow>(_data.AsSpan(P_0));
		}

		internal JsonTokenType GetJsonTokenType(int P_0)
		{
			uint num = MemoryMarshal.Read<uint>(_data.AsSpan(P_0 + 8));
			return (JsonTokenType)(num >> 28);
		}
	}

	private struct StackRow
	{
		internal int SizeOrLength;

		internal int NumberOfRows;

		internal StackRow(int P_0 = 0, int P_1 = -1)
		{
			SizeOrLength = P_0;
			NumberOfRows = P_1;
		}
	}

	private struct StackRowStack : IDisposable
	{
		private byte[] _rentedBuffer;

		private int _topOfStack;

		public StackRowStack(int P_0)
		{
			_rentedBuffer = ArrayPool<byte>.Shared.Rent(P_0);
			_topOfStack = _rentedBuffer.Length;
		}

		public void Dispose()
		{
			byte[] rentedBuffer = _rentedBuffer;
			_rentedBuffer = null;
			_topOfStack = 0;
			if (rentedBuffer != null)
			{
				ArrayPool<byte>.Shared.Return(rentedBuffer);
			}
		}

		internal void Push(StackRow P_0)
		{
			if (_topOfStack < 8)
			{
				Enlarge();
			}
			_topOfStack -= 8;
			MemoryMarshal.Write(_rentedBuffer.AsSpan(_topOfStack), ref P_0);
		}

		internal StackRow Pop()
		{
			StackRow result = MemoryMarshal.Read<StackRow>(_rentedBuffer.AsSpan(_topOfStack));
			_topOfStack += 8;
			return result;
		}

		private void Enlarge()
		{
			byte[] rentedBuffer = _rentedBuffer;
			_rentedBuffer = ArrayPool<byte>.Shared.Rent(rentedBuffer.Length * 2);
			Buffer.BlockCopy(rentedBuffer, _topOfStack, _rentedBuffer, _rentedBuffer.Length - rentedBuffer.Length + _topOfStack, rentedBuffer.Length - _topOfStack);
			_topOfStack += _rentedBuffer.Length - rentedBuffer.Length;
			ArrayPool<byte>.Shared.Return(rentedBuffer);
		}
	}

	private ReadOnlyMemory<byte> _utf8Json;

	private MetadataDb _parsedData;

	private byte[] _extraRentedArrayPoolBytes;

	private PooledByteBufferWriter _extraPooledByteBufferWriter;

	private static JsonDocument s_nullLiteral;

	private static JsonDocument s_trueLiteral;

	private static JsonDocument s_falseLiteral;

	internal bool IsDisposable { get; }

	public JsonElement RootElement => new JsonElement(this, 0);

	private JsonDocument(ReadOnlyMemory<byte> P_0, MetadataDb P_1, byte[] P_2 = null, PooledByteBufferWriter P_3 = null, bool P_4 = true)
	{
		_utf8Json = P_0;
		_parsedData = P_1;
		_extraRentedArrayPoolBytes = P_2;
		_extraPooledByteBufferWriter = P_3;
		IsDisposable = P_4;
	}

	public void Dispose()
	{
		int length = _utf8Json.Length;
		if (length == 0 || !IsDisposable)
		{
			return;
		}
		_parsedData.Dispose();
		_utf8Json = ReadOnlyMemory<byte>.Empty;
		if (_extraRentedArrayPoolBytes != null)
		{
			byte[] array = Interlocked.Exchange(ref _extraRentedArrayPoolBytes, null);
			if (array != null)
			{
				array.AsSpan(0, length).Clear();
				ArrayPool<byte>.Shared.Return(array);
			}
		}
		else if (_extraPooledByteBufferWriter != null)
		{
			Interlocked.Exchange(ref _extraPooledByteBufferWriter, null)?.Dispose();
		}
	}

	public void WriteTo(Utf8JsonWriter P_0)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException("writer");
		}
		RootElement.WriteTo(P_0);
	}

	internal JsonTokenType GetJsonTokenType(int P_0)
	{
		CheckNotDisposed();
		return _parsedData.GetJsonTokenType(P_0);
	}

	internal int GetArrayLength(int P_0)
	{
		CheckNotDisposed();
		DbRow dbRow = _parsedData.Get(P_0);
		CheckExpectedType(JsonTokenType.StartArray, dbRow.TokenType);
		return dbRow.SizeOrLength;
	}

	internal int GetEndIndex(int P_0, bool P_1)
	{
		CheckNotDisposed();
		DbRow dbRow = _parsedData.Get(P_0);
		if (dbRow.IsSimpleValue)
		{
			return P_0 + 12;
		}
		int num = P_0 + 12 * dbRow.NumberOfRows;
		if (P_1)
		{
			num += 12;
		}
		return num;
	}

	internal ReadOnlyMemory<byte> GetRawValue(int P_0, bool P_1)
	{
		CheckNotDisposed();
		DbRow dbRow = _parsedData.Get(P_0);
		if (dbRow.IsSimpleValue)
		{
			if (P_1 && dbRow.TokenType == JsonTokenType.String)
			{
				return _utf8Json.Slice(dbRow.Location - 1, dbRow.SizeOrLength + 2);
			}
			return _utf8Json.Slice(dbRow.Location, dbRow.SizeOrLength);
		}
		int endIndex = GetEndIndex(P_0, false);
		int location = dbRow.Location;
		dbRow = _parsedData.Get(endIndex);
		return _utf8Json.Slice(location, dbRow.Location - location + dbRow.SizeOrLength);
	}

	private ReadOnlyMemory<byte> GetPropertyRawValue(int P_0)
	{
		CheckNotDisposed();
		int num = _parsedData.Get(P_0 - 12).Location - 1;
		DbRow dbRow = _parsedData.Get(P_0);
		int num2;
		if (dbRow.IsSimpleValue)
		{
			num2 = dbRow.Location + dbRow.SizeOrLength;
			if (dbRow.TokenType == JsonTokenType.String)
			{
				num2++;
			}
			return _utf8Json.Slice(num, num2 - num);
		}
		int endIndex = GetEndIndex(P_0, false);
		dbRow = _parsedData.Get(endIndex);
		num2 = dbRow.Location + dbRow.SizeOrLength;
		return _utf8Json.Slice(num, num2 - num);
	}

	internal string GetString(int P_0, JsonTokenType P_1)
	{
		CheckNotDisposed();
		DbRow dbRow = _parsedData.Get(P_0);
		JsonTokenType tokenType = dbRow.TokenType;
		if (tokenType == JsonTokenType.Null)
		{
			return null;
		}
		CheckExpectedType(P_1, tokenType);
		ReadOnlySpan<byte> readOnlySpan = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
		if (!dbRow.HasComplexChildren)
		{
			return JsonReaderHelper.TranscodeHelper(readOnlySpan);
		}
		return JsonReaderHelper.GetUnescapedString(readOnlySpan);
	}

	internal bool TextEquals(int P_0, ReadOnlySpan<char> P_1, bool P_2)
	{
		CheckNotDisposed();
		int num = (P_2 ? (P_0 - 12) : P_0);
		byte[] array = null;
		int num2 = checked(P_1.Length * 3);
		Span<byte> span = ((num2 > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(num2))) : stackalloc byte[256]);
		Span<byte> span2 = span;
		ReadOnlySpan<byte> readOnlySpan = MemoryMarshal.AsBytes(P_1);
		int num3;
		int num4;
		OperationStatus operationStatus = JsonWriterHelper.ToUtf8(readOnlySpan, span2, out num3, out num4);
		bool result = operationStatus <= OperationStatus.DestinationTooSmall && TextEquals(P_0, span2.Slice(0, num4), P_2, true);
		if (array != null)
		{
			span2.Slice(0, num4).Clear();
			ArrayPool<byte>.Shared.Return(array);
		}
		return result;
	}

	internal bool TextEquals(int P_0, ReadOnlySpan<byte> P_1, bool P_2, bool P_3)
	{
		CheckNotDisposed();
		int num = (P_2 ? (P_0 - 12) : P_0);
		DbRow dbRow = _parsedData.Get(num);
		CheckExpectedType(P_2 ? JsonTokenType.PropertyName : JsonTokenType.String, dbRow.TokenType);
		ReadOnlySpan<byte> readOnlySpan = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
		if (P_1.Length > readOnlySpan.Length || (!P_3 && P_1.Length != readOnlySpan.Length))
		{
			return false;
		}
		if (dbRow.HasComplexChildren && P_3)
		{
			if (P_1.Length < readOnlySpan.Length / 6)
			{
				return false;
			}
			int num2 = readOnlySpan.IndexOf<byte>(92);
			if (!P_1.StartsWith(readOnlySpan.Slice(0, num2)))
			{
				return false;
			}
			return JsonReaderHelper.UnescapeAndCompare(readOnlySpan.Slice(num2), P_1.Slice(num2));
		}
		return readOnlySpan.SequenceEqual(P_1);
	}

	internal string GetNameOfPropertyValue(int P_0)
	{
		return GetString(P_0 - 12, JsonTokenType.PropertyName);
	}

	internal bool TryGetValue(int P_0, out sbyte P_1)
	{
		CheckNotDisposed();
		DbRow dbRow = _parsedData.Get(P_0);
		CheckExpectedType(JsonTokenType.Number, dbRow.TokenType);
		ReadOnlySpan<byte> readOnlySpan = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
		if (Utf8Parser.TryParse(readOnlySpan, out sbyte b, out int num, '\0') && num == readOnlySpan.Length)
		{
			P_1 = b;
			return true;
		}
		P_1 = 0;
		return false;
	}

	internal bool TryGetValue(int P_0, out byte P_1)
	{
		CheckNotDisposed();
		DbRow dbRow = _parsedData.Get(P_0);
		CheckExpectedType(JsonTokenType.Number, dbRow.TokenType);
		ReadOnlySpan<byte> readOnlySpan = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
		if (Utf8Parser.TryParse(readOnlySpan, out byte b, out int num, '\0') && num == readOnlySpan.Length)
		{
			P_1 = b;
			return true;
		}
		P_1 = 0;
		return false;
	}

	internal bool TryGetValue(int P_0, out short P_1)
	{
		CheckNotDisposed();
		DbRow dbRow = _parsedData.Get(P_0);
		CheckExpectedType(JsonTokenType.Number, dbRow.TokenType);
		ReadOnlySpan<byte> readOnlySpan = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
		if (Utf8Parser.TryParse(readOnlySpan, out short num, out int num2, '\0') && num2 == readOnlySpan.Length)
		{
			P_1 = num;
			return true;
		}
		P_1 = 0;
		return false;
	}

	internal bool TryGetValue(int P_0, out ushort P_1)
	{
		CheckNotDisposed();
		DbRow dbRow = _parsedData.Get(P_0);
		CheckExpectedType(JsonTokenType.Number, dbRow.TokenType);
		ReadOnlySpan<byte> readOnlySpan = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
		if (Utf8Parser.TryParse(readOnlySpan, out ushort num, out int num2, '\0') && num2 == readOnlySpan.Length)
		{
			P_1 = num;
			return true;
		}
		P_1 = 0;
		return false;
	}

	internal bool TryGetValue(int P_0, out int P_1)
	{
		CheckNotDisposed();
		DbRow dbRow = _parsedData.Get(P_0);
		CheckExpectedType(JsonTokenType.Number, dbRow.TokenType);
		ReadOnlySpan<byte> readOnlySpan = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
		if (Utf8Parser.TryParse(readOnlySpan, out int num, out int num2, '\0') && num2 == readOnlySpan.Length)
		{
			P_1 = num;
			return true;
		}
		P_1 = 0;
		return false;
	}

	internal bool TryGetValue(int P_0, out uint P_1)
	{
		CheckNotDisposed();
		DbRow dbRow = _parsedData.Get(P_0);
		CheckExpectedType(JsonTokenType.Number, dbRow.TokenType);
		ReadOnlySpan<byte> readOnlySpan = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
		if (Utf8Parser.TryParse(readOnlySpan, out uint num, out int num2, '\0') && num2 == readOnlySpan.Length)
		{
			P_1 = num;
			return true;
		}
		P_1 = 0u;
		return false;
	}

	internal bool TryGetValue(int P_0, out long P_1)
	{
		CheckNotDisposed();
		DbRow dbRow = _parsedData.Get(P_0);
		CheckExpectedType(JsonTokenType.Number, dbRow.TokenType);
		ReadOnlySpan<byte> readOnlySpan = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
		if (Utf8Parser.TryParse(readOnlySpan, out long num, out int num2, '\0') && num2 == readOnlySpan.Length)
		{
			P_1 = num;
			return true;
		}
		P_1 = 0L;
		return false;
	}

	internal bool TryGetValue(int P_0, out ulong P_1)
	{
		CheckNotDisposed();
		DbRow dbRow = _parsedData.Get(P_0);
		CheckExpectedType(JsonTokenType.Number, dbRow.TokenType);
		ReadOnlySpan<byte> readOnlySpan = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
		if (Utf8Parser.TryParse(readOnlySpan, out ulong num, out int num2, '\0') && num2 == readOnlySpan.Length)
		{
			P_1 = num;
			return true;
		}
		P_1 = 0uL;
		return false;
	}

	internal bool TryGetValue(int P_0, out double P_1)
	{
		CheckNotDisposed();
		DbRow dbRow = _parsedData.Get(P_0);
		CheckExpectedType(JsonTokenType.Number, dbRow.TokenType);
		ReadOnlySpan<byte> readOnlySpan = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
		if (Utf8Parser.TryParse(readOnlySpan, out double num, out int num2, '\0') && readOnlySpan.Length == num2)
		{
			P_1 = num;
			return true;
		}
		P_1 = 0.0;
		return false;
	}

	internal bool TryGetValue(int P_0, out float P_1)
	{
		CheckNotDisposed();
		DbRow dbRow = _parsedData.Get(P_0);
		CheckExpectedType(JsonTokenType.Number, dbRow.TokenType);
		ReadOnlySpan<byte> readOnlySpan = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
		if (Utf8Parser.TryParse(readOnlySpan, out float num, out int num2, '\0') && readOnlySpan.Length == num2)
		{
			P_1 = num;
			return true;
		}
		P_1 = 0f;
		return false;
	}

	internal bool TryGetValue(int P_0, out decimal P_1)
	{
		CheckNotDisposed();
		DbRow dbRow = _parsedData.Get(P_0);
		CheckExpectedType(JsonTokenType.Number, dbRow.TokenType);
		ReadOnlySpan<byte> readOnlySpan = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
		if (Utf8Parser.TryParse(readOnlySpan, out decimal num, out int num2, '\0') && readOnlySpan.Length == num2)
		{
			P_1 = num;
			return true;
		}
		P_1 = default(decimal);
		return false;
	}

	internal bool TryGetValue(int P_0, out DateTime P_1)
	{
		CheckNotDisposed();
		DbRow dbRow = _parsedData.Get(P_0);
		CheckExpectedType(JsonTokenType.String, dbRow.TokenType);
		ReadOnlySpan<byte> readOnlySpan = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
		if (!JsonHelpers.IsValidDateTimeOffsetParseLength(readOnlySpan.Length))
		{
			P_1 = default(DateTime);
			return false;
		}
		if (dbRow.HasComplexChildren)
		{
			return JsonReaderHelper.TryGetEscapedDateTime(readOnlySpan, out P_1);
		}
		if (JsonHelpers.TryParseAsISO(readOnlySpan, out DateTime dateTime))
		{
			P_1 = dateTime;
			return true;
		}
		P_1 = default(DateTime);
		return false;
	}

	internal bool TryGetValue(int P_0, out DateTimeOffset P_1)
	{
		CheckNotDisposed();
		DbRow dbRow = _parsedData.Get(P_0);
		CheckExpectedType(JsonTokenType.String, dbRow.TokenType);
		ReadOnlySpan<byte> readOnlySpan = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
		if (!JsonHelpers.IsValidDateTimeOffsetParseLength(readOnlySpan.Length))
		{
			P_1 = default(DateTimeOffset);
			return false;
		}
		if (dbRow.HasComplexChildren)
		{
			return JsonReaderHelper.TryGetEscapedDateTimeOffset(readOnlySpan, out P_1);
		}
		if (JsonHelpers.TryParseAsISO(readOnlySpan, out DateTimeOffset dateTimeOffset))
		{
			P_1 = dateTimeOffset;
			return true;
		}
		P_1 = default(DateTimeOffset);
		return false;
	}

	internal bool TryGetValue(int P_0, out Guid P_1)
	{
		CheckNotDisposed();
		DbRow dbRow = _parsedData.Get(P_0);
		CheckExpectedType(JsonTokenType.String, dbRow.TokenType);
		ReadOnlySpan<byte> readOnlySpan = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
		if (readOnlySpan.Length > 216)
		{
			P_1 = default(Guid);
			return false;
		}
		if (dbRow.HasComplexChildren)
		{
			return JsonReaderHelper.TryGetEscapedGuid(readOnlySpan, out P_1);
		}
		if (readOnlySpan.Length == 36 && Utf8Parser.TryParse(readOnlySpan, out Guid guid, out int _, 'D'))
		{
			P_1 = guid;
			return true;
		}
		P_1 = default(Guid);
		return false;
	}

	internal string GetRawValueAsString(int P_0)
	{
		return JsonReaderHelper.TranscodeHelper(GetRawValue(P_0, true).Span);
	}

	internal string GetPropertyRawValueAsString(int P_0)
	{
		return JsonReaderHelper.TranscodeHelper(GetPropertyRawValue(P_0).Span);
	}

	internal void WriteElementTo(int P_0, Utf8JsonWriter P_1)
	{
		CheckNotDisposed();
		DbRow dbRow = _parsedData.Get(P_0);
		switch (dbRow.TokenType)
		{
		case JsonTokenType.StartObject:
			P_1.WriteStartObject();
			WriteComplexElement(P_0, P_1);
			break;
		case JsonTokenType.StartArray:
			P_1.WriteStartArray();
			WriteComplexElement(P_0, P_1);
			break;
		case JsonTokenType.String:
			WriteString(in dbRow, P_1);
			break;
		case JsonTokenType.Number:
			P_1.WriteNumberValue(_utf8Json.Slice(dbRow.Location, dbRow.SizeOrLength).Span);
			break;
		case JsonTokenType.True:
			P_1.WriteBooleanValue(true);
			break;
		case JsonTokenType.False:
			P_1.WriteBooleanValue(false);
			break;
		case JsonTokenType.Null:
			P_1.WriteNullValue();
			break;
		case JsonTokenType.EndObject:
		case JsonTokenType.EndArray:
		case JsonTokenType.PropertyName:
		case JsonTokenType.Comment:
			break;
		}
	}

	private void WriteComplexElement(int P_0, Utf8JsonWriter P_1)
	{
		int endIndex = GetEndIndex(P_0, true);
		for (int i = P_0 + 12; i < endIndex; i += 12)
		{
			DbRow dbRow = _parsedData.Get(i);
			switch (dbRow.TokenType)
			{
			case JsonTokenType.String:
				WriteString(in dbRow, P_1);
				break;
			case JsonTokenType.Number:
				P_1.WriteNumberValue(_utf8Json.Slice(dbRow.Location, dbRow.SizeOrLength).Span);
				break;
			case JsonTokenType.True:
				P_1.WriteBooleanValue(true);
				break;
			case JsonTokenType.False:
				P_1.WriteBooleanValue(false);
				break;
			case JsonTokenType.Null:
				P_1.WriteNullValue();
				break;
			case JsonTokenType.StartObject:
				P_1.WriteStartObject();
				break;
			case JsonTokenType.EndObject:
				P_1.WriteEndObject();
				break;
			case JsonTokenType.StartArray:
				P_1.WriteStartArray();
				break;
			case JsonTokenType.EndArray:
				P_1.WriteEndArray();
				break;
			case JsonTokenType.PropertyName:
				WritePropertyName(in dbRow, P_1);
				break;
			}
		}
	}

	private ReadOnlySpan<byte> UnescapeString(in DbRow P_0, out ArraySegment<byte> P_1)
	{
		int location = P_0.Location;
		int sizeOrLength = P_0.SizeOrLength;
		ReadOnlySpan<byte> span = _utf8Json.Slice(location, sizeOrLength).Span;
		if (!P_0.HasComplexChildren)
		{
			P_1 = default(ArraySegment<byte>);
			return span;
		}
		byte[] array = ArrayPool<byte>.Shared.Rent(sizeOrLength);
		JsonReaderHelper.Unescape(span, array, out var num);
		P_1 = new ArraySegment<byte>(array, 0, num);
		return P_1.AsSpan();
	}

	private static void ClearAndReturn(ArraySegment<byte> P_0)
	{
		if (P_0.Array != null)
		{
			P_0.AsSpan().Clear();
			ArrayPool<byte>.Shared.Return(P_0.Array);
		}
	}

	private void WritePropertyName(in DbRow P_0, Utf8JsonWriter P_1)
	{
		ArraySegment<byte> arraySegment = default(ArraySegment<byte>);
		try
		{
			P_1.WritePropertyName(UnescapeString(in P_0, out arraySegment));
		}
		finally
		{
			ClearAndReturn(arraySegment);
		}
	}

	private void WriteString(in DbRow P_0, Utf8JsonWriter P_1)
	{
		ArraySegment<byte> arraySegment = default(ArraySegment<byte>);
		try
		{
			P_1.WriteStringValue(UnescapeString(in P_0, out arraySegment));
		}
		finally
		{
			ClearAndReturn(arraySegment);
		}
	}

	private static void Parse(ReadOnlySpan<byte> P_0, JsonReaderOptions P_1, ref MetadataDb P_2, ref StackRowStack P_3)
	{
		bool flag = false;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		Utf8JsonReader utf8JsonReader = new Utf8JsonReader(P_0, true, new JsonReaderState(P_1));
		while (utf8JsonReader.Read())
		{
			JsonTokenType tokenType = utf8JsonReader.TokenType;
			int num4 = (int)utf8JsonReader.TokenStartIndex;
			switch (tokenType)
			{
			case JsonTokenType.StartObject:
			{
				if (flag)
				{
					num++;
				}
				num3++;
				P_2.Append(tokenType, num4, -1);
				StackRow stackRow3 = new StackRow(num2 + 1);
				P_3.Push(stackRow3);
				num2 = 0;
				break;
			}
			case JsonTokenType.EndObject:
			{
				int num6 = P_2.FindIndexOfFirstUnsetSizeOrLength(JsonTokenType.StartObject);
				num3++;
				num2++;
				P_2.SetLength(num6, num2);
				int length2 = P_2.Length;
				P_2.Append(tokenType, num4, utf8JsonReader.ValueSpan.Length);
				P_2.SetNumberOfRows(num6, num2);
				P_2.SetNumberOfRows(length2, num2);
				num2 += P_3.Pop().SizeOrLength;
				break;
			}
			case JsonTokenType.StartArray:
			{
				if (flag)
				{
					num++;
				}
				num2++;
				P_2.Append(tokenType, num4, -1);
				StackRow stackRow = new StackRow(num, num3 + 1);
				P_3.Push(stackRow);
				num = 0;
				num3 = 0;
				break;
			}
			case JsonTokenType.EndArray:
			{
				int num5 = P_2.FindIndexOfFirstUnsetSizeOrLength(JsonTokenType.StartArray);
				num3++;
				num2++;
				P_2.SetLength(num5, num);
				P_2.SetNumberOfRows(num5, num3);
				if (num + 1 != num3)
				{
					P_2.SetHasComplexChildren(num5);
				}
				int length = P_2.Length;
				P_2.Append(tokenType, num4, utf8JsonReader.ValueSpan.Length);
				P_2.SetNumberOfRows(length, num3);
				StackRow stackRow2 = P_3.Pop();
				num = stackRow2.SizeOrLength;
				num3 += stackRow2.NumberOfRows;
				break;
			}
			case JsonTokenType.PropertyName:
				num3++;
				num2++;
				P_2.Append(tokenType, num4 + 1, utf8JsonReader.ValueSpan.Length);
				if (utf8JsonReader.ValueIsEscaped)
				{
					P_2.SetHasComplexChildren(P_2.Length - 12);
				}
				break;
			default:
				num3++;
				num2++;
				if (flag)
				{
					num++;
				}
				if (tokenType == JsonTokenType.String)
				{
					P_2.Append(tokenType, num4 + 1, utf8JsonReader.ValueSpan.Length);
					if (utf8JsonReader.ValueIsEscaped)
					{
						P_2.SetHasComplexChildren(P_2.Length - 12);
					}
				}
				else
				{
					P_2.Append(tokenType, num4, utf8JsonReader.ValueSpan.Length);
				}
				break;
			}
			flag = utf8JsonReader.IsInArray;
		}
		P_2.CompleteAllocations();
	}

	private void CheckNotDisposed()
	{
		if (_utf8Json.IsEmpty)
		{
			ThrowHelper.ThrowObjectDisposedException_JsonDocument();
		}
	}

	private static void CheckExpectedType(JsonTokenType P_0, JsonTokenType P_1)
	{
		if (P_0 != P_1)
		{
			ThrowHelper.ThrowJsonElementWrongTypeException(P_0, P_1);
		}
	}

	private static void CheckSupportedOptions(JsonReaderOptions P_0, string P_1)
	{
		if (P_0.CommentHandling == JsonCommentHandling.Allow)
		{
			throw new ArgumentException("JsonDocumentDoesNotSupportComments", P_1);
		}
	}

	internal static JsonDocument ParseValue(ReadOnlySpan<byte> P_0, JsonDocumentOptions P_1)
	{
		byte[] array = new byte[P_0.Length];
		P_0.CopyTo(array);
		return ParseUnrented(array.AsMemory(), P_1.GetReaderOptions());
	}

	internal static JsonDocument ParseValue(string P_0, JsonDocumentOptions P_1)
	{
		return ParseValue(P_0.AsMemory(), P_1);
	}

	public static JsonDocument Parse([StringSyntax("Json")] ReadOnlyMemory<char> P_0, JsonDocumentOptions P_1 = default(JsonDocumentOptions))
	{
		ReadOnlySpan<char> span = P_0.Span;
		int utf8ByteCount = JsonReaderHelper.GetUtf8ByteCount(span);
		byte[] array = ArrayPool<byte>.Shared.Rent(utf8ByteCount);
		try
		{
			int utf8FromText = JsonReaderHelper.GetUtf8FromText(span, array);
			return Parse(array.AsMemory(0, utf8FromText), P_1.GetReaderOptions(), array);
		}
		catch
		{
			array.AsSpan(0, utf8ByteCount).Clear();
			ArrayPool<byte>.Shared.Return(array);
			throw;
		}
	}

	internal static JsonDocument ParseValue(ReadOnlyMemory<char> P_0, JsonDocumentOptions P_1)
	{
		ReadOnlySpan<char> span = P_0.Span;
		int utf8ByteCount = JsonReaderHelper.GetUtf8ByteCount(span);
		byte[] array = ArrayPool<byte>.Shared.Rent(utf8ByteCount);
		byte[] array2;
		try
		{
			int utf8FromText = JsonReaderHelper.GetUtf8FromText(span, array);
			array2 = new byte[utf8FromText];
			Buffer.BlockCopy(array, 0, array2, 0, utf8FromText);
		}
		finally
		{
			array.AsSpan(0, utf8ByteCount).Clear();
			ArrayPool<byte>.Shared.Return(array);
		}
		return ParseUnrented(array2.AsMemory(), P_1.GetReaderOptions());
	}

	public static JsonDocument Parse([StringSyntax("Json")] string P_0, JsonDocumentOptions P_1 = default(JsonDocumentOptions))
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException("json");
		}
		return Parse(P_0.AsMemory(), P_1);
	}

	public static JsonDocument ParseValue(ref Utf8JsonReader P_0)
	{
		JsonDocument result;
		bool flag = TryParseValue(ref P_0, out result, true, true);
		return result;
	}

	internal static bool TryParseValue(ref Utf8JsonReader P_0, [NotNullWhen(true)] out JsonDocument P_1, bool P_2, bool P_3)
	{
		JsonReaderState currentState = P_0.CurrentState;
		CheckSupportedOptions(currentState.Options, "reader");
		Utf8JsonReader utf8JsonReader = P_0;
		ReadOnlySpan<byte> readOnlySpan = default(ReadOnlySpan<byte>);
		ReadOnlySequence<byte> readOnlySequence = default(ReadOnlySequence<byte>);
		try
		{
			JsonTokenType tokenType = P_0.TokenType;
			ReadOnlySpan<byte> readOnlySpan2;
			if ((tokenType == JsonTokenType.None || tokenType == JsonTokenType.PropertyName) && !P_0.Read())
			{
				if (P_2)
				{
					readOnlySpan2 = default(ReadOnlySpan<byte>);
					ThrowHelper.ThrowJsonReaderException(ref P_0, ExceptionResource.ExpectedJsonTokens, 0, readOnlySpan2);
				}
				P_0 = utf8JsonReader;
				P_1 = null;
				return false;
			}
			switch (P_0.TokenType)
			{
			case JsonTokenType.StartObject:
			case JsonTokenType.StartArray:
			{
				long tokenStartIndex = P_0.TokenStartIndex;
				if (!P_0.TrySkip())
				{
					if (P_2)
					{
						readOnlySpan2 = default(ReadOnlySpan<byte>);
						ThrowHelper.ThrowJsonReaderException(ref P_0, ExceptionResource.ExpectedJsonTokens, 0, readOnlySpan2);
					}
					P_0 = utf8JsonReader;
					P_1 = null;
					return false;
				}
				long num4 = P_0.BytesConsumed - tokenStartIndex;
				ReadOnlySequence<byte> originalSequence2 = P_0.OriginalSequence;
				if (originalSequence2.IsEmpty)
				{
					readOnlySpan2 = P_0.OriginalSpan;
					readOnlySpan = checked(readOnlySpan2.Slice((int)tokenStartIndex, (int)num4));
				}
				else
				{
					readOnlySequence = originalSequence2.Slice(tokenStartIndex, num4);
				}
				break;
			}
			case JsonTokenType.True:
			case JsonTokenType.False:
			case JsonTokenType.Null:
				if (P_3)
				{
					if (P_0.HasValueSequence)
					{
						readOnlySequence = P_0.ValueSequence;
					}
					else
					{
						readOnlySpan = P_0.ValueSpan;
					}
					break;
				}
				P_1 = CreateForLiteral(P_0.TokenType);
				return true;
			case JsonTokenType.Number:
				if (P_0.HasValueSequence)
				{
					readOnlySequence = P_0.ValueSequence;
				}
				else
				{
					readOnlySpan = P_0.ValueSpan;
				}
				break;
			case JsonTokenType.String:
			{
				ReadOnlySequence<byte> originalSequence = P_0.OriginalSequence;
				if (originalSequence.IsEmpty)
				{
					readOnlySpan2 = P_0.ValueSpan;
					int num = readOnlySpan2.Length + 2;
					readOnlySpan = P_0.OriginalSpan.Slice((int)P_0.TokenStartIndex, num);
					break;
				}
				long num2 = 2L;
				if (P_0.HasValueSequence)
				{
					num2 += P_0.ValueSequence.Length;
				}
				else
				{
					long num3 = num2;
					readOnlySpan2 = P_0.ValueSpan;
					num2 = num3 + readOnlySpan2.Length;
				}
				readOnlySequence = originalSequence.Slice(P_0.TokenStartIndex, num2);
				break;
			}
			default:
				if (P_2)
				{
					readOnlySpan2 = P_0.ValueSpan;
					byte b = readOnlySpan2[0];
					readOnlySpan2 = default(ReadOnlySpan<byte>);
					ThrowHelper.ThrowJsonReaderException(ref P_0, ExceptionResource.ExpectedStartOfValueNotFound, b, readOnlySpan2);
				}
				P_0 = utf8JsonReader;
				P_1 = null;
				return false;
			}
		}
		catch
		{
			P_0 = utf8JsonReader;
			throw;
		}
		int num5 = (readOnlySpan.IsEmpty ? checked((int)readOnlySequence.Length) : readOnlySpan.Length);
		if (P_3)
		{
			byte[] array = ArrayPool<byte>.Shared.Rent(num5);
			Span<byte> span = array.AsSpan(0, num5);
			try
			{
				if (readOnlySpan.IsEmpty)
				{
					readOnlySequence.CopyTo(span);
				}
				else
				{
					readOnlySpan.CopyTo(span);
				}
				P_1 = Parse(array.AsMemory(0, num5), currentState.Options, array);
			}
			catch
			{
				span.Clear();
				ArrayPool<byte>.Shared.Return(array);
				throw;
			}
		}
		else
		{
			byte[] array2 = ((!readOnlySpan.IsEmpty) ? readOnlySpan.ToArray() : BuffersExtensions.ToArray(in readOnlySequence));
			P_1 = ParseUnrented(array2, currentState.Options, P_0.TokenType);
		}
		return true;
	}

	private static JsonDocument CreateForLiteral(JsonTokenType P_0)
	{
		switch (P_0)
		{
		case JsonTokenType.False:
			if (s_falseLiteral == null)
			{
				s_falseLiteral = Create(JsonConstants.FalseValue.ToArray());
			}
			return s_falseLiteral;
		case JsonTokenType.True:
			if (s_trueLiteral == null)
			{
				s_trueLiteral = Create(JsonConstants.TrueValue.ToArray());
			}
			return s_trueLiteral;
		default:
			if (s_nullLiteral == null)
			{
				s_nullLiteral = Create(JsonConstants.NullValue.ToArray());
			}
			return s_nullLiteral;
		}
		JsonDocument Create(byte[] array)
		{
			MetadataDb metadataDb = MetadataDb.CreateLocked(array.Length);
			metadataDb.Append(P_0, 0, array.Length);
			return new JsonDocument(array, metadataDb);
		}
	}

	private static JsonDocument Parse(ReadOnlyMemory<byte> P_0, JsonReaderOptions P_1, byte[] P_2 = null, PooledByteBufferWriter P_3 = null)
	{
		ReadOnlySpan<byte> span = P_0.Span;
		MetadataDb metadataDb = MetadataDb.CreateRented(P_0.Length, false);
		StackRowStack stackRowStack = new StackRowStack(512);
		try
		{
			Parse(span, P_1, ref metadataDb, ref stackRowStack);
		}
		catch
		{
			metadataDb.Dispose();
			throw;
		}
		finally
		{
			stackRowStack.Dispose();
		}
		return new JsonDocument(P_0, metadataDb, P_2, P_3);
	}

	private static JsonDocument ParseUnrented(ReadOnlyMemory<byte> P_0, JsonReaderOptions P_1, JsonTokenType P_2 = JsonTokenType.None)
	{
		ReadOnlySpan<byte> span = P_0.Span;
		MetadataDb metadataDb;
		if (P_2 == JsonTokenType.String || P_2 == JsonTokenType.Number)
		{
			metadataDb = MetadataDb.CreateLocked(P_0.Length);
			StackRowStack stackRowStack = default(StackRowStack);
			Parse(span, P_1, ref metadataDb, ref stackRowStack);
		}
		else
		{
			metadataDb = MetadataDb.CreateRented(P_0.Length, true);
			StackRowStack stackRowStack2 = new StackRowStack(512);
			try
			{
				Parse(span, P_1, ref metadataDb, ref stackRowStack2);
			}
			finally
			{
				stackRowStack2.Dispose();
			}
		}
		return new JsonDocument(P_0, metadataDb);
	}

	internal bool TryGetNamedPropertyValue(int P_0, ReadOnlySpan<char> P_1, out JsonElement P_2)
	{
		CheckNotDisposed();
		DbRow dbRow = _parsedData.Get(P_0);
		CheckExpectedType(JsonTokenType.StartObject, dbRow.TokenType);
		if (dbRow.NumberOfRows == 1)
		{
			P_2 = default(JsonElement);
			return false;
		}
		int maxByteCount = JsonReaderHelper.s_utf8Encoding.GetMaxByteCount(P_1.Length);
		int num = P_0 + 12;
		int num2 = checked(dbRow.NumberOfRows * 12 + P_0);
		if (maxByteCount < 256)
		{
			Span<byte> span = stackalloc byte[256];
			int utf8FromText = JsonReaderHelper.GetUtf8FromText(P_1, span);
			span = span.Slice(0, utf8FromText);
			return TryGetNamedPropertyValue(num, num2, span, out P_2);
		}
		int length = P_1.Length;
		int num3;
		for (num3 = num2 - 12; num3 > P_0; num3 -= 12)
		{
			int num4 = num3;
			dbRow = _parsedData.Get(num3);
			num3 = ((!dbRow.IsSimpleValue) ? (num3 - 12 * (dbRow.NumberOfRows + 1)) : (num3 - 12));
			if (_parsedData.Get(num3).SizeOrLength >= length)
			{
				byte[] array = ArrayPool<byte>.Shared.Rent(maxByteCount);
				Span<byte> span2 = default(Span<byte>);
				try
				{
					int utf8FromText2 = JsonReaderHelper.GetUtf8FromText(P_1, array);
					span2 = array.AsSpan(0, utf8FromText2);
					return TryGetNamedPropertyValue(num, num4 + 12, span2, out P_2);
				}
				finally
				{
					span2.Clear();
					ArrayPool<byte>.Shared.Return(array);
				}
			}
		}
		P_2 = default(JsonElement);
		return false;
	}

	private bool TryGetNamedPropertyValue(int P_0, int P_1, ReadOnlySpan<byte> P_2, out JsonElement P_3)
	{
		ReadOnlySpan<byte> span = _utf8Json.Span;
		Span<byte> span2 = stackalloc byte[256];
		int num;
		for (num = P_1 - 12; num > P_0; num -= 12)
		{
			DbRow dbRow = _parsedData.Get(num);
			num = ((!dbRow.IsSimpleValue) ? (num - 12 * (dbRow.NumberOfRows + 1)) : (num - 12));
			dbRow = _parsedData.Get(num);
			ReadOnlySpan<byte> readOnlySpan = span.Slice(dbRow.Location, dbRow.SizeOrLength);
			if (dbRow.HasComplexChildren)
			{
				if (readOnlySpan.Length > P_2.Length)
				{
					int num2 = readOnlySpan.IndexOf<byte>(92);
					if (P_2.Length > num2 && readOnlySpan.Slice(0, num2).SequenceEqual(P_2.Slice(0, num2)))
					{
						int num3 = readOnlySpan.Length - num2;
						int num4 = 0;
						byte[] array = null;
						try
						{
							Span<byte> span3 = ((num3 <= span2.Length) ? span2 : ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(num3))));
							JsonReaderHelper.Unescape(readOnlySpan.Slice(num2), span3, 0, out num4);
							if (span3.Slice(0, num4).SequenceEqual(P_2.Slice(num2)))
							{
								P_3 = new JsonElement(this, num + 12);
								return true;
							}
						}
						finally
						{
							if (array != null)
							{
								array.AsSpan(0, num4).Clear();
								ArrayPool<byte>.Shared.Return(array);
							}
						}
					}
				}
			}
			else if (readOnlySpan.SequenceEqual(P_2))
			{
				P_3 = new JsonElement(this, num + 12);
				return true;
			}
		}
		P_3 = default(JsonElement);
		return false;
	}
}
