using System.Buffers;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json;

internal static class ThrowHelper
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	[DoesNotReturn]
	public static void ThrowOutOfMemoryException_BufferMaximumSizeExceeded(uint P_0)
	{
		throw new OutOfMemoryException(System.SR.Format("BufferMaximumSizeExceeded", P_0));
	}

	[DoesNotReturn]
	public static void ThrowArgumentNullException(string P_0)
	{
		throw new ArgumentNullException(P_0);
	}

	[DoesNotReturn]
	public static void ThrowArgumentOutOfRangeException_MaxDepthMustBePositive(string P_0)
	{
		throw GetArgumentOutOfRangeException(P_0, "MaxDepthMustBePositive");
	}

	private static ArgumentOutOfRangeException GetArgumentOutOfRangeException(string P_0, string P_1)
	{
		return new ArgumentOutOfRangeException(P_0, P_1);
	}

	[DoesNotReturn]
	public static void ThrowArgumentOutOfRangeException_CommentEnumMustBeInRange(string P_0)
	{
		throw GetArgumentOutOfRangeException(P_0, "CommentHandlingMustBeValid");
	}

	[DoesNotReturn]
	public static void ThrowArgumentOutOfRangeException_ArrayIndexNegative(string P_0)
	{
		throw new ArgumentOutOfRangeException(P_0, "ArrayIndexNegative");
	}

	[DoesNotReturn]
	public static void ThrowArgumentException_ArrayTooSmall(string P_0)
	{
		throw new ArgumentException("ArrayTooSmall", P_0);
	}

	private static ArgumentException GetArgumentException(string P_0)
	{
		return new ArgumentException(P_0);
	}

	[DoesNotReturn]
	public static void ThrowArgumentException(string P_0)
	{
		throw GetArgumentException(P_0);
	}

	[DoesNotReturn]
	public static void ThrowArgumentException_DestinationTooShort()
	{
		throw GetArgumentException("DestinationTooShort");
	}

	[DoesNotReturn]
	public static void ThrowArgumentException_PropertyNameTooLarge(int P_0)
	{
		throw GetArgumentException(System.SR.Format("PropertyNameTooLarge", P_0));
	}

	[DoesNotReturn]
	public static void ThrowArgumentException_ValueTooLarge(int P_0)
	{
		throw GetArgumentException(System.SR.Format("ValueTooLarge", P_0));
	}

	[DoesNotReturn]
	public static void ThrowArgumentException_ValueNotSupported()
	{
		throw GetArgumentException("SpecialNumberValuesNotSupported");
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_NeedLargerSpan()
	{
		throw GetInvalidOperationException("FailedToGetLargerSpan");
	}

	[DoesNotReturn]
	public static void ThrowArgumentException(ReadOnlySpan<char> P_0, ReadOnlySpan<char> P_1)
	{
		if (P_0.Length > 166666666)
		{
			ThrowArgumentException(System.SR.Format("PropertyNameTooLarge", P_0.Length));
		}
		else
		{
			ThrowArgumentException(System.SR.Format("ValueTooLarge", P_1.Length));
		}
	}

	private static InvalidOperationException GetInvalidOperationException(string P_0)
	{
		return new InvalidOperationException(P_0)
		{
			Source = "System.Text.Json.Rethrowable"
		};
	}

	public static InvalidOperationException GetInvalidOperationException_ExpectedArray(JsonTokenType P_0)
	{
		return GetInvalidOperationException("array", P_0);
	}

	public static InvalidOperationException GetInvalidOperationException_ExpectedObject(JsonTokenType P_0)
	{
		return GetInvalidOperationException("object", P_0);
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_ExpectedNumber(JsonTokenType P_0)
	{
		throw GetInvalidOperationException("number", P_0);
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_ExpectedBoolean(JsonTokenType P_0)
	{
		throw GetInvalidOperationException("boolean", P_0);
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_ExpectedString(JsonTokenType P_0)
	{
		throw GetInvalidOperationException("string", P_0);
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_ExpectedStringComparison(JsonTokenType P_0)
	{
		throw GetInvalidOperationException(P_0);
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_CannotSkipOnPartial()
	{
		throw GetInvalidOperationException("CannotSkip");
	}

	private static InvalidOperationException GetInvalidOperationException(string P_0, JsonTokenType P_1)
	{
		return GetInvalidOperationException(System.SR.Format("InvalidCast", P_1, P_0));
	}

	private static InvalidOperationException GetInvalidOperationException(JsonTokenType P_0)
	{
		return GetInvalidOperationException(System.SR.Format("InvalidComparison", P_0));
	}

	[DoesNotReturn]
	internal static void ThrowJsonElementWrongTypeException(JsonTokenType P_0, JsonTokenType P_1)
	{
		throw GetJsonElementWrongTypeException(P_0.ToValueKind(), P_1.ToValueKind());
	}

	internal static InvalidOperationException GetJsonElementWrongTypeException(JsonValueKind P_0, JsonValueKind P_1)
	{
		return GetInvalidOperationException(System.SR.Format("JsonElementHasWrongType", P_0, P_1));
	}

	internal static InvalidOperationException GetJsonElementWrongTypeException(string P_0, JsonValueKind P_1)
	{
		return GetInvalidOperationException(System.SR.Format("JsonElementHasWrongType", P_0, P_1));
	}

	[DoesNotReturn]
	public static void ThrowJsonReaderException(ref Utf8JsonReader P_0, ExceptionResource P_1, byte P_2 = 0, ReadOnlySpan<byte> P_3 = default(ReadOnlySpan<byte>))
	{
		throw GetJsonReaderException(ref P_0, P_1, P_2, P_3);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static JsonException GetJsonReaderException(ref Utf8JsonReader P_0, ExceptionResource P_1, byte P_2, ReadOnlySpan<byte> P_3)
	{
		string resourceString = GetResourceString(ref P_0, P_1, P_2, JsonHelpers.Utf8GetString(P_3));
		long lineNumber = P_0.CurrentState._lineNumber;
		long bytePositionInLine = P_0.CurrentState._bytePositionInLine;
		resourceString += $" LineNumber: {lineNumber} | BytePositionInLine: {bytePositionInLine}.";
		return new JsonReaderException(resourceString, lineNumber, bytePositionInLine);
	}

	private static bool IsPrintable(byte P_0)
	{
		if (P_0 >= 32)
		{
			return P_0 < 127;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static string GetPrintableString(byte P_0)
	{
		if (!IsPrintable(P_0))
		{
			return $"0x{P_0:X2}";
		}
		char c = (char)P_0;
		return c.ToString();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string GetResourceString(ref Utf8JsonReader P_0, ExceptionResource P_1, byte P_2, string P_3)
	{
		string printableString = GetPrintableString(P_2);
		string result = "";
		switch (P_1)
		{
		case ExceptionResource.ArrayDepthTooLarge:
			result = System.SR.Format("ArrayDepthTooLarge", P_0.CurrentState.Options.MaxDepth);
			break;
		case ExceptionResource.MismatchedObjectArray:
			result = System.SR.Format("MismatchedObjectArray", printableString);
			break;
		case ExceptionResource.TrailingCommaNotAllowedBeforeArrayEnd:
			result = "TrailingCommaNotAllowedBeforeArrayEnd";
			break;
		case ExceptionResource.TrailingCommaNotAllowedBeforeObjectEnd:
			result = "TrailingCommaNotAllowedBeforeObjectEnd";
			break;
		case ExceptionResource.EndOfStringNotFound:
			result = "EndOfStringNotFound";
			break;
		case ExceptionResource.RequiredDigitNotFoundAfterSign:
			result = System.SR.Format("RequiredDigitNotFoundAfterSign", printableString);
			break;
		case ExceptionResource.RequiredDigitNotFoundAfterDecimal:
			result = System.SR.Format("RequiredDigitNotFoundAfterDecimal", printableString);
			break;
		case ExceptionResource.RequiredDigitNotFoundEndOfData:
			result = "RequiredDigitNotFoundEndOfData";
			break;
		case ExceptionResource.ExpectedEndAfterSingleJson:
			result = System.SR.Format("ExpectedEndAfterSingleJson", printableString);
			break;
		case ExceptionResource.ExpectedEndOfDigitNotFound:
			result = System.SR.Format("ExpectedEndOfDigitNotFound", printableString);
			break;
		case ExceptionResource.ExpectedNextDigitEValueNotFound:
			result = System.SR.Format("ExpectedNextDigitEValueNotFound", printableString);
			break;
		case ExceptionResource.ExpectedSeparatorAfterPropertyNameNotFound:
			result = System.SR.Format("ExpectedSeparatorAfterPropertyNameNotFound", printableString);
			break;
		case ExceptionResource.ExpectedStartOfPropertyNotFound:
			result = System.SR.Format("ExpectedStartOfPropertyNotFound", printableString);
			break;
		case ExceptionResource.ExpectedStartOfPropertyOrValueNotFound:
			result = "ExpectedStartOfPropertyOrValueNotFound";
			break;
		case ExceptionResource.ExpectedStartOfPropertyOrValueAfterComment:
			result = System.SR.Format("ExpectedStartOfPropertyOrValueAfterComment", printableString);
			break;
		case ExceptionResource.ExpectedStartOfValueNotFound:
			result = System.SR.Format("ExpectedStartOfValueNotFound", printableString);
			break;
		case ExceptionResource.ExpectedValueAfterPropertyNameNotFound:
			result = "ExpectedValueAfterPropertyNameNotFound";
			break;
		case ExceptionResource.FoundInvalidCharacter:
			result = System.SR.Format("FoundInvalidCharacter", printableString);
			break;
		case ExceptionResource.InvalidEndOfJsonNonPrimitive:
			result = System.SR.Format("InvalidEndOfJsonNonPrimitive", P_0.TokenType);
			break;
		case ExceptionResource.ObjectDepthTooLarge:
			result = System.SR.Format("ObjectDepthTooLarge", P_0.CurrentState.Options.MaxDepth);
			break;
		case ExceptionResource.ExpectedFalse:
			result = System.SR.Format("ExpectedFalse", P_3);
			break;
		case ExceptionResource.ExpectedNull:
			result = System.SR.Format("ExpectedNull", P_3);
			break;
		case ExceptionResource.ExpectedTrue:
			result = System.SR.Format("ExpectedTrue", P_3);
			break;
		case ExceptionResource.InvalidCharacterWithinString:
			result = System.SR.Format("InvalidCharacterWithinString", printableString);
			break;
		case ExceptionResource.InvalidCharacterAfterEscapeWithinString:
			result = System.SR.Format("InvalidCharacterAfterEscapeWithinString", printableString);
			break;
		case ExceptionResource.InvalidHexCharacterWithinString:
			result = System.SR.Format("InvalidHexCharacterWithinString", printableString);
			break;
		case ExceptionResource.EndOfCommentNotFound:
			result = "EndOfCommentNotFound";
			break;
		case ExceptionResource.ZeroDepthAtEnd:
			result = System.SR.Format("ZeroDepthAtEnd");
			break;
		case ExceptionResource.ExpectedJsonTokens:
			result = "ExpectedJsonTokens";
			break;
		case ExceptionResource.NotEnoughData:
			result = "NotEnoughData";
			break;
		case ExceptionResource.ExpectedOneCompleteToken:
			result = "ExpectedOneCompleteToken";
			break;
		case ExceptionResource.InvalidCharacterAtStartOfComment:
			result = System.SR.Format("InvalidCharacterAtStartOfComment", printableString);
			break;
		case ExceptionResource.UnexpectedEndOfDataWhileReadingComment:
			result = System.SR.Format("UnexpectedEndOfDataWhileReadingComment");
			break;
		case ExceptionResource.UnexpectedEndOfLineSeparator:
			result = System.SR.Format("UnexpectedEndOfLineSeparator");
			break;
		case ExceptionResource.InvalidLeadingZeroInNumber:
			result = System.SR.Format("InvalidLeadingZeroInNumber", printableString);
			break;
		}
		return result;
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException(ExceptionResource P_0, int P_1, int P_2, byte P_3, JsonTokenType P_4)
	{
		throw GetInvalidOperationException(P_0, P_1, P_2, P_3, P_4);
	}

	[DoesNotReturn]
	public static void ThrowArgumentException_InvalidUTF8(ReadOnlySpan<byte> P_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = Math.Min(P_0.Length, 10);
		for (int i = 0; i < num; i++)
		{
			byte b = P_0[i];
			if (IsPrintable(b))
			{
				stringBuilder.Append((char)b);
				continue;
			}
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(2, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendLiteral("0x");
			appendInterpolatedStringHandler.AppendFormatted(b, "X2");
			stringBuilder2.Append(ref appendInterpolatedStringHandler);
		}
		if (num < P_0.Length)
		{
			stringBuilder.Append("...");
		}
		throw new ArgumentException(System.SR.Format("CannotEncodeInvalidUTF8", stringBuilder));
	}

	[DoesNotReturn]
	public static void ThrowArgumentException_InvalidUTF16(int P_0)
	{
		throw new ArgumentException(System.SR.Format("CannotEncodeInvalidUTF16", $"0x{P_0:X2}"));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_ReadInvalidUTF16(int P_0)
	{
		throw GetInvalidOperationException(System.SR.Format("CannotReadInvalidUTF16", $"0x{P_0:X2}"));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_ReadIncompleteUTF16()
	{
		throw GetInvalidOperationException("CannotReadIncompleteUTF16");
	}

	public static InvalidOperationException GetInvalidOperationException_ReadInvalidUTF8(DecoderFallbackException P_0)
	{
		return GetInvalidOperationException("CannotTranscodeInvalidUtf8", P_0);
	}

	public static ArgumentException GetArgumentException_ReadInvalidUTF16(EncoderFallbackException P_0)
	{
		return new ArgumentException("CannotTranscodeInvalidUtf16", P_0);
	}

	public static InvalidOperationException GetInvalidOperationException(string P_0, Exception P_1)
	{
		InvalidOperationException ex = new InvalidOperationException(P_0, P_1);
		ex.Source = "System.Text.Json.Rethrowable";
		return ex;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static InvalidOperationException GetInvalidOperationException(ExceptionResource P_0, int P_1, int P_2, byte P_3, JsonTokenType P_4)
	{
		string resourceString = GetResourceString(P_0, P_1, P_2, P_3, P_4);
		InvalidOperationException invalidOperationException = GetInvalidOperationException(resourceString);
		invalidOperationException.Source = "System.Text.Json.Rethrowable";
		return invalidOperationException;
	}

	[DoesNotReturn]
	public static void ThrowOutOfMemoryException(uint P_0)
	{
		throw new OutOfMemoryException(System.SR.Format("BufferMaximumSizeExceeded", P_0));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string GetResourceString(ExceptionResource P_0, int P_1, int P_2, byte P_3, JsonTokenType P_4)
	{
		string result = "";
		switch (P_0)
		{
		case ExceptionResource.MismatchedObjectArray:
			result = ((P_4 == JsonTokenType.PropertyName) ? System.SR.Format("CannotWriteEndAfterProperty", (char)P_3) : System.SR.Format("MismatchedObjectArray", (char)P_3));
			break;
		case ExceptionResource.DepthTooLarge:
			result = System.SR.Format("DepthTooLarge", P_1 & 0x7FFFFFFF, P_2);
			break;
		case ExceptionResource.CannotStartObjectArrayWithoutProperty:
			result = System.SR.Format("CannotStartObjectArrayWithoutProperty", P_4);
			break;
		case ExceptionResource.CannotStartObjectArrayAfterPrimitiveOrClose:
			result = System.SR.Format("CannotStartObjectArrayAfterPrimitiveOrClose", P_4);
			break;
		case ExceptionResource.CannotWriteValueWithinObject:
			result = System.SR.Format("CannotWriteValueWithinObject", P_4);
			break;
		case ExceptionResource.CannotWritePropertyWithinArray:
			result = ((P_4 == JsonTokenType.PropertyName) ? System.SR.Format("CannotWritePropertyAfterProperty") : System.SR.Format("CannotWritePropertyWithinArray", P_4));
			break;
		case ExceptionResource.CannotWriteValueAfterPrimitiveOrClose:
			result = System.SR.Format("CannotWriteValueAfterPrimitiveOrClose", P_4);
			break;
		}
		return result;
	}

	[DoesNotReturn]
	public static void ThrowFormatException()
	{
		throw new FormatException
		{
			Source = "System.Text.Json.Rethrowable"
		};
	}

	public static void ThrowFormatException(NumericType P_0)
	{
		string text = "";
		switch (P_0)
		{
		case NumericType.Byte:
			text = "FormatByte";
			break;
		case NumericType.SByte:
			text = "FormatSByte";
			break;
		case NumericType.Int16:
			text = "FormatInt16";
			break;
		case NumericType.Int32:
			text = "FormatInt32";
			break;
		case NumericType.Int64:
			text = "FormatInt64";
			break;
		case NumericType.UInt16:
			text = "FormatUInt16";
			break;
		case NumericType.UInt32:
			text = "FormatUInt32";
			break;
		case NumericType.UInt64:
			text = "FormatUInt64";
			break;
		case NumericType.Single:
			text = "FormatSingle";
			break;
		case NumericType.Double:
			text = "FormatDouble";
			break;
		case NumericType.Decimal:
			text = "FormatDecimal";
			break;
		}
		throw new FormatException(text)
		{
			Source = "System.Text.Json.Rethrowable"
		};
	}

	[DoesNotReturn]
	public static void ThrowFormatException(DataType P_0)
	{
		string text = "";
		switch (P_0)
		{
		case DataType.Boolean:
		case DataType.DateOnly:
		case DataType.DateTime:
		case DataType.DateTimeOffset:
		case DataType.TimeOnly:
		case DataType.TimeSpan:
		case DataType.Guid:
		case DataType.Version:
			text = System.SR.Format("UnsupportedFormat", P_0);
			break;
		case DataType.Base64String:
			text = "CannotDecodeInvalidBase64";
			break;
		}
		throw new FormatException(text)
		{
			Source = "System.Text.Json.Rethrowable"
		};
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_ExpectedChar(JsonTokenType P_0)
	{
		throw GetInvalidOperationException("char", P_0);
	}

	[DoesNotReturn]
	public static void ThrowObjectDisposedException_Utf8JsonWriter()
	{
		throw new ObjectDisposedException("Utf8JsonWriter");
	}

	[DoesNotReturn]
	public static void ThrowObjectDisposedException_JsonDocument()
	{
		throw new ObjectDisposedException("JsonDocument");
	}

	[DoesNotReturn]
	public static void ThrowArgumentException_NodeValueNotAllowed(string P_0)
	{
		throw new ArgumentException("NodeValueNotAllowed", P_0);
	}

	[DoesNotReturn]
	public static void ThrowArgumentException_DuplicateKey(string P_0, string P_1)
	{
		throw new ArgumentException(System.SR.Format("NodeDuplicateKey", P_1), P_0);
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_NodeAlreadyHasParent()
	{
		throw new InvalidOperationException("NodeAlreadyHasParent");
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_NodeCycleDetected()
	{
		throw new InvalidOperationException("NodeCycleDetected");
	}

	[DoesNotReturn]
	public static void ThrowNotSupportedException_CollectionIsReadOnly()
	{
		throw GetNotSupportedException_CollectionIsReadOnly();
	}

	public static NotSupportedException GetNotSupportedException_CollectionIsReadOnly()
	{
		return new NotSupportedException("CollectionIsReadOnly");
	}

	[DoesNotReturn]
	public static void ThrowArgumentException_DeserializeWrongType(Type P_0, object P_1)
	{
		throw new ArgumentException(System.SR.Format("DeserializeWrongType", P_0, P_1.GetType()));
	}

	[DoesNotReturn]
	public static void ThrowArgumentException_SerializerDoesNotSupportComments(string P_0)
	{
		throw new ArgumentException("JsonSerializerDoesNotSupportComments", P_0);
	}

	[DoesNotReturn]
	public static void ThrowNotSupportedException_SerializationNotSupported(Type P_0)
	{
		throw new NotSupportedException(System.SR.Format("SerializationNotSupportedType", P_0));
	}

	[DoesNotReturn]
	public static void ThrowNotSupportedException_TypeRequiresAsyncSerialization(Type P_0)
	{
		throw new NotSupportedException(System.SR.Format("TypeRequiresAsyncSerialization", P_0));
	}

	[DoesNotReturn]
	public static void ThrowNotSupportedException_ConstructorMaxOf64Parameters(Type P_0)
	{
		throw new NotSupportedException(System.SR.Format("ConstructorMaxOf64Parameters", P_0));
	}

	[DoesNotReturn]
	public static void ThrowNotSupportedException_DictionaryKeyTypeNotSupported(Type P_0, JsonConverter P_1)
	{
		throw new NotSupportedException(System.SR.Format("DictionaryKeyTypeNotSupported", P_0, P_1.GetType()));
	}

	[DoesNotReturn]
	public static void ThrowJsonException_DeserializeUnableToConvertValue(Type P_0)
	{
		throw new JsonException(System.SR.Format("DeserializeUnableToConvertValue", P_0))
		{
			AppendPathInformation = true
		};
	}

	[DoesNotReturn]
	public static void ThrowInvalidCastException_DeserializeUnableToAssignValue(Type P_0, Type P_1)
	{
		throw new InvalidCastException(System.SR.Format("DeserializeUnableToAssignValue", P_0, P_1));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_DeserializeUnableToAssignNull(Type P_0)
	{
		throw new InvalidOperationException(System.SR.Format("DeserializeUnableToAssignNull", P_0));
	}

	[DoesNotReturn]
	public static void ThrowJsonException_SerializationConverterRead(JsonConverter P_0)
	{
		throw new JsonException(System.SR.Format("SerializationConverterRead", P_0))
		{
			AppendPathInformation = true
		};
	}

	[DoesNotReturn]
	public static void ThrowJsonException_SerializationConverterWrite(JsonConverter P_0)
	{
		throw new JsonException(System.SR.Format("SerializationConverterWrite", P_0))
		{
			AppendPathInformation = true
		};
	}

	[DoesNotReturn]
	public static void ThrowJsonException_SerializerCycleDetected(int P_0)
	{
		throw new JsonException(System.SR.Format("SerializerCycleDetected", P_0))
		{
			AppendPathInformation = true
		};
	}

	[DoesNotReturn]
	public static void ThrowJsonException(string P_0 = null)
	{
		throw new JsonException(P_0)
		{
			AppendPathInformation = true
		};
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_CannotSerializeInvalidType(Type P_0, Type P_1, MemberInfo P_2)
	{
		if (P_1 == null)
		{
			throw new InvalidOperationException(System.SR.Format("CannotSerializeInvalidType", P_0));
		}
		throw new InvalidOperationException(System.SR.Format("CannotSerializeInvalidMember", P_0, P_2.Name, P_1));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_SerializationConverterNotCompatible(Type P_0, Type P_1)
	{
		throw new InvalidOperationException(System.SR.Format("SerializationConverterNotCompatible", P_0, P_1));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_ResolverTypeNotCompatible(Type P_0, Type P_1)
	{
		throw new InvalidOperationException(System.SR.Format("ResolverTypeNotCompatible", P_1, P_0));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_ResolverTypeInfoOptionsNotCompatible()
	{
		throw new InvalidOperationException("ResolverTypeInfoOptionsNotCompatible");
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_JsonTypeInfoUsedButTypeInfoResolverNotSet()
	{
		throw new InvalidOperationException("JsonTypeInfoUsedButTypeInfoResolverNotSet");
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_SerializationConverterOnAttributeInvalid(Type P_0, MemberInfo P_1)
	{
		string text = P_0.ToString();
		if (P_1 != null)
		{
			text = text + "." + P_1.Name;
		}
		throw new InvalidOperationException(System.SR.Format("SerializationConverterOnAttributeInvalid", text));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_SerializationConverterOnAttributeNotCompatible(Type P_0, MemberInfo P_1, Type P_2)
	{
		string text = P_0.ToString();
		if (P_1 != null)
		{
			text = text + "." + P_1.Name;
		}
		throw new InvalidOperationException(System.SR.Format("SerializationConverterOnAttributeNotCompatible", text, P_2));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_SerializerOptionsImmutable(JsonSerializerContext P_0)
	{
		string text = ((P_0 == null) ? "SerializerOptionsImmutable" : "SerializerContextOptionsImmutable");
		throw new InvalidOperationException(text);
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_TypeInfoImmutable()
	{
		throw new InvalidOperationException("TypeInfoImmutable");
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_PropertyInfoImmutable()
	{
		throw new InvalidOperationException("PropertyInfoImmutable");
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_SerializerPropertyNameConflict(Type P_0, string P_1)
	{
		throw new InvalidOperationException(System.SR.Format("SerializerPropertyNameConflict", P_0, P_1));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_SerializerPropertyNameNull(JsonPropertyInfo P_0)
	{
		throw new InvalidOperationException(System.SR.Format("SerializerPropertyNameNull", P_0.DeclaringType, P_0.MemberName));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_JsonPropertyRequiredAndNotDeserializable(JsonPropertyInfo P_0)
	{
		throw new InvalidOperationException(System.SR.Format("JsonPropertyRequiredAndNotDeserializable", P_0.Name, P_0.DeclaringType));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_JsonPropertyRequiredAndExtensionData(JsonPropertyInfo P_0)
	{
		throw new InvalidOperationException(System.SR.Format("JsonPropertyRequiredAndExtensionData", P_0.Name, P_0.DeclaringType));
	}

	[DoesNotReturn]
	public static void ThrowJsonException_JsonRequiredPropertyMissing(JsonTypeInfo P_0, BitArray P_1)
	{
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = true;
		for (int i = 0; i < P_0.PropertyCache.List.Count; i++)
		{
			JsonPropertyInfo value = P_0.PropertyCache.List[i].Value;
			if (value.IsRequired && !P_1[value.RequiredPropertyIndex])
			{
				if (!flag)
				{
					stringBuilder.Append(CultureInfo.CurrentUICulture.TextInfo.ListSeparator);
					stringBuilder.Append(' ');
				}
				stringBuilder.Append(value.Name);
				flag = false;
				if (stringBuilder.Length >= 50)
				{
					break;
				}
			}
		}
		throw new JsonException(System.SR.Format("JsonRequiredPropertiesMissing", P_0.Type, stringBuilder.ToString()));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_NamingPolicyReturnNull(JsonNamingPolicy P_0)
	{
		throw new InvalidOperationException(System.SR.Format("NamingPolicyReturnNull", P_0));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_SerializerConverterFactoryReturnsNull(Type P_0)
	{
		throw new InvalidOperationException(System.SR.Format("SerializerConverterFactoryReturnsNull", P_0));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_SerializerConverterFactoryReturnsJsonConverterFactorty(Type P_0)
	{
		throw new InvalidOperationException(System.SR.Format("SerializerConverterFactoryReturnsJsonConverterFactory", P_0));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_MultiplePropertiesBindToConstructorParameters(Type P_0, string P_1, string P_2, string P_3)
	{
		throw new InvalidOperationException(System.SR.Format("MultipleMembersBindWithConstructorParameter", P_2, P_3, P_0, P_1));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_ConstructorParameterIncompleteBinding(Type P_0)
	{
		throw new InvalidOperationException(System.SR.Format("ConstructorParamIncompleteBinding", P_0));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_ExtensionDataCannotBindToCtorParam(string P_0, JsonPropertyInfo P_1)
	{
		throw new InvalidOperationException(System.SR.Format("ExtensionDataCannotBindToCtorParam", P_0, P_1.DeclaringType));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_JsonIncludeOnNonPublicInvalid(string P_0, Type P_1)
	{
		throw new InvalidOperationException(System.SR.Format("JsonIncludeOnNonPublicInvalid", P_0, P_1));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_IgnoreConditionOnValueTypeInvalid(string P_0, Type P_1)
	{
		throw new InvalidOperationException(System.SR.Format("IgnoreConditionOnValueTypeInvalid", P_0, P_1));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_NumberHandlingOnPropertyInvalid(JsonPropertyInfo P_0)
	{
		throw new InvalidOperationException(System.SR.Format("NumberHandlingOnPropertyInvalid", P_0.MemberName, P_0.DeclaringType));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_ConverterCanConvertMultipleTypes(Type P_0, JsonConverter P_1)
	{
		throw new InvalidOperationException(System.SR.Format("ConverterCanConvertMultipleTypes", P_1.GetType(), P_1.TypeToConvert, P_0));
	}

	[DoesNotReturn]
	public static void ThrowNotSupportedException_ObjectWithParameterizedCtorRefMetadataNotSupported(ReadOnlySpan<byte> P_0, ref Utf8JsonReader P_1, scoped ref ReadStack P_2)
	{
		JsonTypeInfo topJsonTypeInfoWithParameterizedConstructor = P_2.GetTopJsonTypeInfoWithParameterizedConstructor();
		P_2.Current.JsonPropertyName = P_0.ToArray();
		NotSupportedException ex = new NotSupportedException(System.SR.Format("ObjectWithParameterizedCtorRefMetadataNotSupported", topJsonTypeInfoWithParameterizedConstructor.Type));
		ThrowNotSupportedException(ref P_2, in P_1, ex);
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_JsonTypeInfoOperationNotPossibleForKind(JsonTypeInfoKind P_0)
	{
		throw new InvalidOperationException(System.SR.Format("InvalidJsonTypeInfoOperationForKind", P_0));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_CreateObjectConverterNotCompatible(Type P_0)
	{
		throw new InvalidOperationException(System.SR.Format("CreateObjectConverterNotCompatible", P_0));
	}

	[DoesNotReturn]
	public static void ReThrowWithPath(scoped ref ReadStack P_0, JsonReaderException P_1)
	{
		string text = P_0.JsonPath();
		string message = P_1.Message;
		int num = message.AsSpan().LastIndexOf(" LineNumber: ");
		message = ((num < 0) ? (message + " Path: " + text + ".") : $"{message.Substring(0, num)} Path: {text} |{message.Substring(num)}");
		throw new JsonException(message, text, P_1.LineNumber, P_1.BytePositionInLine, P_1);
	}

	[DoesNotReturn]
	public static void ReThrowWithPath(scoped ref ReadStack P_0, in Utf8JsonReader P_1, Exception P_2)
	{
		JsonException ex = new JsonException(null, P_2);
		AddJsonExceptionInformation(ref P_0, in P_1, ex);
		throw ex;
	}

	public static void AddJsonExceptionInformation(scoped ref ReadStack P_0, in Utf8JsonReader P_1, JsonException P_2)
	{
		long lineNumber = P_1.CurrentState._lineNumber;
		P_2.LineNumber = lineNumber;
		long bytePositionInLine = P_1.CurrentState._bytePositionInLine;
		P_2.BytePositionInLine = bytePositionInLine;
		string text = (P_2.Path = P_0.JsonPath());
		string text3 = P_2._message;
		if (string.IsNullOrEmpty(text3))
		{
			Type type = P_0.Current.JsonPropertyInfo?.PropertyType ?? P_0.Current.JsonTypeInfo.Type;
			text3 = System.SR.Format("DeserializeUnableToConvertValue", type);
			P_2.AppendPathInformation = true;
		}
		if (P_2.AppendPathInformation)
		{
			text3 += $" Path: {text} | LineNumber: {lineNumber} | BytePositionInLine: {bytePositionInLine}.";
			P_2.SetMessage(text3);
		}
	}

	[DoesNotReturn]
	public static void ReThrowWithPath(ref WriteStack P_0, Exception P_1)
	{
		JsonException ex = new JsonException(null, P_1);
		AddJsonExceptionInformation(ref P_0, ex);
		throw ex;
	}

	public static void AddJsonExceptionInformation(ref WriteStack P_0, JsonException P_1)
	{
		string text = (P_1.Path = P_0.PropertyPath());
		string text3 = P_1._message;
		if (string.IsNullOrEmpty(text3))
		{
			text3 = System.SR.Format("SerializeUnableToSerialize");
			P_1.AppendPathInformation = true;
		}
		if (P_1.AppendPathInformation)
		{
			text3 = text3 + " Path: " + text + ".";
			P_1.SetMessage(text3);
		}
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_SerializationDuplicateAttribute(Type P_0, MemberInfo P_1)
	{
		string text = ((P_1 is Type type) ? type.ToString() : $"{P_1.DeclaringType}.{P_1.Name}");
		throw new InvalidOperationException(System.SR.Format("SerializationDuplicateAttribute", P_0, text));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_SerializationDuplicateTypeAttribute(Type P_0, Type P_1)
	{
		throw new InvalidOperationException(System.SR.Format("SerializationDuplicateTypeAttribute", P_0, P_1));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_SerializationDuplicateTypeAttribute<TAttribute>(Type P_0)
	{
		throw new InvalidOperationException(System.SR.Format("SerializationDuplicateTypeAttribute", P_0, typeof(TAttribute)));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_SerializationDataExtensionPropertyInvalid(JsonPropertyInfo P_0)
	{
		throw new InvalidOperationException(System.SR.Format("SerializationDataExtensionPropertyInvalid", P_0.PropertyType, P_0.MemberName));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_NodeJsonObjectCustomConverterNotAllowedOnExtensionProperty()
	{
		throw new InvalidOperationException("NodeJsonObjectCustomConverterNotAllowedOnExtensionProperty");
	}

	[DoesNotReturn]
	public static void ThrowNotSupportedException(scoped ref ReadStack P_0, in Utf8JsonReader P_1, NotSupportedException P_2)
	{
		string text = P_2.Message;
		Type type = P_0.Current.JsonPropertyInfo?.PropertyType ?? P_0.Current.JsonTypeInfo.Type;
		if (!text.Contains(type.ToString()))
		{
			if (text.Length > 0)
			{
				text += " ";
			}
			text += System.SR.Format("SerializationNotSupportedParentType", type);
		}
		long lineNumber = P_1.CurrentState._lineNumber;
		long bytePositionInLine = P_1.CurrentState._bytePositionInLine;
		text += $" Path: {P_0.JsonPath()} | LineNumber: {lineNumber} | BytePositionInLine: {bytePositionInLine}.";
		throw new NotSupportedException(text, P_2);
	}

	[DoesNotReturn]
	public static void ThrowNotSupportedException(ref WriteStack P_0, NotSupportedException P_1)
	{
		string text = P_1.Message;
		Type type = P_0.Current.JsonPropertyInfo?.PropertyType ?? P_0.Current.JsonTypeInfo.Type;
		if (!text.Contains(type.ToString()))
		{
			if (text.Length > 0)
			{
				text += " ";
			}
			text += System.SR.Format("SerializationNotSupportedParentType", type);
		}
		text = text + " Path: " + P_0.PropertyPath() + ".";
		throw new NotSupportedException(text, P_1);
	}

	[DoesNotReturn]
	public static void ThrowNotSupportedException_DeserializeNoConstructor(Type P_0, ref Utf8JsonReader P_1, scoped ref ReadStack P_2)
	{
		string text = ((!P_0.IsInterface) ? System.SR.Format("DeserializeNoConstructor", "JsonConstructorAttribute", P_0) : System.SR.Format("DeserializePolymorphicInterface", P_0));
		ThrowNotSupportedException(ref P_2, in P_1, new NotSupportedException(text));
	}

	[DoesNotReturn]
	public static void ThrowNotSupportedException_CannotPopulateCollection(Type P_0, ref Utf8JsonReader P_1, scoped ref ReadStack P_2)
	{
		ThrowNotSupportedException(ref P_2, in P_1, new NotSupportedException(System.SR.Format("CannotPopulateCollection", P_0)));
	}

	[DoesNotReturn]
	public static void ThrowJsonException_MetadataValuesInvalidToken(JsonTokenType P_0)
	{
		ThrowJsonException(System.SR.Format("MetadataInvalidTokenAfterValues", P_0));
	}

	[DoesNotReturn]
	public static void ThrowJsonException_MetadataValueWasNotString(JsonTokenType P_0)
	{
		ThrowJsonException(System.SR.Format("MetadataValueWasNotString", P_0));
	}

	[DoesNotReturn]
	public static void ThrowJsonException_MetadataValueWasNotString(JsonValueKind P_0)
	{
		ThrowJsonException(System.SR.Format("MetadataValueWasNotString", P_0));
	}

	[DoesNotReturn]
	public static void ThrowJsonException_MetadataReferenceObjectCannotContainOtherProperties(ReadOnlySpan<byte> P_0, scoped ref ReadStack P_1)
	{
		P_1.Current.JsonPropertyName = P_0.ToArray();
		ThrowJsonException_MetadataReferenceObjectCannotContainOtherProperties();
	}

	[DoesNotReturn]
	public static void ThrowJsonException_MetadataUnexpectedProperty(ReadOnlySpan<byte> P_0, scoped ref ReadStack P_1)
	{
		P_1.Current.JsonPropertyName = P_0.ToArray();
		ThrowJsonException(System.SR.Format("MetadataUnexpectedProperty"));
	}

	[DoesNotReturn]
	public static void ThrowJsonException_MetadataReferenceObjectCannotContainOtherProperties()
	{
		ThrowJsonException("MetadataReferenceCannotContainOtherProperties");
	}

	[DoesNotReturn]
	public static void ThrowJsonException_MetadataIdIsNotFirstProperty(ReadOnlySpan<byte> P_0, scoped ref ReadStack P_1)
	{
		P_1.Current.JsonPropertyName = P_0.ToArray();
		ThrowJsonException("MetadataIdIsNotFirstProperty");
	}

	[DoesNotReturn]
	public static void ThrowJsonException_MetadataStandaloneValuesProperty(scoped ref ReadStack P_0, ReadOnlySpan<byte> P_1)
	{
		P_0.Current.JsonPropertyName = P_1.ToArray();
		ThrowJsonException("MetadataStandaloneValuesProperty");
	}

	[DoesNotReturn]
	public static void ThrowJsonException_MetadataInvalidPropertyWithLeadingDollarSign(ReadOnlySpan<byte> P_0, scoped ref ReadStack P_1, in Utf8JsonReader P_2)
	{
		if (P_1.Current.IsProcessingDictionary())
		{
			P_1.Current.JsonPropertyNameAsString = P_2.GetString();
		}
		else
		{
			P_1.Current.JsonPropertyName = P_0.ToArray();
		}
		ThrowJsonException("MetadataInvalidPropertyWithLeadingDollarSign");
	}

	[DoesNotReturn]
	public static void ThrowJsonException_MetadataDuplicateTypeProperty()
	{
		ThrowJsonException("MetadataDuplicateTypeProperty");
	}

	[DoesNotReturn]
	public static void ThrowJsonException_MetadataInvalidReferenceToValueType(Type P_0)
	{
		ThrowJsonException(System.SR.Format("MetadataInvalidReferenceToValueType", P_0));
	}

	[DoesNotReturn]
	public static void ThrowJsonException_MetadataInvalidPropertyInArrayMetadata(scoped ref ReadStack P_0, Type P_1, in Utf8JsonReader P_2)
	{
		P_0.Current.JsonPropertyName = (P_2.HasValueSequence ? P_2.ValueSequence.ToArray<byte>() : P_2.ValueSpan.ToArray());
		string text = P_2.GetString();
		ThrowJsonException(System.SR.Format("MetadataPreservedArrayFailed", System.SR.Format("MetadataInvalidPropertyInArrayMetadata", text), System.SR.Format("DeserializeUnableToConvertValue", P_1)));
	}

	[DoesNotReturn]
	public static void ThrowJsonException_MetadataPreservedArrayValuesNotFound(scoped ref ReadStack P_0, Type P_1)
	{
		P_0.Current.JsonPropertyName = null;
		ThrowJsonException(System.SR.Format("MetadataPreservedArrayFailed", "MetadataStandaloneValuesProperty", System.SR.Format("DeserializeUnableToConvertValue", P_1)));
	}

	[DoesNotReturn]
	public static void ThrowJsonException_MetadataCannotParsePreservedObjectIntoImmutable(Type P_0)
	{
		ThrowJsonException(System.SR.Format("MetadataCannotParsePreservedObjectToImmutable", P_0));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_MetadataReferenceOfTypeCannotBeAssignedToType(string P_0, Type P_1, Type P_2)
	{
		throw new InvalidOperationException(System.SR.Format("MetadataReferenceOfTypeCannotBeAssignedToType", P_0, P_1, P_2));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_JsonPropertyInfoIsBoundToDifferentJsonTypeInfo(JsonPropertyInfo P_0)
	{
		throw new InvalidOperationException(System.SR.Format("JsonPropertyInfoBoundToDifferentParent", P_0.Name, P_0.ParentTypeInfo.Type.FullName));
	}

	[DoesNotReturn]
	internal static void ThrowUnexpectedMetadataException(ReadOnlySpan<byte> P_0, ref Utf8JsonReader P_1, scoped ref ReadStack P_2)
	{
		if (JsonSerializer.GetMetadataPropertyName(P_0, P_2.Current.BaseJsonTypeInfo.PolymorphicTypeResolver) != MetadataPropertyName.None)
		{
			ThrowJsonException_MetadataUnexpectedProperty(P_0, ref P_2);
		}
		else
		{
			ThrowJsonException_MetadataInvalidPropertyWithLeadingDollarSign(P_0, ref P_2, in P_1);
		}
	}

	[DoesNotReturn]
	public static void ThrowNotSupportedException_NoMetadataForType(Type P_0, IJsonTypeInfoResolver P_1)
	{
		throw new NotSupportedException(System.SR.Format("NoMetadataForType", P_0, P_1?.GetType().FullName ?? "<null>"));
	}

	[DoesNotReturn]
	public static void ThrowNotSupportedException_ConstructorContainsNullParameterNames(Type P_0)
	{
		throw new NotSupportedException(System.SR.Format("ConstructorContainsNullParameterNames", P_0));
	}

	public static Exception GetInvalidOperationException_NoMetadataForTypeProperties(IJsonTypeInfoResolver P_0, Type P_1)
	{
		return new InvalidOperationException(System.SR.Format("NoMetadataForTypeProperties", P_0?.GetType().FullName ?? "<null>", P_1));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_NoMetadataForTypeProperties(IJsonTypeInfoResolver P_0, Type P_1)
	{
		throw GetInvalidOperationException_NoMetadataForTypeProperties(P_0, P_1);
	}

	[DoesNotReturn]
	public static void ThrowMissingMemberException_MissingFSharpCoreMember(string P_0)
	{
		throw new MissingMemberException(System.SR.Format("MissingFSharpCoreMember", P_0));
	}

	[DoesNotReturn]
	public static void ThrowNotSupportedException_BaseConverterDoesNotSupportMetadata(Type P_0)
	{
		throw new NotSupportedException(System.SR.Format("Polymorphism_DerivedConverterDoesNotSupportMetadata", P_0));
	}

	[DoesNotReturn]
	public static void ThrowNotSupportedException_DerivedConverterDoesNotSupportMetadata(Type P_0)
	{
		throw new NotSupportedException(System.SR.Format("Polymorphism_DerivedConverterDoesNotSupportMetadata", P_0));
	}

	[DoesNotReturn]
	public static void ThrowNotSupportedException_RuntimeTypeNotSupported(Type P_0, Type P_1)
	{
		throw new NotSupportedException(System.SR.Format("Polymorphism_RuntimeTypeNotSupported", P_1, P_0));
	}

	[DoesNotReturn]
	public static void ThrowNotSupportedException_RuntimeTypeDiamondAmbiguity(Type P_0, Type P_1, Type P_2, Type P_3)
	{
		throw new NotSupportedException(System.SR.Format("Polymorphism_RuntimeTypeDiamondAmbiguity", P_1, P_2, P_3, P_0));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_TypeDoesNotSupportPolymorphism(Type P_0)
	{
		throw new InvalidOperationException(System.SR.Format("Polymorphism_TypeDoesNotSupportPolymorphism", P_0));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_DerivedTypeNotSupported(Type P_0, Type P_1)
	{
		throw new InvalidOperationException(System.SR.Format("Polymorphism_DerivedTypeIsNotSupported", P_1, P_0));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_DerivedTypeIsAlreadySpecified(Type P_0, Type P_1)
	{
		throw new InvalidOperationException(System.SR.Format("Polymorphism_DerivedTypeIsAlreadySpecified", P_0, P_1));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_TypeDicriminatorIdIsAlreadySpecified(Type P_0, object P_1)
	{
		throw new InvalidOperationException(System.SR.Format("Polymorphism_TypeDicriminatorIdIsAlreadySpecified", P_0, P_1));
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_InvalidCustomTypeDiscriminatorPropertyName()
	{
		throw new InvalidOperationException("Polymorphism_InvalidCustomTypeDiscriminatorPropertyName");
	}

	[DoesNotReturn]
	public static void ThrowInvalidOperationException_PolymorphicTypeConfigurationDoesNotSpecifyDerivedTypes(Type P_0)
	{
		throw new InvalidOperationException(System.SR.Format("Polymorphism_ConfigurationDoesNotSpecifyDerivedTypes", P_0));
	}

	[DoesNotReturn]
	public static void ThrowJsonException_UnrecognizedTypeDiscriminator(object P_0)
	{
		ThrowJsonException(System.SR.Format("Polymorphism_UnrecognizedTypeDiscriminator", P_0));
	}
}
