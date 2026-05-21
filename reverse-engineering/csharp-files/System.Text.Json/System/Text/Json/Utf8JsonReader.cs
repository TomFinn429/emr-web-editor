using System.Buffers;
using System.Buffers.Text;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Text.Json;

public ref struct Utf8JsonReader
{
	private readonly struct PartialStateForRollback
	{
		public readonly long _prevTotalConsumed;

		public readonly long _prevBytePositionInLine;

		public readonly int _prevConsumed;

		public readonly SequencePosition _prevCurrentPosition;

		public PartialStateForRollback(long P_0, long P_1, int P_2, SequencePosition P_3)
		{
			_prevTotalConsumed = P_0;
			_prevBytePositionInLine = P_1;
			_prevConsumed = P_2;
			_prevCurrentPosition = P_3;
		}

		public SequencePosition GetStartPosition(int P_0 = 0)
		{
			return new SequencePosition(_prevCurrentPosition.GetObject(), _prevCurrentPosition.GetInteger() + _prevConsumed + P_0);
		}
	}

	private ReadOnlySpan<byte> _buffer;

	private readonly bool _isFinalBlock;

	private readonly bool _isInputSequence;

	private long _lineNumber;

	private long _bytePositionInLine;

	private int _consumed;

	private bool _inObject;

	private bool _isNotPrimitive;

	private JsonTokenType _tokenType;

	private JsonTokenType _previousTokenType;

	private JsonReaderOptions _readerOptions;

	private BitStack _bitStack;

	private long _totalConsumed;

	private bool _isLastSegment;

	private readonly bool _isMultiSegment;

	private bool _trailingCommaBeforeComment;

	private SequencePosition _nextPosition;

	private SequencePosition _currentPosition;

	private readonly ReadOnlySequence<byte> _sequence;

	[CompilerGenerated]
	private ReadOnlySpan<byte> _003CValueSpan_003Ek__BackingField;

	[CompilerGenerated]
	private long _003CTokenStartIndex_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CHasValueSequence_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CValueIsEscaped_003Ek__BackingField;

	[CompilerGenerated]
	private ReadOnlySequence<byte> _003CValueSequence_003Ek__BackingField;

	private bool IsLastSpan
	{
		get
		{
			if (_isFinalBlock)
			{
				if (_isMultiSegment)
				{
					return _isLastSegment;
				}
				return true;
			}
			return false;
		}
	}

	internal ReadOnlySequence<byte> OriginalSequence => _sequence;

	internal ReadOnlySpan<byte> OriginalSpan
	{
		get
		{
			if (!_sequence.IsEmpty)
			{
				return default(ReadOnlySpan<byte>);
			}
			return _buffer;
		}
	}

	internal readonly int ValueLength
	{
		get
		{
			if (!HasValueSequence)
			{
				return ValueSpan.Length;
			}
			return checked((int)ValueSequence.Length);
		}
	}

	public ReadOnlySpan<byte> ValueSpan
	{
		[CompilerGenerated]
		readonly get
		{
			return _003CValueSpan_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CValueSpan_003Ek__BackingField = readOnlySpan;
		}
	}

	public readonly long BytesConsumed => _totalConsumed + _consumed;

	public long TokenStartIndex
	{
		[CompilerGenerated]
		readonly get
		{
			return _003CTokenStartIndex_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CTokenStartIndex_003Ek__BackingField = num;
		}
	}

	public readonly int CurrentDepth
	{
		get
		{
			int num = _bitStack.CurrentDepth;
			if (TokenType == JsonTokenType.StartArray || TokenType == JsonTokenType.StartObject)
			{
				num--;
			}
			return num;
		}
	}

	internal bool IsInArray => !_inObject;

	public readonly JsonTokenType TokenType => _tokenType;

	public bool HasValueSequence
	{
		[CompilerGenerated]
		readonly get
		{
			return _003CHasValueSequence_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CHasValueSequence_003Ek__BackingField = flag;
		}
	}

	public bool ValueIsEscaped
	{
		[CompilerGenerated]
		readonly get
		{
			return _003CValueIsEscaped_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CValueIsEscaped_003Ek__BackingField = flag;
		}
	}

	public readonly bool IsFinalBlock => _isFinalBlock;

	public ReadOnlySequence<byte> ValueSequence
	{
		[CompilerGenerated]
		readonly get
		{
			return _003CValueSequence_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CValueSequence_003Ek__BackingField = readOnlySequence;
		}
	}

	public readonly JsonReaderState CurrentState => new JsonReaderState
	{
		_lineNumber = _lineNumber,
		_bytePositionInLine = _bytePositionInLine,
		_inObject = _inObject,
		_isNotPrimitive = _isNotPrimitive,
		_valueIsEscaped = ValueIsEscaped,
		_trailingCommaBeforeComment = _trailingCommaBeforeComment,
		_tokenType = _tokenType,
		_previousTokenType = _previousTokenType,
		_readerOptions = _readerOptions,
		_bitStack = _bitStack
	};

	public Utf8JsonReader(ReadOnlySpan<byte> P_0, bool P_1, JsonReaderState P_2)
	{
		_buffer = P_0;
		_isFinalBlock = P_1;
		_isInputSequence = false;
		_lineNumber = P_2._lineNumber;
		_bytePositionInLine = P_2._bytePositionInLine;
		_inObject = P_2._inObject;
		_isNotPrimitive = P_2._isNotPrimitive;
		ValueIsEscaped = P_2._valueIsEscaped;
		_trailingCommaBeforeComment = P_2._trailingCommaBeforeComment;
		_tokenType = P_2._tokenType;
		_previousTokenType = P_2._previousTokenType;
		_readerOptions = P_2._readerOptions;
		if (_readerOptions.MaxDepth == 0)
		{
			_readerOptions.MaxDepth = 64;
		}
		_bitStack = P_2._bitStack;
		_consumed = 0;
		TokenStartIndex = 0L;
		_totalConsumed = 0L;
		_isLastSegment = _isFinalBlock;
		_isMultiSegment = false;
		ValueSpan = ReadOnlySpan<byte>.Empty;
		_currentPosition = default(SequencePosition);
		_nextPosition = default(SequencePosition);
		_sequence = default(ReadOnlySequence<byte>);
		HasValueSequence = false;
		ValueSequence = ReadOnlySequence<byte>.Empty;
	}

	public Utf8JsonReader(ReadOnlySpan<byte> P_0, JsonReaderOptions P_1 = default(JsonReaderOptions))
		: this(P_0, true, new JsonReaderState(P_1))
	{
	}

	public bool Read()
	{
		bool flag = (_isMultiSegment ? ReadMultiSegment() : ReadSingleSegment());
		if (!flag && _isFinalBlock && TokenType == JsonTokenType.None)
		{
			ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedJsonTokens, 0);
		}
		return flag;
	}

	public void Skip()
	{
		if (!_isFinalBlock)
		{
			ThrowHelper.ThrowInvalidOperationException_CannotSkipOnPartial();
		}
		SkipHelper();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void SkipHelper()
	{
		if (TokenType == JsonTokenType.PropertyName)
		{
			bool flag = Read();
		}
		if (TokenType == JsonTokenType.StartObject || TokenType == JsonTokenType.StartArray)
		{
			int currentDepth = CurrentDepth;
			do
			{
				bool flag2 = Read();
			}
			while (currentDepth < CurrentDepth);
		}
	}

	public bool TrySkip()
	{
		if (_isFinalBlock)
		{
			SkipHelper();
			return true;
		}
		return TrySkipHelper();
	}

	private bool TrySkipHelper()
	{
		Utf8JsonReader utf8JsonReader = this;
		if (TokenType != JsonTokenType.PropertyName || Read())
		{
			if (TokenType != JsonTokenType.StartObject && TokenType != JsonTokenType.StartArray)
			{
				goto IL_0042;
			}
			int currentDepth = CurrentDepth;
			while (Read())
			{
				if (currentDepth < CurrentDepth)
				{
					continue;
				}
				goto IL_0042;
			}
		}
		this = utf8JsonReader;
		return false;
		IL_0042:
		return true;
	}

	public readonly bool ValueTextEquals(ReadOnlySpan<byte> P_0)
	{
		if (!IsTokenTypeString(TokenType))
		{
			ThrowHelper.ThrowInvalidOperationException_ExpectedStringComparison(TokenType);
		}
		return TextEqualsHelper(P_0);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private readonly bool TextEqualsHelper(ReadOnlySpan<byte> P_0)
	{
		if (HasValueSequence)
		{
			return CompareToSequence(P_0);
		}
		if (ValueIsEscaped)
		{
			return UnescapeAndCompare(P_0);
		}
		return P_0.SequenceEqual(ValueSpan);
	}

	private readonly bool CompareToSequence(ReadOnlySpan<byte> P_0)
	{
		if (ValueIsEscaped)
		{
			return UnescapeSequenceAndCompare(P_0);
		}
		ReadOnlySequence<byte> valueSequence = ValueSequence;
		if (valueSequence.Length != P_0.Length)
		{
			return false;
		}
		int num = 0;
		ReadOnlySequence<byte>.Enumerator enumerator = valueSequence.GetEnumerator();
		while (enumerator.MoveNext())
		{
			ReadOnlySpan<byte> span = enumerator.Current.Span;
			if (P_0.Slice(num).StartsWith(span))
			{
				num += span.Length;
				continue;
			}
			return false;
		}
		return true;
	}

	private readonly bool UnescapeAndCompare(ReadOnlySpan<byte> P_0)
	{
		ReadOnlySpan<byte> valueSpan = ValueSpan;
		if (valueSpan.Length < P_0.Length || valueSpan.Length / 6 > P_0.Length)
		{
			return false;
		}
		int num = valueSpan.IndexOf<byte>(92);
		if (!P_0.StartsWith(valueSpan.Slice(0, num)))
		{
			return false;
		}
		return JsonReaderHelper.UnescapeAndCompare(valueSpan.Slice(num), P_0.Slice(num));
	}

	private readonly bool UnescapeSequenceAndCompare(ReadOnlySpan<byte> P_0)
	{
		ReadOnlySequence<byte> valueSequence = ValueSequence;
		long length = valueSequence.Length;
		if (length < P_0.Length || length / 6 > P_0.Length)
		{
			return false;
		}
		int num = 0;
		bool result = false;
		ReadOnlySequence<byte>.Enumerator enumerator = valueSequence.GetEnumerator();
		while (enumerator.MoveNext())
		{
			ReadOnlySpan<byte> span = enumerator.Current.Span;
			int num2 = span.IndexOf<byte>(92);
			if (num2 != -1)
			{
				if (P_0.Slice(num).StartsWith(span.Slice(0, num2)))
				{
					num += num2;
					P_0 = P_0.Slice(num);
					valueSequence = valueSequence.Slice(num);
					result = ((!valueSequence.IsSingleSegment) ? JsonReaderHelper.UnescapeAndCompare(valueSequence, P_0) : JsonReaderHelper.UnescapeAndCompare(valueSequence.First.Span, P_0));
				}
				break;
			}
			if (!P_0.Slice(num).StartsWith(span))
			{
				break;
			}
			num += span.Length;
		}
		return result;
	}

	private static bool IsTokenTypeString(JsonTokenType P_0)
	{
		if (P_0 != JsonTokenType.PropertyName)
		{
			return P_0 == JsonTokenType.String;
		}
		return true;
	}

	private void StartObject()
	{
		if (_bitStack.CurrentDepth >= _readerOptions.MaxDepth)
		{
			ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ObjectDepthTooLarge, 0);
		}
		_bitStack.PushTrue();
		ValueSpan = _buffer.Slice(_consumed, 1);
		_consumed++;
		_bytePositionInLine++;
		_tokenType = JsonTokenType.StartObject;
		_inObject = true;
	}

	private void EndObject()
	{
		if (!_inObject || _bitStack.CurrentDepth <= 0)
		{
			ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.MismatchedObjectArray, 125);
		}
		if (_trailingCommaBeforeComment)
		{
			if (!_readerOptions.AllowTrailingCommas)
			{
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.TrailingCommaNotAllowedBeforeObjectEnd, 0);
			}
			_trailingCommaBeforeComment = false;
		}
		_tokenType = JsonTokenType.EndObject;
		ValueSpan = _buffer.Slice(_consumed, 1);
		UpdateBitStackOnEndToken();
	}

	private void StartArray()
	{
		if (_bitStack.CurrentDepth >= _readerOptions.MaxDepth)
		{
			ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ArrayDepthTooLarge, 0);
		}
		_bitStack.PushFalse();
		ValueSpan = _buffer.Slice(_consumed, 1);
		_consumed++;
		_bytePositionInLine++;
		_tokenType = JsonTokenType.StartArray;
		_inObject = false;
	}

	private void EndArray()
	{
		if (_inObject || _bitStack.CurrentDepth <= 0)
		{
			ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.MismatchedObjectArray, 93);
		}
		if (_trailingCommaBeforeComment)
		{
			if (!_readerOptions.AllowTrailingCommas)
			{
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.TrailingCommaNotAllowedBeforeArrayEnd, 0);
			}
			_trailingCommaBeforeComment = false;
		}
		_tokenType = JsonTokenType.EndArray;
		ValueSpan = _buffer.Slice(_consumed, 1);
		UpdateBitStackOnEndToken();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void UpdateBitStackOnEndToken()
	{
		_consumed++;
		_bytePositionInLine++;
		_inObject = _bitStack.Pop();
	}

	private bool ReadSingleSegment()
	{
		bool flag = false;
		ValueSpan = default(ReadOnlySpan<byte>);
		ValueIsEscaped = false;
		if (HasMoreData())
		{
			byte b = _buffer[_consumed];
			if (b <= 32)
			{
				SkipWhiteSpace();
				if (!HasMoreData())
				{
					goto IL_0139;
				}
				b = _buffer[_consumed];
			}
			TokenStartIndex = _consumed;
			if (_tokenType != JsonTokenType.None)
			{
				if (b == 47)
				{
					flag = ConsumeNextTokenOrRollback(b);
				}
				else if (_tokenType == JsonTokenType.StartObject)
				{
					if (b == 125)
					{
						EndObject();
						goto IL_0137;
					}
					if (b != 34)
					{
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyNotFound, b);
					}
					int consumed = _consumed;
					long bytePositionInLine = _bytePositionInLine;
					long lineNumber = _lineNumber;
					flag = ConsumePropertyName();
					if (!flag)
					{
						_consumed = consumed;
						_tokenType = JsonTokenType.StartObject;
						_bytePositionInLine = bytePositionInLine;
						_lineNumber = lineNumber;
					}
				}
				else if (_tokenType != JsonTokenType.StartArray)
				{
					flag = ((_tokenType != JsonTokenType.PropertyName) ? ConsumeNextTokenOrRollback(b) : ConsumeValue(b));
				}
				else
				{
					if (b == 93)
					{
						EndArray();
						goto IL_0137;
					}
					flag = ConsumeValue(b);
				}
			}
			else
			{
				flag = ReadFirstToken(b);
			}
		}
		goto IL_0139;
		IL_0139:
		return flag;
		IL_0137:
		flag = true;
		goto IL_0139;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private bool HasMoreData()
	{
		if (_consumed >= (uint)_buffer.Length)
		{
			if (_isNotPrimitive && IsLastSpan)
			{
				if (_bitStack.CurrentDepth != 0)
				{
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ZeroDepthAtEnd, 0);
				}
				if (_readerOptions.CommentHandling == JsonCommentHandling.Allow && _tokenType == JsonTokenType.Comment)
				{
					return false;
				}
				if (_tokenType != JsonTokenType.EndArray && _tokenType != JsonTokenType.EndObject)
				{
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.InvalidEndOfJsonNonPrimitive, 0);
				}
			}
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private bool HasMoreData(ExceptionResource P_0)
	{
		if (_consumed >= (uint)_buffer.Length)
		{
			if (IsLastSpan)
			{
				ThrowHelper.ThrowJsonReaderException(ref this, P_0, 0);
			}
			return false;
		}
		return true;
	}

	private bool ReadFirstToken(byte P_0)
	{
		switch (P_0)
		{
		case 123:
			_bitStack.SetFirstBit();
			_tokenType = JsonTokenType.StartObject;
			ValueSpan = _buffer.Slice(_consumed, 1);
			_consumed++;
			_bytePositionInLine++;
			_inObject = true;
			_isNotPrimitive = true;
			break;
		case 91:
			_bitStack.ResetFirstBit();
			_tokenType = JsonTokenType.StartArray;
			ValueSpan = _buffer.Slice(_consumed, 1);
			_consumed++;
			_bytePositionInLine++;
			_isNotPrimitive = true;
			break;
		default:
		{
			ReadOnlySpan<byte> buffer = _buffer;
			if (JsonHelpers.IsDigit(P_0) || P_0 == 45)
			{
				if (!TryGetNumber(buffer.Slice(_consumed), out var num))
				{
					return false;
				}
				_tokenType = JsonTokenType.Number;
				_consumed += num;
				_bytePositionInLine += num;
				return true;
			}
			if (!ConsumeValue(P_0))
			{
				return false;
			}
			if (_tokenType == JsonTokenType.StartObject || _tokenType == JsonTokenType.StartArray)
			{
				_isNotPrimitive = true;
			}
			break;
		}
		}
		return true;
	}

	private void SkipWhiteSpace()
	{
		ReadOnlySpan<byte> buffer = _buffer;
		while (_consumed < buffer.Length)
		{
			byte b = buffer[_consumed];
			if (b == 32 || b == 13 || b == 10 || b == 9)
			{
				if (b == 10)
				{
					_lineNumber++;
					_bytePositionInLine = 0L;
				}
				else
				{
					_bytePositionInLine++;
				}
				_consumed++;
				continue;
			}
			break;
		}
	}

	private bool ConsumeValue(byte P_0)
	{
		while (true)
		{
			_trailingCommaBeforeComment = false;
			switch (P_0)
			{
			case 34:
				return ConsumeString();
			case 123:
				StartObject();
				break;
			case 91:
				StartArray();
				break;
			default:
				if (JsonHelpers.IsDigit(P_0) || P_0 == 45)
				{
					return ConsumeNumber();
				}
				switch (P_0)
				{
				case 102:
					return ConsumeLiteral(JsonConstants.FalseValue, JsonTokenType.False);
				case 116:
					return ConsumeLiteral(JsonConstants.TrueValue, JsonTokenType.True);
				case 110:
					return ConsumeLiteral(JsonConstants.NullValue, JsonTokenType.Null);
				}
				switch (_readerOptions.CommentHandling)
				{
				case JsonCommentHandling.Allow:
					if (P_0 == 47)
					{
						return ConsumeComment();
					}
					break;
				default:
					if (P_0 != 47)
					{
						break;
					}
					if (SkipComment())
					{
						if (_consumed >= (uint)_buffer.Length)
						{
							if (_isNotPrimitive && IsLastSpan && _tokenType != JsonTokenType.EndArray && _tokenType != JsonTokenType.EndObject)
							{
								ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.InvalidEndOfJsonNonPrimitive, 0);
							}
							return false;
						}
						P_0 = _buffer[_consumed];
						if (P_0 <= 32)
						{
							SkipWhiteSpace();
							if (!HasMoreData())
							{
								return false;
							}
							P_0 = _buffer[_consumed];
						}
						goto IL_0140;
					}
					return false;
				case JsonCommentHandling.Disallow:
					break;
				}
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfValueNotFound, P_0);
				break;
			}
			break;
			IL_0140:
			TokenStartIndex = _consumed;
		}
		return true;
	}

	private bool ConsumeLiteral(ReadOnlySpan<byte> P_0, JsonTokenType P_1)
	{
		ReadOnlySpan<byte> readOnlySpan = _buffer.Slice(_consumed);
		if (!readOnlySpan.StartsWith(P_0))
		{
			return CheckLiteral(readOnlySpan, P_0);
		}
		ValueSpan = readOnlySpan.Slice(0, P_0.Length);
		_tokenType = P_1;
		_consumed += P_0.Length;
		_bytePositionInLine += P_0.Length;
		return true;
	}

	private bool CheckLiteral(ReadOnlySpan<byte> P_0, ReadOnlySpan<byte> P_1)
	{
		int num = 0;
		for (int i = 1; i < P_1.Length; i++)
		{
			if (P_0.Length > i)
			{
				if (P_0[i] != P_1[i])
				{
					_bytePositionInLine += i;
					ThrowInvalidLiteral(P_0);
				}
				continue;
			}
			num = i;
			break;
		}
		if (IsLastSpan)
		{
			_bytePositionInLine += num;
			ThrowInvalidLiteral(P_0);
		}
		return false;
	}

	private void ThrowInvalidLiteral(ReadOnlySpan<byte> P_0)
	{
		ThrowHelper.ThrowJsonReaderException(ref this, P_0[0] switch
		{
			116 => ExceptionResource.ExpectedTrue, 
			102 => ExceptionResource.ExpectedFalse, 
			_ => ExceptionResource.ExpectedNull, 
		}, 0, P_0);
	}

	private bool ConsumeNumber()
	{
		if (!TryGetNumber(_buffer.Slice(_consumed), out var num))
		{
			return false;
		}
		_tokenType = JsonTokenType.Number;
		_consumed += num;
		_bytePositionInLine += num;
		if (_consumed >= (uint)_buffer.Length && _isNotPrimitive)
		{
			ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedEndOfDigitNotFound, _buffer[_consumed - 1]);
		}
		return true;
	}

	private bool ConsumePropertyName()
	{
		_trailingCommaBeforeComment = false;
		if (!ConsumeString())
		{
			return false;
		}
		if (!HasMoreData(ExceptionResource.ExpectedValueAfterPropertyNameNotFound))
		{
			return false;
		}
		byte b = _buffer[_consumed];
		if (b <= 32)
		{
			SkipWhiteSpace();
			if (!HasMoreData(ExceptionResource.ExpectedValueAfterPropertyNameNotFound))
			{
				return false;
			}
			b = _buffer[_consumed];
		}
		if (b != 58)
		{
			ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedSeparatorAfterPropertyNameNotFound, b);
		}
		_consumed++;
		_bytePositionInLine++;
		_tokenType = JsonTokenType.PropertyName;
		return true;
	}

	private bool ConsumeString()
	{
		ReadOnlySpan<byte> readOnlySpan = _buffer.Slice(_consumed + 1);
		int num = readOnlySpan.IndexOfQuoteOrAnyControlOrBackSlash();
		if (num >= 0)
		{
			byte b = readOnlySpan[num];
			if (b == 34)
			{
				_bytePositionInLine += num + 2;
				ValueSpan = readOnlySpan.Slice(0, num);
				ValueIsEscaped = false;
				_tokenType = JsonTokenType.String;
				_consumed += num + 2;
				return true;
			}
			return ConsumeStringAndValidate(readOnlySpan, num);
		}
		if (IsLastSpan)
		{
			_bytePositionInLine += readOnlySpan.Length + 1;
			ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.EndOfStringNotFound, 0);
		}
		return false;
	}

	private bool ConsumeStringAndValidate(ReadOnlySpan<byte> P_0, int P_1)
	{
		long bytePositionInLine = _bytePositionInLine;
		long lineNumber = _lineNumber;
		_bytePositionInLine += P_1 + 1;
		bool flag = false;
		while (true)
		{
			if (P_1 < P_0.Length)
			{
				byte b = P_0[P_1];
				if (b == 34)
				{
					if (!flag)
					{
						break;
					}
					flag = false;
				}
				else if (b == 92)
				{
					flag = !flag;
				}
				else if (flag)
				{
					int num = JsonConstants.EscapableChars.IndexOf(b);
					if (num == -1)
					{
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.InvalidCharacterAfterEscapeWithinString, b);
					}
					if (b == 117)
					{
						_bytePositionInLine++;
						if (!ValidateHexDigits(P_0, P_1 + 1))
						{
							P_1 = P_0.Length;
							goto IL_00e5;
						}
						P_1 += 4;
					}
					flag = false;
				}
				else if (b < 32)
				{
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.InvalidCharacterWithinString, b);
				}
				_bytePositionInLine++;
				P_1++;
				continue;
			}
			goto IL_00e5;
			IL_00e5:
			if (P_1 < P_0.Length)
			{
				break;
			}
			if (IsLastSpan)
			{
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.EndOfStringNotFound, 0);
			}
			_lineNumber = lineNumber;
			_bytePositionInLine = bytePositionInLine;
			return false;
		}
		_bytePositionInLine++;
		ValueSpan = P_0.Slice(0, P_1);
		ValueIsEscaped = true;
		_tokenType = JsonTokenType.String;
		_consumed += P_1 + 2;
		return true;
	}

	private bool ValidateHexDigits(ReadOnlySpan<byte> P_0, int P_1)
	{
		for (int i = P_1; i < P_0.Length; i++)
		{
			byte b = P_0[i];
			if (!JsonReaderHelper.IsHexDigit(b))
			{
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.InvalidHexCharacterWithinString, b);
			}
			if (i - P_1 >= 3)
			{
				return true;
			}
			_bytePositionInLine++;
		}
		return false;
	}

	private bool TryGetNumber(ReadOnlySpan<byte> P_0, out int P_1)
	{
		P_1 = 0;
		int num = 0;
		ConsumeNumberResult consumeNumberResult = ConsumeNegativeSign(ref P_0, ref num);
		if (consumeNumberResult == ConsumeNumberResult.NeedMoreData)
		{
			return false;
		}
		byte b = P_0[num];
		if (b == 48)
		{
			ConsumeNumberResult consumeNumberResult2 = ConsumeZero(ref P_0, ref num);
			if (consumeNumberResult2 == ConsumeNumberResult.NeedMoreData)
			{
				return false;
			}
			if (consumeNumberResult2 != ConsumeNumberResult.Success)
			{
				b = P_0[num];
				goto IL_00a3;
			}
		}
		else
		{
			num++;
			ConsumeNumberResult consumeNumberResult3 = ConsumeIntegerDigits(ref P_0, ref num);
			if (consumeNumberResult3 == ConsumeNumberResult.NeedMoreData)
			{
				return false;
			}
			if (consumeNumberResult3 != ConsumeNumberResult.Success)
			{
				b = P_0[num];
				if (b != 46 && b != 69 && b != 101)
				{
					_bytePositionInLine += num;
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedEndOfDigitNotFound, b);
				}
				goto IL_00a3;
			}
		}
		goto IL_0152;
		IL_00a3:
		if (b == 46)
		{
			num++;
			ConsumeNumberResult consumeNumberResult4 = ConsumeDecimalDigits(ref P_0, ref num);
			if (consumeNumberResult4 == ConsumeNumberResult.NeedMoreData)
			{
				return false;
			}
			if (consumeNumberResult4 == ConsumeNumberResult.Success)
			{
				goto IL_0152;
			}
			b = P_0[num];
			if (b != 69 && b != 101)
			{
				_bytePositionInLine += num;
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedNextDigitEValueNotFound, b);
			}
		}
		num++;
		consumeNumberResult = ConsumeSign(ref P_0, ref num);
		if (consumeNumberResult == ConsumeNumberResult.NeedMoreData)
		{
			return false;
		}
		num++;
		switch (ConsumeIntegerDigits(ref P_0, ref num))
		{
		case ConsumeNumberResult.NeedMoreData:
			return false;
		default:
			_bytePositionInLine += num;
			ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedEndOfDigitNotFound, P_0[num]);
			break;
		case ConsumeNumberResult.Success:
			break;
		}
		goto IL_0152;
		IL_0152:
		ValueSpan = P_0.Slice(0, num);
		P_1 = num;
		return true;
	}

	private ConsumeNumberResult ConsumeNegativeSign(ref ReadOnlySpan<byte> P_0, scoped ref int P_1)
	{
		byte b = P_0[P_1];
		if (b == 45)
		{
			P_1++;
			if (P_1 >= P_0.Length)
			{
				if (IsLastSpan)
				{
					_bytePositionInLine += P_1;
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundEndOfData, 0);
				}
				return ConsumeNumberResult.NeedMoreData;
			}
			b = P_0[P_1];
			if (!JsonHelpers.IsDigit(b))
			{
				_bytePositionInLine += P_1;
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundAfterSign, b);
			}
		}
		return ConsumeNumberResult.OperationIncomplete;
	}

	private ConsumeNumberResult ConsumeZero(ref ReadOnlySpan<byte> P_0, scoped ref int P_1)
	{
		P_1++;
		if (P_1 < P_0.Length)
		{
			byte b = P_0[P_1];
			if (JsonConstants.Delimiters.IndexOf(b) >= 0)
			{
				return ConsumeNumberResult.Success;
			}
			b = P_0[P_1];
			if (b != 46 && b != 69 && b != 101)
			{
				_bytePositionInLine += P_1;
				ThrowHelper.ThrowJsonReaderException(ref this, JsonHelpers.IsInRangeInclusive(b, 48, 57) ? ExceptionResource.InvalidLeadingZeroInNumber : ExceptionResource.ExpectedEndOfDigitNotFound, b);
			}
			return ConsumeNumberResult.OperationIncomplete;
		}
		if (IsLastSpan)
		{
			return ConsumeNumberResult.Success;
		}
		return ConsumeNumberResult.NeedMoreData;
	}

	private ConsumeNumberResult ConsumeIntegerDigits(ref ReadOnlySpan<byte> P_0, scoped ref int P_1)
	{
		byte b = 0;
		while (P_1 < P_0.Length)
		{
			b = P_0[P_1];
			if (!JsonHelpers.IsDigit(b))
			{
				break;
			}
			P_1++;
		}
		if (P_1 >= P_0.Length)
		{
			if (IsLastSpan)
			{
				return ConsumeNumberResult.Success;
			}
			return ConsumeNumberResult.NeedMoreData;
		}
		if (JsonConstants.Delimiters.IndexOf(b) >= 0)
		{
			return ConsumeNumberResult.Success;
		}
		return ConsumeNumberResult.OperationIncomplete;
	}

	private ConsumeNumberResult ConsumeDecimalDigits(ref ReadOnlySpan<byte> P_0, scoped ref int P_1)
	{
		if (P_1 >= P_0.Length)
		{
			if (IsLastSpan)
			{
				_bytePositionInLine += P_1;
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundEndOfData, 0);
			}
			return ConsumeNumberResult.NeedMoreData;
		}
		byte b = P_0[P_1];
		if (!JsonHelpers.IsDigit(b))
		{
			_bytePositionInLine += P_1;
			ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundAfterDecimal, b);
		}
		P_1++;
		return ConsumeIntegerDigits(ref P_0, ref P_1);
	}

	private ConsumeNumberResult ConsumeSign(ref ReadOnlySpan<byte> P_0, scoped ref int P_1)
	{
		if (P_1 >= P_0.Length)
		{
			if (IsLastSpan)
			{
				_bytePositionInLine += P_1;
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundEndOfData, 0);
			}
			return ConsumeNumberResult.NeedMoreData;
		}
		byte b = P_0[P_1];
		if (b == 43 || b == 45)
		{
			P_1++;
			if (P_1 >= P_0.Length)
			{
				if (IsLastSpan)
				{
					_bytePositionInLine += P_1;
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundEndOfData, 0);
				}
				return ConsumeNumberResult.NeedMoreData;
			}
			b = P_0[P_1];
		}
		if (!JsonHelpers.IsDigit(b))
		{
			_bytePositionInLine += P_1;
			ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundAfterSign, b);
		}
		return ConsumeNumberResult.OperationIncomplete;
	}

	private bool ConsumeNextTokenOrRollback(byte P_0)
	{
		int consumed = _consumed;
		long bytePositionInLine = _bytePositionInLine;
		long lineNumber = _lineNumber;
		JsonTokenType tokenType = _tokenType;
		bool trailingCommaBeforeComment = _trailingCommaBeforeComment;
		switch (ConsumeNextToken(P_0))
		{
		case ConsumeTokenResult.Success:
			return true;
		case ConsumeTokenResult.NotEnoughDataRollBackState:
			_consumed = consumed;
			_tokenType = tokenType;
			_bytePositionInLine = bytePositionInLine;
			_lineNumber = lineNumber;
			_trailingCommaBeforeComment = trailingCommaBeforeComment;
			break;
		}
		return false;
	}

	private ConsumeTokenResult ConsumeNextToken(byte P_0)
	{
		if (_readerOptions.CommentHandling != JsonCommentHandling.Disallow)
		{
			if (_readerOptions.CommentHandling != JsonCommentHandling.Allow)
			{
				return ConsumeNextTokenUntilAfterAllCommentsAreSkipped(P_0);
			}
			if (P_0 == 47)
			{
				if (!ConsumeComment())
				{
					return ConsumeTokenResult.NotEnoughDataRollBackState;
				}
				return ConsumeTokenResult.Success;
			}
			if (_tokenType == JsonTokenType.Comment)
			{
				return ConsumeNextTokenFromLastNonCommentToken();
			}
		}
		if (_bitStack.CurrentDepth == 0)
		{
			ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedEndAfterSingleJson, P_0);
		}
		switch (P_0)
		{
		case 44:
		{
			_consumed++;
			_bytePositionInLine++;
			if (_consumed >= (uint)_buffer.Length)
			{
				if (IsLastSpan)
				{
					_consumed--;
					_bytePositionInLine--;
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyOrValueNotFound, 0);
				}
				return ConsumeTokenResult.NotEnoughDataRollBackState;
			}
			byte b = _buffer[_consumed];
			if (b <= 32)
			{
				SkipWhiteSpace();
				if (!HasMoreData(ExceptionResource.ExpectedStartOfPropertyOrValueNotFound))
				{
					return ConsumeTokenResult.NotEnoughDataRollBackState;
				}
				b = _buffer[_consumed];
			}
			TokenStartIndex = _consumed;
			if (_readerOptions.CommentHandling == JsonCommentHandling.Allow && b == 47)
			{
				_trailingCommaBeforeComment = true;
				if (!ConsumeComment())
				{
					return ConsumeTokenResult.NotEnoughDataRollBackState;
				}
				return ConsumeTokenResult.Success;
			}
			if (_inObject)
			{
				if (b != 34)
				{
					if (b == 125)
					{
						if (_readerOptions.AllowTrailingCommas)
						{
							EndObject();
							return ConsumeTokenResult.Success;
						}
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.TrailingCommaNotAllowedBeforeObjectEnd, 0);
					}
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyNotFound, b);
				}
				if (!ConsumePropertyName())
				{
					return ConsumeTokenResult.NotEnoughDataRollBackState;
				}
				return ConsumeTokenResult.Success;
			}
			if (b == 93)
			{
				if (_readerOptions.AllowTrailingCommas)
				{
					EndArray();
					return ConsumeTokenResult.Success;
				}
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.TrailingCommaNotAllowedBeforeArrayEnd, 0);
			}
			if (!ConsumeValue(b))
			{
				return ConsumeTokenResult.NotEnoughDataRollBackState;
			}
			return ConsumeTokenResult.Success;
		}
		case 125:
			EndObject();
			break;
		case 93:
			EndArray();
			break;
		default:
			ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.FoundInvalidCharacter, P_0);
			break;
		}
		return ConsumeTokenResult.Success;
	}

	private ConsumeTokenResult ConsumeNextTokenFromLastNonCommentToken()
	{
		if (JsonReaderHelper.IsTokenTypePrimitive(_previousTokenType))
		{
			_tokenType = (_inObject ? JsonTokenType.StartObject : JsonTokenType.StartArray);
		}
		else
		{
			_tokenType = _previousTokenType;
		}
		if (HasMoreData())
		{
			byte b = _buffer[_consumed];
			if (b <= 32)
			{
				SkipWhiteSpace();
				if (!HasMoreData())
				{
					goto IL_0343;
				}
				b = _buffer[_consumed];
			}
			if (_bitStack.CurrentDepth == 0 && _tokenType != JsonTokenType.None)
			{
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedEndAfterSingleJson, b);
			}
			TokenStartIndex = _consumed;
			if (b != 44)
			{
				if (b == 125)
				{
					EndObject();
				}
				else
				{
					if (b != 93)
					{
						if (_tokenType == JsonTokenType.None)
						{
							if (ReadFirstToken(b))
							{
								goto IL_0341;
							}
						}
						else if (_tokenType == JsonTokenType.StartObject)
						{
							if (b != 34)
							{
								ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyNotFound, b);
							}
							int consumed = _consumed;
							long bytePositionInLine = _bytePositionInLine;
							long lineNumber = _lineNumber;
							if (ConsumePropertyName())
							{
								goto IL_0341;
							}
							_consumed = consumed;
							_tokenType = JsonTokenType.StartObject;
							_bytePositionInLine = bytePositionInLine;
							_lineNumber = lineNumber;
						}
						else if (_tokenType == JsonTokenType.StartArray)
						{
							if (ConsumeValue(b))
							{
								goto IL_0341;
							}
						}
						else if (_tokenType == JsonTokenType.PropertyName)
						{
							if (ConsumeValue(b))
							{
								goto IL_0341;
							}
						}
						else if (_inObject)
						{
							if (b != 34)
							{
								ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyNotFound, b);
							}
							if (ConsumePropertyName())
							{
								goto IL_0341;
							}
						}
						else if (ConsumeValue(b))
						{
							goto IL_0341;
						}
						goto IL_0343;
					}
					EndArray();
				}
				goto IL_0341;
			}
			if ((int)_previousTokenType <= 1 || _previousTokenType == JsonTokenType.StartArray || _trailingCommaBeforeComment)
			{
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyOrValueAfterComment, b);
			}
			_consumed++;
			_bytePositionInLine++;
			if (_consumed >= (uint)_buffer.Length)
			{
				if (IsLastSpan)
				{
					_consumed--;
					_bytePositionInLine--;
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyOrValueNotFound, 0);
				}
			}
			else
			{
				b = _buffer[_consumed];
				if (b <= 32)
				{
					SkipWhiteSpace();
					if (!HasMoreData(ExceptionResource.ExpectedStartOfPropertyOrValueNotFound))
					{
						goto IL_0343;
					}
					b = _buffer[_consumed];
				}
				TokenStartIndex = _consumed;
				if (b == 47)
				{
					_trailingCommaBeforeComment = true;
					if (ConsumeComment())
					{
						goto IL_0341;
					}
				}
				else if (_inObject)
				{
					if (b != 34)
					{
						if (b == 125)
						{
							if (_readerOptions.AllowTrailingCommas)
							{
								EndObject();
								goto IL_0341;
							}
							ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.TrailingCommaNotAllowedBeforeObjectEnd, 0);
						}
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyNotFound, b);
					}
					if (ConsumePropertyName())
					{
						goto IL_0341;
					}
				}
				else
				{
					if (b == 93)
					{
						if (_readerOptions.AllowTrailingCommas)
						{
							EndArray();
							goto IL_0341;
						}
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.TrailingCommaNotAllowedBeforeArrayEnd, 0);
					}
					if (ConsumeValue(b))
					{
						goto IL_0341;
					}
				}
			}
		}
		goto IL_0343;
		IL_0343:
		return ConsumeTokenResult.NotEnoughDataRollBackState;
		IL_0341:
		return ConsumeTokenResult.Success;
	}

	private bool SkipAllComments(scoped ref byte P_0)
	{
		while (true)
		{
			if (P_0 == 47)
			{
				if (!SkipComment() || !HasMoreData())
				{
					break;
				}
				P_0 = _buffer[_consumed];
				if (P_0 <= 32)
				{
					SkipWhiteSpace();
					if (!HasMoreData())
					{
						break;
					}
					P_0 = _buffer[_consumed];
				}
				continue;
			}
			return true;
		}
		return false;
	}

	private bool SkipAllComments(scoped ref byte P_0, ExceptionResource P_1)
	{
		while (true)
		{
			if (P_0 == 47)
			{
				if (!SkipComment() || !HasMoreData(P_1))
				{
					break;
				}
				P_0 = _buffer[_consumed];
				if (P_0 <= 32)
				{
					SkipWhiteSpace();
					if (!HasMoreData(P_1))
					{
						break;
					}
					P_0 = _buffer[_consumed];
				}
				continue;
			}
			return true;
		}
		return false;
	}

	private ConsumeTokenResult ConsumeNextTokenUntilAfterAllCommentsAreSkipped(byte P_0)
	{
		if (SkipAllComments(ref P_0))
		{
			TokenStartIndex = _consumed;
			if (_tokenType == JsonTokenType.StartObject)
			{
				if (P_0 == 125)
				{
					EndObject();
				}
				else
				{
					if (P_0 != 34)
					{
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyNotFound, P_0);
					}
					int consumed = _consumed;
					long bytePositionInLine = _bytePositionInLine;
					long lineNumber = _lineNumber;
					if (!ConsumePropertyName())
					{
						_consumed = consumed;
						_tokenType = JsonTokenType.StartObject;
						_bytePositionInLine = bytePositionInLine;
						_lineNumber = lineNumber;
						goto IL_0281;
					}
				}
			}
			else if (_tokenType == JsonTokenType.StartArray)
			{
				if (P_0 == 93)
				{
					EndArray();
				}
				else if (!ConsumeValue(P_0))
				{
					goto IL_0281;
				}
			}
			else if (_tokenType == JsonTokenType.PropertyName)
			{
				if (!ConsumeValue(P_0))
				{
					goto IL_0281;
				}
			}
			else if (_bitStack.CurrentDepth == 0)
			{
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedEndAfterSingleJson, P_0);
			}
			else
			{
				switch (P_0)
				{
				case 44:
					_consumed++;
					_bytePositionInLine++;
					if (_consumed >= (uint)_buffer.Length)
					{
						if (IsLastSpan)
						{
							_consumed--;
							_bytePositionInLine--;
							ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyOrValueNotFound, 0);
						}
						return ConsumeTokenResult.NotEnoughDataRollBackState;
					}
					P_0 = _buffer[_consumed];
					if (P_0 <= 32)
					{
						SkipWhiteSpace();
						if (!HasMoreData(ExceptionResource.ExpectedStartOfPropertyOrValueNotFound))
						{
							return ConsumeTokenResult.NotEnoughDataRollBackState;
						}
						P_0 = _buffer[_consumed];
					}
					if (SkipAllComments(ref P_0, ExceptionResource.ExpectedStartOfPropertyOrValueNotFound))
					{
						TokenStartIndex = _consumed;
						if (_inObject)
						{
							if (P_0 != 34)
							{
								if (P_0 == 125)
								{
									if (_readerOptions.AllowTrailingCommas)
									{
										EndObject();
										break;
									}
									ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.TrailingCommaNotAllowedBeforeObjectEnd, 0);
								}
								ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyNotFound, P_0);
							}
							if (!ConsumePropertyName())
							{
								return ConsumeTokenResult.NotEnoughDataRollBackState;
							}
							return ConsumeTokenResult.Success;
						}
						if (P_0 == 93)
						{
							if (_readerOptions.AllowTrailingCommas)
							{
								EndArray();
								break;
							}
							ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.TrailingCommaNotAllowedBeforeArrayEnd, 0);
						}
						if (!ConsumeValue(P_0))
						{
							return ConsumeTokenResult.NotEnoughDataRollBackState;
						}
						return ConsumeTokenResult.Success;
					}
					return ConsumeTokenResult.NotEnoughDataRollBackState;
				case 125:
					EndObject();
					break;
				case 93:
					EndArray();
					break;
				default:
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.FoundInvalidCharacter, P_0);
					break;
				}
			}
			return ConsumeTokenResult.Success;
		}
		goto IL_0281;
		IL_0281:
		return ConsumeTokenResult.IncompleteNoRollBackNecessary;
	}

	private bool SkipComment()
	{
		ReadOnlySpan<byte> readOnlySpan = _buffer.Slice(_consumed + 1);
		if (readOnlySpan.Length > 0)
		{
			int num;
			switch (readOnlySpan[0])
			{
			case 47:
				return SkipSingleLineComment(readOnlySpan.Slice(1), out num);
			case 42:
				return SkipMultiLineComment(readOnlySpan.Slice(1), out num);
			}
			ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfValueNotFound, 47);
		}
		if (IsLastSpan)
		{
			ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfValueNotFound, 47);
		}
		return false;
	}

	private bool SkipSingleLineComment(ReadOnlySpan<byte> P_0, out int P_1)
	{
		P_1 = FindLineSeparator(P_0);
		int num;
		if (P_1 != -1)
		{
			num = P_1;
			if (P_0[P_1] != 10)
			{
				if (P_1 < P_0.Length - 1)
				{
					if (P_0[P_1 + 1] == 10)
					{
						num++;
					}
				}
				else if (!IsLastSpan)
				{
					return false;
				}
			}
			num++;
			_bytePositionInLine = 0L;
			_lineNumber++;
		}
		else
		{
			if (!IsLastSpan)
			{
				return false;
			}
			P_1 = P_0.Length;
			num = P_1;
			_bytePositionInLine += 2 + P_0.Length;
		}
		_consumed += 2 + num;
		return true;
	}

	private int FindLineSeparator(ReadOnlySpan<byte> P_0)
	{
		int num = 0;
		while (true)
		{
			int num2 = P_0.IndexOfAny<byte>(10, 13, 226);
			if (num2 == -1)
			{
				return -1;
			}
			num += num2;
			if (P_0[num2] != 226)
			{
				break;
			}
			num++;
			P_0 = P_0.Slice(num2 + 1);
			ThrowOnDangerousLineSeparator(P_0);
		}
		return num;
	}

	private void ThrowOnDangerousLineSeparator(ReadOnlySpan<byte> P_0)
	{
		if (P_0.Length >= 2)
		{
			byte b = P_0[1];
			if (P_0[0] == 128 && (b == 168 || b == 169))
			{
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.UnexpectedEndOfLineSeparator, 0);
			}
		}
	}

	private bool SkipMultiLineComment(ReadOnlySpan<byte> P_0, out int P_1)
	{
		P_1 = 0;
		while (true)
		{
			int num = P_0.Slice(P_1).IndexOf<byte>(47);
			switch (num)
			{
			case -1:
				if (IsLastSpan)
				{
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.EndOfCommentNotFound, 0);
				}
				return false;
			default:
				if (P_0[num + P_1 - 1] == 42)
				{
					P_1 += num - 1;
					_consumed += 4 + P_1;
					var (num2, num3) = JsonReaderHelper.CountNewLines(P_0.Slice(0, P_1));
					_lineNumber += num2;
					if (num3 != -1)
					{
						_bytePositionInLine = P_1 - num3 + 1;
					}
					else
					{
						_bytePositionInLine += 4 + P_1;
					}
					return true;
				}
				break;
			case 0:
				break;
			}
			P_1 += num + 1;
		}
	}

	private bool ConsumeComment()
	{
		ReadOnlySpan<byte> readOnlySpan = _buffer.Slice(_consumed + 1);
		if (readOnlySpan.Length > 0)
		{
			byte b = readOnlySpan[0];
			switch (b)
			{
			case 47:
				return ConsumeSingleLineComment(readOnlySpan.Slice(1), _consumed);
			case 42:
				return ConsumeMultiLineComment(readOnlySpan.Slice(1), _consumed);
			}
			ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.InvalidCharacterAtStartOfComment, b);
		}
		if (IsLastSpan)
		{
			ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.UnexpectedEndOfDataWhileReadingComment, 0);
		}
		return false;
	}

	private bool ConsumeSingleLineComment(ReadOnlySpan<byte> P_0, int P_1)
	{
		if (!SkipSingleLineComment(P_0, out var num))
		{
			return false;
		}
		ValueSpan = _buffer.Slice(P_1 + 2, num);
		if (_tokenType != JsonTokenType.Comment)
		{
			_previousTokenType = _tokenType;
		}
		_tokenType = JsonTokenType.Comment;
		return true;
	}

	private bool ConsumeMultiLineComment(ReadOnlySpan<byte> P_0, int P_1)
	{
		if (!SkipMultiLineComment(P_0, out var num))
		{
			return false;
		}
		ValueSpan = _buffer.Slice(P_1 + 2, num);
		if (_tokenType != JsonTokenType.Comment)
		{
			_previousTokenType = _tokenType;
		}
		_tokenType = JsonTokenType.Comment;
		return true;
	}

	private ReadOnlySpan<byte> GetUnescapedSpan()
	{
		ReadOnlySpan<byte> readOnlySpan = (HasValueSequence ? ((ReadOnlySpan<byte>)ValueSequence.ToArray<byte>()) : ValueSpan);
		if (ValueIsEscaped)
		{
			readOnlySpan = JsonReaderHelper.GetUnescapedSpan(readOnlySpan);
		}
		return readOnlySpan;
	}

	public Utf8JsonReader(ReadOnlySequence<byte> P_0, bool P_1, JsonReaderState P_2)
	{
		ReadOnlyMemory<byte> first = P_0.First;
		_buffer = first.Span;
		_isFinalBlock = P_1;
		_isInputSequence = true;
		_lineNumber = P_2._lineNumber;
		_bytePositionInLine = P_2._bytePositionInLine;
		_inObject = P_2._inObject;
		_isNotPrimitive = P_2._isNotPrimitive;
		ValueIsEscaped = P_2._valueIsEscaped;
		_trailingCommaBeforeComment = P_2._trailingCommaBeforeComment;
		_tokenType = P_2._tokenType;
		_previousTokenType = P_2._previousTokenType;
		_readerOptions = P_2._readerOptions;
		if (_readerOptions.MaxDepth == 0)
		{
			_readerOptions.MaxDepth = 64;
		}
		_bitStack = P_2._bitStack;
		_consumed = 0;
		TokenStartIndex = 0L;
		_totalConsumed = 0L;
		ValueSpan = ReadOnlySpan<byte>.Empty;
		_sequence = P_0;
		HasValueSequence = false;
		ValueSequence = ReadOnlySequence<byte>.Empty;
		if (P_0.IsSingleSegment)
		{
			_nextPosition = default(SequencePosition);
			_currentPosition = P_0.Start;
			_isLastSegment = P_1;
			_isMultiSegment = false;
			return;
		}
		_currentPosition = P_0.Start;
		_nextPosition = _currentPosition;
		bool flag = _buffer.Length == 0;
		if (flag)
		{
			SequencePosition nextPosition = _nextPosition;
			ReadOnlyMemory<byte> readOnlyMemory;
			while (P_0.TryGet(ref _nextPosition, out readOnlyMemory))
			{
				_currentPosition = nextPosition;
				if (readOnlyMemory.Length != 0)
				{
					_buffer = readOnlyMemory.Span;
					break;
				}
				nextPosition = _nextPosition;
			}
		}
		_isLastSegment = !P_0.TryGet(ref _nextPosition, out first, !flag) && P_1;
		_isMultiSegment = true;
	}

	public Utf8JsonReader(ReadOnlySequence<byte> P_0, JsonReaderOptions P_1 = default(JsonReaderOptions))
		: this(P_0, true, new JsonReaderState(P_1))
	{
	}

	private bool ReadMultiSegment()
	{
		bool flag = false;
		HasValueSequence = false;
		ValueIsEscaped = false;
		ValueSpan = default(ReadOnlySpan<byte>);
		ValueSequence = default(ReadOnlySequence<byte>);
		if (HasMoreDataMultiSegment())
		{
			byte b = _buffer[_consumed];
			if (b <= 32)
			{
				SkipWhiteSpaceMultiSegment();
				if (!HasMoreDataMultiSegment())
				{
					goto IL_0173;
				}
				b = _buffer[_consumed];
			}
			TokenStartIndex = BytesConsumed;
			if (_tokenType != JsonTokenType.None)
			{
				if (b == 47)
				{
					flag = ConsumeNextTokenOrRollbackMultiSegment(b);
				}
				else if (_tokenType == JsonTokenType.StartObject)
				{
					if (b == 125)
					{
						EndObject();
						goto IL_0171;
					}
					if (b != 34)
					{
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyNotFound, b);
					}
					long totalConsumed = _totalConsumed;
					int consumed = _consumed;
					long bytePositionInLine = _bytePositionInLine;
					long lineNumber = _lineNumber;
					SequencePosition currentPosition = _currentPosition;
					flag = ConsumePropertyNameMultiSegment();
					if (!flag)
					{
						_consumed = consumed;
						_tokenType = JsonTokenType.StartObject;
						_bytePositionInLine = bytePositionInLine;
						_lineNumber = lineNumber;
						_totalConsumed = totalConsumed;
						_currentPosition = currentPosition;
					}
				}
				else if (_tokenType != JsonTokenType.StartArray)
				{
					flag = ((_tokenType != JsonTokenType.PropertyName) ? ConsumeNextTokenOrRollbackMultiSegment(b) : ConsumeValueMultiSegment(b));
				}
				else
				{
					if (b == 93)
					{
						EndArray();
						goto IL_0171;
					}
					flag = ConsumeValueMultiSegment(b);
				}
			}
			else
			{
				flag = ReadFirstTokenMultiSegment(b);
			}
		}
		goto IL_0173;
		IL_0173:
		return flag;
		IL_0171:
		flag = true;
		goto IL_0173;
	}

	private bool ValidateStateAtEndOfData()
	{
		if (_bitStack.CurrentDepth != 0)
		{
			ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ZeroDepthAtEnd, 0);
		}
		if (_readerOptions.CommentHandling == JsonCommentHandling.Allow && _tokenType == JsonTokenType.Comment)
		{
			return false;
		}
		if (_tokenType != JsonTokenType.EndArray && _tokenType != JsonTokenType.EndObject)
		{
			ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.InvalidEndOfJsonNonPrimitive, 0);
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private bool HasMoreDataMultiSegment()
	{
		if (_consumed >= (uint)_buffer.Length)
		{
			if (_isNotPrimitive && IsLastSpan && !ValidateStateAtEndOfData())
			{
				return false;
			}
			if (!GetNextSpan())
			{
				if (_isNotPrimitive && IsLastSpan)
				{
					ValidateStateAtEndOfData();
				}
				return false;
			}
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private bool HasMoreDataMultiSegment(ExceptionResource P_0)
	{
		if (_consumed >= (uint)_buffer.Length)
		{
			if (IsLastSpan)
			{
				ThrowHelper.ThrowJsonReaderException(ref this, P_0, 0);
			}
			if (!GetNextSpan())
			{
				if (IsLastSpan)
				{
					ThrowHelper.ThrowJsonReaderException(ref this, P_0, 0);
				}
				return false;
			}
		}
		return true;
	}

	private bool GetNextSpan()
	{
		ReadOnlyMemory<byte> readOnlyMemory;
		while (true)
		{
			SequencePosition currentPosition = _currentPosition;
			_currentPosition = _nextPosition;
			if (!_sequence.TryGet(ref _nextPosition, out readOnlyMemory))
			{
				_currentPosition = currentPosition;
				_isLastSegment = true;
				return false;
			}
			if (readOnlyMemory.Length != 0)
			{
				break;
			}
			_currentPosition = currentPosition;
		}
		if (_isFinalBlock)
		{
			_isLastSegment = !_sequence.TryGet(ref _nextPosition, out var _, false);
		}
		_buffer = readOnlyMemory.Span;
		_totalConsumed += _consumed;
		_consumed = 0;
		return true;
	}

	private bool ReadFirstTokenMultiSegment(byte P_0)
	{
		switch (P_0)
		{
		case 123:
			_bitStack.SetFirstBit();
			_tokenType = JsonTokenType.StartObject;
			ValueSpan = _buffer.Slice(_consumed, 1);
			_consumed++;
			_bytePositionInLine++;
			_inObject = true;
			_isNotPrimitive = true;
			break;
		case 91:
			_bitStack.ResetFirstBit();
			_tokenType = JsonTokenType.StartArray;
			ValueSpan = _buffer.Slice(_consumed, 1);
			_consumed++;
			_bytePositionInLine++;
			_isNotPrimitive = true;
			break;
		default:
			if (JsonHelpers.IsDigit(P_0) || P_0 == 45)
			{
				if (!TryGetNumberMultiSegment(_buffer.Slice(_consumed), out var num))
				{
					return false;
				}
				_tokenType = JsonTokenType.Number;
				_consumed += num;
				return true;
			}
			if (!ConsumeValueMultiSegment(P_0))
			{
				return false;
			}
			if (_tokenType == JsonTokenType.StartObject || _tokenType == JsonTokenType.StartArray)
			{
				_isNotPrimitive = true;
			}
			break;
		}
		return true;
	}

	private void SkipWhiteSpaceMultiSegment()
	{
		do
		{
			SkipWhiteSpace();
		}
		while (_consumed >= _buffer.Length && GetNextSpan());
	}

	private bool ConsumeValueMultiSegment(byte P_0)
	{
		while (true)
		{
			_trailingCommaBeforeComment = false;
			switch (P_0)
			{
			case 34:
				return ConsumeStringMultiSegment();
			case 123:
				StartObject();
				break;
			case 91:
				StartArray();
				break;
			default:
				if (JsonHelpers.IsDigit(P_0) || P_0 == 45)
				{
					return ConsumeNumberMultiSegment();
				}
				switch (P_0)
				{
				case 102:
					return ConsumeLiteralMultiSegment(JsonConstants.FalseValue, JsonTokenType.False);
				case 116:
					return ConsumeLiteralMultiSegment(JsonConstants.TrueValue, JsonTokenType.True);
				case 110:
					return ConsumeLiteralMultiSegment(JsonConstants.NullValue, JsonTokenType.Null);
				}
				switch (_readerOptions.CommentHandling)
				{
				case JsonCommentHandling.Allow:
					if (P_0 == 47)
					{
						SequencePosition currentPosition2 = _currentPosition;
						if (!SkipOrConsumeCommentMultiSegmentWithRollback())
						{
							_currentPosition = currentPosition2;
							return false;
						}
						return true;
					}
					break;
				default:
				{
					if (P_0 != 47)
					{
						break;
					}
					SequencePosition currentPosition = _currentPosition;
					if (SkipCommentMultiSegment(out var _))
					{
						if (_consumed >= (uint)_buffer.Length)
						{
							if (_isNotPrimitive && IsLastSpan && _tokenType != JsonTokenType.EndArray && _tokenType != JsonTokenType.EndObject)
							{
								ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.InvalidEndOfJsonNonPrimitive, 0);
							}
							if (!GetNextSpan())
							{
								if (_isNotPrimitive && IsLastSpan && _tokenType != JsonTokenType.EndArray && _tokenType != JsonTokenType.EndObject)
								{
									ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.InvalidEndOfJsonNonPrimitive, 0);
								}
								_currentPosition = currentPosition;
								return false;
							}
						}
						P_0 = _buffer[_consumed];
						if (P_0 <= 32)
						{
							SkipWhiteSpaceMultiSegment();
							if (!HasMoreDataMultiSegment())
							{
								_currentPosition = currentPosition;
								return false;
							}
							P_0 = _buffer[_consumed];
						}
						goto IL_01a8;
					}
					_currentPosition = currentPosition;
					return false;
				}
				case JsonCommentHandling.Disallow:
					break;
				}
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfValueNotFound, P_0);
				break;
			}
			break;
			IL_01a8:
			TokenStartIndex = BytesConsumed;
		}
		return true;
	}

	private bool ConsumeLiteralMultiSegment(ReadOnlySpan<byte> P_0, JsonTokenType P_1)
	{
		ReadOnlySpan<byte> readOnlySpan = _buffer.Slice(_consumed);
		int length = P_0.Length;
		if (!readOnlySpan.StartsWith(P_0))
		{
			int consumed = _consumed;
			if (!CheckLiteralMultiSegment(readOnlySpan, P_0, out length))
			{
				_consumed = consumed;
				return false;
			}
		}
		else
		{
			ValueSpan = readOnlySpan.Slice(0, P_0.Length);
			HasValueSequence = false;
		}
		_tokenType = P_1;
		_consumed += length;
		_bytePositionInLine += length;
		return true;
	}

	private bool CheckLiteralMultiSegment(ReadOnlySpan<byte> P_0, ReadOnlySpan<byte> P_1, out int P_2)
	{
		Span<byte> span = stackalloc byte[5];
		int num = 0;
		long totalConsumed = _totalConsumed;
		SequencePosition currentPosition = _currentPosition;
		if (P_0.Length >= P_1.Length || IsLastSpan)
		{
			_bytePositionInLine += FindMismatch(P_0, P_1);
			int num2 = Math.Min(P_0.Length, (int)_bytePositionInLine + 1);
			P_0.Slice(0, num2).CopyTo(span);
			num += num2;
		}
		else if (!P_1.StartsWith(P_0))
		{
			_bytePositionInLine += FindMismatch(P_0, P_1);
			int num3 = Math.Min(P_0.Length, (int)_bytePositionInLine + 1);
			P_0.Slice(0, num3).CopyTo(span);
			num += num3;
		}
		else
		{
			ReadOnlySpan<byte> readOnlySpan = P_1.Slice(P_0.Length);
			SequencePosition currentPosition2 = _currentPosition;
			int consumed = _consumed;
			int num4 = P_1.Length - readOnlySpan.Length;
			while (true)
			{
				_totalConsumed += num4;
				_bytePositionInLine += num4;
				if (!GetNextSpan())
				{
					_totalConsumed = totalConsumed;
					P_2 = 0;
					_currentPosition = currentPosition;
					if (IsLastSpan)
					{
						break;
					}
					return false;
				}
				int num5 = Math.Min(P_0.Length, span.Length - num);
				P_0.Slice(0, num5).CopyTo(span.Slice(num));
				num += num5;
				P_0 = _buffer;
				if (P_0.StartsWith(readOnlySpan))
				{
					HasValueSequence = true;
					SequencePosition sequencePosition = new SequencePosition(currentPosition2.GetObject(), currentPosition2.GetInteger() + consumed);
					SequencePosition sequencePosition2 = new SequencePosition(_currentPosition.GetObject(), _currentPosition.GetInteger() + readOnlySpan.Length);
					ValueSequence = _sequence.Slice(sequencePosition, sequencePosition2);
					P_2 = readOnlySpan.Length;
					return true;
				}
				if (!readOnlySpan.StartsWith(P_0))
				{
					_bytePositionInLine += FindMismatch(P_0, readOnlySpan);
					num5 = Math.Min(P_0.Length, (int)_bytePositionInLine + 1);
					P_0.Slice(0, num5).CopyTo(span.Slice(num));
					num += num5;
					break;
				}
				readOnlySpan = readOnlySpan.Slice(P_0.Length);
				num4 = P_0.Length;
			}
		}
		_totalConsumed = totalConsumed;
		P_2 = 0;
		_currentPosition = currentPosition;
		throw GetInvalidLiteralMultiSegment(span.Slice(0, num).ToArray());
	}

	private static int FindMismatch(ReadOnlySpan<byte> P_0, ReadOnlySpan<byte> P_1)
	{
		return P_0.CommonPrefixLength(P_1);
	}

	private JsonException GetInvalidLiteralMultiSegment(ReadOnlySpan<byte> P_0)
	{
		return ThrowHelper.GetJsonReaderException(ref this, P_0[0] switch
		{
			116 => ExceptionResource.ExpectedTrue, 
			102 => ExceptionResource.ExpectedFalse, 
			_ => ExceptionResource.ExpectedNull, 
		}, 0, P_0);
	}

	private bool ConsumeNumberMultiSegment()
	{
		if (!TryGetNumberMultiSegment(_buffer.Slice(_consumed), out var num))
		{
			return false;
		}
		_tokenType = JsonTokenType.Number;
		_consumed += num;
		if (_consumed >= (uint)_buffer.Length && _isNotPrimitive)
		{
			ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedEndOfDigitNotFound, _buffer[_consumed - 1]);
		}
		return true;
	}

	private bool ConsumePropertyNameMultiSegment()
	{
		_trailingCommaBeforeComment = false;
		if (!ConsumeStringMultiSegment())
		{
			return false;
		}
		if (!HasMoreDataMultiSegment(ExceptionResource.ExpectedValueAfterPropertyNameNotFound))
		{
			return false;
		}
		byte b = _buffer[_consumed];
		if (b <= 32)
		{
			SkipWhiteSpaceMultiSegment();
			if (!HasMoreDataMultiSegment(ExceptionResource.ExpectedValueAfterPropertyNameNotFound))
			{
				return false;
			}
			b = _buffer[_consumed];
		}
		if (b != 58)
		{
			ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedSeparatorAfterPropertyNameNotFound, b);
		}
		_consumed++;
		_bytePositionInLine++;
		_tokenType = JsonTokenType.PropertyName;
		return true;
	}

	private bool ConsumeStringMultiSegment()
	{
		ReadOnlySpan<byte> readOnlySpan = _buffer.Slice(_consumed + 1);
		int num = readOnlySpan.IndexOfQuoteOrAnyControlOrBackSlash();
		if (num >= 0)
		{
			byte b = readOnlySpan[num];
			if (b == 34)
			{
				_bytePositionInLine += num + 2;
				ValueSpan = readOnlySpan.Slice(0, num);
				HasValueSequence = false;
				ValueIsEscaped = false;
				_tokenType = JsonTokenType.String;
				_consumed += num + 2;
				return true;
			}
			return ConsumeStringAndValidateMultiSegment(readOnlySpan, num);
		}
		if (IsLastSpan)
		{
			_bytePositionInLine += readOnlySpan.Length + 1;
			ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.EndOfStringNotFound, 0);
		}
		return ConsumeStringNextSegment();
	}

	private bool ConsumeStringNextSegment()
	{
		PartialStateForRollback partialStateForRollback = CaptureState();
		HasValueSequence = true;
		int num = _buffer.Length - _consumed;
		ReadOnlySpan<byte> buffer;
		int num2;
		while (true)
		{
			if (!GetNextSpan())
			{
				if (IsLastSpan)
				{
					_bytePositionInLine += num;
					RollBackState(in partialStateForRollback, true);
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.EndOfStringNotFound, 0);
				}
				RollBackState(in partialStateForRollback);
				return false;
			}
			buffer = _buffer;
			num2 = buffer.IndexOfQuoteOrAnyControlOrBackSlash();
			if (num2 >= 0)
			{
				break;
			}
			_totalConsumed += buffer.Length;
			_bytePositionInLine += buffer.Length;
		}
		byte b = buffer[num2];
		SequencePosition sequencePosition;
		if (b == 34)
		{
			sequencePosition = new SequencePosition(_currentPosition.GetObject(), _currentPosition.GetInteger() + num2);
			_bytePositionInLine += num + num2 + 1;
			_totalConsumed += num;
			_consumed = num2 + 1;
			ValueIsEscaped = false;
		}
		else
		{
			_bytePositionInLine += num + num2;
			ValueIsEscaped = true;
			bool flag = false;
			while (true)
			{
				if (num2 < buffer.Length)
				{
					byte b2 = buffer[num2];
					if (b2 == 34)
					{
						if (!flag)
						{
							break;
						}
						flag = false;
					}
					else if (b2 == 92)
					{
						flag = !flag;
					}
					else if (flag)
					{
						int num3 = JsonConstants.EscapableChars.IndexOf(b2);
						if (num3 == -1)
						{
							RollBackState(in partialStateForRollback, true);
							ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.InvalidCharacterAfterEscapeWithinString, b2);
						}
						if (b2 == 117)
						{
							_bytePositionInLine++;
							int num4 = 0;
							int num5 = num2 + 1;
							while (true)
							{
								if (num5 < buffer.Length)
								{
									byte b3 = buffer[num5];
									if (!JsonReaderHelper.IsHexDigit(b3))
									{
										RollBackState(in partialStateForRollback, true);
										ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.InvalidHexCharacterWithinString, b3);
									}
									num4++;
									_bytePositionInLine++;
									if (num4 >= 4)
									{
										break;
									}
									num5++;
									continue;
								}
								if (!GetNextSpan())
								{
									if (IsLastSpan)
									{
										RollBackState(in partialStateForRollback, true);
										ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.EndOfStringNotFound, 0);
									}
									RollBackState(in partialStateForRollback);
									return false;
								}
								_totalConsumed += buffer.Length;
								buffer = _buffer;
								num5 = 0;
							}
							flag = false;
							num2 = num5 + 1;
							continue;
						}
						flag = false;
					}
					else if (b2 < 32)
					{
						RollBackState(in partialStateForRollback, true);
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.InvalidCharacterWithinString, b2);
					}
					_bytePositionInLine++;
					num2++;
					continue;
				}
				if (!GetNextSpan())
				{
					if (IsLastSpan)
					{
						RollBackState(in partialStateForRollback, true);
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.EndOfStringNotFound, 0);
					}
					RollBackState(in partialStateForRollback);
					return false;
				}
				_totalConsumed += buffer.Length;
				buffer = _buffer;
				num2 = 0;
			}
			_bytePositionInLine++;
			_consumed = num2 + 1;
			_totalConsumed += num;
			sequencePosition = new SequencePosition(_currentPosition.GetObject(), _currentPosition.GetInteger() + num2);
		}
		SequencePosition startPosition = partialStateForRollback.GetStartPosition(1);
		ValueSequence = _sequence.Slice(startPosition, sequencePosition);
		_tokenType = JsonTokenType.String;
		return true;
	}

	private bool ConsumeStringAndValidateMultiSegment(ReadOnlySpan<byte> P_0, int P_1)
	{
		PartialStateForRollback partialStateForRollback = CaptureState();
		HasValueSequence = false;
		int num = _buffer.Length - _consumed;
		_bytePositionInLine += P_1 + 1;
		bool flag = false;
		while (true)
		{
			if (P_1 < P_0.Length)
			{
				byte b = P_0[P_1];
				switch (b)
				{
				case 34:
					if (flag)
					{
						flag = false;
						goto IL_01b7;
					}
					if (HasValueSequence)
					{
						_bytePositionInLine++;
						_consumed = P_1 + 1;
						_totalConsumed += num;
						SequencePosition sequencePosition = new SequencePosition(_currentPosition.GetObject(), _currentPosition.GetInteger() + P_1);
						SequencePosition startPosition = partialStateForRollback.GetStartPosition(1);
						ValueSequence = _sequence.Slice(startPosition, sequencePosition);
					}
					else
					{
						_bytePositionInLine++;
						_consumed += P_1 + 2;
						ValueSpan = P_0.Slice(0, P_1);
					}
					ValueIsEscaped = true;
					_tokenType = JsonTokenType.String;
					return true;
				case 92:
					flag = !flag;
					goto IL_01b7;
				default:
					{
						if (flag)
						{
							int num2 = JsonConstants.EscapableChars.IndexOf(b);
							if (num2 == -1)
							{
								RollBackState(in partialStateForRollback, true);
								ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.InvalidCharacterAfterEscapeWithinString, b);
							}
							if (b == 117)
							{
								_bytePositionInLine++;
								int num3 = 0;
								int num4 = P_1 + 1;
								while (true)
								{
									if (num4 < P_0.Length)
									{
										byte b2 = P_0[num4];
										if (!JsonReaderHelper.IsHexDigit(b2))
										{
											RollBackState(in partialStateForRollback, true);
											ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.InvalidHexCharacterWithinString, b2);
										}
										num3++;
										_bytePositionInLine++;
										if (num3 >= 4)
										{
											break;
										}
										num4++;
										continue;
									}
									if (!GetNextSpan())
									{
										if (IsLastSpan)
										{
											RollBackState(in partialStateForRollback, true);
											ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.EndOfStringNotFound, 0);
										}
										RollBackState(in partialStateForRollback);
										return false;
									}
									if (HasValueSequence)
									{
										_totalConsumed += P_0.Length;
									}
									P_0 = _buffer;
									num4 = 0;
									HasValueSequence = true;
								}
								flag = false;
								P_1 = num4 + 1;
								break;
							}
							flag = false;
						}
						else if (b < 32)
						{
							RollBackState(in partialStateForRollback, true);
							ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.InvalidCharacterWithinString, b);
						}
						goto IL_01b7;
					}
					IL_01b7:
					_bytePositionInLine++;
					P_1++;
					break;
				}
			}
			else
			{
				if (!GetNextSpan())
				{
					break;
				}
				if (HasValueSequence)
				{
					_totalConsumed += P_0.Length;
				}
				P_0 = _buffer;
				P_1 = 0;
				HasValueSequence = true;
			}
		}
		if (IsLastSpan)
		{
			RollBackState(in partialStateForRollback, true);
			ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.EndOfStringNotFound, 0);
		}
		RollBackState(in partialStateForRollback);
		return false;
	}

	private void RollBackState(scoped in PartialStateForRollback P_0, bool P_1 = false)
	{
		_totalConsumed = P_0._prevTotalConsumed;
		if (!P_1)
		{
			_bytePositionInLine = P_0._prevBytePositionInLine;
		}
		_consumed = P_0._prevConsumed;
		_currentPosition = P_0._prevCurrentPosition;
	}

	private bool TryGetNumberMultiSegment(ReadOnlySpan<byte> P_0, out int P_1)
	{
		PartialStateForRollback partialStateForRollback = CaptureState();
		P_1 = 0;
		int num = 0;
		ConsumeNumberResult consumeNumberResult = ConsumeNegativeSignMultiSegment(ref P_0, ref num, in partialStateForRollback);
		if (consumeNumberResult == ConsumeNumberResult.NeedMoreData)
		{
			RollBackState(in partialStateForRollback);
			return false;
		}
		byte b = P_0[num];
		if (b == 48)
		{
			ConsumeNumberResult consumeNumberResult2 = ConsumeZeroMultiSegment(ref P_0, ref num, in partialStateForRollback);
			if (consumeNumberResult2 == ConsumeNumberResult.NeedMoreData)
			{
				RollBackState(in partialStateForRollback);
				return false;
			}
			if (consumeNumberResult2 != ConsumeNumberResult.Success)
			{
				b = P_0[num];
				goto IL_00bf;
			}
		}
		else
		{
			ConsumeNumberResult consumeNumberResult3 = ConsumeIntegerDigitsMultiSegment(ref P_0, ref num);
			if (consumeNumberResult3 == ConsumeNumberResult.NeedMoreData)
			{
				RollBackState(in partialStateForRollback);
				return false;
			}
			if (consumeNumberResult3 != ConsumeNumberResult.Success)
			{
				b = P_0[num];
				if (b != 46 && b != 69 && b != 101)
				{
					RollBackState(in partialStateForRollback, true);
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedEndOfDigitNotFound, b);
				}
				goto IL_00bf;
			}
		}
		goto IL_01b1;
		IL_00bf:
		if (b == 46)
		{
			num++;
			_bytePositionInLine++;
			ConsumeNumberResult consumeNumberResult4 = ConsumeDecimalDigitsMultiSegment(ref P_0, ref num, in partialStateForRollback);
			if (consumeNumberResult4 == ConsumeNumberResult.NeedMoreData)
			{
				RollBackState(in partialStateForRollback);
				return false;
			}
			if (consumeNumberResult4 == ConsumeNumberResult.Success)
			{
				goto IL_01b1;
			}
			b = P_0[num];
			if (b != 69 && b != 101)
			{
				RollBackState(in partialStateForRollback, true);
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedNextDigitEValueNotFound, b);
			}
		}
		num++;
		_bytePositionInLine++;
		consumeNumberResult = ConsumeSignMultiSegment(ref P_0, ref num, in partialStateForRollback);
		if (consumeNumberResult == ConsumeNumberResult.NeedMoreData)
		{
			RollBackState(in partialStateForRollback);
			return false;
		}
		num++;
		_bytePositionInLine++;
		switch (ConsumeIntegerDigitsMultiSegment(ref P_0, ref num))
		{
		case ConsumeNumberResult.NeedMoreData:
			RollBackState(in partialStateForRollback);
			return false;
		default:
			RollBackState(in partialStateForRollback, true);
			ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedEndOfDigitNotFound, P_0[num]);
			break;
		case ConsumeNumberResult.Success:
			break;
		}
		goto IL_01b1;
		IL_01b1:
		if (HasValueSequence)
		{
			SequencePosition startPosition = partialStateForRollback.GetStartPosition();
			SequencePosition sequencePosition = new SequencePosition(_currentPosition.GetObject(), _currentPosition.GetInteger() + num);
			ValueSequence = _sequence.Slice(startPosition, sequencePosition);
			P_1 = num;
		}
		else
		{
			ValueSpan = P_0.Slice(0, num);
			P_1 = num;
		}
		return true;
	}

	private ConsumeNumberResult ConsumeNegativeSignMultiSegment(ref ReadOnlySpan<byte> P_0, scoped ref int P_1, scoped in PartialStateForRollback P_2)
	{
		byte b = P_0[P_1];
		if (b == 45)
		{
			P_1++;
			_bytePositionInLine++;
			if (P_1 >= P_0.Length)
			{
				if (IsLastSpan)
				{
					RollBackState(in P_2, true);
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundEndOfData, 0);
				}
				if (!GetNextSpan())
				{
					if (IsLastSpan)
					{
						RollBackState(in P_2, true);
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundEndOfData, 0);
					}
					return ConsumeNumberResult.NeedMoreData;
				}
				_totalConsumed += P_1;
				HasValueSequence = true;
				P_1 = 0;
				P_0 = _buffer;
			}
			b = P_0[P_1];
			if (!JsonHelpers.IsDigit(b))
			{
				RollBackState(in P_2, true);
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundAfterSign, b);
			}
		}
		return ConsumeNumberResult.OperationIncomplete;
	}

	private ConsumeNumberResult ConsumeZeroMultiSegment(ref ReadOnlySpan<byte> P_0, scoped ref int P_1, scoped in PartialStateForRollback P_2)
	{
		P_1++;
		_bytePositionInLine++;
		byte b;
		if (P_1 < P_0.Length)
		{
			b = P_0[P_1];
			if (JsonConstants.Delimiters.IndexOf(b) >= 0)
			{
				return ConsumeNumberResult.Success;
			}
		}
		else
		{
			if (IsLastSpan)
			{
				return ConsumeNumberResult.Success;
			}
			if (!GetNextSpan())
			{
				if (IsLastSpan)
				{
					return ConsumeNumberResult.Success;
				}
				return ConsumeNumberResult.NeedMoreData;
			}
			_totalConsumed += P_1;
			HasValueSequence = true;
			P_1 = 0;
			P_0 = _buffer;
			b = P_0[P_1];
			if (JsonConstants.Delimiters.IndexOf(b) >= 0)
			{
				return ConsumeNumberResult.Success;
			}
		}
		b = P_0[P_1];
		if (b != 46 && b != 69 && b != 101)
		{
			RollBackState(in P_2, true);
			ThrowHelper.ThrowJsonReaderException(ref this, JsonHelpers.IsInRangeInclusive(b, 48, 57) ? ExceptionResource.InvalidLeadingZeroInNumber : ExceptionResource.ExpectedEndOfDigitNotFound, b);
		}
		return ConsumeNumberResult.OperationIncomplete;
	}

	private ConsumeNumberResult ConsumeIntegerDigitsMultiSegment(ref ReadOnlySpan<byte> P_0, scoped ref int P_1)
	{
		byte b = 0;
		int num = 0;
		while (P_1 < P_0.Length)
		{
			b = P_0[P_1];
			if (!JsonHelpers.IsDigit(b))
			{
				break;
			}
			num++;
			P_1++;
		}
		if (P_1 >= P_0.Length)
		{
			if (IsLastSpan)
			{
				_bytePositionInLine += num;
				return ConsumeNumberResult.Success;
			}
			while (true)
			{
				if (!GetNextSpan())
				{
					if (IsLastSpan)
					{
						_bytePositionInLine += num;
						return ConsumeNumberResult.Success;
					}
					return ConsumeNumberResult.NeedMoreData;
				}
				_totalConsumed += P_1;
				_bytePositionInLine += num;
				num = 0;
				HasValueSequence = true;
				P_1 = 0;
				P_0 = _buffer;
				while (P_1 < P_0.Length)
				{
					b = P_0[P_1];
					if (!JsonHelpers.IsDigit(b))
					{
						break;
					}
					P_1++;
				}
				_bytePositionInLine += P_1;
				if (P_1 < P_0.Length)
				{
					break;
				}
				if (IsLastSpan)
				{
					return ConsumeNumberResult.Success;
				}
			}
		}
		else
		{
			_bytePositionInLine += num;
		}
		if (JsonConstants.Delimiters.IndexOf(b) >= 0)
		{
			return ConsumeNumberResult.Success;
		}
		return ConsumeNumberResult.OperationIncomplete;
	}

	private ConsumeNumberResult ConsumeDecimalDigitsMultiSegment(ref ReadOnlySpan<byte> P_0, scoped ref int P_1, scoped in PartialStateForRollback P_2)
	{
		if (P_1 >= P_0.Length)
		{
			if (IsLastSpan)
			{
				RollBackState(in P_2, true);
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundEndOfData, 0);
			}
			if (!GetNextSpan())
			{
				if (IsLastSpan)
				{
					RollBackState(in P_2, true);
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundEndOfData, 0);
				}
				return ConsumeNumberResult.NeedMoreData;
			}
			_totalConsumed += P_1;
			HasValueSequence = true;
			P_1 = 0;
			P_0 = _buffer;
		}
		byte b = P_0[P_1];
		if (!JsonHelpers.IsDigit(b))
		{
			RollBackState(in P_2, true);
			ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundAfterDecimal, b);
		}
		P_1++;
		_bytePositionInLine++;
		return ConsumeIntegerDigitsMultiSegment(ref P_0, ref P_1);
	}

	private ConsumeNumberResult ConsumeSignMultiSegment(ref ReadOnlySpan<byte> P_0, scoped ref int P_1, scoped in PartialStateForRollback P_2)
	{
		if (P_1 >= P_0.Length)
		{
			if (IsLastSpan)
			{
				RollBackState(in P_2, true);
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundEndOfData, 0);
			}
			if (!GetNextSpan())
			{
				if (IsLastSpan)
				{
					RollBackState(in P_2, true);
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundEndOfData, 0);
				}
				return ConsumeNumberResult.NeedMoreData;
			}
			_totalConsumed += P_1;
			HasValueSequence = true;
			P_1 = 0;
			P_0 = _buffer;
		}
		byte b = P_0[P_1];
		if (b == 43 || b == 45)
		{
			P_1++;
			_bytePositionInLine++;
			if (P_1 >= P_0.Length)
			{
				if (IsLastSpan)
				{
					RollBackState(in P_2, true);
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundEndOfData, 0);
				}
				if (!GetNextSpan())
				{
					if (IsLastSpan)
					{
						RollBackState(in P_2, true);
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundEndOfData, 0);
					}
					return ConsumeNumberResult.NeedMoreData;
				}
				_totalConsumed += P_1;
				HasValueSequence = true;
				P_1 = 0;
				P_0 = _buffer;
			}
			b = P_0[P_1];
		}
		if (!JsonHelpers.IsDigit(b))
		{
			RollBackState(in P_2, true);
			ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.RequiredDigitNotFoundAfterSign, b);
		}
		return ConsumeNumberResult.OperationIncomplete;
	}

	private bool ConsumeNextTokenOrRollbackMultiSegment(byte P_0)
	{
		long totalConsumed = _totalConsumed;
		int consumed = _consumed;
		long bytePositionInLine = _bytePositionInLine;
		long lineNumber = _lineNumber;
		JsonTokenType tokenType = _tokenType;
		SequencePosition currentPosition = _currentPosition;
		bool trailingCommaBeforeComment = _trailingCommaBeforeComment;
		switch (ConsumeNextTokenMultiSegment(P_0))
		{
		case ConsumeTokenResult.Success:
			return true;
		case ConsumeTokenResult.NotEnoughDataRollBackState:
			_consumed = consumed;
			_tokenType = tokenType;
			_bytePositionInLine = bytePositionInLine;
			_lineNumber = lineNumber;
			_totalConsumed = totalConsumed;
			_currentPosition = currentPosition;
			_trailingCommaBeforeComment = trailingCommaBeforeComment;
			break;
		}
		return false;
	}

	private ConsumeTokenResult ConsumeNextTokenMultiSegment(byte P_0)
	{
		if (_readerOptions.CommentHandling != JsonCommentHandling.Disallow)
		{
			if (_readerOptions.CommentHandling != JsonCommentHandling.Allow)
			{
				return ConsumeNextTokenUntilAfterAllCommentsAreSkippedMultiSegment(P_0);
			}
			if (P_0 == 47)
			{
				if (!SkipOrConsumeCommentMultiSegmentWithRollback())
				{
					return ConsumeTokenResult.NotEnoughDataRollBackState;
				}
				return ConsumeTokenResult.Success;
			}
			if (_tokenType == JsonTokenType.Comment)
			{
				return ConsumeNextTokenFromLastNonCommentTokenMultiSegment();
			}
		}
		if (_bitStack.CurrentDepth == 0)
		{
			ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedEndAfterSingleJson, P_0);
		}
		switch (P_0)
		{
		case 44:
		{
			_consumed++;
			_bytePositionInLine++;
			if (_consumed >= (uint)_buffer.Length)
			{
				if (IsLastSpan)
				{
					_consumed--;
					_bytePositionInLine--;
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyOrValueNotFound, 0);
				}
				if (!GetNextSpan())
				{
					if (IsLastSpan)
					{
						_consumed--;
						_bytePositionInLine--;
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyOrValueNotFound, 0);
					}
					return ConsumeTokenResult.NotEnoughDataRollBackState;
				}
			}
			byte b = _buffer[_consumed];
			if (b <= 32)
			{
				SkipWhiteSpaceMultiSegment();
				if (!HasMoreDataMultiSegment(ExceptionResource.ExpectedStartOfPropertyOrValueNotFound))
				{
					return ConsumeTokenResult.NotEnoughDataRollBackState;
				}
				b = _buffer[_consumed];
			}
			TokenStartIndex = BytesConsumed;
			if (_readerOptions.CommentHandling == JsonCommentHandling.Allow && b == 47)
			{
				_trailingCommaBeforeComment = true;
				if (!SkipOrConsumeCommentMultiSegmentWithRollback())
				{
					return ConsumeTokenResult.NotEnoughDataRollBackState;
				}
				return ConsumeTokenResult.Success;
			}
			if (_inObject)
			{
				if (b != 34)
				{
					if (b == 125)
					{
						if (_readerOptions.AllowTrailingCommas)
						{
							EndObject();
							return ConsumeTokenResult.Success;
						}
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.TrailingCommaNotAllowedBeforeObjectEnd, 0);
					}
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyNotFound, b);
				}
				if (!ConsumePropertyNameMultiSegment())
				{
					return ConsumeTokenResult.NotEnoughDataRollBackState;
				}
				return ConsumeTokenResult.Success;
			}
			if (b == 93)
			{
				if (_readerOptions.AllowTrailingCommas)
				{
					EndArray();
					return ConsumeTokenResult.Success;
				}
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.TrailingCommaNotAllowedBeforeArrayEnd, 0);
			}
			if (!ConsumeValueMultiSegment(b))
			{
				return ConsumeTokenResult.NotEnoughDataRollBackState;
			}
			return ConsumeTokenResult.Success;
		}
		case 125:
			EndObject();
			break;
		case 93:
			EndArray();
			break;
		default:
			ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.FoundInvalidCharacter, P_0);
			break;
		}
		return ConsumeTokenResult.Success;
	}

	private ConsumeTokenResult ConsumeNextTokenFromLastNonCommentTokenMultiSegment()
	{
		if (JsonReaderHelper.IsTokenTypePrimitive(_previousTokenType))
		{
			_tokenType = (_inObject ? JsonTokenType.StartObject : JsonTokenType.StartArray);
		}
		else
		{
			_tokenType = _previousTokenType;
		}
		if (HasMoreDataMultiSegment())
		{
			byte b = _buffer[_consumed];
			if (b <= 32)
			{
				SkipWhiteSpaceMultiSegment();
				if (!HasMoreDataMultiSegment())
				{
					goto IL_0393;
				}
				b = _buffer[_consumed];
			}
			if (_bitStack.CurrentDepth == 0 && _tokenType != JsonTokenType.None)
			{
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedEndAfterSingleJson, b);
			}
			TokenStartIndex = BytesConsumed;
			if (b != 44)
			{
				if (b == 125)
				{
					EndObject();
				}
				else
				{
					if (b != 93)
					{
						if (_tokenType == JsonTokenType.None)
						{
							if (ReadFirstTokenMultiSegment(b))
							{
								goto IL_0391;
							}
						}
						else if (_tokenType == JsonTokenType.StartObject)
						{
							if (b != 34)
							{
								ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyNotFound, b);
							}
							long totalConsumed = _totalConsumed;
							int consumed = _consumed;
							long bytePositionInLine = _bytePositionInLine;
							long lineNumber = _lineNumber;
							if (ConsumePropertyNameMultiSegment())
							{
								goto IL_0391;
							}
							_consumed = consumed;
							_tokenType = JsonTokenType.StartObject;
							_bytePositionInLine = bytePositionInLine;
							_lineNumber = lineNumber;
							_totalConsumed = totalConsumed;
						}
						else if (_tokenType == JsonTokenType.StartArray)
						{
							if (ConsumeValueMultiSegment(b))
							{
								goto IL_0391;
							}
						}
						else if (_tokenType == JsonTokenType.PropertyName)
						{
							if (ConsumeValueMultiSegment(b))
							{
								goto IL_0391;
							}
						}
						else if (_inObject)
						{
							if (b != 34)
							{
								ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyNotFound, b);
							}
							if (ConsumePropertyNameMultiSegment())
							{
								goto IL_0391;
							}
						}
						else if (ConsumeValueMultiSegment(b))
						{
							goto IL_0391;
						}
						goto IL_0393;
					}
					EndArray();
				}
				goto IL_0391;
			}
			if ((int)_previousTokenType <= 1 || _previousTokenType == JsonTokenType.StartArray || _trailingCommaBeforeComment)
			{
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyOrValueAfterComment, b);
			}
			_consumed++;
			_bytePositionInLine++;
			if (_consumed >= (uint)_buffer.Length)
			{
				if (IsLastSpan)
				{
					_consumed--;
					_bytePositionInLine--;
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyOrValueNotFound, 0);
				}
				if (!GetNextSpan())
				{
					if (IsLastSpan)
					{
						_consumed--;
						_bytePositionInLine--;
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyOrValueNotFound, 0);
					}
					goto IL_0393;
				}
			}
			b = _buffer[_consumed];
			if (b <= 32)
			{
				SkipWhiteSpaceMultiSegment();
				if (!HasMoreDataMultiSegment(ExceptionResource.ExpectedStartOfPropertyOrValueNotFound))
				{
					goto IL_0393;
				}
				b = _buffer[_consumed];
			}
			TokenStartIndex = BytesConsumed;
			if (b == 47)
			{
				_trailingCommaBeforeComment = true;
				if (SkipOrConsumeCommentMultiSegmentWithRollback())
				{
					goto IL_0391;
				}
			}
			else if (_inObject)
			{
				if (b != 34)
				{
					if (b == 125)
					{
						if (_readerOptions.AllowTrailingCommas)
						{
							EndObject();
							goto IL_0391;
						}
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.TrailingCommaNotAllowedBeforeObjectEnd, 0);
					}
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyNotFound, b);
				}
				if (ConsumePropertyNameMultiSegment())
				{
					goto IL_0391;
				}
			}
			else
			{
				if (b == 93)
				{
					if (_readerOptions.AllowTrailingCommas)
					{
						EndArray();
						goto IL_0391;
					}
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.TrailingCommaNotAllowedBeforeArrayEnd, 0);
				}
				if (ConsumeValueMultiSegment(b))
				{
					goto IL_0391;
				}
			}
		}
		goto IL_0393;
		IL_0393:
		return ConsumeTokenResult.NotEnoughDataRollBackState;
		IL_0391:
		return ConsumeTokenResult.Success;
	}

	private bool SkipAllCommentsMultiSegment(scoped ref byte P_0)
	{
		while (true)
		{
			if (P_0 == 47)
			{
				if (!SkipOrConsumeCommentMultiSegmentWithRollback() || !HasMoreDataMultiSegment())
				{
					break;
				}
				P_0 = _buffer[_consumed];
				if (P_0 <= 32)
				{
					SkipWhiteSpaceMultiSegment();
					if (!HasMoreDataMultiSegment())
					{
						break;
					}
					P_0 = _buffer[_consumed];
				}
				continue;
			}
			return true;
		}
		return false;
	}

	private bool SkipAllCommentsMultiSegment(scoped ref byte P_0, ExceptionResource P_1)
	{
		while (true)
		{
			if (P_0 == 47)
			{
				if (!SkipOrConsumeCommentMultiSegmentWithRollback() || !HasMoreDataMultiSegment(P_1))
				{
					break;
				}
				P_0 = _buffer[_consumed];
				if (P_0 <= 32)
				{
					SkipWhiteSpaceMultiSegment();
					if (!HasMoreDataMultiSegment(P_1))
					{
						break;
					}
					P_0 = _buffer[_consumed];
				}
				continue;
			}
			return true;
		}
		return false;
	}

	private ConsumeTokenResult ConsumeNextTokenUntilAfterAllCommentsAreSkippedMultiSegment(byte P_0)
	{
		if (SkipAllCommentsMultiSegment(ref P_0))
		{
			TokenStartIndex = BytesConsumed;
			if (_tokenType == JsonTokenType.StartObject)
			{
				if (P_0 == 125)
				{
					EndObject();
				}
				else
				{
					if (P_0 != 34)
					{
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyNotFound, P_0);
					}
					long totalConsumed = _totalConsumed;
					int consumed = _consumed;
					long bytePositionInLine = _bytePositionInLine;
					long lineNumber = _lineNumber;
					SequencePosition currentPosition = _currentPosition;
					if (!ConsumePropertyNameMultiSegment())
					{
						_consumed = consumed;
						_tokenType = JsonTokenType.StartObject;
						_bytePositionInLine = bytePositionInLine;
						_lineNumber = lineNumber;
						_totalConsumed = totalConsumed;
						_currentPosition = currentPosition;
						goto IL_02e7;
					}
				}
			}
			else if (_tokenType == JsonTokenType.StartArray)
			{
				if (P_0 == 93)
				{
					EndArray();
				}
				else if (!ConsumeValueMultiSegment(P_0))
				{
					goto IL_02e7;
				}
			}
			else if (_tokenType == JsonTokenType.PropertyName)
			{
				if (!ConsumeValueMultiSegment(P_0))
				{
					goto IL_02e7;
				}
			}
			else if (_bitStack.CurrentDepth == 0)
			{
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedEndAfterSingleJson, P_0);
			}
			else
			{
				switch (P_0)
				{
				case 44:
					_consumed++;
					_bytePositionInLine++;
					if (_consumed >= (uint)_buffer.Length)
					{
						if (IsLastSpan)
						{
							_consumed--;
							_bytePositionInLine--;
							ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyOrValueNotFound, 0);
						}
						if (!GetNextSpan())
						{
							if (IsLastSpan)
							{
								_consumed--;
								_bytePositionInLine--;
								ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyOrValueNotFound, 0);
							}
							return ConsumeTokenResult.NotEnoughDataRollBackState;
						}
					}
					P_0 = _buffer[_consumed];
					if (P_0 <= 32)
					{
						SkipWhiteSpaceMultiSegment();
						if (!HasMoreDataMultiSegment(ExceptionResource.ExpectedStartOfPropertyOrValueNotFound))
						{
							return ConsumeTokenResult.NotEnoughDataRollBackState;
						}
						P_0 = _buffer[_consumed];
					}
					if (SkipAllCommentsMultiSegment(ref P_0, ExceptionResource.ExpectedStartOfPropertyOrValueNotFound))
					{
						TokenStartIndex = BytesConsumed;
						if (_inObject)
						{
							if (P_0 != 34)
							{
								if (P_0 == 125)
								{
									if (_readerOptions.AllowTrailingCommas)
									{
										EndObject();
										break;
									}
									ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.TrailingCommaNotAllowedBeforeObjectEnd, 0);
								}
								ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.ExpectedStartOfPropertyNotFound, P_0);
							}
							if (!ConsumePropertyNameMultiSegment())
							{
								return ConsumeTokenResult.NotEnoughDataRollBackState;
							}
							return ConsumeTokenResult.Success;
						}
						if (P_0 == 93)
						{
							if (_readerOptions.AllowTrailingCommas)
							{
								EndArray();
								break;
							}
							ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.TrailingCommaNotAllowedBeforeArrayEnd, 0);
						}
						if (!ConsumeValueMultiSegment(P_0))
						{
							return ConsumeTokenResult.NotEnoughDataRollBackState;
						}
						return ConsumeTokenResult.Success;
					}
					return ConsumeTokenResult.NotEnoughDataRollBackState;
				case 125:
					EndObject();
					break;
				case 93:
					EndArray();
					break;
				default:
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.FoundInvalidCharacter, P_0);
					break;
				}
			}
			return ConsumeTokenResult.Success;
		}
		goto IL_02e7;
		IL_02e7:
		return ConsumeTokenResult.IncompleteNoRollBackNecessary;
	}

	private bool SkipOrConsumeCommentMultiSegmentWithRollback()
	{
		long bytesConsumed = BytesConsumed;
		SequencePosition sequencePosition = new SequencePosition(_currentPosition.GetObject(), _currentPosition.GetInteger() + _consumed);
		int num;
		bool flag = SkipCommentMultiSegment(out num);
		if (flag)
		{
			if (_readerOptions.CommentHandling == JsonCommentHandling.Allow)
			{
				SequencePosition sequencePosition2 = new SequencePosition(_currentPosition.GetObject(), _currentPosition.GetInteger() + _consumed);
				ReadOnlySequence<byte> readOnlySequence = _sequence.Slice(sequencePosition, sequencePosition2);
				readOnlySequence = readOnlySequence.Slice(2L, readOnlySequence.Length - 2 - num);
				HasValueSequence = !readOnlySequence.IsSingleSegment;
				if (HasValueSequence)
				{
					ValueSequence = readOnlySequence;
				}
				else
				{
					ValueSpan = readOnlySequence.First.Span;
				}
				if (_tokenType != JsonTokenType.Comment)
				{
					_previousTokenType = _tokenType;
				}
				_tokenType = JsonTokenType.Comment;
			}
		}
		else
		{
			_totalConsumed = bytesConsumed;
			_consumed = 0;
		}
		return flag;
	}

	private bool SkipCommentMultiSegment(out int P_0)
	{
		_consumed++;
		_bytePositionInLine++;
		ReadOnlySpan<byte> readOnlySpan = _buffer.Slice(_consumed);
		if (readOnlySpan.Length == 0)
		{
			if (IsLastSpan)
			{
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.UnexpectedEndOfDataWhileReadingComment, 0);
			}
			if (!GetNextSpan())
			{
				if (IsLastSpan)
				{
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.UnexpectedEndOfDataWhileReadingComment, 0);
				}
				P_0 = 0;
				return false;
			}
			readOnlySpan = _buffer;
		}
		byte b = readOnlySpan[0];
		if (b != 47 && b != 42)
		{
			ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.InvalidCharacterAtStartOfComment, b);
		}
		bool flag = b == 42;
		_consumed++;
		_bytePositionInLine++;
		readOnlySpan = readOnlySpan.Slice(1);
		if (readOnlySpan.Length == 0)
		{
			if (IsLastSpan)
			{
				P_0 = 0;
				if (flag)
				{
					ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.UnexpectedEndOfDataWhileReadingComment, 0);
				}
				return true;
			}
			if (!GetNextSpan())
			{
				P_0 = 0;
				if (IsLastSpan)
				{
					if (flag)
					{
						ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.UnexpectedEndOfDataWhileReadingComment, 0);
					}
					return true;
				}
				return false;
			}
			readOnlySpan = _buffer;
		}
		if (flag)
		{
			P_0 = 2;
			return SkipMultiLineCommentMultiSegment(readOnlySpan);
		}
		return SkipSingleLineCommentMultiSegment(readOnlySpan, out P_0);
	}

	private bool SkipSingleLineCommentMultiSegment(ReadOnlySpan<byte> P_0, out int P_1)
	{
		bool flag = false;
		int num = 0;
		P_1 = 0;
		while (true)
		{
			if (flag)
			{
				if (P_0[0] == 10)
				{
					P_1++;
					_consumed++;
				}
				break;
			}
			int num2 = FindLineSeparatorMultiSegment(P_0, ref num);
			if (num2 != -1)
			{
				P_1++;
				_consumed += num2 + 1;
				_bytePositionInLine += num2 + 1;
				if (P_0[num2] == 10)
				{
					break;
				}
				if (num2 < P_0.Length - 1)
				{
					if (P_0[num2 + 1] == 10)
					{
						P_1++;
						_consumed++;
						_bytePositionInLine++;
					}
					break;
				}
				flag = true;
			}
			else
			{
				_consumed += P_0.Length;
				_bytePositionInLine += P_0.Length;
			}
			if (IsLastSpan)
			{
				if (flag)
				{
					break;
				}
				return true;
			}
			if (!GetNextSpan())
			{
				if (IsLastSpan)
				{
					if (flag)
					{
						break;
					}
					return true;
				}
				return false;
			}
			P_0 = _buffer;
		}
		_bytePositionInLine = 0L;
		_lineNumber++;
		return true;
	}

	private int FindLineSeparatorMultiSegment(ReadOnlySpan<byte> P_0, scoped ref int P_1)
	{
		if (P_1 != 0)
		{
			ThrowOnDangerousLineSeparatorMultiSegment(P_0, ref P_1);
			if (P_1 != 0)
			{
				return -1;
			}
		}
		int num = 0;
		do
		{
			int num2 = P_0.IndexOfAny<byte>(10, 13, 226);
			P_1 = 0;
			if (num2 == -1)
			{
				return -1;
			}
			if (P_0[num2] != 226)
			{
				return num + num2;
			}
			int num3 = num2 + 1;
			P_0 = P_0.Slice(num3);
			num += num3;
			P_1++;
			ThrowOnDangerousLineSeparatorMultiSegment(P_0, ref P_1);
		}
		while (P_1 == 0);
		return -1;
	}

	private void ThrowOnDangerousLineSeparatorMultiSegment(ReadOnlySpan<byte> P_0, scoped ref int P_1)
	{
		if (P_0.IsEmpty)
		{
			return;
		}
		if (P_1 == 1)
		{
			if (P_0[0] != 128)
			{
				P_1 = 0;
				return;
			}
			P_0 = P_0.Slice(1);
			P_1++;
			if (P_0.IsEmpty)
			{
				return;
			}
		}
		if (P_1 == 2)
		{
			byte b = P_0[0];
			if (b == 168 || b == 169)
			{
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.UnexpectedEndOfLineSeparator, 0);
			}
			else
			{
				P_1 = 0;
			}
		}
	}

	private bool SkipMultiLineCommentMultiSegment(ReadOnlySpan<byte> P_0)
	{
		bool flag = false;
		bool flag2 = false;
		while (true)
		{
			if (flag)
			{
				if (P_0[0] == 47)
				{
					_consumed++;
					_bytePositionInLine++;
					return true;
				}
				flag = false;
			}
			if (flag2)
			{
				if (P_0[0] == 10)
				{
					_consumed++;
					P_0 = P_0.Slice(1);
				}
				flag2 = false;
			}
			int num = P_0.IndexOfAny<byte>(42, 10, 13);
			if (num != -1)
			{
				int num2 = num + 1;
				byte b = P_0[num];
				P_0 = P_0.Slice(num2);
				_consumed += num2;
				switch (b)
				{
				case 42:
					flag = true;
					_bytePositionInLine += num2;
					break;
				case 10:
					_bytePositionInLine = 0L;
					_lineNumber++;
					break;
				default:
					_bytePositionInLine = 0L;
					_lineNumber++;
					flag2 = true;
					break;
				}
			}
			else
			{
				_consumed += P_0.Length;
				_bytePositionInLine += P_0.Length;
				P_0 = ReadOnlySpan<byte>.Empty;
			}
			if (!P_0.IsEmpty)
			{
				continue;
			}
			if (IsLastSpan)
			{
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.UnexpectedEndOfDataWhileReadingComment, 0);
			}
			if (!GetNextSpan())
			{
				if (!IsLastSpan)
				{
					break;
				}
				ThrowHelper.ThrowJsonReaderException(ref this, ExceptionResource.UnexpectedEndOfDataWhileReadingComment, 0);
			}
			P_0 = _buffer;
		}
		return false;
	}

	private PartialStateForRollback CaptureState()
	{
		return new PartialStateForRollback(_totalConsumed, _bytePositionInLine, _consumed, _currentPosition);
	}

	public string? GetString()
	{
		if (TokenType == JsonTokenType.Null)
		{
			return null;
		}
		if (TokenType != JsonTokenType.String && TokenType != JsonTokenType.PropertyName)
		{
			ThrowHelper.ThrowInvalidOperationException_ExpectedString(TokenType);
		}
		ReadOnlySpan<byte> readOnlySpan = (HasValueSequence ? ((ReadOnlySpan<byte>)ValueSequence.ToArray<byte>()) : ValueSpan);
		if (ValueIsEscaped)
		{
			return JsonReaderHelper.GetUnescapedString(readOnlySpan);
		}
		return JsonReaderHelper.TranscodeHelper(readOnlySpan);
	}

	public readonly int CopyString(Span<byte> P_0)
	{
		JsonTokenType tokenType = _tokenType;
		if (tokenType != JsonTokenType.String && tokenType != JsonTokenType.PropertyName)
		{
			ThrowHelper.ThrowInvalidOperationException_ExpectedString(_tokenType);
		}
		int num;
		if (ValueIsEscaped)
		{
			if (!TryCopyEscapedString(P_0, out num))
			{
				P_0.Slice(0, num).Clear();
				ThrowHelper.ThrowArgumentException_DestinationTooShort();
			}
		}
		else if (HasValueSequence)
		{
			ReadOnlySequence<byte> valueSequence = ValueSequence;
			valueSequence.CopyTo(P_0);
			num = (int)valueSequence.Length;
		}
		else
		{
			ReadOnlySpan<byte> valueSpan = ValueSpan;
			valueSpan.CopyTo(P_0);
			num = valueSpan.Length;
		}
		JsonReaderHelper.ValidateUtf8(P_0.Slice(0, num));
		return num;
	}

	public readonly int CopyString(Span<char> P_0)
	{
		JsonTokenType tokenType = _tokenType;
		if (tokenType != JsonTokenType.String && tokenType != JsonTokenType.PropertyName)
		{
			ThrowHelper.ThrowInvalidOperationException_ExpectedString(_tokenType);
		}
		byte[] array = null;
		ReadOnlySpan<byte> readOnlySpan;
		if (ValueIsEscaped)
		{
			int valueLength = ValueLength;
			Span<byte> span = ((valueLength > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(valueLength))) : stackalloc byte[256]);
			Span<byte> span2 = span;
			int num;
			bool flag = TryCopyEscapedString(span2, out num);
			readOnlySpan = span2.Slice(0, num);
		}
		else if (HasValueSequence)
		{
			ReadOnlySequence<byte> valueSequence = ValueSequence;
			int valueLength = checked((int)valueSequence.Length);
			Span<byte> span3 = ((valueLength > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(valueLength))) : stackalloc byte[256]);
			Span<byte> span4 = span3;
			valueSequence.CopyTo(span4);
			readOnlySpan = span4.Slice(0, valueLength);
		}
		else
		{
			readOnlySpan = ValueSpan;
		}
		int result = JsonReaderHelper.TranscodeHelper(readOnlySpan, P_0);
		if (array != null)
		{
			new Span<byte>(array, 0, readOnlySpan.Length).Clear();
			ArrayPool<byte>.Shared.Return(array);
		}
		return result;
	}

	private readonly bool TryCopyEscapedString(Span<byte> P_0, out int P_1)
	{
		byte[] array = null;
		ReadOnlySpan<byte> readOnlySpan;
		if (HasValueSequence)
		{
			ReadOnlySequence<byte> valueSequence = ValueSequence;
			int num = checked((int)valueSequence.Length);
			Span<byte> span = ((num > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(num))) : stackalloc byte[256]);
			Span<byte> span2 = span;
			valueSequence.CopyTo(span2);
			readOnlySpan = span2.Slice(0, num);
		}
		else
		{
			readOnlySpan = ValueSpan;
		}
		bool result = JsonReaderHelper.TryUnescape(readOnlySpan, P_0, out P_1);
		if (array != null)
		{
			new Span<byte>(array, 0, readOnlySpan.Length).Clear();
			ArrayPool<byte>.Shared.Return(array);
		}
		return result;
	}

	public bool GetBoolean()
	{
		switch (TokenType)
		{
		case JsonTokenType.True:
			return true;
		default:
			ThrowHelper.ThrowInvalidOperationException_ExpectedBoolean(TokenType);
			break;
		case JsonTokenType.False:
			break;
		}
		return false;
	}

	public byte[] GetBytesFromBase64()
	{
		if (!TryGetBytesFromBase64(out byte[] result))
		{
			ThrowHelper.ThrowFormatException(DataType.Base64String);
		}
		return result;
	}

	public byte GetByte()
	{
		if (!TryGetByte(out var result))
		{
			ThrowHelper.ThrowFormatException(NumericType.Byte);
		}
		return result;
	}

	internal byte GetByteWithQuotes()
	{
		ReadOnlySpan<byte> unescapedSpan = GetUnescapedSpan();
		if (!TryGetByteCore(out var result, unescapedSpan))
		{
			ThrowHelper.ThrowFormatException(NumericType.Byte);
		}
		return result;
	}

	[CLSCompliant(false)]
	public sbyte GetSByte()
	{
		if (!TryGetSByte(out var result))
		{
			ThrowHelper.ThrowFormatException(NumericType.SByte);
		}
		return result;
	}

	internal sbyte GetSByteWithQuotes()
	{
		ReadOnlySpan<byte> unescapedSpan = GetUnescapedSpan();
		if (!TryGetSByteCore(out var result, unescapedSpan))
		{
			ThrowHelper.ThrowFormatException(NumericType.SByte);
		}
		return result;
	}

	public short GetInt16()
	{
		if (!TryGetInt16(out var result))
		{
			ThrowHelper.ThrowFormatException(NumericType.Int16);
		}
		return result;
	}

	internal short GetInt16WithQuotes()
	{
		ReadOnlySpan<byte> unescapedSpan = GetUnescapedSpan();
		if (!TryGetInt16Core(out var result, unescapedSpan))
		{
			ThrowHelper.ThrowFormatException(NumericType.Int16);
		}
		return result;
	}

	public int GetInt32()
	{
		if (!TryGetInt32(out var result))
		{
			ThrowHelper.ThrowFormatException(NumericType.Int32);
		}
		return result;
	}

	internal int GetInt32WithQuotes()
	{
		ReadOnlySpan<byte> unescapedSpan = GetUnescapedSpan();
		if (!TryGetInt32Core(out var result, unescapedSpan))
		{
			ThrowHelper.ThrowFormatException(NumericType.Int32);
		}
		return result;
	}

	public long GetInt64()
	{
		if (!TryGetInt64(out var result))
		{
			ThrowHelper.ThrowFormatException(NumericType.Int64);
		}
		return result;
	}

	internal long GetInt64WithQuotes()
	{
		ReadOnlySpan<byte> unescapedSpan = GetUnescapedSpan();
		if (!TryGetInt64Core(out var result, unescapedSpan))
		{
			ThrowHelper.ThrowFormatException(NumericType.Int64);
		}
		return result;
	}

	[CLSCompliant(false)]
	public ushort GetUInt16()
	{
		if (!TryGetUInt16(out var result))
		{
			ThrowHelper.ThrowFormatException(NumericType.UInt16);
		}
		return result;
	}

	internal ushort GetUInt16WithQuotes()
	{
		ReadOnlySpan<byte> unescapedSpan = GetUnescapedSpan();
		if (!TryGetUInt16Core(out var result, unescapedSpan))
		{
			ThrowHelper.ThrowFormatException(NumericType.UInt16);
		}
		return result;
	}

	[CLSCompliant(false)]
	public uint GetUInt32()
	{
		if (!TryGetUInt32(out var result))
		{
			ThrowHelper.ThrowFormatException(NumericType.UInt32);
		}
		return result;
	}

	internal uint GetUInt32WithQuotes()
	{
		ReadOnlySpan<byte> unescapedSpan = GetUnescapedSpan();
		if (!TryGetUInt32Core(out var result, unescapedSpan))
		{
			ThrowHelper.ThrowFormatException(NumericType.UInt32);
		}
		return result;
	}

	[CLSCompliant(false)]
	public ulong GetUInt64()
	{
		if (!TryGetUInt64(out var result))
		{
			ThrowHelper.ThrowFormatException(NumericType.UInt64);
		}
		return result;
	}

	internal ulong GetUInt64WithQuotes()
	{
		ReadOnlySpan<byte> unescapedSpan = GetUnescapedSpan();
		if (!TryGetUInt64Core(out var result, unescapedSpan))
		{
			ThrowHelper.ThrowFormatException(NumericType.UInt64);
		}
		return result;
	}

	public float GetSingle()
	{
		if (!TryGetSingle(out var result))
		{
			ThrowHelper.ThrowFormatException(NumericType.Single);
		}
		return result;
	}

	internal float GetSingleWithQuotes()
	{
		ReadOnlySpan<byte> unescapedSpan = GetUnescapedSpan();
		if (JsonReaderHelper.TryGetFloatingPointConstant(unescapedSpan, out float num))
		{
			return num;
		}
		if (!Utf8Parser.TryParse(unescapedSpan, out num, out int num2, '\0') || unescapedSpan.Length != num2 || !JsonHelpers.IsFinite(num))
		{
			ThrowHelper.ThrowFormatException(NumericType.Single);
		}
		return num;
	}

	internal float GetSingleFloatingPointConstant()
	{
		ReadOnlySpan<byte> unescapedSpan = GetUnescapedSpan();
		if (!JsonReaderHelper.TryGetFloatingPointConstant(unescapedSpan, out float result))
		{
			ThrowHelper.ThrowFormatException(NumericType.Single);
		}
		return result;
	}

	public double GetDouble()
	{
		if (!TryGetDouble(out var result))
		{
			ThrowHelper.ThrowFormatException(NumericType.Double);
		}
		return result;
	}

	internal double GetDoubleWithQuotes()
	{
		ReadOnlySpan<byte> unescapedSpan = GetUnescapedSpan();
		if (JsonReaderHelper.TryGetFloatingPointConstant(unescapedSpan, out double num))
		{
			return num;
		}
		if (!Utf8Parser.TryParse(unescapedSpan, out num, out int num2, '\0') || unescapedSpan.Length != num2 || !JsonHelpers.IsFinite(num))
		{
			ThrowHelper.ThrowFormatException(NumericType.Double);
		}
		return num;
	}

	internal double GetDoubleFloatingPointConstant()
	{
		ReadOnlySpan<byte> unescapedSpan = GetUnescapedSpan();
		if (!JsonReaderHelper.TryGetFloatingPointConstant(unescapedSpan, out double result))
		{
			ThrowHelper.ThrowFormatException(NumericType.Double);
		}
		return result;
	}

	public decimal GetDecimal()
	{
		if (!TryGetDecimal(out var result))
		{
			ThrowHelper.ThrowFormatException(NumericType.Decimal);
		}
		return result;
	}

	internal decimal GetDecimalWithQuotes()
	{
		ReadOnlySpan<byte> unescapedSpan = GetUnescapedSpan();
		if (!TryGetDecimalCore(out var result, unescapedSpan))
		{
			ThrowHelper.ThrowFormatException(NumericType.Decimal);
		}
		return result;
	}

	public DateTime GetDateTime()
	{
		if (!TryGetDateTime(out var result))
		{
			ThrowHelper.ThrowFormatException(DataType.DateTime);
		}
		return result;
	}

	internal DateTime GetDateTimeNoValidation()
	{
		if (!TryGetDateTimeCore(out var result))
		{
			ThrowHelper.ThrowFormatException(DataType.DateTime);
		}
		return result;
	}

	public DateTimeOffset GetDateTimeOffset()
	{
		if (!TryGetDateTimeOffset(out var result))
		{
			ThrowHelper.ThrowFormatException(DataType.DateTimeOffset);
		}
		return result;
	}

	internal DateTimeOffset GetDateTimeOffsetNoValidation()
	{
		if (!TryGetDateTimeOffsetCore(out var result))
		{
			ThrowHelper.ThrowFormatException(DataType.DateTimeOffset);
		}
		return result;
	}

	public Guid GetGuid()
	{
		if (!TryGetGuid(out var result))
		{
			ThrowHelper.ThrowFormatException(DataType.Guid);
		}
		return result;
	}

	internal Guid GetGuidNoValidation()
	{
		if (!TryGetGuidCore(out var result))
		{
			ThrowHelper.ThrowFormatException(DataType.Guid);
		}
		return result;
	}

	public bool TryGetBytesFromBase64([NotNullWhen(true)] out byte[]? P_0)
	{
		if (TokenType != JsonTokenType.String)
		{
			ThrowHelper.ThrowInvalidOperationException_ExpectedString(TokenType);
		}
		ReadOnlySpan<byte> readOnlySpan = (HasValueSequence ? ((ReadOnlySpan<byte>)ValueSequence.ToArray<byte>()) : ValueSpan);
		if (ValueIsEscaped)
		{
			return JsonReaderHelper.TryGetUnescapedBase64Bytes(readOnlySpan, out P_0);
		}
		return JsonReaderHelper.TryDecodeBase64(readOnlySpan, out P_0);
	}

	public bool TryGetByte(out byte P_0)
	{
		if (TokenType != JsonTokenType.Number)
		{
			ThrowHelper.ThrowInvalidOperationException_ExpectedNumber(TokenType);
		}
		ReadOnlySpan<byte> readOnlySpan = (HasValueSequence ? ((ReadOnlySpan<byte>)ValueSequence.ToArray<byte>()) : ValueSpan);
		return TryGetByteCore(out P_0, readOnlySpan);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool TryGetByteCore(out byte P_0, ReadOnlySpan<byte> P_1)
	{
		if (Utf8Parser.TryParse(P_1, out byte b, out int num, '\0') && P_1.Length == num)
		{
			P_0 = b;
			return true;
		}
		P_0 = 0;
		return false;
	}

	[CLSCompliant(false)]
	public bool TryGetSByte(out sbyte P_0)
	{
		if (TokenType != JsonTokenType.Number)
		{
			ThrowHelper.ThrowInvalidOperationException_ExpectedNumber(TokenType);
		}
		ReadOnlySpan<byte> readOnlySpan = (HasValueSequence ? ((ReadOnlySpan<byte>)ValueSequence.ToArray<byte>()) : ValueSpan);
		return TryGetSByteCore(out P_0, readOnlySpan);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool TryGetSByteCore(out sbyte P_0, ReadOnlySpan<byte> P_1)
	{
		if (Utf8Parser.TryParse(P_1, out sbyte b, out int num, '\0') && P_1.Length == num)
		{
			P_0 = b;
			return true;
		}
		P_0 = 0;
		return false;
	}

	public bool TryGetInt16(out short P_0)
	{
		if (TokenType != JsonTokenType.Number)
		{
			ThrowHelper.ThrowInvalidOperationException_ExpectedNumber(TokenType);
		}
		ReadOnlySpan<byte> readOnlySpan = (HasValueSequence ? ((ReadOnlySpan<byte>)ValueSequence.ToArray<byte>()) : ValueSpan);
		return TryGetInt16Core(out P_0, readOnlySpan);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool TryGetInt16Core(out short P_0, ReadOnlySpan<byte> P_1)
	{
		if (Utf8Parser.TryParse(P_1, out short num, out int num2, '\0') && P_1.Length == num2)
		{
			P_0 = num;
			return true;
		}
		P_0 = 0;
		return false;
	}

	public bool TryGetInt32(out int P_0)
	{
		if (TokenType != JsonTokenType.Number)
		{
			ThrowHelper.ThrowInvalidOperationException_ExpectedNumber(TokenType);
		}
		ReadOnlySpan<byte> readOnlySpan = (HasValueSequence ? ((ReadOnlySpan<byte>)ValueSequence.ToArray<byte>()) : ValueSpan);
		return TryGetInt32Core(out P_0, readOnlySpan);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool TryGetInt32Core(out int P_0, ReadOnlySpan<byte> P_1)
	{
		if (Utf8Parser.TryParse(P_1, out int num, out int num2, '\0') && P_1.Length == num2)
		{
			P_0 = num;
			return true;
		}
		P_0 = 0;
		return false;
	}

	public bool TryGetInt64(out long P_0)
	{
		if (TokenType != JsonTokenType.Number)
		{
			ThrowHelper.ThrowInvalidOperationException_ExpectedNumber(TokenType);
		}
		ReadOnlySpan<byte> readOnlySpan = (HasValueSequence ? ((ReadOnlySpan<byte>)ValueSequence.ToArray<byte>()) : ValueSpan);
		return TryGetInt64Core(out P_0, readOnlySpan);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool TryGetInt64Core(out long P_0, ReadOnlySpan<byte> P_1)
	{
		if (Utf8Parser.TryParse(P_1, out long num, out int num2, '\0') && P_1.Length == num2)
		{
			P_0 = num;
			return true;
		}
		P_0 = 0L;
		return false;
	}

	[CLSCompliant(false)]
	public bool TryGetUInt16(out ushort P_0)
	{
		if (TokenType != JsonTokenType.Number)
		{
			ThrowHelper.ThrowInvalidOperationException_ExpectedNumber(TokenType);
		}
		ReadOnlySpan<byte> readOnlySpan = (HasValueSequence ? ((ReadOnlySpan<byte>)ValueSequence.ToArray<byte>()) : ValueSpan);
		return TryGetUInt16Core(out P_0, readOnlySpan);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool TryGetUInt16Core(out ushort P_0, ReadOnlySpan<byte> P_1)
	{
		if (Utf8Parser.TryParse(P_1, out ushort num, out int num2, '\0') && P_1.Length == num2)
		{
			P_0 = num;
			return true;
		}
		P_0 = 0;
		return false;
	}

	[CLSCompliant(false)]
	public bool TryGetUInt32(out uint P_0)
	{
		if (TokenType != JsonTokenType.Number)
		{
			ThrowHelper.ThrowInvalidOperationException_ExpectedNumber(TokenType);
		}
		ReadOnlySpan<byte> readOnlySpan = (HasValueSequence ? ((ReadOnlySpan<byte>)ValueSequence.ToArray<byte>()) : ValueSpan);
		return TryGetUInt32Core(out P_0, readOnlySpan);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool TryGetUInt32Core(out uint P_0, ReadOnlySpan<byte> P_1)
	{
		if (Utf8Parser.TryParse(P_1, out uint num, out int num2, '\0') && P_1.Length == num2)
		{
			P_0 = num;
			return true;
		}
		P_0 = 0u;
		return false;
	}

	[CLSCompliant(false)]
	public bool TryGetUInt64(out ulong P_0)
	{
		if (TokenType != JsonTokenType.Number)
		{
			ThrowHelper.ThrowInvalidOperationException_ExpectedNumber(TokenType);
		}
		ReadOnlySpan<byte> readOnlySpan = (HasValueSequence ? ((ReadOnlySpan<byte>)ValueSequence.ToArray<byte>()) : ValueSpan);
		return TryGetUInt64Core(out P_0, readOnlySpan);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool TryGetUInt64Core(out ulong P_0, ReadOnlySpan<byte> P_1)
	{
		if (Utf8Parser.TryParse(P_1, out ulong num, out int num2, '\0') && P_1.Length == num2)
		{
			P_0 = num;
			return true;
		}
		P_0 = 0uL;
		return false;
	}

	public bool TryGetSingle(out float P_0)
	{
		if (TokenType != JsonTokenType.Number)
		{
			ThrowHelper.ThrowInvalidOperationException_ExpectedNumber(TokenType);
		}
		ReadOnlySpan<byte> readOnlySpan = (HasValueSequence ? ((ReadOnlySpan<byte>)ValueSequence.ToArray<byte>()) : ValueSpan);
		if (Utf8Parser.TryParse(readOnlySpan, out float num, out int num2, '\0') && readOnlySpan.Length == num2)
		{
			P_0 = num;
			return true;
		}
		P_0 = 0f;
		return false;
	}

	public bool TryGetDouble(out double P_0)
	{
		if (TokenType != JsonTokenType.Number)
		{
			ThrowHelper.ThrowInvalidOperationException_ExpectedNumber(TokenType);
		}
		ReadOnlySpan<byte> readOnlySpan = (HasValueSequence ? ((ReadOnlySpan<byte>)ValueSequence.ToArray<byte>()) : ValueSpan);
		if (Utf8Parser.TryParse(readOnlySpan, out double num, out int num2, '\0') && readOnlySpan.Length == num2)
		{
			P_0 = num;
			return true;
		}
		P_0 = 0.0;
		return false;
	}

	public bool TryGetDecimal(out decimal P_0)
	{
		if (TokenType != JsonTokenType.Number)
		{
			ThrowHelper.ThrowInvalidOperationException_ExpectedNumber(TokenType);
		}
		ReadOnlySpan<byte> readOnlySpan = (HasValueSequence ? ((ReadOnlySpan<byte>)ValueSequence.ToArray<byte>()) : ValueSpan);
		return TryGetDecimalCore(out P_0, readOnlySpan);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool TryGetDecimalCore(out decimal P_0, ReadOnlySpan<byte> P_1)
	{
		if (Utf8Parser.TryParse(P_1, out decimal num, out int num2, '\0') && P_1.Length == num2)
		{
			P_0 = num;
			return true;
		}
		P_0 = default(decimal);
		return false;
	}

	public bool TryGetDateTime(out DateTime P_0)
	{
		if (TokenType != JsonTokenType.String)
		{
			ThrowHelper.ThrowInvalidOperationException_ExpectedString(TokenType);
		}
		return TryGetDateTimeCore(out P_0);
	}

	internal bool TryGetDateTimeCore(out DateTime P_0)
	{
		ReadOnlySpan<byte> readOnlySpan;
		if (HasValueSequence)
		{
			long length = ValueSequence.Length;
			if (!JsonHelpers.IsInRangeInclusive(length, 10L, 252L))
			{
				P_0 = default(DateTime);
				return false;
			}
			Span<byte> span = stackalloc byte[252];
			ValueSequence.CopyTo(span);
			readOnlySpan = span.Slice(0, (int)length);
		}
		else
		{
			if (!JsonHelpers.IsInRangeInclusive(ValueSpan.Length, 10, 252))
			{
				P_0 = default(DateTime);
				return false;
			}
			readOnlySpan = ValueSpan;
		}
		if (ValueIsEscaped)
		{
			return JsonReaderHelper.TryGetEscapedDateTime(readOnlySpan, out P_0);
		}
		if (JsonHelpers.TryParseAsISO(readOnlySpan, out DateTime dateTime))
		{
			P_0 = dateTime;
			return true;
		}
		P_0 = default(DateTime);
		return false;
	}

	public bool TryGetDateTimeOffset(out DateTimeOffset P_0)
	{
		if (TokenType != JsonTokenType.String)
		{
			ThrowHelper.ThrowInvalidOperationException_ExpectedString(TokenType);
		}
		return TryGetDateTimeOffsetCore(out P_0);
	}

	internal bool TryGetDateTimeOffsetCore(out DateTimeOffset P_0)
	{
		ReadOnlySpan<byte> readOnlySpan;
		if (HasValueSequence)
		{
			long length = ValueSequence.Length;
			if (!JsonHelpers.IsInRangeInclusive(length, 10L, 252L))
			{
				P_0 = default(DateTimeOffset);
				return false;
			}
			Span<byte> span = stackalloc byte[252];
			ValueSequence.CopyTo(span);
			readOnlySpan = span.Slice(0, (int)length);
		}
		else
		{
			if (!JsonHelpers.IsInRangeInclusive(ValueSpan.Length, 10, 252))
			{
				P_0 = default(DateTimeOffset);
				return false;
			}
			readOnlySpan = ValueSpan;
		}
		if (ValueIsEscaped)
		{
			return JsonReaderHelper.TryGetEscapedDateTimeOffset(readOnlySpan, out P_0);
		}
		if (JsonHelpers.TryParseAsISO(readOnlySpan, out DateTimeOffset dateTimeOffset))
		{
			P_0 = dateTimeOffset;
			return true;
		}
		P_0 = default(DateTimeOffset);
		return false;
	}

	public bool TryGetGuid(out Guid P_0)
	{
		if (TokenType != JsonTokenType.String)
		{
			ThrowHelper.ThrowInvalidOperationException_ExpectedString(TokenType);
		}
		return TryGetGuidCore(out P_0);
	}

	internal bool TryGetGuidCore(out Guid P_0)
	{
		ReadOnlySpan<byte> readOnlySpan;
		if (HasValueSequence)
		{
			long length = ValueSequence.Length;
			if (length > 216)
			{
				P_0 = default(Guid);
				return false;
			}
			Span<byte> span = stackalloc byte[216];
			ValueSequence.CopyTo(span);
			readOnlySpan = span.Slice(0, (int)length);
		}
		else
		{
			if (ValueSpan.Length > 216)
			{
				P_0 = default(Guid);
				return false;
			}
			readOnlySpan = ValueSpan;
		}
		if (ValueIsEscaped)
		{
			return JsonReaderHelper.TryGetEscapedGuid(readOnlySpan, out P_0);
		}
		if (readOnlySpan.Length == 36 && Utf8Parser.TryParse(readOnlySpan, out Guid guid, out int _, 'D'))
		{
			P_0 = guid;
			return true;
		}
		P_0 = default(Guid);
		return false;
	}
}
