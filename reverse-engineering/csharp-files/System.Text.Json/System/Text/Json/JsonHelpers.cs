using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.Encodings.Web;

namespace System.Text.Json;

internal static class JsonHelpers
{
	[StructLayout((LayoutKind)3)]
	private struct DateTimeParseData
	{
		public int Year;

		public int Month;

		public int Day;

		public bool IsCalendarDateOnly;

		public int Hour;

		public int Minute;

		public int Second;

		public int Fraction;

		public int OffsetHours;

		public int OffsetMinutes;

		public byte OffsetToken;

		public bool OffsetNegative => OffsetToken == 45;
	}

	private static readonly int[] s_daysToMonth365 = new int[13]
	{
		0, 31, 59, 90, 120, 151, 181, 212, 243, 273,
		304, 334, 365
	};

	private static readonly int[] s_daysToMonth366 = new int[13]
	{
		0, 31, 60, 91, 121, 152, 182, 213, 244, 274,
		305, 335, 366
	};

	public static bool TryAdd<TKey, TValue>(this Dictionary<TKey, TValue> P_0, in TKey P_1, in TValue P_2)
	{
		return P_0.TryAdd(P_1, P_2);
	}

	internal static void StableSortByKey<T, TKey>(this List<T> P_0, Func<T, TKey> P_1) where TKey : unmanaged, IComparable<TKey>
	{
		Span<T> span = CollectionsMarshal.AsSpan(P_0);
		Span<(TKey, int)> span2 = ((span.Length > 32) ? ((Span<(TKey, int)>)new(TKey, int)[span.Length]) : stackalloc(TKey, int)[32].Slice(0, span.Length));
		Span<(TKey, int)> span3 = span2;
		for (int i = 0; i < span3.Length; i++)
		{
			span3[i] = (P_1(span[i]), i);
		}
		span3.Sort(span);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ReadOnlySpan<byte> GetSpan(this scoped ref Utf8JsonReader P_0)
	{
		if (!P_0.HasValueSequence)
		{
			return P_0.ValueSpan;
		}
		return P_0.ValueSequence.ToArray<byte>();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsInRangeInclusive(uint P_0, uint P_1, uint P_2)
	{
		return P_0 - P_1 <= P_2 - P_1;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsInRangeInclusive(int P_0, int P_1, int P_2)
	{
		return (uint)(P_0 - P_1) <= (uint)(P_2 - P_1);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsInRangeInclusive(long P_0, long P_1, long P_2)
	{
		return (ulong)(P_0 - P_1) <= (ulong)(P_2 - P_1);
	}

	public static bool IsDigit(byte P_0)
	{
		return (uint)(P_0 - 48) <= 9u;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void ReadWithVerify(this ref Utf8JsonReader P_0)
	{
		bool flag = P_0.Read();
	}

	public static string Utf8GetString(ReadOnlySpan<byte> P_0)
	{
		return Encoding.UTF8.GetString(P_0);
	}

	public static Dictionary<TKey, TValue> CreateDictionaryFromCollection<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> P_0, IEqualityComparer<TKey> P_1)
	{
		return new Dictionary<TKey, TValue>(P_0, P_1);
	}

	public static bool IsFinite(double P_0)
	{
		return double.IsFinite(P_0);
	}

	public static bool IsFinite(float P_0)
	{
		return float.IsFinite(P_0);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void ValidateInt32MaxArrayLength(uint P_0)
	{
		if (P_0 > 2146435071)
		{
			ThrowHelper.ThrowOutOfMemoryException(P_0);
		}
	}

	public static bool AllBitsEqual(this BitArray P_0, bool P_1)
	{
		for (int i = 0; i < P_0.Count; i++)
		{
			if (P_0[i] != P_1)
			{
				return false;
			}
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsValidDateTimeOffsetParseLength(int P_0)
	{
		return IsInRangeInclusive(P_0, 10, 252);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsValidUnescapedDateTimeOffsetParseLength(int P_0)
	{
		return IsInRangeInclusive(P_0, 10, 42);
	}

	public static bool TryParseAsISO(ReadOnlySpan<byte> P_0, out DateTime P_1)
	{
		if (!TryParseDateTimeOffset(P_0, out var dateTimeParseData))
		{
			P_1 = default(DateTime);
			return false;
		}
		if (dateTimeParseData.OffsetToken == 90)
		{
			return TryCreateDateTime(dateTimeParseData, DateTimeKind.Utc, out P_1);
		}
		if (dateTimeParseData.OffsetToken == 43 || dateTimeParseData.OffsetToken == 45)
		{
			if (!TryCreateDateTimeOffset(ref dateTimeParseData, out var dateTimeOffset))
			{
				P_1 = default(DateTime);
				return false;
			}
			P_1 = dateTimeOffset.LocalDateTime;
			return true;
		}
		return TryCreateDateTime(dateTimeParseData, DateTimeKind.Unspecified, out P_1);
	}

	public static bool TryParseAsISO(ReadOnlySpan<byte> P_0, out DateTimeOffset P_1)
	{
		if (!TryParseDateTimeOffset(P_0, out var dateTimeParseData))
		{
			P_1 = default(DateTimeOffset);
			return false;
		}
		if (dateTimeParseData.OffsetToken == 90 || dateTimeParseData.OffsetToken == 43 || dateTimeParseData.OffsetToken == 45)
		{
			return TryCreateDateTimeOffset(ref dateTimeParseData, out P_1);
		}
		return TryCreateDateTimeOffsetInterpretingDataAsLocalTime(dateTimeParseData, out P_1);
	}

	public static bool TryParseAsIso(ReadOnlySpan<byte> P_0, out DateOnly P_1)
	{
		if (TryParseDateTimeOffset(P_0, out var dateTimeParseData) && dateTimeParseData.IsCalendarDateOnly && TryCreateDateTime(dateTimeParseData, DateTimeKind.Unspecified, out var dateTime))
		{
			P_1 = DateOnly.FromDateTime(dateTime);
			return true;
		}
		P_1 = default(DateOnly);
		return false;
	}

	private static bool TryParseDateTimeOffset(ReadOnlySpan<byte> P_0, out DateTimeParseData P_1)
	{
		P_1 = default(DateTimeParseData);
		uint num = (uint)(P_0[0] - 48);
		uint num2 = (uint)(P_0[1] - 48);
		uint num3 = (uint)(P_0[2] - 48);
		uint num4 = (uint)(P_0[3] - 48);
		if (num > 9 || num2 > 9 || num3 > 9 || num4 > 9)
		{
			return false;
		}
		P_1.Year = (int)(num * 1000 + num2 * 100 + num3 * 10 + num4);
		if (P_0[4] != 45 || !TryGetNextTwoDigits(P_0.Slice(5, 2), ref P_1.Month) || P_0[7] != 45 || !TryGetNextTwoDigits(P_0.Slice(8, 2), ref P_1.Day))
		{
			return false;
		}
		if (P_0.Length == 10)
		{
			P_1.IsCalendarDateOnly = true;
			return true;
		}
		if (P_0.Length < 16)
		{
			return false;
		}
		if (P_0[10] != 84 || P_0[13] != 58 || !TryGetNextTwoDigits(P_0.Slice(11, 2), ref P_1.Hour) || !TryGetNextTwoDigits(P_0.Slice(14, 2), ref P_1.Minute))
		{
			return false;
		}
		if (P_0.Length == 16)
		{
			return true;
		}
		byte b = P_0[16];
		int num5 = 17;
		switch (b)
		{
		case 90:
			P_1.OffsetToken = 90;
			return num5 == P_0.Length;
		case 43:
		case 45:
			P_1.OffsetToken = b;
			return ParseOffset(ref P_1, P_0.Slice(num5));
		default:
			return false;
		case 58:
			if (P_0.Length < 19 || !TryGetNextTwoDigits(P_0.Slice(17, 2), ref P_1.Second))
			{
				return false;
			}
			if (P_0.Length == 19)
			{
				return true;
			}
			b = P_0[19];
			num5 = 20;
			switch (b)
			{
			case 90:
				P_1.OffsetToken = 90;
				return num5 == P_0.Length;
			case 43:
			case 45:
				P_1.OffsetToken = b;
				return ParseOffset(ref P_1, P_0.Slice(num5));
			default:
				return false;
			case 46:
			{
				if (P_0.Length < 21)
				{
					return false;
				}
				int i = 0;
				for (int num6 = Math.Min(num5 + 16, P_0.Length); num5 < num6; num5++)
				{
					if (!IsDigit(b = P_0[num5]))
					{
						break;
					}
					if (i < 7)
					{
						P_1.Fraction = P_1.Fraction * 10 + (b - 48);
						i++;
					}
				}
				if (P_1.Fraction != 0)
				{
					for (; i < 7; i++)
					{
						P_1.Fraction *= 10;
					}
				}
				if (num5 == P_0.Length)
				{
					return true;
				}
				b = P_0[num5++];
				switch (b)
				{
				case 90:
					P_1.OffsetToken = 90;
					return num5 == P_0.Length;
				case 43:
				case 45:
					P_1.OffsetToken = b;
					return ParseOffset(ref P_1, P_0.Slice(num5));
				default:
					return false;
				}
			}
			}
		}
		static bool ParseOffset(ref DateTimeParseData reference, ReadOnlySpan<byte> readOnlySpan)
		{
			if (readOnlySpan.Length < 2 || !TryGetNextTwoDigits(readOnlySpan.Slice(0, 2), ref reference.OffsetHours))
			{
				return false;
			}
			if (readOnlySpan.Length == 2)
			{
				return true;
			}
			if (readOnlySpan.Length != 5 || readOnlySpan[2] != 58 || !TryGetNextTwoDigits(readOnlySpan.Slice(3), ref reference.OffsetMinutes))
			{
				return false;
			}
			return true;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool TryGetNextTwoDigits(ReadOnlySpan<byte> P_0, ref int P_1)
	{
		uint num = (uint)(P_0[0] - 48);
		uint num2 = (uint)(P_0[1] - 48);
		if (num > 9 || num2 > 9)
		{
			P_1 = 0;
			return false;
		}
		P_1 = (int)(num * 10 + num2);
		return true;
	}

	private static bool TryCreateDateTimeOffset(DateTime P_0, ref DateTimeParseData P_1, out DateTimeOffset P_2)
	{
		if ((uint)P_1.OffsetHours > 14u)
		{
			P_2 = default(DateTimeOffset);
			return false;
		}
		if ((uint)P_1.OffsetMinutes > 59u)
		{
			P_2 = default(DateTimeOffset);
			return false;
		}
		if (P_1.OffsetHours == 14 && P_1.OffsetMinutes != 0)
		{
			P_2 = default(DateTimeOffset);
			return false;
		}
		long num = ((long)P_1.OffsetHours * 3600L + (long)P_1.OffsetMinutes * 60L) * 10000000;
		if (P_1.OffsetNegative)
		{
			num = -num;
		}
		try
		{
			P_2 = new DateTimeOffset(P_0.Ticks, new TimeSpan(num));
		}
		catch (ArgumentOutOfRangeException)
		{
			P_2 = default(DateTimeOffset);
			return false;
		}
		return true;
	}

	private static bool TryCreateDateTimeOffset(ref DateTimeParseData P_0, out DateTimeOffset P_1)
	{
		if (!TryCreateDateTime(P_0, DateTimeKind.Unspecified, out var dateTime))
		{
			P_1 = default(DateTimeOffset);
			return false;
		}
		if (!TryCreateDateTimeOffset(dateTime, ref P_0, out P_1))
		{
			P_1 = default(DateTimeOffset);
			return false;
		}
		return true;
	}

	private static bool TryCreateDateTimeOffsetInterpretingDataAsLocalTime(DateTimeParseData P_0, out DateTimeOffset P_1)
	{
		if (!TryCreateDateTime(P_0, DateTimeKind.Local, out var dateTime))
		{
			P_1 = default(DateTimeOffset);
			return false;
		}
		try
		{
			P_1 = new DateTimeOffset(dateTime);
		}
		catch (ArgumentOutOfRangeException)
		{
			P_1 = default(DateTimeOffset);
			return false;
		}
		return true;
	}

	private static bool TryCreateDateTime(DateTimeParseData P_0, DateTimeKind P_1, out DateTime P_2)
	{
		if (P_0.Year == 0)
		{
			P_2 = default(DateTime);
			return false;
		}
		if ((uint)(P_0.Month - 1) >= 12u)
		{
			P_2 = default(DateTime);
			return false;
		}
		uint num = (uint)(P_0.Day - 1);
		if (num >= 28 && num >= DateTime.DaysInMonth(P_0.Year, P_0.Month))
		{
			P_2 = default(DateTime);
			return false;
		}
		if ((uint)P_0.Hour > 23u)
		{
			P_2 = default(DateTime);
			return false;
		}
		if ((uint)P_0.Minute > 59u)
		{
			P_2 = default(DateTime);
			return false;
		}
		if ((uint)P_0.Second > 59u)
		{
			P_2 = default(DateTime);
			return false;
		}
		int[] array = (DateTime.IsLeapYear(P_0.Year) ? s_daysToMonth366 : s_daysToMonth365);
		int num2 = P_0.Year - 1;
		int num3 = num2 * 365 + num2 / 4 - num2 / 100 + num2 / 400 + array[P_0.Month - 1] + P_0.Day - 1;
		long num4 = num3 * 864000000000L;
		int num5 = P_0.Hour * 3600 + P_0.Minute * 60 + P_0.Second;
		num4 += (long)num5 * 10000000L;
		num4 += P_0.Fraction;
		P_2 = new DateTime(num4, P_1);
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte[] GetEscapedPropertyNameSection(ReadOnlySpan<byte> P_0, JavaScriptEncoder P_1)
	{
		int num = JsonWriterHelper.NeedsEscaping(P_0, P_1);
		if (num != -1)
		{
			return GetEscapedPropertyNameSection(P_0, num, P_1);
		}
		return GetPropertyNameSection(P_0);
	}

	public static byte[] EscapeValue(ReadOnlySpan<byte> P_0, int P_1, JavaScriptEncoder P_2)
	{
		byte[] array = null;
		int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(P_0.Length, P_1);
		Span<byte> span = ((maxEscapedLength > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(maxEscapedLength))) : stackalloc byte[256]);
		Span<byte> span2 = span;
		JsonWriterHelper.EscapeString(P_0, span2, P_1, P_2, out var num);
		byte[] result = span2.Slice(0, num).ToArray();
		if (array != null)
		{
			ArrayPool<byte>.Shared.Return(array);
		}
		return result;
	}

	private static byte[] GetEscapedPropertyNameSection(ReadOnlySpan<byte> P_0, int P_1, JavaScriptEncoder P_2)
	{
		byte[] array = null;
		int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(P_0.Length, P_1);
		Span<byte> span = ((maxEscapedLength > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(maxEscapedLength))) : stackalloc byte[256]);
		Span<byte> span2 = span;
		JsonWriterHelper.EscapeString(P_0, span2, P_1, P_2, out var num);
		byte[] propertyNameSection = GetPropertyNameSection(span2.Slice(0, num));
		if (array != null)
		{
			ArrayPool<byte>.Shared.Return(array);
		}
		return propertyNameSection;
	}

	private static byte[] GetPropertyNameSection(ReadOnlySpan<byte> P_0)
	{
		int length = P_0.Length;
		byte[] array = new byte[length + 3];
		array[0] = 34;
		P_0.CopyTo(array.AsSpan(1, length));
		array[++length] = 34;
		array[++length] = 58;
		return array;
	}
}
