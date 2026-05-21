using System.Buffers.Binary;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System;

[Serializable]
[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public abstract class Enum : ValueType, IComparable, IFormattable, IConvertible
{
	internal sealed class EnumInfo
	{
		public readonly bool HasFlagsAttribute;

		public readonly ulong[] Values;

		public readonly string[] Names;

		public EnumInfo(bool P_0, ulong[] P_1, string[] P_2)
		{
			HasFlagsAttribute = P_0;
			Values = P_1;
			Names = P_2;
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool GetEnumValuesAndNames(QCallTypeHandle P_0, out ulong[] P_1, out string[] P_2);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void InternalBoxEnum(QCallTypeHandle P_0, ObjectHandleOnStack P_1, long P_2);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern CorElementType InternalGetCorElementType(QCallTypeHandle P_0);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void InternalGetUnderlyingType(QCallTypeHandle P_0, ObjectHandleOnStack P_1);

	private static object InternalBoxEnum(RuntimeType P_0, long P_1)
	{
		object result = null;
		InternalBoxEnum(new QCallTypeHandle(ref P_0), ObjectHandleOnStack.Create(ref result), P_1);
		return result;
	}

	private CorElementType InternalGetCorElementType()
	{
		RuntimeType runtimeType = (RuntimeType)GetType();
		return InternalGetCorElementType(new QCallTypeHandle(ref runtimeType));
	}

	internal static RuntimeType InternalGetUnderlyingType(RuntimeType P_0)
	{
		RuntimeType result = null;
		InternalGetUnderlyingType(new QCallTypeHandle(ref P_0), ObjectHandleOnStack.Create(ref result));
		return result;
	}

	private static EnumInfo GetEnumInfo(RuntimeType P_0, bool P_1 = true)
	{
		EnumInfo enumInfo = P_0.Cache.EnumInfo;
		if (enumInfo == null || (P_1 && enumInfo.Names == null))
		{
			if (!GetEnumValuesAndNames(new QCallTypeHandle(ref P_0), out var array, out var array2))
			{
				Array.Sort(array, array2, Comparer<ulong>.Default);
			}
			bool flag = P_0.IsDefined(typeof(FlagsAttribute), false);
			enumInfo = new EnumInfo(flag, array, array2);
			P_0.Cache.EnumInfo = enumInfo;
		}
		return enumInfo;
	}

	private string ValueToString()
	{
		ref byte rawData = ref this.GetRawData();
		return InternalGetCorElementType() switch
		{
			CorElementType.ELEMENT_TYPE_I1 => Unsafe.As<byte, sbyte>(ref rawData).ToString(), 
			CorElementType.ELEMENT_TYPE_U1 => rawData.ToString(), 
			CorElementType.ELEMENT_TYPE_BOOLEAN => Unsafe.As<byte, bool>(ref rawData).ToString(), 
			CorElementType.ELEMENT_TYPE_I2 => Unsafe.As<byte, short>(ref rawData).ToString(), 
			CorElementType.ELEMENT_TYPE_U2 => Unsafe.As<byte, ushort>(ref rawData).ToString(), 
			CorElementType.ELEMENT_TYPE_CHAR => Unsafe.As<byte, char>(ref rawData).ToString(), 
			CorElementType.ELEMENT_TYPE_I4 => Unsafe.As<byte, int>(ref rawData).ToString(), 
			CorElementType.ELEMENT_TYPE_U4 => Unsafe.As<byte, uint>(ref rawData).ToString(), 
			CorElementType.ELEMENT_TYPE_R4 => Unsafe.As<byte, float>(ref rawData).ToString(), 
			CorElementType.ELEMENT_TYPE_I8 => Unsafe.As<byte, long>(ref rawData).ToString(), 
			CorElementType.ELEMENT_TYPE_U8 => Unsafe.As<byte, ulong>(ref rawData).ToString(), 
			CorElementType.ELEMENT_TYPE_R8 => Unsafe.As<byte, double>(ref rawData).ToString(), 
			CorElementType.ELEMENT_TYPE_I => ((IntPtr)Unsafe.As<byte, nint>(ref rawData)).ToString(), 
			CorElementType.ELEMENT_TYPE_U => ((UIntPtr)Unsafe.As<byte, nuint>(ref rawData)).ToString(), 
			_ => throw new InvalidOperationException("InvalidOperation_UnknownEnumType"), 
		};
	}

	private string ValueToHexString()
	{
		ref byte rawData = ref this.GetRawData();
		Span<byte> span = stackalloc byte[8];
		int num;
		switch (InternalGetCorElementType())
		{
		case CorElementType.ELEMENT_TYPE_I1:
		case CorElementType.ELEMENT_TYPE_U1:
			span[0] = rawData;
			num = 1;
			break;
		case CorElementType.ELEMENT_TYPE_BOOLEAN:
			if (rawData == 0)
			{
				return "00";
			}
			return "01";
		case CorElementType.ELEMENT_TYPE_CHAR:
		case CorElementType.ELEMENT_TYPE_I2:
		case CorElementType.ELEMENT_TYPE_U2:
			BinaryPrimitives.WriteUInt16BigEndian(span, Unsafe.As<byte, ushort>(ref rawData));
			num = 2;
			break;
		case CorElementType.ELEMENT_TYPE_I4:
		case CorElementType.ELEMENT_TYPE_U4:
			BinaryPrimitives.WriteUInt32BigEndian(span, Unsafe.As<byte, uint>(ref rawData));
			num = 4;
			break;
		case CorElementType.ELEMENT_TYPE_I8:
		case CorElementType.ELEMENT_TYPE_U8:
			BinaryPrimitives.WriteUInt64BigEndian(span, Unsafe.As<byte, ulong>(ref rawData));
			num = 8;
			break;
		default:
			throw new InvalidOperationException("InvalidOperation_UnknownEnumType");
		}
		return HexConverter.ToString(span.Slice(0, num));
	}

	private static string ValueToHexString(object P_0)
	{
		return Convert.GetTypeCode(P_0) switch
		{
			TypeCode.SByte => ((byte)(sbyte)P_0).ToString("X2", null), 
			TypeCode.Byte => ((byte)P_0).ToString("X2", null), 
			TypeCode.Boolean => ((bool)P_0) ? "01" : "00", 
			TypeCode.Int16 => ((ushort)(short)P_0).ToString("X4", null), 
			TypeCode.UInt16 => ((ushort)P_0).ToString("X4", null), 
			TypeCode.Char => ((ushort)(char)P_0).ToString("X4", null), 
			TypeCode.UInt32 => ((uint)P_0).ToString("X8", null), 
			TypeCode.Int32 => ((uint)(int)P_0).ToString("X8", null), 
			TypeCode.UInt64 => ((ulong)P_0).ToString("X16", null), 
			TypeCode.Int64 => ((ulong)(long)P_0).ToString("X16", null), 
			_ => throw new InvalidOperationException("InvalidOperation_UnknownEnumType"), 
		};
	}

	internal static string GetEnumName(RuntimeType P_0, ulong P_1)
	{
		return GetEnumName(GetEnumInfo(P_0), P_1);
	}

	private static string GetEnumName(EnumInfo P_0, ulong P_1)
	{
		int num = FindDefinedIndex(P_0.Values, P_1);
		if (num >= 0)
		{
			return P_0.Names[num];
		}
		return null;
	}

	private static string InternalFormat(RuntimeType P_0, ulong P_1)
	{
		EnumInfo enumInfo = GetEnumInfo(P_0);
		if (!enumInfo.HasFlagsAttribute)
		{
			return GetEnumName(enumInfo, P_1);
		}
		return InternalFlagsFormat(enumInfo, P_1);
	}

	private static string InternalFlagsFormat(RuntimeType P_0, ulong P_1)
	{
		return InternalFlagsFormat(GetEnumInfo(P_0), P_1);
	}

	private static string InternalFlagsFormat(EnumInfo P_0, ulong P_1)
	{
		string[] names = P_0.Names;
		ulong[] values = P_0.Values;
		if (P_1 == 0L)
		{
			if (values.Length == 0 || values[0] != 0L)
			{
				return "0";
			}
			return names[0];
		}
		Span<int> span = stackalloc int[64];
		int num;
		for (num = values.Length - 1; num >= 0; num--)
		{
			if (values[num] == P_1)
			{
				return names[num];
			}
			if (values[num] < P_1)
			{
				break;
			}
		}
		int num2 = 0;
		int num3 = 0;
		while (num >= 0)
		{
			ulong num4 = values[num];
			if (num == 0 && num4 == 0L)
			{
				break;
			}
			if ((P_1 & num4) == num4)
			{
				P_1 -= num4;
				span[num3++] = num;
				num2 = checked(num2 + names[num].Length);
			}
			num--;
		}
		if (P_1 != 0L)
		{
			return null;
		}
		string text = string.FastAllocateString(checked(num2 + 2 * (num3 - 1)));
		Span<char> span2 = new Span<char>(ref text.GetRawStringData(), text.Length);
		string text2 = names[span[--num3]];
		text2.CopyTo(span2);
		span2 = span2.Slice(text2.Length);
		while (--num3 >= 0)
		{
			span2[0] = ',';
			span2[1] = ' ';
			span2 = span2.Slice(2);
			text2 = names[span[num3]];
			text2.CopyTo(span2);
			span2 = span2.Slice(text2.Length);
		}
		return text;
	}

	internal static ulong ToUInt64(object P_0)
	{
		return Convert.GetTypeCode(P_0) switch
		{
			TypeCode.SByte => (ulong)(sbyte)P_0, 
			TypeCode.Byte => (byte)P_0, 
			TypeCode.Boolean => (ulong)(((bool)P_0) ? 1 : 0), 
			TypeCode.Int16 => (ulong)(short)P_0, 
			TypeCode.UInt16 => (ushort)P_0, 
			TypeCode.Char => (char)P_0, 
			TypeCode.UInt32 => (uint)P_0, 
			TypeCode.Int32 => (ulong)(int)P_0, 
			TypeCode.UInt64 => (ulong)P_0, 
			TypeCode.Int64 => (ulong)(long)P_0, 
			_ => throw new InvalidOperationException("InvalidOperation_UnknownEnumType"), 
		};
	}

	private static ulong ToUInt64<TEnum>(TEnum P_0) where TEnum : struct, Enum
	{
		return Type.GetTypeCode(typeof(TEnum)) switch
		{
			TypeCode.SByte => (ulong)Unsafe.As<TEnum, sbyte>(ref P_0), 
			TypeCode.Byte => Unsafe.As<TEnum, byte>(ref P_0), 
			TypeCode.Boolean => (ulong)(Unsafe.As<TEnum, bool>(ref P_0) ? 1 : 0), 
			TypeCode.Int16 => (ulong)Unsafe.As<TEnum, short>(ref P_0), 
			TypeCode.UInt16 => Unsafe.As<TEnum, ushort>(ref P_0), 
			TypeCode.Char => Unsafe.As<TEnum, char>(ref P_0), 
			TypeCode.UInt32 => Unsafe.As<TEnum, uint>(ref P_0), 
			TypeCode.Int32 => (ulong)Unsafe.As<TEnum, int>(ref P_0), 
			TypeCode.UInt64 => Unsafe.As<TEnum, ulong>(ref P_0), 
			TypeCode.Int64 => (ulong)Unsafe.As<TEnum, long>(ref P_0), 
			_ => throw new InvalidOperationException("InvalidOperation_UnknownEnumType"), 
		};
	}

	public static string? GetName<TEnum>(TEnum P_0) where TEnum : struct, Enum
	{
		return GetEnumName((RuntimeType)typeof(TEnum), ToUInt64(P_0));
	}

	public static string? GetName(Type P_0, object P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "enumType");
		return P_0.GetEnumName(P_1);
	}

	public static string[] GetNames<TEnum>() where TEnum : struct, Enum
	{
		return new ReadOnlySpan<string>(InternalGetNames((RuntimeType)typeof(TEnum))).ToArray();
	}

	internal static string[] InternalGetNames(RuntimeType P_0)
	{
		return GetEnumInfo(P_0).Names;
	}

	public static Type GetUnderlyingType(Type P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "enumType");
		return P_0.GetEnumUnderlyingType();
	}

	public static TEnum[] GetValues<TEnum>() where TEnum : struct, Enum
	{
		return (TEnum[])GetValues(typeof(TEnum));
	}

	[RequiresDynamicCode("It might not be possible to create an array of the enum type at runtime. Use the GetValues<TEnum> overload or the GetValuesAsUnderlyingType method instead.")]
	public static Array GetValues(Type P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "enumType");
		return P_0.GetEnumValues();
	}

	public static Array GetValuesAsUnderlyingType(Type P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "enumType");
		return P_0.GetEnumValuesAsUnderlyingType();
	}

	[Intrinsic]
	public bool HasFlag(Enum P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "flag");
		if (GetType() != P_0.GetType() && !GetType().IsEquivalentTo(P_0.GetType()))
		{
			throw new ArgumentException(SR.Format("Argument_EnumTypeDoesNotMatch", P_0.GetType(), GetType()));
		}
		ref byte rawData = ref this.GetRawData();
		ref byte rawData2 = ref P_0.GetRawData();
		switch (InternalGetCorElementType())
		{
		case CorElementType.ELEMENT_TYPE_BOOLEAN:
		case CorElementType.ELEMENT_TYPE_I1:
		case CorElementType.ELEMENT_TYPE_U1:
		{
			byte b = rawData2;
			return (rawData & b) == b;
		}
		case CorElementType.ELEMENT_TYPE_CHAR:
		case CorElementType.ELEMENT_TYPE_I2:
		case CorElementType.ELEMENT_TYPE_U2:
		{
			ushort num3 = Unsafe.As<byte, ushort>(ref rawData2);
			return (Unsafe.As<byte, ushort>(ref rawData) & num3) == num3;
		}
		case CorElementType.ELEMENT_TYPE_I4:
		case CorElementType.ELEMENT_TYPE_U4:
		case CorElementType.ELEMENT_TYPE_R4:
		case CorElementType.ELEMENT_TYPE_I:
		case CorElementType.ELEMENT_TYPE_U:
		{
			uint num2 = Unsafe.As<byte, uint>(ref rawData2);
			return (Unsafe.As<byte, uint>(ref rawData) & num2) == num2;
		}
		case CorElementType.ELEMENT_TYPE_I8:
		case CorElementType.ELEMENT_TYPE_U8:
		case CorElementType.ELEMENT_TYPE_R8:
		{
			ulong num = Unsafe.As<byte, ulong>(ref rawData2);
			return (Unsafe.As<byte, ulong>(ref rawData) & num) == num;
		}
		default:
			return false;
		}
	}

	internal static ulong[] InternalGetValues(RuntimeType P_0)
	{
		return GetEnumInfo(P_0, false).Values;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int FindDefinedIndex(ulong[] P_0, ulong P_1)
	{
		int num = P_0.Length;
		ref ulong arrayDataReference = ref MemoryMarshal.GetArrayDataReference(P_0);
		if (num > 32)
		{
			return SpanHelpers.BinarySearch(ref arrayDataReference, num, P_1);
		}
		return SpanHelpers.IndexOfValueType(ref Unsafe.As<ulong, long>(ref arrayDataReference), (long)P_1, num);
	}

	public static bool IsDefined(Type P_0, object P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "enumType");
		return P_0.IsEnumDefined(P_1);
	}

	public static object Parse(Type P_0, string P_1)
	{
		return Parse(P_0, P_1, false);
	}

	public static object Parse(Type P_0, string P_1, bool P_2)
	{
		object result;
		bool flag = TryParse(P_0, P_1, P_2, true, out result);
		return result;
	}

	public static bool TryParse(Type P_0, string? P_1, bool P_2, [NotNullWhen(true)] out object? P_3)
	{
		return TryParse(P_0, P_1, P_2, false, out P_3);
	}

	private static bool TryParse(Type P_0, string P_1, bool P_2, bool P_3, [NotNullWhen(true)] out object P_4)
	{
		if (P_1 == null)
		{
			if (P_3)
			{
				ThrowHelper.ThrowArgumentNullException(ExceptionArgument.value);
			}
			P_4 = null;
			return false;
		}
		return TryParse(P_0, P_1.AsSpan(), P_2, P_3, out P_4);
	}

	private static bool TryParse(Type P_0, ReadOnlySpan<char> P_1, bool P_2, bool P_3, [NotNullWhen(true)] out object P_4)
	{
		RuntimeType runtimeType = ValidateRuntimeType(P_0);
		P_1 = P_1.TrimStart();
		if (P_1.Length == 0)
		{
			if (P_3)
			{
				throw new ArgumentException("Arg_MustContainEnumInfo", "value");
			}
			P_4 = null;
			return false;
		}
		int num2;
		uint num3;
		switch (Type.GetTypeCode(runtimeType))
		{
		case TypeCode.SByte:
		{
			bool flag = TryParseInt32Enum(runtimeType, P_1, -128, 127, P_2, P_3, TypeCode.SByte, out num2);
			P_4 = (flag ? InternalBoxEnum(runtimeType, num2) : null);
			return flag;
		}
		case TypeCode.Int16:
		{
			bool flag = TryParseInt32Enum(runtimeType, P_1, -32768, 32767, P_2, P_3, TypeCode.Int16, out num2);
			P_4 = (flag ? InternalBoxEnum(runtimeType, num2) : null);
			return flag;
		}
		case TypeCode.Int32:
		{
			bool flag = TryParseInt32Enum(runtimeType, P_1, -2147483648, 2147483647, P_2, P_3, TypeCode.Int32, out num2);
			P_4 = (flag ? InternalBoxEnum(runtimeType, num2) : null);
			return flag;
		}
		case TypeCode.Byte:
		{
			bool flag = TryParseUInt32Enum(runtimeType, P_1, 255u, P_2, P_3, TypeCode.Byte, out num3);
			P_4 = (flag ? InternalBoxEnum(runtimeType, num3) : null);
			return flag;
		}
		case TypeCode.UInt16:
		{
			bool flag = TryParseUInt32Enum(runtimeType, P_1, 65535u, P_2, P_3, TypeCode.UInt16, out num3);
			P_4 = (flag ? InternalBoxEnum(runtimeType, num3) : null);
			return flag;
		}
		case TypeCode.UInt32:
		{
			bool flag = TryParseUInt32Enum(runtimeType, P_1, 4294967295u, P_2, P_3, TypeCode.UInt32, out num3);
			P_4 = (flag ? InternalBoxEnum(runtimeType, num3) : null);
			return flag;
		}
		case TypeCode.Int64:
		{
			long num4;
			bool flag = TryParseInt64Enum(runtimeType, P_1, P_2, P_3, out num4);
			P_4 = (flag ? InternalBoxEnum(runtimeType, num4) : null);
			return flag;
		}
		case TypeCode.UInt64:
		{
			ulong num;
			bool flag = TryParseUInt64Enum(runtimeType, P_1, P_2, P_3, out num);
			P_4 = (flag ? InternalBoxEnum(runtimeType, (long)num) : null);
			return flag;
		}
		default:
			return TryParseRareEnum(runtimeType, P_1, P_2, P_3, out P_4);
		}
	}

	public static bool TryParse<TEnum>([NotNullWhen(true)] string? P_0, out TEnum P_1) where TEnum : struct
	{
		return TryParse<TEnum>(P_0, false, out P_1);
	}

	public static bool TryParse<TEnum>(ReadOnlySpan<char> P_0, out TEnum P_1) where TEnum : struct
	{
		return TryParse<TEnum>(P_0, false, out P_1);
	}

	public static bool TryParse<TEnum>([NotNullWhen(true)] string? P_0, bool P_1, out TEnum P_2) where TEnum : struct
	{
		return TryParse<TEnum>(P_0, P_1, false, out P_2);
	}

	public static bool TryParse<TEnum>(ReadOnlySpan<char> P_0, bool P_1, out TEnum P_2) where TEnum : struct
	{
		return TryParse<TEnum>(P_0, P_1, false, out P_2);
	}

	private static bool TryParse<TEnum>(string P_0, bool P_1, bool P_2, out TEnum P_3) where TEnum : struct
	{
		if (P_0 == null)
		{
			if (P_2)
			{
				ArgumentNullException.Throw("value");
			}
			P_3 = default(TEnum);
			return false;
		}
		return TryParse<TEnum>(P_0.AsSpan(), P_1, P_2, out P_3);
	}

	private static bool TryParse<TEnum>(ReadOnlySpan<char> P_0, bool P_1, bool P_2, out TEnum P_3) where TEnum : struct
	{
		if (!typeof(TEnum).IsEnum)
		{
			throw new ArgumentException("Arg_MustBeEnum", "TEnum");
		}
		P_0 = P_0.TrimStart();
		if (P_0.Length == 0)
		{
			if (P_2)
			{
				throw new ArgumentException("Arg_MustContainEnumInfo", "value");
			}
			P_3 = default(TEnum);
			return false;
		}
		RuntimeType runtimeType = (RuntimeType)typeof(TEnum);
		int num;
		uint num5;
		switch (Type.GetTypeCode(typeof(TEnum)))
		{
		case TypeCode.SByte:
		{
			bool flag = TryParseInt32Enum(runtimeType, P_0, -128, 127, P_1, P_2, TypeCode.SByte, out num);
			sbyte b = (sbyte)num;
			P_3 = Unsafe.As<sbyte, TEnum>(ref b);
			return flag;
		}
		case TypeCode.Int16:
		{
			bool flag = TryParseInt32Enum(runtimeType, P_0, -32768, 32767, P_1, P_2, TypeCode.Int16, out num);
			short num2 = (short)num;
			P_3 = Unsafe.As<short, TEnum>(ref num2);
			return flag;
		}
		case TypeCode.Int32:
		{
			bool flag = TryParseInt32Enum(runtimeType, P_0, -2147483648, 2147483647, P_1, P_2, TypeCode.Int32, out num);
			P_3 = Unsafe.As<int, TEnum>(ref num);
			return flag;
		}
		case TypeCode.Byte:
		{
			bool flag = TryParseUInt32Enum(runtimeType, P_0, 255u, P_1, P_2, TypeCode.Byte, out num5);
			byte b2 = (byte)num5;
			P_3 = Unsafe.As<byte, TEnum>(ref b2);
			return flag;
		}
		case TypeCode.UInt16:
		{
			bool flag = TryParseUInt32Enum(runtimeType, P_0, 65535u, P_1, P_2, TypeCode.UInt16, out num5);
			ushort num6 = (ushort)num5;
			P_3 = Unsafe.As<ushort, TEnum>(ref num6);
			return flag;
		}
		case TypeCode.UInt32:
		{
			bool flag = TryParseUInt32Enum(runtimeType, P_0, 4294967295u, P_1, P_2, TypeCode.UInt32, out num5);
			P_3 = Unsafe.As<uint, TEnum>(ref num5);
			return flag;
		}
		case TypeCode.Int64:
		{
			long num4;
			bool flag = TryParseInt64Enum(runtimeType, P_0, P_1, P_2, out num4);
			P_3 = Unsafe.As<long, TEnum>(ref num4);
			return flag;
		}
		case TypeCode.UInt64:
		{
			ulong num3;
			bool flag = TryParseUInt64Enum(runtimeType, P_0, P_1, P_2, out num3);
			P_3 = Unsafe.As<ulong, TEnum>(ref num3);
			return flag;
		}
		default:
		{
			object obj;
			bool flag = TryParseRareEnum(runtimeType, P_0, P_1, P_2, out obj);
			P_3 = (flag ? ((TEnum)obj) : default(TEnum));
			return flag;
		}
		}
	}

	private static bool TryParseInt32Enum(RuntimeType P_0, ReadOnlySpan<char> P_1, int P_2, int P_3, bool P_4, bool P_5, TypeCode P_6, out int P_7)
	{
		Number.ParsingStatus parsingStatus = Number.ParsingStatus.OK;
		if (StartsNumber(P_1[0]))
		{
			parsingStatus = Number.TryParseInt32IntegerStyle(P_1, NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture.NumberFormat, out P_7);
			if (parsingStatus == Number.ParsingStatus.OK)
			{
				if ((uint)(P_7 - P_2) <= (uint)(P_3 - P_2))
				{
					return true;
				}
				parsingStatus = Number.ParsingStatus.Overflow;
			}
		}
		ulong num;
		if (parsingStatus == Number.ParsingStatus.Overflow)
		{
			if (P_5)
			{
				Number.ThrowOverflowException(P_6);
			}
		}
		else if (TryParseByName(P_0, P_1, P_4, P_5, out num))
		{
			P_7 = (int)num;
			return true;
		}
		P_7 = 0;
		return false;
	}

	private static bool TryParseUInt32Enum(RuntimeType P_0, ReadOnlySpan<char> P_1, uint P_2, bool P_3, bool P_4, TypeCode P_5, out uint P_6)
	{
		Number.ParsingStatus parsingStatus = Number.ParsingStatus.OK;
		if (StartsNumber(P_1[0]))
		{
			parsingStatus = Number.TryParseUInt32IntegerStyle(P_1, NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture.NumberFormat, out P_6);
			if (parsingStatus == Number.ParsingStatus.OK)
			{
				if (P_6 <= P_2)
				{
					return true;
				}
				parsingStatus = Number.ParsingStatus.Overflow;
			}
		}
		ulong num;
		if (parsingStatus == Number.ParsingStatus.Overflow)
		{
			if (P_4)
			{
				Number.ThrowOverflowException(P_5);
			}
		}
		else if (TryParseByName(P_0, P_1, P_3, P_4, out num))
		{
			P_6 = (uint)num;
			return true;
		}
		P_6 = 0u;
		return false;
	}

	private static bool TryParseInt64Enum(RuntimeType P_0, ReadOnlySpan<char> P_1, bool P_2, bool P_3, out long P_4)
	{
		Number.ParsingStatus parsingStatus = Number.ParsingStatus.OK;
		if (StartsNumber(P_1[0]))
		{
			parsingStatus = Number.TryParseInt64IntegerStyle(P_1, NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture.NumberFormat, out P_4);
			if (parsingStatus == Number.ParsingStatus.OK)
			{
				return true;
			}
		}
		ulong num;
		if (parsingStatus == Number.ParsingStatus.Overflow)
		{
			if (P_3)
			{
				Number.ThrowOverflowException(TypeCode.Int64);
			}
		}
		else if (TryParseByName(P_0, P_1, P_2, P_3, out num))
		{
			P_4 = (long)num;
			return true;
		}
		P_4 = 0L;
		return false;
	}

	private static bool TryParseUInt64Enum(RuntimeType P_0, ReadOnlySpan<char> P_1, bool P_2, bool P_3, out ulong P_4)
	{
		Number.ParsingStatus parsingStatus = Number.ParsingStatus.OK;
		if (StartsNumber(P_1[0]))
		{
			parsingStatus = Number.TryParseUInt64IntegerStyle(P_1, NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture.NumberFormat, out P_4);
			if (parsingStatus == Number.ParsingStatus.OK)
			{
				return true;
			}
		}
		if (parsingStatus == Number.ParsingStatus.Overflow)
		{
			if (P_3)
			{
				Number.ThrowOverflowException(TypeCode.UInt64);
			}
		}
		else if (TryParseByName(P_0, P_1, P_2, P_3, out P_4))
		{
			return true;
		}
		P_4 = 0uL;
		return false;
	}

	private static bool TryParseRareEnum(RuntimeType P_0, ReadOnlySpan<char> P_1, bool P_2, bool P_3, [NotNullWhen(true)] out object P_4)
	{
		if (StartsNumber(P_1[0]))
		{
			Type underlyingType = GetUnderlyingType(P_0);
			try
			{
				P_4 = ToObject(P_0, Convert.ChangeType(P_1.ToString(), underlyingType, CultureInfo.InvariantCulture));
				return true;
			}
			catch (FormatException)
			{
			}
			catch when (!P_3)
			{
				P_4 = null;
				return false;
			}
		}
		if (TryParseByName(P_0, P_1, P_2, P_3, out var value))
		{
			try
			{
				P_4 = ToObject(P_0, value);
				return true;
			}
			catch when (!P_3)
			{
			}
		}
		P_4 = null;
		return false;
	}

	private static bool TryParseByName(RuntimeType P_0, ReadOnlySpan<char> P_1, bool P_2, bool P_3, out ulong P_4)
	{
		ReadOnlySpan<char> readOnlySpan = P_1;
		EnumInfo enumInfo = GetEnumInfo(P_0);
		string[] names = enumInfo.Names;
		ulong[] values = enumInfo.Values;
		bool flag = true;
		ulong num = 0uL;
		while (P_1.Length > 0)
		{
			int num2 = P_1.IndexOf(',');
			ReadOnlySpan<char> readOnlySpan2;
			if (num2 < 0)
			{
				readOnlySpan2 = P_1.Trim();
				P_1 = default(ReadOnlySpan<char>);
			}
			else
			{
				if (num2 == P_1.Length - 1)
				{
					flag = false;
					break;
				}
				readOnlySpan2 = P_1.Slice(0, num2).Trim();
				P_1 = P_1.Slice(num2 + 1);
			}
			bool flag2 = false;
			if (P_2)
			{
				for (int i = 0; i < names.Length; i++)
				{
					if (readOnlySpan2.EqualsOrdinalIgnoreCase(names[i]))
					{
						num |= values[i];
						flag2 = true;
						break;
					}
				}
			}
			else
			{
				for (int j = 0; j < names.Length; j++)
				{
					if (readOnlySpan2.EqualsOrdinal(names[j]))
					{
						num |= values[j];
						flag2 = true;
						break;
					}
				}
			}
			if (!flag2)
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			P_4 = num;
			return true;
		}
		if (P_3)
		{
			throw new ArgumentException(SR.Format("Arg_EnumValueNotFound", readOnlySpan.ToString()));
		}
		P_4 = 0uL;
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool StartsNumber(char P_0)
	{
		if (!char.IsAsciiDigit(P_0) && P_0 != '-')
		{
			return P_0 == '+';
		}
		return true;
	}

	public static object ToObject(Type enumType, object value)
	{
		ArgumentNullException.ThrowIfNull(value, "value");
		return Convert.GetTypeCode(value) switch
		{
			TypeCode.Int32 => ToObject(enumType, (int)value), 
			TypeCode.SByte => ToObject(enumType, (sbyte)value), 
			TypeCode.Int16 => ToObject(enumType, (short)value), 
			TypeCode.Int64 => ToObject(enumType, (long)value), 
			TypeCode.UInt32 => ToObject(enumType, (uint)value), 
			TypeCode.Byte => ToObject(enumType, (byte)value), 
			TypeCode.UInt16 => ToObject(enumType, (ushort)value), 
			TypeCode.UInt64 => ToObject(enumType, (ulong)value), 
			TypeCode.Char => ToObject(enumType, (char)value), 
			TypeCode.Boolean => ToObject(enumType, (bool)value), 
			_ => throw new ArgumentException("Arg_MustBeEnumBaseTypeOrEnum", "value"), 
		};
	}

	public static string Format(Type P_0, object P_1, [StringSyntax("EnumFormat")] string P_2)
	{
		ArgumentNullException.ThrowIfNull(P_1, "value");
		ArgumentNullException.ThrowIfNull(P_2, "format");
		RuntimeType runtimeType = ValidateRuntimeType(P_0);
		Type type = P_1.GetType();
		if (type.IsEnum)
		{
			if (!type.IsEquivalentTo(P_0))
			{
				throw new ArgumentException(SR.Format("Arg_EnumAndObjectMustBeSameType", type, P_0));
			}
			if (P_2.Length != 1)
			{
				throw new FormatException("Format_InvalidEnumFormatSpecification");
			}
			return ((Enum)P_1).ToString(P_2);
		}
		Type underlyingType = GetUnderlyingType(P_0);
		if (type != underlyingType)
		{
			throw new ArgumentException(SR.Format("Arg_EnumFormatUnderlyingTypeAndObjectMustBeSameType", type, underlyingType));
		}
		if (P_2.Length == 1)
		{
			switch (P_2[0])
			{
			case 'G':
			case 'g':
				return InternalFormat(runtimeType, ToUInt64(P_1)) ?? P_1.ToString();
			case 'D':
			case 'd':
				return P_1.ToString();
			case 'X':
			case 'x':
				return ValueToHexString(P_1);
			case 'F':
			case 'f':
				return InternalFlagsFormat(runtimeType, ToUInt64(P_1)) ?? P_1.ToString();
			}
		}
		throw new FormatException("Format_InvalidEnumFormatSpecification");
	}

	internal object GetValue()
	{
		ref byte rawData = ref this.GetRawData();
		return InternalGetCorElementType() switch
		{
			CorElementType.ELEMENT_TYPE_I1 => Unsafe.As<byte, sbyte>(ref rawData), 
			CorElementType.ELEMENT_TYPE_U1 => rawData, 
			CorElementType.ELEMENT_TYPE_BOOLEAN => Unsafe.As<byte, bool>(ref rawData), 
			CorElementType.ELEMENT_TYPE_I2 => Unsafe.As<byte, short>(ref rawData), 
			CorElementType.ELEMENT_TYPE_U2 => Unsafe.As<byte, ushort>(ref rawData), 
			CorElementType.ELEMENT_TYPE_CHAR => Unsafe.As<byte, char>(ref rawData), 
			CorElementType.ELEMENT_TYPE_I4 => Unsafe.As<byte, int>(ref rawData), 
			CorElementType.ELEMENT_TYPE_U4 => Unsafe.As<byte, uint>(ref rawData), 
			CorElementType.ELEMENT_TYPE_R4 => Unsafe.As<byte, float>(ref rawData), 
			CorElementType.ELEMENT_TYPE_I8 => Unsafe.As<byte, long>(ref rawData), 
			CorElementType.ELEMENT_TYPE_U8 => Unsafe.As<byte, ulong>(ref rawData), 
			CorElementType.ELEMENT_TYPE_R8 => Unsafe.As<byte, double>(ref rawData), 
			CorElementType.ELEMENT_TYPE_I => Unsafe.As<byte, nint>(ref rawData), 
			CorElementType.ELEMENT_TYPE_U => Unsafe.As<byte, nuint>(ref rawData), 
			_ => throw new InvalidOperationException("InvalidOperation_UnknownEnumType"), 
		};
	}

	private ulong ToUInt64()
	{
		ref byte rawData = ref this.GetRawData();
		switch (InternalGetCorElementType())
		{
		case CorElementType.ELEMENT_TYPE_I1:
			return (ulong)Unsafe.As<byte, sbyte>(ref rawData);
		case CorElementType.ELEMENT_TYPE_U1:
			return rawData;
		case CorElementType.ELEMENT_TYPE_BOOLEAN:
			if (rawData == 0)
			{
				return 0uL;
			}
			return 1uL;
		case CorElementType.ELEMENT_TYPE_I2:
			return (ulong)Unsafe.As<byte, short>(ref rawData);
		case CorElementType.ELEMENT_TYPE_CHAR:
		case CorElementType.ELEMENT_TYPE_U2:
			return Unsafe.As<byte, ushort>(ref rawData);
		case CorElementType.ELEMENT_TYPE_I4:
		case CorElementType.ELEMENT_TYPE_I:
			return (ulong)Unsafe.As<byte, int>(ref rawData);
		case CorElementType.ELEMENT_TYPE_U4:
		case CorElementType.ELEMENT_TYPE_R4:
		case CorElementType.ELEMENT_TYPE_U:
			return Unsafe.As<byte, uint>(ref rawData);
		case CorElementType.ELEMENT_TYPE_I8:
			return (ulong)Unsafe.As<byte, long>(ref rawData);
		case CorElementType.ELEMENT_TYPE_U8:
		case CorElementType.ELEMENT_TYPE_R8:
			return Unsafe.As<byte, ulong>(ref rawData);
		default:
			return 0uL;
		}
	}

	public override bool Equals([NotNullWhen(true)] object? P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (this == P_0)
		{
			return true;
		}
		if (GetType() != P_0.GetType())
		{
			return false;
		}
		ref byte rawData = ref this.GetRawData();
		ref byte rawData2 = ref P_0.GetRawData();
		switch (InternalGetCorElementType())
		{
		case CorElementType.ELEMENT_TYPE_BOOLEAN:
		case CorElementType.ELEMENT_TYPE_I1:
		case CorElementType.ELEMENT_TYPE_U1:
			return rawData == rawData2;
		case CorElementType.ELEMENT_TYPE_CHAR:
		case CorElementType.ELEMENT_TYPE_I2:
		case CorElementType.ELEMENT_TYPE_U2:
			return Unsafe.As<byte, ushort>(ref rawData) == Unsafe.As<byte, ushort>(ref rawData2);
		case CorElementType.ELEMENT_TYPE_I4:
		case CorElementType.ELEMENT_TYPE_U4:
		case CorElementType.ELEMENT_TYPE_R4:
		case CorElementType.ELEMENT_TYPE_I:
		case CorElementType.ELEMENT_TYPE_U:
			return Unsafe.As<byte, uint>(ref rawData) == Unsafe.As<byte, uint>(ref rawData2);
		case CorElementType.ELEMENT_TYPE_I8:
		case CorElementType.ELEMENT_TYPE_U8:
		case CorElementType.ELEMENT_TYPE_R8:
			return Unsafe.As<byte, ulong>(ref rawData) == Unsafe.As<byte, ulong>(ref rawData2);
		default:
			return false;
		}
	}

	public override int GetHashCode()
	{
		ref byte rawData = ref this.GetRawData();
		return InternalGetCorElementType() switch
		{
			CorElementType.ELEMENT_TYPE_I1 => Unsafe.As<byte, sbyte>(ref rawData).GetHashCode(), 
			CorElementType.ELEMENT_TYPE_U1 => rawData.GetHashCode(), 
			CorElementType.ELEMENT_TYPE_BOOLEAN => Unsafe.As<byte, bool>(ref rawData).GetHashCode(), 
			CorElementType.ELEMENT_TYPE_I2 => Unsafe.As<byte, short>(ref rawData).GetHashCode(), 
			CorElementType.ELEMENT_TYPE_U2 => Unsafe.As<byte, ushort>(ref rawData).GetHashCode(), 
			CorElementType.ELEMENT_TYPE_CHAR => Unsafe.As<byte, char>(ref rawData).GetHashCode(), 
			CorElementType.ELEMENT_TYPE_I4 => Unsafe.As<byte, int>(ref rawData).GetHashCode(), 
			CorElementType.ELEMENT_TYPE_U4 => Unsafe.As<byte, uint>(ref rawData).GetHashCode(), 
			CorElementType.ELEMENT_TYPE_R4 => Unsafe.As<byte, float>(ref rawData).GetHashCode(), 
			CorElementType.ELEMENT_TYPE_I8 => Unsafe.As<byte, long>(ref rawData).GetHashCode(), 
			CorElementType.ELEMENT_TYPE_U8 => Unsafe.As<byte, ulong>(ref rawData).GetHashCode(), 
			CorElementType.ELEMENT_TYPE_R8 => Unsafe.As<byte, double>(ref rawData).GetHashCode(), 
			CorElementType.ELEMENT_TYPE_I => ((IntPtr)Unsafe.As<byte, nint>(ref rawData)).GetHashCode(), 
			CorElementType.ELEMENT_TYPE_U => ((UIntPtr)Unsafe.As<byte, nuint>(ref rawData)).GetHashCode(), 
			_ => throw new InvalidOperationException("InvalidOperation_UnknownEnumType"), 
		};
	}

	public override string ToString()
	{
		return InternalFormat((RuntimeType)GetType(), ToUInt64()) ?? ValueToString();
	}

	public int CompareTo(object? P_0)
	{
		if (P_0 == this)
		{
			return 0;
		}
		if (P_0 == null)
		{
			return 1;
		}
		if (GetType() != P_0.GetType())
		{
			throw new ArgumentException(SR.Format("Arg_EnumAndObjectMustBeSameType", P_0.GetType(), GetType()));
		}
		ref byte rawData = ref this.GetRawData();
		ref byte rawData2 = ref P_0.GetRawData();
		switch (InternalGetCorElementType())
		{
		case CorElementType.ELEMENT_TYPE_I1:
			return Unsafe.As<byte, sbyte>(ref rawData).CompareTo(Unsafe.As<byte, sbyte>(ref rawData2));
		case CorElementType.ELEMENT_TYPE_BOOLEAN:
		case CorElementType.ELEMENT_TYPE_U1:
			return rawData.CompareTo(rawData2);
		case CorElementType.ELEMENT_TYPE_I2:
			return Unsafe.As<byte, short>(ref rawData).CompareTo(Unsafe.As<byte, short>(ref rawData2));
		case CorElementType.ELEMENT_TYPE_CHAR:
		case CorElementType.ELEMENT_TYPE_U2:
			return Unsafe.As<byte, ushort>(ref rawData).CompareTo(Unsafe.As<byte, ushort>(ref rawData2));
		case CorElementType.ELEMENT_TYPE_I4:
		case CorElementType.ELEMENT_TYPE_I:
			return Unsafe.As<byte, int>(ref rawData).CompareTo(Unsafe.As<byte, int>(ref rawData2));
		case CorElementType.ELEMENT_TYPE_U4:
		case CorElementType.ELEMENT_TYPE_U:
			return Unsafe.As<byte, uint>(ref rawData).CompareTo(Unsafe.As<byte, uint>(ref rawData2));
		case CorElementType.ELEMENT_TYPE_I8:
			return Unsafe.As<byte, long>(ref rawData).CompareTo(Unsafe.As<byte, long>(ref rawData2));
		case CorElementType.ELEMENT_TYPE_U8:
			return Unsafe.As<byte, ulong>(ref rawData).CompareTo(Unsafe.As<byte, ulong>(ref rawData2));
		case CorElementType.ELEMENT_TYPE_R4:
			return Unsafe.As<byte, float>(ref rawData).CompareTo(Unsafe.As<byte, float>(ref rawData2));
		case CorElementType.ELEMENT_TYPE_R8:
			return Unsafe.As<byte, double>(ref rawData).CompareTo(Unsafe.As<byte, double>(ref rawData2));
		default:
			return 0;
		}
	}

	[Obsolete("The provider argument is not used. Use ToString(String) instead.")]
	public string ToString([StringSyntax("EnumFormat")] string? P_0, IFormatProvider? P_1)
	{
		return ToString(P_0);
	}

	public string ToString([StringSyntax("EnumFormat")] string? P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return ToString();
		}
		if (P_0.Length == 1)
		{
			switch (P_0[0])
			{
			case 'G':
			case 'g':
				return ToString();
			case 'D':
			case 'd':
				return ValueToString();
			case 'X':
			case 'x':
				return ValueToHexString();
			case 'F':
			case 'f':
				return InternalFlagsFormat((RuntimeType)GetType(), ToUInt64()) ?? ValueToString();
			}
		}
		throw new FormatException("Format_InvalidEnumFormatSpecification");
	}

	[Obsolete("The provider argument is not used. Use ToString() instead.")]
	public string ToString(IFormatProvider? P_0)
	{
		return ToString();
	}

	public TypeCode GetTypeCode()
	{
		return InternalGetCorElementType() switch
		{
			CorElementType.ELEMENT_TYPE_I1 => TypeCode.SByte, 
			CorElementType.ELEMENT_TYPE_U1 => TypeCode.Byte, 
			CorElementType.ELEMENT_TYPE_BOOLEAN => TypeCode.Boolean, 
			CorElementType.ELEMENT_TYPE_I2 => TypeCode.Int16, 
			CorElementType.ELEMENT_TYPE_U2 => TypeCode.UInt16, 
			CorElementType.ELEMENT_TYPE_CHAR => TypeCode.Char, 
			CorElementType.ELEMENT_TYPE_I4 => TypeCode.Int32, 
			CorElementType.ELEMENT_TYPE_U4 => TypeCode.UInt32, 
			CorElementType.ELEMENT_TYPE_I8 => TypeCode.Int64, 
			CorElementType.ELEMENT_TYPE_U8 => TypeCode.UInt64, 
			_ => throw new InvalidOperationException("InvalidOperation_UnknownEnumType"), 
		};
	}

	bool IConvertible.ToBoolean(IFormatProvider P_0)
	{
		return Convert.ToBoolean(GetValue());
	}

	char IConvertible.ToChar(IFormatProvider P_0)
	{
		return Convert.ToChar(GetValue());
	}

	sbyte IConvertible.ToSByte(IFormatProvider P_0)
	{
		return Convert.ToSByte(GetValue());
	}

	byte IConvertible.ToByte(IFormatProvider P_0)
	{
		return Convert.ToByte(GetValue());
	}

	short IConvertible.ToInt16(IFormatProvider P_0)
	{
		return Convert.ToInt16(GetValue());
	}

	ushort IConvertible.ToUInt16(IFormatProvider P_0)
	{
		return Convert.ToUInt16(GetValue());
	}

	int IConvertible.ToInt32(IFormatProvider P_0)
	{
		return Convert.ToInt32(GetValue());
	}

	uint IConvertible.ToUInt32(IFormatProvider P_0)
	{
		return Convert.ToUInt32(GetValue());
	}

	long IConvertible.ToInt64(IFormatProvider P_0)
	{
		return Convert.ToInt64(GetValue());
	}

	ulong IConvertible.ToUInt64(IFormatProvider P_0)
	{
		return Convert.ToUInt64(GetValue());
	}

	float IConvertible.ToSingle(IFormatProvider P_0)
	{
		return Convert.ToSingle(GetValue());
	}

	double IConvertible.ToDouble(IFormatProvider P_0)
	{
		return Convert.ToDouble(GetValue());
	}

	decimal IConvertible.ToDecimal(IFormatProvider P_0)
	{
		return Convert.ToDecimal(GetValue());
	}

	DateTime IConvertible.ToDateTime(IFormatProvider P_0)
	{
		throw new InvalidCastException(SR.Format("InvalidCast_FromTo", "Enum", "DateTime"));
	}

	object IConvertible.ToType(Type P_0, IFormatProvider P_1)
	{
		return Convert.DefaultToType(this, P_0, P_1);
	}

	[CLSCompliant(false)]
	public static object ToObject(Type enumType, sbyte value)
	{
		return InternalBoxEnum(ValidateRuntimeType(enumType), value);
	}

	public static object ToObject(Type enumType, short value)
	{
		return InternalBoxEnum(ValidateRuntimeType(enumType), value);
	}

	public static object ToObject(Type enumType, int value)
	{
		return InternalBoxEnum(ValidateRuntimeType(enumType), value);
	}

	public static object ToObject(Type enumType, byte value)
	{
		return InternalBoxEnum(ValidateRuntimeType(enumType), value);
	}

	[CLSCompliant(false)]
	public static object ToObject(Type enumType, ushort value)
	{
		return InternalBoxEnum(ValidateRuntimeType(enumType), value);
	}

	[CLSCompliant(false)]
	public static object ToObject(Type enumType, uint value)
	{
		return InternalBoxEnum(ValidateRuntimeType(enumType), value);
	}

	public static object ToObject(Type enumType, long value)
	{
		return InternalBoxEnum(ValidateRuntimeType(enumType), value);
	}

	[CLSCompliant(false)]
	public static object ToObject(Type enumType, ulong value)
	{
		return InternalBoxEnum(ValidateRuntimeType(enumType), (long)value);
	}

	private static object ToObject(Type P_0, char P_1)
	{
		return InternalBoxEnum(ValidateRuntimeType(P_0), P_1);
	}

	private static object ToObject(Type P_0, bool P_1)
	{
		return InternalBoxEnum(ValidateRuntimeType(P_0), P_1 ? 1 : 0);
	}

	private static RuntimeType ValidateRuntimeType(Type P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "enumType");
		if (!(P_0 is RuntimeType runtimeType))
		{
			throw new ArgumentException("Arg_MustBeType", "enumType");
		}
		if (!runtimeType.IsActualEnum)
		{
			throw new ArgumentException("Arg_MustBeEnum", "enumType");
		}
		return runtimeType;
	}
}
