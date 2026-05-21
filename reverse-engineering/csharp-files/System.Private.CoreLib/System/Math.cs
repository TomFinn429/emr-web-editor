using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

namespace System;

public static class Math
{
	private static readonly double[] roundPower10Double = new double[16]
	{
		1.0, 10.0, 100.0, 1000.0, 10000.0, 100000.0, 1000000.0, 10000000.0, 100000000.0, 1000000000.0,
		10000000000.0, 100000000000.0, 1000000000000.0, 10000000000000.0, 100000000000000.0, 1000000000000000.0
	};

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern double Atan(double P_0);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern double Atan2(double P_0, double P_1);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern double Ceiling(double P_0);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern double Cos(double P_0);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern double Floor(double P_0);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern double Log(double P_0);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern double Log10(double P_0);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern double Pow(double P_0, double P_1);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern double Sin(double P_0);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern double Sqrt(double P_0);

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern double Tan(double P_0);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private unsafe static extern double ModF(double P_0, double* P_1);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Abs(int P_0)
	{
		if (P_0 < 0)
		{
			P_0 = -P_0;
			if (P_0 < 0)
			{
				ThrowNegateTwosCompOverflow();
			}
		}
		return P_0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static long Abs(long P_0)
	{
		if (P_0 < 0)
		{
			P_0 = -P_0;
			if (P_0 < 0)
			{
				ThrowNegateTwosCompOverflow();
			}
		}
		return P_0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	public static double Abs(double P_0)
	{
		ulong num = BitConverter.DoubleToUInt64Bits(P_0);
		return BitConverter.UInt64BitsToDouble(num & 0x7FFFFFFFFFFFFFFFL);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	public static float Abs(float P_0)
	{
		uint num = BitConverter.SingleToUInt32Bits(P_0);
		return BitConverter.UInt32BitsToSingle(num & 0x7FFFFFFF);
	}

	[DoesNotReturn]
	[StackTraceHidden]
	internal static void ThrowNegateTwosCompOverflow()
	{
		throw new OverflowException("Overflow_NegateTwosCompNum");
	}

	public static long BigMul(int P_0, int P_1)
	{
		return (long)P_0 * (long)P_1;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[CLSCompliant(false)]
	public static ulong BigMul(ulong P_0, ulong P_1, out ulong P_2)
	{
		if (false)
		{
		}
		if (false)
		{
		}
		return SoftwareFallback(P_0, P_1, out P_2);
		static ulong SoftwareFallback(ulong num2, ulong num5, out ulong reference)
		{
			uint num = (uint)num2;
			uint num3 = (uint)(num2 >> 32);
			uint num4 = (uint)num5;
			uint num6 = (uint)(num5 >> 32);
			ulong num7 = (ulong)num * (ulong)num4;
			ulong num8 = (ulong)((long)num3 * (long)num4) + (num7 >> 32);
			ulong num9 = (ulong)((long)num * (long)num6 + (uint)num8);
			reference = (num9 << 32) | (uint)num7;
			return (ulong)((long)num3 * (long)num6 + (long)(num8 >> 32)) + (num9 >> 32);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static double CopySign(double P_0, double P_1)
	{
		_ = 0;
		if (false)
		{
		}
		return SoftwareFallback(P_0, P_1);
		static double SoftwareFallback(double num2, double num4)
		{
			long num = BitConverter.DoubleToInt64Bits(num2);
			long num3 = BitConverter.DoubleToInt64Bits(num4);
			num &= 0x7FFFFFFFFFFFFFFFL;
			num3 &= -9223372036854775808L;
			return BitConverter.Int64BitsToDouble(num | num3);
		}
	}

	public static int DivRem(int P_0, int P_1, out int P_2)
	{
		int num = P_0 / P_1;
		P_2 = P_0 - num * P_1;
		return num;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[NonVersionable]
	[CLSCompliant(false)]
	public static (uint Quotient, uint Remainder) DivRem(uint P_0, uint P_1)
	{
		uint num = P_0 / P_1;
		return (Quotient: num, Remainder: P_0 - num * P_1);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[NonVersionable]
	[CLSCompliant(false)]
	public static (ulong Quotient, ulong Remainder) DivRem(ulong P_0, ulong P_1)
	{
		ulong num = P_0 / P_1;
		return (Quotient: num, Remainder: P_0 - num * P_1);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Clamp(int P_0, int P_1, int P_2)
	{
		if (P_1 > P_2)
		{
			ThrowMinMaxException(P_1, P_2);
		}
		if (P_0 < P_1)
		{
			return P_1;
		}
		if (P_0 > P_2)
		{
			return P_2;
		}
		return P_0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[CLSCompliant(false)]
	public static uint Clamp(uint P_0, uint P_1, uint P_2)
	{
		if (P_1 > P_2)
		{
			ThrowMinMaxException(P_1, P_2);
		}
		if (P_0 < P_1)
		{
			return P_1;
		}
		if (P_0 > P_2)
		{
			return P_2;
		}
		return P_0;
	}

	public static double IEEERemainder(double P_0, double P_1)
	{
		if (double.IsNaN(P_0))
		{
			return P_0;
		}
		if (double.IsNaN(P_1))
		{
			return P_1;
		}
		double num = P_0 % P_1;
		if (double.IsNaN(num))
		{
			return 0.0 / 0.0;
		}
		if (num == 0.0 && double.IsNegative(P_0))
		{
			return -0.0;
		}
		double num2 = num - Abs(P_1) * (double)Sign(P_0);
		if (Abs(num2) == Abs(num))
		{
			double num3 = P_0 / P_1;
			double num4 = Round(num3);
			if (Abs(num4) > Abs(num3))
			{
				return num2;
			}
			return num;
		}
		if (Abs(num2) < Abs(num))
		{
			return num2;
		}
		return num;
	}

	public static double Log(double P_0, double P_1)
	{
		if (double.IsNaN(P_0))
		{
			return P_0;
		}
		if (double.IsNaN(P_1))
		{
			return P_1;
		}
		if (P_1 == 1.0)
		{
			return 0.0 / 0.0;
		}
		if (P_0 != 1.0 && (P_1 == 0.0 || double.IsPositiveInfinity(P_1)))
		{
			return 0.0 / 0.0;
		}
		return Log(P_0) / Log(P_1);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	public static double Max(double P_0, double P_1)
	{
		if (P_0 != P_1)
		{
			if (!double.IsNaN(P_0))
			{
				if (!(P_1 < P_0))
				{
					return P_1;
				}
				return P_0;
			}
			return P_0;
		}
		if (!double.IsNegative(P_1))
		{
			return P_1;
		}
		return P_0;
	}

	[NonVersionable]
	public static int Max(int P_0, int P_1)
	{
		if (P_0 < P_1)
		{
			return P_1;
		}
		return P_0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	public static float Max(float P_0, float P_1)
	{
		if (P_0 != P_1)
		{
			if (!float.IsNaN(P_0))
			{
				if (!(P_1 < P_0))
				{
					return P_1;
				}
				return P_0;
			}
			return P_0;
		}
		if (!float.IsNegative(P_1))
		{
			return P_1;
		}
		return P_0;
	}

	[CLSCompliant(false)]
	[NonVersionable]
	public static uint Max(uint P_0, uint P_1)
	{
		if (P_0 < P_1)
		{
			return P_1;
		}
		return P_0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	public static double Min(double P_0, double P_1)
	{
		if (P_0 != P_1)
		{
			if (!double.IsNaN(P_0))
			{
				if (!(P_0 < P_1))
				{
					return P_1;
				}
				return P_0;
			}
			return P_0;
		}
		if (!double.IsNegative(P_0))
		{
			return P_1;
		}
		return P_0;
	}

	[NonVersionable]
	public static int Min(int P_0, int P_1)
	{
		if (P_0 > P_1)
		{
			return P_1;
		}
		return P_0;
	}

	[NonVersionable]
	public static long Min(long P_0, long P_1)
	{
		if (P_0 > P_1)
		{
			return P_1;
		}
		return P_0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Intrinsic]
	public static float Min(float P_0, float P_1)
	{
		if (P_0 != P_1)
		{
			if (!float.IsNaN(P_0))
			{
				if (!(P_0 < P_1))
				{
					return P_1;
				}
				return P_0;
			}
			return P_0;
		}
		if (!float.IsNegative(P_0))
		{
			return P_1;
		}
		return P_0;
	}

	[CLSCompliant(false)]
	[NonVersionable]
	public static uint Min(uint P_0, uint P_1)
	{
		if (P_0 > P_1)
		{
			return P_1;
		}
		return P_0;
	}

	[CLSCompliant(false)]
	[NonVersionable]
	public static nuint Min(nuint P_0, nuint P_1)
	{
		if (P_0 > P_1)
		{
			return P_1;
		}
		return P_0;
	}

	[Intrinsic]
	public static double Round(double P_0)
	{
		ulong num = BitConverter.DoubleToUInt64Bits(P_0);
		ushort num2 = double.ExtractBiasedExponentFromBits(num);
		if (num2 <= 1022)
		{
			if (num << 1 == 0L)
			{
				return P_0;
			}
			double num3 = ((num2 == 1022 && double.ExtractTrailingSignificandFromBits(num) != 0L) ? 1.0 : 0.0);
			return CopySign(num3, P_0);
		}
		if (num2 >= 1075)
		{
			return P_0;
		}
		ulong num4 = (ulong)(1L << 1075 - num2);
		ulong num5 = num4 - 1;
		num += num4 >> 1;
		num = (((num & num5) != 0L) ? (num & ~num5) : (num & ~num4));
		return BitConverter.UInt64BitsToDouble(num);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static double Round(double P_0, int P_1)
	{
		return Round(P_0, P_1, MidpointRounding.ToEven);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static double Round(double P_0, MidpointRounding P_1)
	{
		if (RuntimeHelpers.IsKnownConstant((int)P_1))
		{
			if (P_1 == MidpointRounding.ToEven)
			{
				return Round(P_0);
			}
			if (0 == 0)
			{
			}
		}
		return Round(P_0, 0, P_1);
	}

	public unsafe static double Round(double P_0, int P_1, MidpointRounding P_2)
	{
		if (P_1 < 0 || P_1 > 15)
		{
			throw new ArgumentOutOfRangeException("digits", "ArgumentOutOfRange_RoundingDigits");
		}
		if (P_2 < MidpointRounding.ToEven || P_2 > MidpointRounding.ToPositiveInfinity)
		{
			throw new ArgumentException(SR.Format("Argument_InvalidEnumValue", P_2, "MidpointRounding"), "mode");
		}
		if (Abs(P_0) < 10000000000000000.0)
		{
			double num = roundPower10Double[P_1];
			P_0 *= num;
			switch (P_2)
			{
			case MidpointRounding.ToEven:
				P_0 = Round(P_0);
				break;
			case MidpointRounding.AwayFromZero:
			{
				double num2 = ModF(P_0, &P_0);
				if (Abs(num2) >= 0.5)
				{
					P_0 += (double)Sign(num2);
				}
				break;
			}
			case MidpointRounding.ToZero:
				P_0 = Truncate(P_0);
				break;
			case MidpointRounding.ToNegativeInfinity:
				P_0 = Floor(P_0);
				break;
			case MidpointRounding.ToPositiveInfinity:
				P_0 = Ceiling(P_0);
				break;
			default:
				throw new ArgumentException(SR.Format("Argument_InvalidEnumValue", P_2, "MidpointRounding"), "mode");
			}
			P_0 /= num;
		}
		return P_0;
	}

	public static int Sign(double P_0)
	{
		if (P_0 < 0.0)
		{
			return -1;
		}
		if (P_0 > 0.0)
		{
			return 1;
		}
		if (P_0 == 0.0)
		{
			return 0;
		}
		throw new ArithmeticException("Arithmetic_NaN");
	}

	[Intrinsic]
	public unsafe static double Truncate(double P_0)
	{
		ModF(P_0, &P_0);
		return P_0;
	}

	[DoesNotReturn]
	internal static void ThrowMinMaxException<T>(T P_0, T P_1)
	{
		throw new ArgumentException(SR.Format("Argument_MinMaxValue", P_0, P_1));
	}
}
