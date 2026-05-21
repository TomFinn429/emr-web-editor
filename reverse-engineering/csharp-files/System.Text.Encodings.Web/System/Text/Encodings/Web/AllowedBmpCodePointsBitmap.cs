using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Text.Unicode;

namespace System.Text.Encodings.Web;

internal struct AllowedBmpCodePointsBitmap
{
	private unsafe fixed uint Bitmap[2048];

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe void AllowChar(char P_0)
	{
		_GetIndexAndOffset(P_0, out var num, out var num2);
		ref uint reference = ref Bitmap[num];
		reference |= (uint)(1 << num2);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe void ForbidChar(char P_0)
	{
		_GetIndexAndOffset(P_0, out var num, out var num2);
		ref uint reference = ref Bitmap[num];
		reference &= (uint)(~(1 << num2));
	}

	public void ForbidHtmlCharacters()
	{
		ForbidChar('<');
		ForbidChar('>');
		ForbidChar('&');
		ForbidChar('\'');
		ForbidChar('"');
		ForbidChar('+');
	}

	public unsafe void ForbidUndefinedCharacters()
	{
		fixed (uint* bitmap = Bitmap)
		{
			ReadOnlySpan<byte> definedBmpCodePointsBitmapLittleEndian = UnicodeHelpers.GetDefinedBmpCodePointsBitmapLittleEndian();
			Span<uint> span = new Span<uint>(bitmap, 2048);
			if (false)
			{
			}
			for (int i = 0; i < span.Length; i++)
			{
				span[i] &= BinaryPrimitives.ReadUInt32LittleEndian(definedBmpCodePointsBitmapLittleEndian.Slice(i * 4));
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe readonly bool IsCharAllowed(char P_0)
	{
		_GetIndexAndOffset(P_0, out var num, out var num2);
		if ((Bitmap[num] & (uint)(1 << num2)) != 0)
		{
			return true;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe readonly bool IsCodePointAllowed(uint P_0)
	{
		if (!System.Text.UnicodeUtility.IsBmpCodePoint(P_0))
		{
			return false;
		}
		_GetIndexAndOffset(P_0, out var num, out var num2);
		if ((Bitmap[num] & (uint)(1 << num2)) != 0)
		{
			return true;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void _GetIndexAndOffset(uint P_0, out nuint P_1, out int P_2)
	{
		P_1 = P_0 >> 5;
		P_2 = (int)(P_0 & 0x1F);
	}
}
