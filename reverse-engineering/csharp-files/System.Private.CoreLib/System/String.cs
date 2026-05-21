using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Versioning;
using System.Text;
using System.Text.Unicode;

namespace System;

[Serializable]
[NonVersionable]
[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public sealed class String : IComparable, IEnumerable, IConvertible, IEnumerable<char>, IComparable<string?>, IEquatable<string?>, ICloneable
{
	[Intrinsic]
	public static readonly string Empty;

	[NonSerialized]
	private readonly int _stringLength;

	[NonSerialized]
	private char _firstChar;

	[IndexerName("Chars")]
	public char this[int P_0]
	{
		[Intrinsic]
		get
		{
			if ((uint)P_0 >= (uint)_stringLength)
			{
				ThrowHelper.ThrowIndexOutOfRangeException();
			}
			return Unsafe.Add(ref _firstChar, (nint)(uint)P_0);
		}
	}

	public int Length
	{
		[Intrinsic]
		get
		{
			return _stringLength;
		}
	}

	public static string Intern(string P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "str");
		return InternalIntern(P_0);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern string FastAllocateString(int P_0);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern string InternalIntern(string P_0);

	private unsafe static void memset(byte* P_0, int P_1, int P_2)
	{
		if (P_2 < 8)
		{
			while (P_2 != 0)
			{
				*P_0 = (byte)P_1;
				P_0++;
				P_2--;
			}
			return;
		}
		int num = P_1;
		if (num != 0)
		{
			num |= num << 8;
			num |= num << 16;
		}
		int num2 = (int)P_0 & 3;
		if (num2 != 0)
		{
			num2 = 4 - num2;
			P_2 -= num2;
			do
			{
				*P_0 = (byte)P_1;
				P_0++;
				num2--;
			}
			while (num2 != 0);
		}
		while (P_2 >= 16)
		{
			*(int*)P_0 = num;
			((int*)P_0)[1] = num;
			((int*)P_0)[2] = num;
			((int*)P_0)[3] = num;
			P_0 += 16;
			P_2 -= 16;
		}
		while (P_2 >= 4)
		{
			*(int*)P_0 = num;
			P_0 += 4;
			P_2 -= 4;
		}
		while (P_2 > 0)
		{
			*P_0 = (byte)P_1;
			P_0++;
			P_2--;
		}
	}

	private unsafe static void memcpy(byte* P_0, byte* P_1, int P_2)
	{
		Buffer.Memmove(ref *P_0, ref *P_1, (nuint)P_2);
	}

	internal unsafe static void bzero(byte* P_0, int P_1)
	{
		memset(P_0, 0, P_1);
	}

	internal unsafe static void bzero_aligned_1(byte* P_0, int P_1)
	{
		*P_0 = 0;
	}

	internal unsafe static void bzero_aligned_2(byte* P_0, int P_1)
	{
		*(short*)P_0 = 0;
	}

	internal unsafe static void bzero_aligned_4(byte* P_0, int P_1)
	{
		*(int*)P_0 = 0;
	}

	internal unsafe static void bzero_aligned_8(byte* P_0, int P_1)
	{
		*(long*)P_0 = 0L;
	}

	internal unsafe static void memcpy_aligned_1(byte* P_0, byte* P_1, int P_2)
	{
		*P_0 = *P_1;
	}

	internal unsafe static void memcpy_aligned_2(byte* P_0, byte* P_1, int P_2)
	{
		*(short*)P_0 = *(short*)P_1;
	}

	internal unsafe static void memcpy_aligned_4(byte* P_0, byte* P_1, int P_2)
	{
		*(int*)P_0 = *(int*)P_1;
	}

	internal unsafe static void memcpy_aligned_8(byte* P_0, byte* P_1, int P_2)
	{
		*(long*)P_0 = *(long*)P_1;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool EqualsHelper(string P_0, string P_1)
	{
		return SpanHelpers.SequenceEqual(ref Unsafe.As<char, byte>(ref P_0.GetRawStringData()), ref Unsafe.As<char, byte>(ref P_1.GetRawStringData()), (uint)(P_0.Length * 2));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int CompareOrdinalHelper(string P_0, int P_1, int P_2, string P_3, int P_4, int P_5)
	{
		return SpanHelpers.SequenceCompareTo(ref Unsafe.Add(ref P_0.GetRawStringData(), (nint)(uint)P_1), P_2, ref Unsafe.Add(ref P_3.GetRawStringData(), (nint)(uint)P_4), P_5);
	}

	internal static bool EqualsOrdinalIgnoreCase(string P_0, string P_1)
	{
		if ((object)P_0 == P_1)
		{
			return true;
		}
		if ((object)P_0 == null || (object)P_1 == null)
		{
			return false;
		}
		if (P_0.Length != P_1.Length)
		{
			return false;
		}
		return EqualsOrdinalIgnoreCaseNoLengthCheck(P_0, P_1);
	}

	private static bool EqualsOrdinalIgnoreCaseNoLengthCheck(string P_0, string P_1)
	{
		return Ordinal.EqualsIgnoreCase(ref P_0.GetRawStringData(), ref P_1.GetRawStringData(), P_1.Length);
	}

	private unsafe static int CompareOrdinalHelper(string P_0, string P_1)
	{
		int num = Math.Min(P_0.Length, P_1.Length);
		fixed (char* firstChar = &P_0._firstChar)
		{
			fixed (char* firstChar2 = &P_1._firstChar)
			{
				char* ptr = firstChar;
				char* ptr2 = firstChar2;
				if (ptr[1] == ptr2[1])
				{
					num -= 2;
					ptr += 2;
					ptr2 += 2;
					while (true)
					{
						if (num >= 10)
						{
							if (*(int*)ptr != *(int*)ptr2)
							{
								break;
							}
							if (*(int*)(ptr + 2) == *(int*)(ptr2 + 2))
							{
								if (*(int*)(ptr + 4) == *(int*)(ptr2 + 4))
								{
									if (*(int*)(ptr + 6) == *(int*)(ptr2 + 6))
									{
										if (*(int*)(ptr + 8) == *(int*)(ptr2 + 8))
										{
											num -= 10;
											ptr += 10;
											ptr2 += 10;
											continue;
										}
										ptr += 8;
										ptr2 += 8;
										break;
									}
									ptr += 6;
									ptr2 += 6;
									break;
								}
								ptr += 2;
								ptr2 += 2;
							}
							ptr += 2;
							ptr2 += 2;
							break;
						}
						while (true)
						{
							if (num > 0)
							{
								if (*(int*)ptr != *(int*)ptr2)
								{
									break;
								}
								num -= 2;
								ptr += 2;
								ptr2 += 2;
								continue;
							}
							return P_0.Length - P_1.Length;
						}
						break;
					}
					if (*ptr != *ptr2)
					{
						return *ptr - *ptr2;
					}
				}
				return ptr[1] - ptr2[1];
			}
		}
	}

	public static int Compare(string? P_0, string? P_1)
	{
		return Compare(P_0, P_1, StringComparison.CurrentCulture);
	}

	public static int Compare(string? P_0, string? P_1, bool P_2)
	{
		StringComparison stringComparison = (P_2 ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
		return Compare(P_0, P_1, stringComparison);
	}

	public static int Compare(string? P_0, string? P_1, StringComparison P_2)
	{
		if ((object)P_0 == P_1)
		{
			CheckStringComparison(P_2);
			return 0;
		}
		if ((object)P_0 == null)
		{
			CheckStringComparison(P_2);
			return -1;
		}
		if ((object)P_1 == null)
		{
			CheckStringComparison(P_2);
			return 1;
		}
		switch (P_2)
		{
		case StringComparison.CurrentCulture:
		case StringComparison.CurrentCultureIgnoreCase:
			return CultureInfo.CurrentCulture.CompareInfo.Compare(P_0, P_1, GetCaseCompareOfComparisonCulture(P_2));
		case StringComparison.InvariantCulture:
		case StringComparison.InvariantCultureIgnoreCase:
			return CompareInfo.Invariant.Compare(P_0, P_1, GetCaseCompareOfComparisonCulture(P_2));
		case StringComparison.Ordinal:
			if (P_0._firstChar != P_1._firstChar)
			{
				return P_0._firstChar - P_1._firstChar;
			}
			return CompareOrdinalHelper(P_0, P_1);
		case StringComparison.OrdinalIgnoreCase:
			return Ordinal.CompareStringIgnoreCase(ref P_0.GetRawStringData(), P_0.Length, ref P_1.GetRawStringData(), P_1.Length);
		default:
			throw new ArgumentException("NotSupported_StringComparison", "comparisonType");
		}
	}

	public static int CompareOrdinal(string? P_0, string? P_1)
	{
		if ((object)P_0 == P_1)
		{
			return 0;
		}
		if ((object)P_0 == null)
		{
			return -1;
		}
		if ((object)P_1 == null)
		{
			return 1;
		}
		if (P_0._firstChar != P_1._firstChar)
		{
			return P_0._firstChar - P_1._firstChar;
		}
		return CompareOrdinalHelper(P_0, P_1);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int CompareOrdinal(ReadOnlySpan<char> P_0, ReadOnlySpan<char> P_1)
	{
		return SpanHelpers.SequenceCompareTo(ref MemoryMarshal.GetReference(P_0), P_0.Length, ref MemoryMarshal.GetReference(P_1), P_1.Length);
	}

	public static int CompareOrdinal(string? P_0, int P_1, string? P_2, int P_3, int P_4)
	{
		if ((object)P_0 == null || (object)P_2 == null)
		{
			if ((object)P_0 == P_2)
			{
				return 0;
			}
			if ((object)P_0 != null)
			{
				return 1;
			}
			return -1;
		}
		if (P_4 < 0)
		{
			throw new ArgumentOutOfRangeException("length", "ArgumentOutOfRange_NegativeCount");
		}
		if (P_1 < 0 || P_3 < 0)
		{
			string text = ((P_1 < 0) ? "indexA" : "indexB");
			throw new ArgumentOutOfRangeException(text, "ArgumentOutOfRange_IndexMustBeLessOrEqual");
		}
		int num = Math.Min(P_4, P_0.Length - P_1);
		int num2 = Math.Min(P_4, P_2.Length - P_3);
		if (num < 0 || num2 < 0)
		{
			string text2 = ((num < 0) ? "indexA" : "indexB");
			throw new ArgumentOutOfRangeException(text2, "ArgumentOutOfRange_IndexMustBeLessOrEqual");
		}
		if (P_4 == 0 || ((object)P_0 == P_2 && P_1 == P_3))
		{
			return 0;
		}
		return CompareOrdinalHelper(P_0, P_1, num, P_2, P_3, num2);
	}

	public int CompareTo(object? P_0)
	{
		if (P_0 == null)
		{
			return 1;
		}
		if (!(P_0 is string text))
		{
			throw new ArgumentException("Arg_MustBeString");
		}
		return CompareTo(text);
	}

	public int CompareTo(string? P_0)
	{
		return Compare(this, P_0, StringComparison.CurrentCulture);
	}

	public bool EndsWith(string P_0)
	{
		return EndsWith(P_0, StringComparison.CurrentCulture);
	}

	public bool EndsWith(string P_0, StringComparison P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		if ((object)this == P_0)
		{
			CheckStringComparison(P_1);
			return true;
		}
		if (P_0.Length == 0)
		{
			CheckStringComparison(P_1);
			return true;
		}
		switch (P_1)
		{
		case StringComparison.CurrentCulture:
		case StringComparison.CurrentCultureIgnoreCase:
			return CultureInfo.CurrentCulture.CompareInfo.IsSuffix(this, P_0, GetCaseCompareOfComparisonCulture(P_1));
		case StringComparison.InvariantCulture:
		case StringComparison.InvariantCultureIgnoreCase:
			return CompareInfo.Invariant.IsSuffix(this, P_0, GetCaseCompareOfComparisonCulture(P_1));
		case StringComparison.Ordinal:
		{
			int num = Length - P_0.Length;
			if ((uint)num <= (uint)Length)
			{
				return this.AsSpan(num).SequenceEqual(P_0);
			}
			return false;
		}
		case StringComparison.OrdinalIgnoreCase:
			if (Length >= P_0.Length)
			{
				return Ordinal.EqualsIgnoreCase(ref Unsafe.Add(ref GetRawStringData(), Length - P_0.Length), ref P_0.GetRawStringData(), P_0.Length);
			}
			return false;
		default:
			throw new ArgumentException("NotSupported_StringComparison", "comparisonType");
		}
	}

	public bool EndsWith(char P_0)
	{
		if (RuntimeHelpers.IsKnownConstant(P_0) && P_0 != 0)
		{
			nuint num = (uint)Length;
			return Unsafe.Add(ref _firstChar, (nint)(num - 1)) == P_0;
		}
		int num2 = Length - 1;
		if ((uint)num2 < (uint)Length)
		{
			return this[num2] == P_0;
		}
		return false;
	}

	public override bool Equals([NotNullWhen(true)] object? P_0)
	{
		if (this == P_0)
		{
			return true;
		}
		if (!(P_0 is string text))
		{
			return false;
		}
		if (Length != text.Length)
		{
			return false;
		}
		return EqualsHelper(this, text);
	}

	[Intrinsic]
	public bool Equals([NotNullWhen(true)] string? P_0)
	{
		if ((object)this == P_0)
		{
			return true;
		}
		if ((object)P_0 == null)
		{
			return false;
		}
		if (Length != P_0.Length)
		{
			return false;
		}
		return EqualsHelper(this, P_0);
	}

	[Intrinsic]
	public bool Equals([NotNullWhen(true)] string? P_0, StringComparison P_1)
	{
		if ((object)this == P_0)
		{
			CheckStringComparison(P_1);
			return true;
		}
		if ((object)P_0 == null)
		{
			CheckStringComparison(P_1);
			return false;
		}
		switch (P_1)
		{
		case StringComparison.CurrentCulture:
		case StringComparison.CurrentCultureIgnoreCase:
			return CultureInfo.CurrentCulture.CompareInfo.Compare(this, P_0, GetCaseCompareOfComparisonCulture(P_1)) == 0;
		case StringComparison.InvariantCulture:
		case StringComparison.InvariantCultureIgnoreCase:
			return CompareInfo.Invariant.Compare(this, P_0, GetCaseCompareOfComparisonCulture(P_1)) == 0;
		case StringComparison.Ordinal:
			if (Length != P_0.Length)
			{
				return false;
			}
			return EqualsHelper(this, P_0);
		case StringComparison.OrdinalIgnoreCase:
			if (Length != P_0.Length)
			{
				return false;
			}
			return EqualsOrdinalIgnoreCaseNoLengthCheck(this, P_0);
		default:
			throw new ArgumentException("NotSupported_StringComparison", "comparisonType");
		}
	}

	[Intrinsic]
	public static bool Equals(string? P_0, string? P_1)
	{
		if ((object)P_0 == P_1)
		{
			return true;
		}
		if ((object)P_0 == null || (object)P_1 == null || P_0.Length != P_1.Length)
		{
			return false;
		}
		return EqualsHelper(P_0, P_1);
	}

	[Intrinsic]
	public static bool Equals(string? P_0, string? P_1, StringComparison P_2)
	{
		if ((object)P_0 == P_1)
		{
			CheckStringComparison(P_2);
			return true;
		}
		if ((object)P_0 == null || (object)P_1 == null)
		{
			CheckStringComparison(P_2);
			return false;
		}
		switch (P_2)
		{
		case StringComparison.CurrentCulture:
		case StringComparison.CurrentCultureIgnoreCase:
			return CultureInfo.CurrentCulture.CompareInfo.Compare(P_0, P_1, GetCaseCompareOfComparisonCulture(P_2)) == 0;
		case StringComparison.InvariantCulture:
		case StringComparison.InvariantCultureIgnoreCase:
			return CompareInfo.Invariant.Compare(P_0, P_1, GetCaseCompareOfComparisonCulture(P_2)) == 0;
		case StringComparison.Ordinal:
			if (P_0.Length != P_1.Length)
			{
				return false;
			}
			return EqualsHelper(P_0, P_1);
		case StringComparison.OrdinalIgnoreCase:
			if (P_0.Length != P_1.Length)
			{
				return false;
			}
			return EqualsOrdinalIgnoreCaseNoLengthCheck(P_0, P_1);
		default:
			throw new ArgumentException("NotSupported_StringComparison", "comparisonType");
		}
	}

	public static bool operator ==(string? P_0, string? P_1)
	{
		return Equals(P_0, P_1);
	}

	public static bool operator !=(string? P_0, string? P_1)
	{
		return !Equals(P_0, P_1);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public override int GetHashCode()
	{
		ulong defaultSeed = Marvin.DefaultSeed;
		return Marvin.ComputeHash32(ref Unsafe.As<char, byte>(ref _firstChar), (uint)(_stringLength * 2), (uint)defaultSeed, (uint)(defaultSeed >> 32));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal int GetHashCodeOrdinalIgnoreCase()
	{
		ulong defaultSeed = Marvin.DefaultSeed;
		return Marvin.ComputeHash32OrdinalIgnoreCase(ref _firstChar, _stringLength, (uint)defaultSeed, (uint)(defaultSeed >> 32));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int GetHashCode(ReadOnlySpan<char> P_0)
	{
		ulong defaultSeed = Marvin.DefaultSeed;
		return Marvin.ComputeHash32(ref Unsafe.As<char, byte>(ref MemoryMarshal.GetReference(P_0)), (uint)(P_0.Length * 2), (uint)defaultSeed, (uint)(defaultSeed >> 32));
	}

	internal unsafe int GetNonRandomizedHashCode()
	{
		fixed (char* firstChar = &_firstChar)
		{
			uint num = 352654597u;
			uint num2 = num;
			uint* ptr = (uint*)firstChar;
			int num3 = Length;
			while (num3 > 2)
			{
				num3 -= 4;
				num = (BitOperations.RotateLeft(num, 5) + num) ^ *ptr;
				num2 = (BitOperations.RotateLeft(num2, 5) + num2) ^ ptr[1];
				ptr += 2;
			}
			if (num3 > 0)
			{
				num2 = (BitOperations.RotateLeft(num2, 5) + num2) ^ *ptr;
			}
			return (int)(num + num2 * 1566083941);
		}
	}

	internal unsafe int GetNonRandomizedHashCodeOrdinalIgnoreCase()
	{
		uint num = 352654597u;
		uint num2 = num;
		fixed (char* firstChar = &_firstChar)
		{
			uint* ptr = (uint*)firstChar;
			int num3 = Length;
			while (true)
			{
				if (num3 > 2)
				{
					uint num4 = *ptr;
					uint num5 = ptr[1];
					if (Utf16Utility.AllCharsInUInt32AreAscii(num4 | num5))
					{
						num3 -= 4;
						num = (BitOperations.RotateLeft(num, 5) + num) ^ (num4 | 0x200020);
						num2 = (BitOperations.RotateLeft(num2, 5) + num2) ^ (num5 | 0x200020);
						ptr += 2;
						continue;
					}
				}
				else
				{
					if (num3 <= 0)
					{
						break;
					}
					uint num6 = *ptr;
					if (Utf16Utility.AllCharsInUInt32AreAscii(num6))
					{
						num2 = (BitOperations.RotateLeft(num2, 5) + num2) ^ (num6 | 0x200020);
						break;
					}
				}
				goto end_IL_0011;
			}
			goto IL_00a1;
			end_IL_0011:;
		}
		return GetNonRandomizedHashCodeOrdinalIgnoreCaseSlow(this);
		IL_00a1:
		return (int)(num + num2 * 1566083941);
		unsafe static int GetNonRandomizedHashCodeOrdinalIgnoreCaseSlow(string P_0)
		{
			int num7 = P_0.Length;
			char[] array = null;
			Span<char> span = (((uint)num7 >= 64u) ? ((Span<char>)(array = ArrayPool<char>.Shared.Rent(num7 + 1))) : stackalloc char[64]);
			Span<char> span2 = span;
			int num8 = Ordinal.ToUpperOrdinal(P_0, span2);
			span2[num7] = '\0';
			uint num9 = 352654597u;
			uint num10 = num9;
			fixed (char* ptr2 = span2)
			{
				uint* ptr3 = (uint*)ptr2;
				while (num7 > 2)
				{
					num7 -= 4;
					num9 = (BitOperations.RotateLeft(num9, 5) + num9) ^ (*ptr3 | 0x200020);
					num10 = (BitOperations.RotateLeft(num10, 5) + num10) ^ (ptr3[1] | 0x200020);
					ptr3 += 2;
				}
				if (num7 > 0)
				{
					num10 = (BitOperations.RotateLeft(num10, 5) + num10) ^ (*ptr3 | 0x200020);
				}
			}
			if (array != null)
			{
				ArrayPool<char>.Shared.Return(array);
			}
			return (int)(num9 + num10 * 1566083941);
		}
	}

	public bool StartsWith(string P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		return StartsWith(P_0, StringComparison.CurrentCulture);
	}

	[Intrinsic]
	public bool StartsWith(string P_0, StringComparison P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		if ((object)this == P_0)
		{
			CheckStringComparison(P_1);
			return true;
		}
		if (P_0.Length == 0)
		{
			CheckStringComparison(P_1);
			return true;
		}
		switch (P_1)
		{
		case StringComparison.CurrentCulture:
		case StringComparison.CurrentCultureIgnoreCase:
			return CultureInfo.CurrentCulture.CompareInfo.IsPrefix(this, P_0, GetCaseCompareOfComparisonCulture(P_1));
		case StringComparison.InvariantCulture:
		case StringComparison.InvariantCultureIgnoreCase:
			return CompareInfo.Invariant.IsPrefix(this, P_0, GetCaseCompareOfComparisonCulture(P_1));
		case StringComparison.Ordinal:
			if (Length < P_0.Length || _firstChar != P_0._firstChar)
			{
				return false;
			}
			if (P_0.Length != 1)
			{
				return SpanHelpers.SequenceEqual(ref Unsafe.As<char, byte>(ref GetRawStringData()), ref Unsafe.As<char, byte>(ref P_0.GetRawStringData()), (nuint)P_0.Length * (nuint)2u);
			}
			return true;
		case StringComparison.OrdinalIgnoreCase:
			if (Length < P_0.Length)
			{
				return false;
			}
			return Ordinal.EqualsIgnoreCase(ref GetRawStringData(), ref P_0.GetRawStringData(), P_0.Length);
		default:
			throw new ArgumentException("NotSupported_StringComparison", "comparisonType");
		}
	}

	public bool StartsWith(char P_0)
	{
		if (RuntimeHelpers.IsKnownConstant(P_0) && P_0 != 0)
		{
			return _firstChar == P_0;
		}
		if (Length != 0)
		{
			return _firstChar == P_0;
		}
		return false;
	}

	internal static void CheckStringComparison(StringComparison P_0)
	{
		if ((uint)P_0 > 5u)
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.NotSupported_StringComparison, ExceptionArgument.comparisonType);
		}
	}

	internal static CompareOptions GetCaseCompareOfComparisonCulture(StringComparison P_0)
	{
		return (CompareOptions)(P_0 & StringComparison.CurrentCultureIgnoreCase);
	}

	private static CompareOptions GetCompareOptionsFromOrdinalStringComparison(StringComparison P_0)
	{
		return (CompareOptions)(((uint)P_0 & (uint)(0 - P_0)) << 28);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public extern String(char[]? value);

	private static string Ctor(char[] value)
	{
		if (value == null || value.Length == 0)
		{
			return Empty;
		}
		string text = FastAllocateString(value.Length);
		nuint num = (uint)text.Length;
		Buffer.Memmove(ref text._firstChar, ref MemoryMarshal.GetArrayDataReference(value), num);
		return text;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public extern String(char[] value, int startIndex, int length);

	private static string Ctor(char[] value, int startIndex, int length)
	{
		ArgumentNullException.ThrowIfNull(value, "value");
		if (startIndex < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex", "ArgumentOutOfRange_StartIndex");
		}
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("length", "ArgumentOutOfRange_NegativeLength");
		}
		if (startIndex > value.Length - length)
		{
			throw new ArgumentOutOfRangeException("startIndex", "ArgumentOutOfRange_IndexMustBeLessOrEqual");
		}
		if (length == 0)
		{
			return Empty;
		}
		string text = FastAllocateString(length);
		nuint num = (uint)text.Length;
		Buffer.Memmove(ref text._firstChar, ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(value), startIndex), num);
		return text;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[CLSCompliant(false)]
	public unsafe extern String(char* value);

	private unsafe static string Ctor(char* ptr)
	{
		if (ptr == null)
		{
			return Empty;
		}
		int num = wcslen(ptr);
		if (num == 0)
		{
			return Empty;
		}
		string text = FastAllocateString(num);
		nuint num2 = (uint)text.Length;
		Buffer.Memmove(ref text._firstChar, ref *ptr, num2);
		return text;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[CLSCompliant(false)]
	public unsafe extern String(char* value, int startIndex, int length);

	private unsafe static string Ctor(char* ptr, int startIndex, int length)
	{
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("length", "ArgumentOutOfRange_NegativeLength");
		}
		if (startIndex < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex", "ArgumentOutOfRange_StartIndex");
		}
		char* ptr2 = ptr + startIndex;
		if (ptr2 < ptr)
		{
			throw new ArgumentOutOfRangeException("startIndex", "ArgumentOutOfRange_PartialWCHAR");
		}
		if (length == 0)
		{
			return Empty;
		}
		if (ptr == null)
		{
			throw new ArgumentOutOfRangeException("ptr", "ArgumentOutOfRange_PartialWCHAR");
		}
		string text = FastAllocateString(length);
		nuint num = (uint)text.Length;
		Buffer.Memmove(ref text._firstChar, ref *ptr2, num);
		return text;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[CLSCompliant(false)]
	public unsafe extern String(sbyte* value);

	private unsafe static string Ctor(sbyte* value)
	{
		if (value == null)
		{
			return Empty;
		}
		int num = strlen((byte*)value);
		return CreateStringForSByteConstructor((byte*)value, num);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[CLSCompliant(false)]
	public unsafe extern String(sbyte* value, int startIndex, int length);

	private unsafe static string Ctor(sbyte* value, int startIndex, int length)
	{
		if (startIndex < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex", "ArgumentOutOfRange_StartIndex");
		}
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("length", "ArgumentOutOfRange_NegativeLength");
		}
		if (value == null)
		{
			if (length == 0)
			{
				return Empty;
			}
			ArgumentNullException.Throw("value");
		}
		byte* ptr = (byte*)(value + startIndex);
		if (ptr < value)
		{
			throw new ArgumentOutOfRangeException("value", "ArgumentOutOfRange_PartialWCHAR");
		}
		return CreateStringForSByteConstructor(ptr, length);
	}

	private unsafe static string CreateStringForSByteConstructor(byte* P_0, int P_1)
	{
		if (P_1 == 0)
		{
			return Empty;
		}
		return CreateStringFromEncoding(P_0, P_1, Encoding.UTF8);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[CLSCompliant(false)]
	public unsafe extern String(sbyte* value, int startIndex, int length, Encoding enc);

	private unsafe static string Ctor(sbyte* value, int startIndex, int length, Encoding enc)
	{
		if (enc == null)
		{
			return new string(value, startIndex, length);
		}
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("length", "ArgumentOutOfRange_NeedNonNegNum");
		}
		if (startIndex < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex", "ArgumentOutOfRange_StartIndex");
		}
		if (value == null)
		{
			if (length == 0)
			{
				return Empty;
			}
			ArgumentNullException.Throw("value");
		}
		byte* ptr = (byte*)(value + startIndex);
		if (ptr < value)
		{
			throw new ArgumentOutOfRangeException("startIndex", "ArgumentOutOfRange_PartialWCHAR");
		}
		return enc.GetString(new ReadOnlySpan<byte>(ptr, length));
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public extern String(char c, int count);

	private static string Ctor(char c, int count)
	{
		if (count <= 0)
		{
			if (count == 0)
			{
				return Empty;
			}
			throw new ArgumentOutOfRangeException("count", "ArgumentOutOfRange_NegativeCount");
		}
		string text = FastAllocateString(count);
		if (c != 0)
		{
			SpanHelpers.Fill(ref text._firstChar, (uint)count, c);
		}
		return text;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public extern String(ReadOnlySpan<char> value);

	private static string Ctor(ReadOnlySpan<char> value)
	{
		if (value.Length == 0)
		{
			return Empty;
		}
		string text = FastAllocateString(value.Length);
		Buffer.Memmove(ref text._firstChar, ref MemoryMarshal.GetReference(value), (uint)value.Length);
		return text;
	}

	public static string Create<TState>(int P_0, TState P_1, SpanAction<char, TState> P_2)
	{
		ArgumentNullException.ThrowIfNull(P_2, "action");
		if (P_0 <= 0)
		{
			if (P_0 == 0)
			{
				return Empty;
			}
			throw new ArgumentOutOfRangeException("length");
		}
		string text = FastAllocateString(P_0);
		P_2(new Span<char>(ref text.GetRawStringData(), P_0), P_1);
		return text;
	}

	public static string Create(IFormatProvider? P_0, Span<char> P_1, [InterpolatedStringHandlerArgument(new string[] { "provider", "initialBuffer" })] ref DefaultInterpolatedStringHandler P_2)
	{
		return P_2.ToStringAndClear();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	public static implicit operator ReadOnlySpan<char>(string? P_0)
	{
		if ((object)P_0 == null)
		{
			return default(ReadOnlySpan<char>);
		}
		return new ReadOnlySpan<char>(ref P_0.GetRawStringData(), P_0.Length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal bool TryGetSpan(int P_0, int P_1, out ReadOnlySpan<char> P_2)
	{
		if ((uint)P_0 > (uint)Length || (uint)P_1 > (uint)(Length - P_0))
		{
			P_2 = default(ReadOnlySpan<char>);
			return false;
		}
		P_2 = new ReadOnlySpan<char>(ref Unsafe.Add(ref _firstChar, (nint)(uint)P_0), P_1);
		return true;
	}

	public object Clone()
	{
		return this;
	}

	public void CopyTo(int P_0, char[] P_1, int P_2, int P_3)
	{
		ArgumentNullException.ThrowIfNull(P_1, "destination");
		if (P_3 < 0)
		{
			throw new ArgumentOutOfRangeException("count", "ArgumentOutOfRange_NegativeCount");
		}
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("sourceIndex", "ArgumentOutOfRange_IndexMustBeLessOrEqual");
		}
		if (P_3 > Length - P_0)
		{
			throw new ArgumentOutOfRangeException("sourceIndex", "ArgumentOutOfRange_IndexCount");
		}
		if (P_2 > P_1.Length - P_3 || P_2 < 0)
		{
			throw new ArgumentOutOfRangeException("destinationIndex", "ArgumentOutOfRange_IndexCount");
		}
		Buffer.Memmove(ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(P_1), P_2), ref Unsafe.Add(ref _firstChar, P_0), (uint)P_3);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void CopyTo(Span<char> P_0)
	{
		if ((uint)Length <= (uint)P_0.Length)
		{
			Buffer.Memmove(ref P_0._reference, ref _firstChar, (uint)Length);
		}
		else
		{
			ThrowHelper.ThrowArgumentException_DestinationTooShort();
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool TryCopyTo(Span<char> P_0)
	{
		bool result = false;
		if ((uint)Length <= (uint)P_0.Length)
		{
			Buffer.Memmove(ref P_0._reference, ref _firstChar, (uint)Length);
			result = true;
		}
		return result;
	}

	public char[] ToCharArray()
	{
		if (Length == 0)
		{
			return Array.Empty<char>();
		}
		char[] array = new char[Length];
		Buffer.Memmove(ref MemoryMarshal.GetArrayDataReference(array), ref _firstChar, (uint)Length);
		return array;
	}

	public static bool IsNullOrEmpty([NotNullWhen(false)] string? P_0)
	{
		if ((object)P_0 != null)
		{
			return P_0.Length == 0;
		}
		return true;
	}

	public static bool IsNullOrWhiteSpace([NotNullWhen(false)] string? P_0)
	{
		if ((object)P_0 == null)
		{
			return true;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			if (!char.IsWhiteSpace(P_0[i]))
			{
				return false;
			}
		}
		return true;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[NonVersionable]
	public ref readonly char GetPinnableReference()
	{
		return ref _firstChar;
	}

	internal ref char GetRawStringData()
	{
		return ref _firstChar;
	}

	internal ref ushort GetRawStringDataAsUInt16()
	{
		return ref Unsafe.As<char, ushort>(ref _firstChar);
	}

	internal unsafe static string CreateStringFromEncoding(byte* P_0, int P_1, Encoding P_2)
	{
		int charCount = P_2.GetCharCount(P_0, P_1);
		if (charCount == 0)
		{
			return Empty;
		}
		string text = FastAllocateString(charCount);
		fixed (char* firstChar = &text._firstChar)
		{
			int chars = P_2.GetChars(P_0, P_1, firstChar, charCount);
		}
		return text;
	}

	internal static string CreateFromChar(char P_0)
	{
		string text = FastAllocateString(1);
		text._firstChar = P_0;
		return text;
	}

	internal static string CreateFromChar(char P_0, char P_1)
	{
		string text = FastAllocateString(2);
		text._firstChar = P_0;
		Unsafe.Add(ref text._firstChar, 1) = P_1;
		return text;
	}

	public override string ToString()
	{
		return this;
	}

	public string ToString(IFormatProvider? P_0)
	{
		return this;
	}

	IEnumerator<char> IEnumerable<char>.GetEnumerator()
	{
		return new CharEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new CharEnumerator(this);
	}

	public StringRuneEnumerator EnumerateRunes()
	{
		return new StringRuneEnumerator(this);
	}

	internal unsafe static int wcslen(char* P_0)
	{
		return SpanHelpers.IndexOfNullCharacter(ref *P_0);
	}

	internal unsafe static int strlen(byte* P_0)
	{
		return SpanHelpers.IndexOfNullByte(ref *P_0);
	}

	public TypeCode GetTypeCode()
	{
		return TypeCode.String;
	}

	bool IConvertible.ToBoolean(IFormatProvider P_0)
	{
		return Convert.ToBoolean(this, P_0);
	}

	char IConvertible.ToChar(IFormatProvider P_0)
	{
		return Convert.ToChar(this, P_0);
	}

	sbyte IConvertible.ToSByte(IFormatProvider P_0)
	{
		return Convert.ToSByte(this, P_0);
	}

	byte IConvertible.ToByte(IFormatProvider P_0)
	{
		return Convert.ToByte(this, P_0);
	}

	short IConvertible.ToInt16(IFormatProvider P_0)
	{
		return Convert.ToInt16(this, P_0);
	}

	ushort IConvertible.ToUInt16(IFormatProvider P_0)
	{
		return Convert.ToUInt16(this, P_0);
	}

	int IConvertible.ToInt32(IFormatProvider P_0)
	{
		return Convert.ToInt32(this, P_0);
	}

	uint IConvertible.ToUInt32(IFormatProvider P_0)
	{
		return Convert.ToUInt32(this, P_0);
	}

	long IConvertible.ToInt64(IFormatProvider P_0)
	{
		return Convert.ToInt64(this, P_0);
	}

	ulong IConvertible.ToUInt64(IFormatProvider P_0)
	{
		return Convert.ToUInt64(this, P_0);
	}

	float IConvertible.ToSingle(IFormatProvider P_0)
	{
		return Convert.ToSingle(this, P_0);
	}

	double IConvertible.ToDouble(IFormatProvider P_0)
	{
		return Convert.ToDouble(this, P_0);
	}

	decimal IConvertible.ToDecimal(IFormatProvider P_0)
	{
		return Convert.ToDecimal(this, P_0);
	}

	DateTime IConvertible.ToDateTime(IFormatProvider P_0)
	{
		return Convert.ToDateTime(this, P_0);
	}

	object IConvertible.ToType(Type P_0, IFormatProvider P_1)
	{
		return Convert.DefaultToType(this, P_0, P_1);
	}

	public string Normalize(NormalizationForm P_0)
	{
		if (IsAscii() && (P_0 == NormalizationForm.FormC || P_0 == NormalizationForm.FormKC || P_0 == NormalizationForm.FormD || P_0 == NormalizationForm.FormKD))
		{
			return this;
		}
		return Normalization.Normalize(this, P_0);
	}

	private unsafe bool IsAscii()
	{
		fixed (char* firstChar = &_firstChar)
		{
			return ASCIIUtility.GetIndexOfFirstNonAsciiChar(firstChar, (uint)Length) == (uint)Length;
		}
	}

	private static void FillStringChecked(string P_0, int P_1, string P_2)
	{
		if (P_2.Length > P_0.Length - P_1)
		{
			throw new IndexOutOfRangeException();
		}
		Buffer.Memmove(ref Unsafe.Add(ref P_0._firstChar, P_1), ref P_2._firstChar, (uint)P_2.Length);
	}

	public static string Concat(object? P_0, object? P_1)
	{
		return P_0?.ToString() + P_1;
	}

	public static string Concat(object? P_0, object? P_1, object? P_2)
	{
		return P_0?.ToString() + P_1?.ToString() + P_2;
	}

	public static string Concat(string? P_0, string? P_1)
	{
		if (IsNullOrEmpty(P_0))
		{
			if (IsNullOrEmpty(P_1))
			{
				return Empty;
			}
			return P_1;
		}
		if (IsNullOrEmpty(P_1))
		{
			return P_0;
		}
		int length = P_0.Length;
		string text = FastAllocateString(length + P_1.Length);
		FillStringChecked(text, 0, P_0);
		FillStringChecked(text, length, P_1);
		return text;
	}

	public static string Concat(string? P_0, string? P_1, string? P_2)
	{
		if (IsNullOrEmpty(P_0))
		{
			return P_1 + P_2;
		}
		if (IsNullOrEmpty(P_1))
		{
			return P_0 + P_2;
		}
		if (IsNullOrEmpty(P_2))
		{
			return P_0 + P_1;
		}
		int num = P_0.Length + P_1.Length + P_2.Length;
		string text = FastAllocateString(num);
		FillStringChecked(text, 0, P_0);
		FillStringChecked(text, P_0.Length, P_1);
		FillStringChecked(text, P_0.Length + P_1.Length, P_2);
		return text;
	}

	public static string Concat(string? P_0, string? P_1, string? P_2, string? P_3)
	{
		if (IsNullOrEmpty(P_0))
		{
			return P_1 + P_2 + P_3;
		}
		if (IsNullOrEmpty(P_1))
		{
			return P_0 + P_2 + P_3;
		}
		if (IsNullOrEmpty(P_2))
		{
			return P_0 + P_1 + P_3;
		}
		if (IsNullOrEmpty(P_3))
		{
			return P_0 + P_1 + P_2;
		}
		int num = P_0.Length + P_1.Length + P_2.Length + P_3.Length;
		string text = FastAllocateString(num);
		FillStringChecked(text, 0, P_0);
		FillStringChecked(text, P_0.Length, P_1);
		FillStringChecked(text, P_0.Length + P_1.Length, P_2);
		FillStringChecked(text, P_0.Length + P_1.Length + P_2.Length, P_3);
		return text;
	}

	public static string Concat(ReadOnlySpan<char> P_0, ReadOnlySpan<char> P_1)
	{
		int num = checked(P_0.Length + P_1.Length);
		if (num == 0)
		{
			return Empty;
		}
		string text = FastAllocateString(num);
		Span<char> span = new Span<char>(ref text._firstChar, text.Length);
		P_0.CopyTo(span);
		P_1.CopyTo(span.Slice(P_0.Length));
		return text;
	}

	public static string Concat(ReadOnlySpan<char> P_0, ReadOnlySpan<char> P_1, ReadOnlySpan<char> P_2)
	{
		int num = checked(P_0.Length + P_1.Length + P_2.Length);
		if (num == 0)
		{
			return Empty;
		}
		string text = FastAllocateString(num);
		Span<char> span = new Span<char>(ref text._firstChar, text.Length);
		P_0.CopyTo(span);
		span = span.Slice(P_0.Length);
		P_1.CopyTo(span);
		span = span.Slice(P_1.Length);
		P_2.CopyTo(span);
		return text;
	}

	public static string Concat(ReadOnlySpan<char> P_0, ReadOnlySpan<char> P_1, ReadOnlySpan<char> P_2, ReadOnlySpan<char> P_3)
	{
		int num = checked(P_0.Length + P_1.Length + P_2.Length + P_3.Length);
		if (num == 0)
		{
			return Empty;
		}
		string text = FastAllocateString(num);
		Span<char> span = new Span<char>(ref text._firstChar, text.Length);
		P_0.CopyTo(span);
		span = span.Slice(P_0.Length);
		P_1.CopyTo(span);
		span = span.Slice(P_1.Length);
		P_2.CopyTo(span);
		span = span.Slice(P_2.Length);
		P_3.CopyTo(span);
		return text;
	}

	public static string Concat(params string?[] P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "values");
		if (P_0.Length <= 1)
		{
			object obj;
			if (P_0.Length != 0)
			{
				obj = P_0[0];
				if (obj == null)
				{
					return Empty;
				}
			}
			else
			{
				obj = Empty;
			}
			return (string)obj;
		}
		long num = 0L;
		foreach (string text in P_0)
		{
			if ((object)text != null)
			{
				num += text.Length;
			}
		}
		if (num > 2147483647)
		{
			throw new OutOfMemoryException();
		}
		int num2 = (int)num;
		if (num2 == 0)
		{
			return Empty;
		}
		string text2 = FastAllocateString(num2);
		int num3 = 0;
		foreach (string text3 in P_0)
		{
			if (!IsNullOrEmpty(text3))
			{
				int length = text3.Length;
				if (length > num2 - num3)
				{
					num3 = -1;
					break;
				}
				FillStringChecked(text2, num3, text3);
				num3 += length;
			}
		}
		if (num3 != num2)
		{
			return Concat((string[])P_0.Clone());
		}
		return text2;
	}

	public static string Format([StringSyntax("CompositeFormat")] string P_0, object? P_1)
	{
		return FormatHelper(null, P_0, new ReadOnlySpan<object>(in P_1));
	}

	public static string Format([StringSyntax("CompositeFormat")] string P_0, object? P_1, object? P_2)
	{
		TwoObjects twoObjects = new TwoObjects(P_1, P_2);
		return FormatHelper(null, P_0, MemoryMarshal.CreateReadOnlySpan(ref twoObjects.Arg0, 2));
	}

	public static string Format([StringSyntax("CompositeFormat")] string P_0, object? P_1, object? P_2, object? P_3)
	{
		ThreeObjects threeObjects = new ThreeObjects(P_1, P_2, P_3);
		return FormatHelper(null, P_0, MemoryMarshal.CreateReadOnlySpan(ref threeObjects.Arg0, 3));
	}

	public static string Format([StringSyntax("CompositeFormat")] string P_0, params object?[] P_1)
	{
		if (P_1 == null)
		{
			ArgumentNullException.Throw(((object)P_0 == null) ? "format" : "args");
		}
		return FormatHelper(null, P_0, P_1);
	}

	public static string Format(IFormatProvider? P_0, [StringSyntax("CompositeFormat")] string P_1, object? P_2)
	{
		return FormatHelper(P_0, P_1, new ReadOnlySpan<object>(in P_2));
	}

	public static string Format(IFormatProvider? P_0, [StringSyntax("CompositeFormat")] string P_1, params object?[] P_2)
	{
		if (P_2 == null)
		{
			ArgumentNullException.Throw(((object)P_1 == null) ? "format" : "args");
		}
		return FormatHelper(P_0, P_1, P_2);
	}

	private static string FormatHelper(IFormatProvider P_0, string P_1, ReadOnlySpan<object> P_2)
	{
		ArgumentNullException.ThrowIfNull(P_1, "format");
		Span<char> span = stackalloc char[256];
		ValueStringBuilder valueStringBuilder = new ValueStringBuilder(span);
		valueStringBuilder.EnsureCapacity(P_1.Length + P_2.Length * 8);
		valueStringBuilder.AppendFormatHelper(P_0, P_1, P_2);
		return valueStringBuilder.ToString();
	}

	public string Insert(int P_0, string P_1)
	{
		ArgumentNullException.ThrowIfNull(P_1, "value");
		if ((uint)P_0 > Length)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		int length = Length;
		int length2 = P_1.Length;
		if (length == 0)
		{
			return P_1;
		}
		if (length2 == 0)
		{
			return this;
		}
		int num = length + length2;
		string text = FastAllocateString(num);
		Buffer.Memmove(ref text._firstChar, ref _firstChar, (nuint)P_0);
		Buffer.Memmove(ref Unsafe.Add(ref text._firstChar, P_0), ref P_1._firstChar, (nuint)length2);
		Buffer.Memmove(ref Unsafe.Add(ref text._firstChar, P_0 + length2), ref Unsafe.Add(ref _firstChar, P_0), (nuint)(length - P_0));
		return text;
	}

	public static string Join(string? P_0, params string?[] P_1)
	{
		if (P_1 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.value);
		}
		return JoinCore(P_0.AsSpan(), new ReadOnlySpan<string>(P_1));
	}

	public static string Join(string? P_0, params object?[] P_1)
	{
		return JoinCore(P_0.AsSpan(), P_1);
	}

	private static string JoinCore(ReadOnlySpan<char> P_0, object[] P_1)
	{
		if (P_1 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.values);
		}
		if (P_1.Length == 0)
		{
			return Empty;
		}
		string text = P_1[0]?.ToString();
		if (P_1.Length == 1)
		{
			return text ?? Empty;
		}
		Span<char> span = stackalloc char[256];
		ValueStringBuilder valueStringBuilder = new ValueStringBuilder(span);
		valueStringBuilder.Append(text);
		for (int i = 1; i < P_1.Length; i++)
		{
			valueStringBuilder.Append(P_0);
			object obj = P_1[i];
			if (obj != null)
			{
				valueStringBuilder.Append(obj.ToString());
			}
		}
		return valueStringBuilder.ToString();
	}

	private static string JoinCore(ReadOnlySpan<char> P_0, ReadOnlySpan<string> P_1)
	{
		if (P_1.Length <= 1)
		{
			object obj;
			if (!P_1.IsEmpty)
			{
				obj = P_1[0];
				if (obj == null)
				{
					return Empty;
				}
			}
			else
			{
				obj = Empty;
			}
			return (string)obj;
		}
		long num = (long)(P_1.Length - 1) * (long)P_0.Length;
		if (num > 2147483647)
		{
			ThrowHelper.ThrowOutOfMemoryException();
		}
		int num2 = (int)num;
		ReadOnlySpan<string> readOnlySpan = P_1;
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			string text = readOnlySpan[i];
			if ((object)text != null)
			{
				num2 += text.Length;
				if (num2 < 0)
				{
					ThrowHelper.ThrowOutOfMemoryException();
				}
			}
		}
		string text2 = FastAllocateString(num2);
		int num3 = 0;
		for (int j = 0; j < P_1.Length; j++)
		{
			string text3 = P_1[j];
			if ((object)text3 != null)
			{
				int length = text3.Length;
				if (length > num2 - num3)
				{
					num3 = -1;
					break;
				}
				FillStringChecked(text2, num3, text3);
				num3 += length;
			}
			if (j < P_1.Length - 1)
			{
				ref char reference = ref Unsafe.Add(ref text2._firstChar, num3);
				if (P_0.Length == 1)
				{
					reference = P_0[0];
				}
				else
				{
					P_0.CopyTo(new Span<char>(ref reference, P_0.Length));
				}
				num3 += P_0.Length;
			}
		}
		if (num3 != num2)
		{
			return JoinCore(P_0, P_1.ToArray().AsSpan());
		}
		return text2;
	}

	public string Remove(int P_0, int P_1)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex", "ArgumentOutOfRange_StartIndex");
		}
		if (P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("count", "ArgumentOutOfRange_NegativeCount");
		}
		int length = Length;
		if (P_1 > length - P_0)
		{
			throw new ArgumentOutOfRangeException("count", "ArgumentOutOfRange_IndexCount");
		}
		if (P_1 == 0)
		{
			return this;
		}
		int num = length - P_1;
		if (num == 0)
		{
			return Empty;
		}
		string text = FastAllocateString(num);
		Buffer.Memmove(ref text._firstChar, ref _firstChar, (nuint)P_0);
		Buffer.Memmove(ref Unsafe.Add(ref text._firstChar, P_0), ref Unsafe.Add(ref _firstChar, P_0 + P_1), (nuint)(num - P_0));
		return text;
	}

	public string Remove(int P_0)
	{
		if ((uint)P_0 > Length)
		{
			throw new ArgumentOutOfRangeException("startIndex", (P_0 < 0) ? "ArgumentOutOfRange_StartIndex" : "ArgumentOutOfRange_StartIndexLargerThanLength");
		}
		return Substring(0, P_0);
	}

	public string Replace(string P_0, string? P_1, StringComparison P_2)
	{
		switch (P_2)
		{
		case StringComparison.CurrentCulture:
		case StringComparison.CurrentCultureIgnoreCase:
			return ReplaceCore(P_0, P_1, CultureInfo.CurrentCulture.CompareInfo, GetCaseCompareOfComparisonCulture(P_2));
		case StringComparison.InvariantCulture:
		case StringComparison.InvariantCultureIgnoreCase:
			return ReplaceCore(P_0, P_1, CompareInfo.Invariant, GetCaseCompareOfComparisonCulture(P_2));
		case StringComparison.Ordinal:
			return Replace(P_0, P_1);
		case StringComparison.OrdinalIgnoreCase:
			return ReplaceCore(P_0, P_1, CompareInfo.Invariant, CompareOptions.OrdinalIgnoreCase);
		default:
			throw new ArgumentException("NotSupported_StringComparison", "comparisonType");
		}
	}

	private string ReplaceCore(string P_0, string P_1, CompareInfo P_2, CompareOptions P_3)
	{
		ArgumentException.ThrowIfNullOrEmpty(P_0, "oldValue");
		return ReplaceCore(this, P_0.AsSpan(), P_1.AsSpan(), P_2 ?? CultureInfo.CurrentCulture.CompareInfo, P_3) ?? this;
	}

	private static string ReplaceCore(ReadOnlySpan<char> P_0, ReadOnlySpan<char> P_1, ReadOnlySpan<char> P_2, CompareInfo P_3, CompareOptions P_4)
	{
		Span<char> span = stackalloc char[256];
		ValueStringBuilder valueStringBuilder = new ValueStringBuilder(span);
		valueStringBuilder.EnsureCapacity(P_0.Length);
		bool flag = false;
		while (true)
		{
			int num2;
			int num = P_3.IndexOf(P_0, P_1, P_4, out num2);
			if (num < 0 || num2 == 0)
			{
				break;
			}
			valueStringBuilder.Append(P_0.Slice(0, num));
			valueStringBuilder.Append(P_2);
			P_0 = P_0.Slice(num + num2);
			flag = true;
		}
		if (!flag)
		{
			valueStringBuilder.Dispose();
			return null;
		}
		valueStringBuilder.Append(P_0);
		return valueStringBuilder.ToString();
	}

	public string Replace(char P_0, char P_1)
	{
		if (P_0 == P_1)
		{
			return this;
		}
		int num = IndexOf(P_0);
		if (num < 0)
		{
			return this;
		}
		nuint num2 = (uint)(Length - num);
		string text = FastAllocateString(Length);
		int num3 = num;
		if (num3 > 0)
		{
			Buffer.Memmove(ref text._firstChar, ref _firstChar, (uint)num3);
		}
		ref ushort reference = ref Unsafe.Add(ref GetRawStringDataAsUInt16(), (uint)num3);
		ref ushort reference2 = ref Unsafe.Add(ref text.GetRawStringDataAsUInt16(), (uint)num3);
		nuint num4 = 0u;
		if (false)
		{
			goto IL_006b;
		}
		goto IL_0091;
		IL_006b:
		ushort num5 = Unsafe.Add(ref reference, num4);
		Unsafe.Add(ref reference2, num4) = ((num5 == P_0) ? P_1 : num5);
		num4++;
		goto IL_0091;
		IL_0091:
		if (num4 >= num2)
		{
			return text;
		}
		goto IL_006b;
	}

	public string Replace(string P_0, string? P_1)
	{
		ArgumentException.ThrowIfNullOrEmpty(P_0, "oldValue");
		if ((object)P_1 == null)
		{
			P_1 = Empty;
		}
		Span<int> span = stackalloc int[128];
		ValueListBuilder<int> valueListBuilder = new ValueListBuilder<int>(span);
		if (P_0.Length == 1)
		{
			if (P_1.Length == 1)
			{
				return Replace(P_0[0], P_1[0]);
			}
			char c = P_0[0];
			int num = 0;
			while (true)
			{
				int num2 = SpanHelpers.IndexOfChar(ref Unsafe.Add(ref _firstChar, num), c, Length - num);
				if (num2 < 0)
				{
					break;
				}
				valueListBuilder.Append(num + num2);
				num += num2 + 1;
			}
		}
		else
		{
			int num3 = 0;
			while (true)
			{
				int num4 = SpanHelpers.IndexOf(ref Unsafe.Add(ref _firstChar, num3), Length - num3, ref P_0._firstChar, P_0.Length);
				if (num4 < 0)
				{
					break;
				}
				valueListBuilder.Append(num3 + num4);
				num3 += num4 + P_0.Length;
			}
		}
		if (valueListBuilder.Length == 0)
		{
			return this;
		}
		string result = ReplaceHelper(P_0.Length, P_1, valueListBuilder.AsSpan());
		valueListBuilder.Dispose();
		return result;
	}

	private string ReplaceHelper(int P_0, string P_1, ReadOnlySpan<int> P_2)
	{
		long num = Length + (long)(P_1.Length - P_0) * (long)P_2.Length;
		if (num > 2147483647)
		{
			throw new OutOfMemoryException();
		}
		string text = FastAllocateString((int)num);
		Span<char> span = new Span<char>(ref text._firstChar, text.Length);
		int num2 = 0;
		int num3 = 0;
		for (int i = 0; i < P_2.Length; i++)
		{
			int num4 = P_2[i];
			int num5 = num4 - num2;
			if (num5 != 0)
			{
				this.AsSpan(num2, num5).CopyTo(span.Slice(num3));
				num3 += num5;
			}
			num2 = num4 + P_0;
			P_1.CopyTo(span.Slice(num3));
			num3 += P_1.Length;
		}
		this.AsSpan(num2).CopyTo(span.Slice(num3));
		return text;
	}

	public string[] Split(char P_0, StringSplitOptions P_1 = StringSplitOptions.None)
	{
		return SplitInternal(new ReadOnlySpan<char>(in P_0), 2147483647, P_1);
	}

	public string[] Split(params char[]? P_0)
	{
		return SplitInternal(P_0, 2147483647, StringSplitOptions.None);
	}

	public string[] Split(char[]? P_0, StringSplitOptions P_1)
	{
		return SplitInternal(P_0, 2147483647, P_1);
	}

	private string[] SplitInternal(ReadOnlySpan<char> P_0, int P_1, StringSplitOptions P_2)
	{
		if (P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("count", "ArgumentOutOfRange_NegativeCount");
		}
		CheckStringSplitOptions(P_2);
		ValueListBuilder<int> valueListBuilder;
		ReadOnlySpan<int> readOnlySpan;
		while (true)
		{
			if (P_1 <= 1 || Length == 0)
			{
				return CreateSplitArrayOfThisAsSoleValue(P_2, P_1);
			}
			if (P_0.IsEmpty)
			{
				P_2 &= ~StringSplitOptions.TrimEntries;
			}
			Span<int> span = stackalloc int[128];
			valueListBuilder = new ValueListBuilder<int>(span);
			MakeSeparatorList(P_0, ref valueListBuilder);
			readOnlySpan = valueListBuilder.AsSpan();
			if (readOnlySpan.Length != 0)
			{
				break;
			}
			P_1 = 1;
		}
		string[] result = ((P_2 != StringSplitOptions.None) ? SplitWithPostProcessing(readOnlySpan, default(ReadOnlySpan<int>), 1, P_1, P_2) : SplitWithoutPostProcessing(readOnlySpan, default(ReadOnlySpan<int>), 1, P_1));
		valueListBuilder.Dispose();
		return result;
	}

	public string[] Split(string? P_0, StringSplitOptions P_1 = StringSplitOptions.None)
	{
		return SplitInternal(P_0 ?? Empty, null, 2147483647, P_1);
	}

	private string[] SplitInternal(string P_0, string[] P_1, int P_2, StringSplitOptions P_3)
	{
		if (P_2 < 0)
		{
			throw new ArgumentOutOfRangeException("count", "ArgumentOutOfRange_NegativeCount");
		}
		CheckStringSplitOptions(P_3);
		bool flag = (object)P_0 != null;
		if (!flag && (P_1 == null || P_1.Length == 0))
		{
			return SplitInternal(default(ReadOnlySpan<char>), P_2, P_3);
		}
		while (true)
		{
			if (P_2 <= 1 || Length == 0)
			{
				return CreateSplitArrayOfThisAsSoleValue(P_3, P_2);
			}
			if (!flag)
			{
				break;
			}
			if (P_0.Length == 0)
			{
				P_2 = 1;
				continue;
			}
			return SplitInternal(P_0, P_2, P_3);
		}
		Span<int> span = stackalloc int[128];
		ValueListBuilder<int> valueListBuilder = new ValueListBuilder<int>(span);
		span = stackalloc int[128];
		ValueListBuilder<int> valueListBuilder2 = new ValueListBuilder<int>(span);
		MakeSeparatorList(P_1, ref valueListBuilder, ref valueListBuilder2);
		ReadOnlySpan<int> readOnlySpan = valueListBuilder.AsSpan();
		ReadOnlySpan<int> readOnlySpan2 = valueListBuilder2.AsSpan();
		if (readOnlySpan.Length == 0)
		{
			return CreateSplitArrayOfThisAsSoleValue(P_3, P_2);
		}
		string[] result = ((P_3 != StringSplitOptions.None) ? SplitWithPostProcessing(readOnlySpan, readOnlySpan2, 0, P_2, P_3) : SplitWithoutPostProcessing(readOnlySpan, readOnlySpan2, 0, P_2));
		valueListBuilder.Dispose();
		valueListBuilder2.Dispose();
		return result;
	}

	private string[] CreateSplitArrayOfThisAsSoleValue(StringSplitOptions P_0, int P_1)
	{
		if (P_1 != 0)
		{
			string text = this;
			if ((P_0 & StringSplitOptions.TrimEntries) != StringSplitOptions.None)
			{
				text = text.Trim();
			}
			if ((P_0 & StringSplitOptions.RemoveEmptyEntries) == 0 || text.Length != 0)
			{
				return new string[1] { text };
			}
		}
		return Array.Empty<string>();
	}

	private string[] SplitInternal(string P_0, int P_1, StringSplitOptions P_2)
	{
		Span<int> span = stackalloc int[128];
		ValueListBuilder<int> valueListBuilder = new ValueListBuilder<int>(span);
		MakeSeparatorList(P_0, ref valueListBuilder);
		ReadOnlySpan<int> readOnlySpan = valueListBuilder.AsSpan();
		if (readOnlySpan.Length == 0)
		{
			return CreateSplitArrayOfThisAsSoleValue(P_2, P_1);
		}
		string[] result = ((P_2 != StringSplitOptions.None) ? SplitWithPostProcessing(readOnlySpan, default(ReadOnlySpan<int>), P_0.Length, P_1, P_2) : SplitWithoutPostProcessing(readOnlySpan, default(ReadOnlySpan<int>), P_0.Length, P_1));
		valueListBuilder.Dispose();
		return result;
	}

	private string[] SplitWithoutPostProcessing(ReadOnlySpan<int> P_0, ReadOnlySpan<int> P_1, int P_2, int P_3)
	{
		int num = 0;
		int num2 = 0;
		P_3--;
		int num3 = ((P_0.Length < P_3) ? P_0.Length : P_3);
		string[] array = new string[num3 + 1];
		for (int i = 0; i < num3; i++)
		{
			if (num >= Length)
			{
				break;
			}
			array[num2++] = Substring(num, P_0[i] - num);
			num = P_0[i] + (P_1.IsEmpty ? P_2 : P_1[i]);
		}
		if (num < Length && num3 >= 0)
		{
			array[num2] = Substring(num);
		}
		else if (num2 == num3)
		{
			array[num2] = Empty;
		}
		return array;
	}

	private string[] SplitWithPostProcessing(ReadOnlySpan<int> P_0, ReadOnlySpan<int> P_1, int P_2, int P_3, StringSplitOptions P_4)
	{
		int length = P_0.Length;
		int num = ((length < P_3) ? (length + 1) : P_3);
		string[] array = new string[num];
		int num2 = 0;
		int num3 = 0;
		ReadOnlySpan<char> readOnlySpan;
		for (int i = 0; i < length; i++)
		{
			readOnlySpan = this.AsSpan(num2, P_0[i] - num2);
			if ((P_4 & StringSplitOptions.TrimEntries) != StringSplitOptions.None)
			{
				readOnlySpan = readOnlySpan.Trim();
			}
			if (!readOnlySpan.IsEmpty || (P_4 & StringSplitOptions.RemoveEmptyEntries) == 0)
			{
				array[num3++] = readOnlySpan.ToString();
			}
			num2 = P_0[i] + (P_1.IsEmpty ? P_2 : P_1[i]);
			if (num3 != P_3 - 1)
			{
				continue;
			}
			if ((P_4 & StringSplitOptions.RemoveEmptyEntries) == 0)
			{
				break;
			}
			while (++i < length)
			{
				readOnlySpan = this.AsSpan(num2, P_0[i] - num2);
				if ((P_4 & StringSplitOptions.TrimEntries) != StringSplitOptions.None)
				{
					readOnlySpan = readOnlySpan.Trim();
				}
				if (!readOnlySpan.IsEmpty)
				{
					break;
				}
				num2 = P_0[i] + (P_1.IsEmpty ? P_2 : P_1[i]);
			}
			break;
		}
		readOnlySpan = this.AsSpan(num2);
		if ((P_4 & StringSplitOptions.TrimEntries) != StringSplitOptions.None)
		{
			readOnlySpan = readOnlySpan.Trim();
		}
		if (!readOnlySpan.IsEmpty || (P_4 & StringSplitOptions.RemoveEmptyEntries) == 0)
		{
			array[num3++] = readOnlySpan.ToString();
		}
		Array.Resize(ref array, num3);
		return array;
	}

	private unsafe void MakeSeparatorList(ReadOnlySpan<char> P_0, ref ValueListBuilder<int> P_1)
	{
		if (P_0.Length == 0)
		{
			for (int i = 0; i < Length; i++)
			{
				if (char.IsWhiteSpace(this[i]))
				{
					P_1.Append(i);
				}
			}
			return;
		}
		if (P_0.Length <= 3)
		{
			char c = P_0[0];
			char c2 = ((P_0.Length > 1) ? P_0[1] : c);
			char c3 = ((P_0.Length > 2) ? P_0[2] : c2);
			if (Vector128.IsHardwareAccelerated && Length >= Vector128<ushort>.Count * 2)
			{
				MakeSeparatorListVectorized(ref P_1, c, c2, c3);
				return;
			}
			for (int j = 0; j < Length; j++)
			{
				char c4 = this[j];
				if (c4 == c || c4 == c2 || c4 == c3)
				{
					P_1.Append(j);
				}
			}
			return;
		}
		ProbabilisticMap probabilisticMap = default(ProbabilisticMap);
		uint* ptr = (uint*)(&probabilisticMap);
		ProbabilisticMap.Initialize(ptr, P_0);
		for (int k = 0; k < Length; k++)
		{
			char c5 = this[k];
			if (ProbabilisticMap.IsCharBitSet(ptr, (byte)c5) && ProbabilisticMap.IsCharBitSet(ptr, (byte)((int)c5 >> 8)) && P_0.Contains(c5))
			{
				P_1.Append(k);
			}
		}
	}

	private void MakeSeparatorListVectorized(ref ValueListBuilder<int> P_0, char P_1, char P_2, char P_3)
	{
		if (!Vector128.IsHardwareAccelerated)
		{
			throw new PlatformNotSupportedException();
		}
		nuint num = 0u;
		nuint num2 = (uint)Length;
		ref ushort reference = ref Unsafe.As<char, ushort>(ref _firstChar);
		Vector128<ushort> vector = Vector128.Create((ushort)P_1);
		Vector128<ushort> vector2 = Vector128.Create((ushort)P_2);
		Vector128<ushort> vector3 = Vector128.Create((ushort)P_3);
		do
		{
			Vector128<ushort> vector4 = Vector128.LoadUnsafe(ref reference, num);
			Vector128<ushort> vector5 = Vector128.Equals(vector4, vector);
			Vector128<ushort> vector6 = Vector128.Equals(vector4, vector2);
			Vector128<ushort> vector7 = Vector128.Equals(vector4, vector3);
			Vector128<byte> vector8 = (vector5 | vector6 | vector7).AsByte();
			if (vector8 != Vector128<byte>.Zero)
			{
				uint num3 = vector8.ExtractMostSignificantBits() & 0x5555;
				do
				{
					uint num4 = (uint)BitOperations.TrailingZeroCount(num3) / 2u;
					P_0.Append((int)(num + num4));
					num3 = BitOperations.ResetLowestSetBit(num3);
				}
				while (num3 != 0);
			}
			num += (nuint)Vector128<ushort>.Count;
		}
		while (num <= (nuint)((nint)num2 - (nint)Vector128<ushort>.Count));
		for (; num < num2; num++)
		{
			char c = (char)Unsafe.Add(ref reference, num);
			if (c == P_1 || c == P_2 || c == P_3)
			{
				P_0.Append((int)num);
			}
		}
	}

	private void MakeSeparatorList(string P_0, ref ValueListBuilder<int> P_1)
	{
		int length = P_0.Length;
		for (int i = 0; i < Length; i++)
		{
			if (this[i] == P_0[0] && length <= Length - i && (length == 1 || this.AsSpan(i, length).SequenceEqual(P_0)))
			{
				P_1.Append(i);
				i += length - 1;
			}
		}
	}

	private void MakeSeparatorList(string[] P_0, ref ValueListBuilder<int> P_1, ref ValueListBuilder<int> P_2)
	{
		for (int i = 0; i < Length; i++)
		{
			foreach (string text in P_0)
			{
				if (!IsNullOrEmpty(text))
				{
					int length = text.Length;
					if (this[i] == text[0] && length <= Length - i && (length == 1 || this.AsSpan(i, length).SequenceEqual(text)))
					{
						P_1.Append(i);
						P_2.Append(length);
						i += length - 1;
						break;
					}
				}
			}
		}
	}

	private static void CheckStringSplitOptions(StringSplitOptions P_0)
	{
		if ((P_0 & ~(StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)) != StringSplitOptions.None)
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidFlag, ExceptionArgument.options);
		}
	}

	public string Substring(int P_0)
	{
		if (P_0 == 0)
		{
			return this;
		}
		int num = Length - P_0;
		if (num == 0)
		{
			return Empty;
		}
		if ((uint)P_0 > (uint)Length)
		{
			ThrowSubstringArgumentOutOfRange(P_0, num);
		}
		return InternalSubString(P_0, num);
	}

	public string Substring(int P_0, int P_1)
	{
		if ((uint)P_0 > (uint)Length || (uint)P_1 > (uint)(Length - P_0))
		{
			ThrowSubstringArgumentOutOfRange(P_0, P_1);
		}
		if (P_1 == 0)
		{
			return Empty;
		}
		if (P_1 == Length)
		{
			return this;
		}
		return InternalSubString(P_0, P_1);
	}

	[DoesNotReturn]
	private void ThrowSubstringArgumentOutOfRange(int P_0, int P_1)
	{
		string text2;
		string text3;
		if (P_0 >= 0)
		{
			if (P_0 <= Length)
			{
				if (P_1 >= 0)
				{
					string text = "ArgumentOutOfRange_IndexLength";
					text2 = "length";
					text3 = text;
				}
				else
				{
					string text = "ArgumentOutOfRange_NegativeLength";
					text2 = "length";
					text3 = text;
				}
			}
			else
			{
				string text = "ArgumentOutOfRange_StartIndexLargerThanLength";
				text2 = "startIndex";
				text3 = text;
			}
		}
		else
		{
			string text = "ArgumentOutOfRange_StartIndex";
			text2 = "startIndex";
			text3 = text;
		}
		throw new ArgumentOutOfRangeException(text2, text3);
	}

	private string InternalSubString(int P_0, int P_1)
	{
		string text = FastAllocateString(P_1);
		nuint num = (uint)text.Length;
		Buffer.Memmove(ref text._firstChar, ref Unsafe.Add(ref _firstChar, (nint)(uint)P_0), num);
		return text;
	}

	public string ToLower()
	{
		return ToLower(null);
	}

	public string ToLower(CultureInfo? P_0)
	{
		CultureInfo cultureInfo = P_0 ?? CultureInfo.CurrentCulture;
		return cultureInfo.TextInfo.ToLower(this);
	}

	public string ToLowerInvariant()
	{
		return TextInfo.Invariant.ToLower(this);
	}

	public string ToUpper()
	{
		return ToUpper(null);
	}

	public string ToUpper(CultureInfo? P_0)
	{
		CultureInfo cultureInfo = P_0 ?? CultureInfo.CurrentCulture;
		return cultureInfo.TextInfo.ToUpper(this);
	}

	public string Trim()
	{
		return TrimWhiteSpaceHelper(TrimType.Both);
	}

	public unsafe string Trim(char P_0)
	{
		return TrimHelper(&P_0, 1, TrimType.Both);
	}

	public unsafe string Trim(params char[]? P_0)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			return TrimWhiteSpaceHelper(TrimType.Both);
		}
		fixed (char* ptr = &P_0[0])
		{
			return TrimHelper(ptr, P_0.Length, TrimType.Both);
		}
	}

	public string TrimStart()
	{
		return TrimWhiteSpaceHelper(TrimType.Head);
	}

	public unsafe string TrimStart(char P_0)
	{
		return TrimHelper(&P_0, 1, TrimType.Head);
	}

	public unsafe string TrimStart(params char[]? P_0)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			return TrimWhiteSpaceHelper(TrimType.Head);
		}
		fixed (char* ptr = &P_0[0])
		{
			return TrimHelper(ptr, P_0.Length, TrimType.Head);
		}
	}

	public string TrimEnd()
	{
		return TrimWhiteSpaceHelper(TrimType.Tail);
	}

	public unsafe string TrimEnd(char P_0)
	{
		return TrimHelper(&P_0, 1, TrimType.Tail);
	}

	public unsafe string TrimEnd(params char[]? P_0)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			return TrimWhiteSpaceHelper(TrimType.Tail);
		}
		fixed (char* ptr = &P_0[0])
		{
			return TrimHelper(ptr, P_0.Length, TrimType.Tail);
		}
	}

	private string TrimWhiteSpaceHelper(TrimType P_0)
	{
		int num = Length - 1;
		int i = 0;
		if ((P_0 & TrimType.Head) != 0)
		{
			for (i = 0; i < Length && char.IsWhiteSpace(this[i]); i++)
			{
			}
		}
		if ((P_0 & TrimType.Tail) != 0)
		{
			num = Length - 1;
			while (num >= i && char.IsWhiteSpace(this[num]))
			{
				num--;
			}
		}
		return CreateTrimmedString(i, num);
	}

	private unsafe string TrimHelper(char* P_0, int P_1, TrimType P_2)
	{
		int num = Length - 1;
		int i = 0;
		if ((P_2 & TrimType.Head) != 0)
		{
			for (i = 0; i < Length; i++)
			{
				int num2 = 0;
				char c = this[i];
				for (num2 = 0; num2 < P_1 && P_0[num2] != c; num2++)
				{
				}
				if (num2 == P_1)
				{
					break;
				}
			}
		}
		if ((P_2 & TrimType.Tail) != 0)
		{
			for (num = Length - 1; num >= i; num--)
			{
				int num3 = 0;
				char c2 = this[num];
				for (num3 = 0; num3 < P_1 && P_0[num3] != c2; num3++)
				{
				}
				if (num3 == P_1)
				{
					break;
				}
			}
		}
		return CreateTrimmedString(i, num);
	}

	private string CreateTrimmedString(int P_0, int P_1)
	{
		int num = P_1 - P_0 + 1;
		if (num != Length)
		{
			if (num != 0)
			{
				return InternalSubString(P_0, num);
			}
			return Empty;
		}
		return this;
	}

	public bool Contains(string P_0)
	{
		if ((object)P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.value);
		}
		return SpanHelpers.IndexOf(ref _firstChar, Length, ref P_0._firstChar, P_0.Length) >= 0;
	}

	public bool Contains(string P_0, StringComparison P_1)
	{
		return IndexOf(P_0, P_1) >= 0;
	}

	public bool Contains(char P_0)
	{
		return SpanHelpers.ContainsValueType(ref Unsafe.As<char, short>(ref _firstChar), (short)P_0, Length);
	}

	public bool Contains(char P_0, StringComparison P_1)
	{
		return IndexOf(P_0, P_1) != -1;
	}

	public int IndexOf(char P_0)
	{
		return SpanHelpers.IndexOfChar(ref _firstChar, P_0, Length);
	}

	public int IndexOf(char P_0, int P_1)
	{
		return IndexOf(P_0, P_1, Length - P_1);
	}

	public int IndexOf(char P_0, StringComparison P_1)
	{
		switch (P_1)
		{
		case StringComparison.CurrentCulture:
		case StringComparison.CurrentCultureIgnoreCase:
			return CultureInfo.CurrentCulture.CompareInfo.IndexOf(this, P_0, GetCaseCompareOfComparisonCulture(P_1));
		case StringComparison.InvariantCulture:
		case StringComparison.InvariantCultureIgnoreCase:
			return CompareInfo.Invariant.IndexOf(this, P_0, GetCaseCompareOfComparisonCulture(P_1));
		case StringComparison.Ordinal:
			return IndexOf(P_0);
		case StringComparison.OrdinalIgnoreCase:
			return IndexOfCharOrdinalIgnoreCase(P_0);
		default:
			throw new ArgumentException("NotSupported_StringComparison", "comparisonType");
		}
	}

	private int IndexOfCharOrdinalIgnoreCase(char P_0)
	{
		if (!char.IsAscii(P_0))
		{
			return CompareInfo.Invariant.IndexOf(this, P_0, CompareOptions.OrdinalIgnoreCase);
		}
		if (char.IsAsciiLetter(P_0))
		{
			char c = (char)(P_0 | 0x20);
			char c2 = (char)(P_0 & -33);
			return SpanHelpers.IndexOfAnyChar(ref _firstChar, c2, c, Length);
		}
		return SpanHelpers.IndexOfChar(ref _firstChar, P_0, Length);
	}

	public int IndexOf(char P_0, int P_1, int P_2)
	{
		if ((uint)P_1 > (uint)Length)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.startIndex, ExceptionResource.ArgumentOutOfRange_IndexMustBeLessOrEqual);
		}
		if ((uint)P_2 > (uint)(Length - P_1))
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_Count);
		}
		int num = SpanHelpers.IndexOfChar(ref Unsafe.Add(ref _firstChar, P_1), P_0, P_2);
		if (num >= 0)
		{
			return num + P_1;
		}
		return num;
	}

	public int IndexOfAny(char[] P_0)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.anyOf);
		}
		return new ReadOnlySpan<char>(ref _firstChar, Length).IndexOfAny(P_0);
	}

	public int IndexOf(string P_0)
	{
		return IndexOf(P_0, StringComparison.CurrentCulture);
	}

	public int IndexOf(string P_0, int P_1)
	{
		return IndexOf(P_0, P_1, StringComparison.CurrentCulture);
	}

	public int IndexOf(string P_0, int P_1, int P_2)
	{
		return IndexOf(P_0, P_1, P_2, StringComparison.CurrentCulture);
	}

	public int IndexOf(string P_0, StringComparison P_1)
	{
		return IndexOf(P_0, 0, Length, P_1);
	}

	public int IndexOf(string P_0, int P_1, StringComparison P_2)
	{
		return IndexOf(P_0, P_1, Length - P_1, P_2);
	}

	public int IndexOf(string P_0, int P_1, int P_2, StringComparison P_3)
	{
		switch (P_3)
		{
		case StringComparison.CurrentCulture:
		case StringComparison.CurrentCultureIgnoreCase:
			return CultureInfo.CurrentCulture.CompareInfo.IndexOf(this, P_0, P_1, P_2, GetCaseCompareOfComparisonCulture(P_3));
		case StringComparison.InvariantCulture:
		case StringComparison.InvariantCultureIgnoreCase:
			return CompareInfo.Invariant.IndexOf(this, P_0, P_1, P_2, GetCaseCompareOfComparisonCulture(P_3));
		case StringComparison.Ordinal:
		case StringComparison.OrdinalIgnoreCase:
			return Ordinal.IndexOf(this, P_0, P_1, P_2, P_3 == StringComparison.OrdinalIgnoreCase);
		default:
			throw ((object)P_0 == null) ? new ArgumentNullException("value") : new ArgumentException("NotSupported_StringComparison", "comparisonType");
		}
	}

	public int LastIndexOf(char P_0)
	{
		return SpanHelpers.LastIndexOfValueType(ref Unsafe.As<char, short>(ref _firstChar), (short)P_0, Length);
	}

	public int LastIndexOfAny(char[] P_0)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.anyOf);
		}
		return new ReadOnlySpan<char>(ref _firstChar, Length).LastIndexOfAny(P_0);
	}

	public int LastIndexOf(string P_0)
	{
		return LastIndexOf(P_0, Length - 1, Length, StringComparison.CurrentCulture);
	}

	public int LastIndexOf(string P_0, StringComparison P_1)
	{
		return LastIndexOf(P_0, Length - 1, Length, P_1);
	}

	public int LastIndexOf(string P_0, int P_1, int P_2, StringComparison P_3)
	{
		switch (P_3)
		{
		case StringComparison.CurrentCulture:
		case StringComparison.CurrentCultureIgnoreCase:
			return CultureInfo.CurrentCulture.CompareInfo.LastIndexOf(this, P_0, P_1, P_2, GetCaseCompareOfComparisonCulture(P_3));
		case StringComparison.InvariantCulture:
		case StringComparison.InvariantCultureIgnoreCase:
			return CompareInfo.Invariant.LastIndexOf(this, P_0, P_1, P_2, GetCaseCompareOfComparisonCulture(P_3));
		case StringComparison.Ordinal:
		case StringComparison.OrdinalIgnoreCase:
			return CompareInfo.Invariant.LastIndexOf(this, P_0, P_1, P_2, GetCompareOptionsFromOrdinalStringComparison(P_3));
		default:
			throw ((object)P_0 == null) ? new ArgumentNullException("value") : new ArgumentException("NotSupported_StringComparison", "comparisonType");
		}
	}
}
