using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System;

public static class Buffer
{
	[StructLayout((LayoutKind)0, Size = 16)]
	private struct Block16
	{
	}

	[StructLayout((LayoutKind)0, Size = 64)]
	private struct Block64
	{
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private unsafe static extern void __Memmove(byte* P_0, byte* P_1, nuint P_2);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void BulkMoveWithWriteBarrier(ref byte P_0, ref byte P_1, nuint P_2, nint P_3);

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal unsafe static void _ZeroMemory(ref byte P_0, nuint P_1)
	{
		fixed (byte* ptr = &P_0)
		{
			__ZeroMemory(ptr, P_1);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private unsafe static extern void __ZeroMemory(void* P_0, nuint P_1);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static void Memmove<T>(ref T P_0, ref T P_1, nuint P_2)
	{
		if (!RuntimeHelpers.IsReferenceOrContainsReferences<T>())
		{
			Memmove(ref Unsafe.As<T, byte>(ref P_0), ref Unsafe.As<T, byte>(ref P_1), P_2 * (nuint)Unsafe.SizeOf<T>());
		}
		else if (P_2 != 0)
		{
			BulkMoveWithWriteBarrier(ref Unsafe.As<T, byte>(ref P_0), ref Unsafe.As<T, byte>(ref P_1), P_2, typeof(T).TypeHandle.Value);
		}
	}

	public static void BlockCopy(Array P_0, int P_1, Array P_2, int P_3, int P_4)
	{
		ArgumentNullException.ThrowIfNull(P_0, "src");
		ArgumentNullException.ThrowIfNull(P_2, "dst");
		nuint num = P_0.NativeLength;
		if (P_0.GetType() != typeof(byte[]))
		{
			if (!P_0.GetCorElementTypeOfElementType().IsPrimitiveType())
			{
				throw new ArgumentException("Arg_MustBePrimArray", "src");
			}
			num *= (nuint)P_0.GetElementSize();
		}
		nuint num2 = num;
		if (P_0 != P_2)
		{
			num2 = P_2.NativeLength;
			if (P_2.GetType() != typeof(byte[]))
			{
				if (!P_2.GetCorElementTypeOfElementType().IsPrimitiveType())
				{
					throw new ArgumentException("Arg_MustBePrimArray", "dst");
				}
				num2 *= (nuint)P_2.GetElementSize();
			}
		}
		if (P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("srcOffset", "ArgumentOutOfRange_MustBeNonNegInt32");
		}
		if (P_3 < 0)
		{
			throw new ArgumentOutOfRangeException("dstOffset", "ArgumentOutOfRange_MustBeNonNegInt32");
		}
		if (P_4 < 0)
		{
			throw new ArgumentOutOfRangeException("count", "ArgumentOutOfRange_MustBeNonNegInt32");
		}
		nuint num3 = (nuint)P_4;
		nuint num4 = (nuint)P_1;
		nuint num5 = (nuint)P_3;
		if (num < num4 + num3 || num2 < num5 + num3)
		{
			throw new ArgumentException("Argument_InvalidOffLen");
		}
		Memmove(ref Unsafe.AddByteOffset(ref MemoryMarshal.GetArrayDataReference(P_2), num5), ref Unsafe.AddByteOffset(ref MemoryMarshal.GetArrayDataReference(P_0), num4), num3);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[CLSCompliant(false)]
	public unsafe static void MemoryCopy(void* P_0, void* P_1, long P_2, long P_3)
	{
		if (P_3 > P_2)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.sourceBytesToCopy);
		}
		Memmove(ref *(byte*)P_1, ref *(byte*)P_0, checked((nuint)P_3));
	}

	internal static void Memmove(ref byte P_0, ref byte P_1, nuint P_2)
	{
		if ((nuint)Unsafe.ByteOffset(ref P_1, ref P_0) >= P_2 && (nuint)Unsafe.ByteOffset(ref P_0, ref P_1) >= P_2)
		{
			ref byte reference = ref Unsafe.Add(ref P_1, (nint)P_2);
			ref byte reference2 = ref Unsafe.Add(ref P_0, (nint)P_2);
			if (P_2 > 16)
			{
				if (P_2 > 64)
				{
					if (P_2 > 2048)
					{
						goto IL_020d;
					}
					nuint num = P_2 >> 6;
					do
					{
						Unsafe.As<byte, Block64>(ref P_0) = Unsafe.As<byte, Block64>(ref P_1);
						P_0 = ref Unsafe.Add(ref P_0, 64);
						P_1 = ref Unsafe.Add(ref P_1, 64);
						num--;
					}
					while (num != 0);
					P_2 %= 64;
					if (P_2 <= 16)
					{
						Unsafe.As<byte, Block16>(ref Unsafe.Add(ref reference2, -16)) = Unsafe.As<byte, Block16>(ref Unsafe.Add(ref reference, -16));
						return;
					}
				}
				Unsafe.As<byte, Block16>(ref P_0) = Unsafe.As<byte, Block16>(ref P_1);
				if (P_2 > 32)
				{
					Unsafe.As<byte, Block16>(ref Unsafe.Add(ref P_0, 16)) = Unsafe.As<byte, Block16>(ref Unsafe.Add(ref P_1, 16));
					if (P_2 > 48)
					{
						Unsafe.As<byte, Block16>(ref Unsafe.Add(ref P_0, 32)) = Unsafe.As<byte, Block16>(ref Unsafe.Add(ref P_1, 32));
					}
				}
				Unsafe.As<byte, Block16>(ref Unsafe.Add(ref reference2, -16)) = Unsafe.As<byte, Block16>(ref Unsafe.Add(ref reference, -16));
			}
			else if ((P_2 & 0x18) != 0)
			{
				Unsafe.As<byte, int>(ref P_0) = Unsafe.As<byte, int>(ref P_1);
				Unsafe.As<byte, int>(ref Unsafe.Add(ref P_0, 4)) = Unsafe.As<byte, int>(ref Unsafe.Add(ref P_1, 4));
				Unsafe.As<byte, int>(ref Unsafe.Add(ref reference2, -8)) = Unsafe.As<byte, int>(ref Unsafe.Add(ref reference, -8));
				Unsafe.As<byte, int>(ref Unsafe.Add(ref reference2, -4)) = Unsafe.As<byte, int>(ref Unsafe.Add(ref reference, -4));
			}
			else if ((P_2 & 4) != 0)
			{
				Unsafe.As<byte, int>(ref P_0) = Unsafe.As<byte, int>(ref P_1);
				Unsafe.As<byte, int>(ref Unsafe.Add(ref reference2, -4)) = Unsafe.As<byte, int>(ref Unsafe.Add(ref reference, -4));
			}
			else if (P_2 != 0)
			{
				P_0 = P_1;
				if ((P_2 & 2) != 0)
				{
					Unsafe.As<byte, short>(ref Unsafe.Add(ref reference2, -2)) = Unsafe.As<byte, short>(ref Unsafe.Add(ref reference, -2));
				}
			}
			return;
		}
		if (Unsafe.AreSame(ref P_0, ref P_1))
		{
			return;
		}
		goto IL_020d;
		IL_020d:
		_Memmove(ref P_0, ref P_1, P_2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe static void _Memmove(ref byte P_0, ref byte P_1, nuint P_2)
	{
		fixed (byte* ptr = &P_0)
		{
			fixed (byte* ptr2 = &P_1)
			{
				__Memmove(ptr, ptr2, P_2);
			}
		}
	}
}
