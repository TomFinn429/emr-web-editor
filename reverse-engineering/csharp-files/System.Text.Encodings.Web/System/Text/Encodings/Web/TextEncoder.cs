using System.Buffers;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.Unicode;

namespace System.Text.Encodings.Web;

public abstract class TextEncoder
{
	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public unsafe abstract bool TryEncodeUnicodeScalar(int P_0, char* P_1, int P_2, out int P_3);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe bool TryEncodeUnicodeScalar(uint P_0, Span<char> P_1, out int P_2)
	{
		fixed (char* reference = &MemoryMarshal.GetReference(P_1))
		{
			return TryEncodeUnicodeScalar((int)P_0, reference, P_1.Length, out P_2);
		}
	}

	private bool TryEncodeUnicodeScalarUtf8(uint P_0, Span<char> P_1, Span<byte> P_2, out int P_3)
	{
		if (!TryEncodeUnicodeScalar(P_0, P_1, out var num))
		{
			ThrowArgumentException_MaxOutputCharsPerInputChar();
		}
		P_1 = P_1.Slice(0, num);
		int num2 = 0;
		while (!P_1.IsEmpty)
		{
			if (Rune.DecodeFromUtf16(P_1, out var rune, out var num3) != OperationStatus.Done)
			{
				ThrowArgumentException_MaxOutputCharsPerInputChar();
			}
			uint num4 = (uint)UnicodeHelpers.GetUtf8RepresentationForScalarValue((uint)rune.Value);
			do
			{
				if (SpanUtility.IsValidIndex(P_2, num2))
				{
					P_2[num2++] = (byte)num4;
					continue;
				}
				P_3 = 0;
				return false;
			}
			while ((num4 >>= 8) != 0);
			P_1 = P_1.Slice(num3);
		}
		P_3 = num2;
		return true;
	}

	[CLSCompliant(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public unsafe abstract int FindFirstCharacterToEncode(char* P_0, int P_1);

	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract bool WillEncode(int P_0);

	public virtual OperationStatus EncodeUtf8(ReadOnlySpan<byte> P_0, Span<byte> P_1, out int P_2, out int P_3, bool P_4 = true)
	{
		ReadOnlySpan<byte> readOnlySpan = P_0;
		if (P_1.Length < P_0.Length)
		{
			readOnlySpan = P_0.Slice(0, P_1.Length);
		}
		int num = FindFirstCharacterToEncodeUtf8(readOnlySpan);
		if (num < 0)
		{
			num = readOnlySpan.Length;
		}
		P_0.Slice(0, num).CopyTo(P_1);
		if (num == P_0.Length)
		{
			P_2 = P_0.Length;
			P_3 = P_0.Length;
			return OperationStatus.Done;
		}
		int num2;
		int num3;
		OperationStatus result = EncodeUtf8Core(P_0.Slice(num), P_1.Slice(num), out num2, out num3, P_4);
		P_2 = num + num2;
		P_3 = num + num3;
		return result;
	}

	private protected virtual OperationStatus EncodeUtf8Core(ReadOnlySpan<byte> P_0, Span<byte> P_1, out int P_2, out int P_3, bool P_4)
	{
		int length = P_0.Length;
		int length2 = P_1.Length;
		Span<char> span = stackalloc char[24];
		OperationStatus result;
		while (true)
		{
			int num;
			int num3;
			if (!P_0.IsEmpty)
			{
				Rune rune;
				OperationStatus operationStatus = Rune.DecodeFromUtf8(P_0, out rune, out num);
				if (operationStatus != OperationStatus.Done)
				{
					if (!P_4 && operationStatus == OperationStatus.NeedMoreData)
					{
						result = OperationStatus.NeedMoreData;
						break;
					}
				}
				else if (!WillEncode(rune.Value))
				{
					uint num2 = (uint)UnicodeHelpers.GetUtf8RepresentationForScalarValue((uint)rune.Value);
					num3 = 0;
					while ((uint)num3 < (uint)P_1.Length)
					{
						P_1[num3++] = (byte)num2;
						if ((num2 >>= 8) != 0)
						{
							continue;
						}
						goto IL_008d;
					}
					goto IL_00f9;
				}
				if (TryEncodeUnicodeScalarUtf8((uint)rune.Value, span, P_1, out var num4))
				{
					P_0 = P_0.Slice(num);
					P_1 = P_1.Slice(num4);
					continue;
				}
				goto IL_00f9;
			}
			result = OperationStatus.Done;
			break;
			IL_008d:
			P_0 = P_0.Slice(num);
			P_1 = P_1.Slice(num3);
			continue;
			IL_00f9:
			result = OperationStatus.DestinationTooSmall;
			break;
		}
		P_2 = length - P_0.Length;
		P_3 = length2 - P_1.Length;
		return result;
	}

	public virtual OperationStatus Encode(ReadOnlySpan<char> P_0, Span<char> P_1, out int P_2, out int P_3, bool P_4 = true)
	{
		ReadOnlySpan<char> readOnlySpan = P_0;
		if (P_1.Length < P_0.Length)
		{
			readOnlySpan = P_0.Slice(0, P_1.Length);
		}
		int num = FindFirstCharacterToEncode(readOnlySpan);
		if (num < 0)
		{
			num = readOnlySpan.Length;
		}
		P_0.Slice(0, num).CopyTo(P_1);
		if (num == P_0.Length)
		{
			P_2 = P_0.Length;
			P_3 = P_0.Length;
			return OperationStatus.Done;
		}
		int num2;
		int num3;
		OperationStatus result = EncodeCore(P_0.Slice(num), P_1.Slice(num), out num2, out num3, P_4);
		P_2 = num + num2;
		P_3 = num + num3;
		return result;
	}

	private protected virtual OperationStatus EncodeCore(ReadOnlySpan<char> P_0, Span<char> P_1, out int P_2, out int P_3, bool P_4)
	{
		int length = P_0.Length;
		int length2 = P_1.Length;
		OperationStatus result;
		while (true)
		{
			if (!P_0.IsEmpty)
			{
				Rune rune;
				int num;
				OperationStatus operationStatus = Rune.DecodeFromUtf16(P_0, out rune, out num);
				if (operationStatus != OperationStatus.Done)
				{
					if (!P_4 && operationStatus == OperationStatus.NeedMoreData)
					{
						result = OperationStatus.NeedMoreData;
						break;
					}
				}
				else if (!WillEncode(rune.Value))
				{
					if (rune.TryEncodeToUtf16(P_1, out var _))
					{
						P_0 = P_0.Slice(num);
						P_1 = P_1.Slice(num);
						continue;
					}
					goto IL_00ad;
				}
				if (TryEncodeUnicodeScalar((uint)rune.Value, P_1, out var num3))
				{
					P_0 = P_0.Slice(num);
					P_1 = P_1.Slice(num3);
					continue;
				}
				goto IL_00ad;
			}
			result = OperationStatus.Done;
			break;
			IL_00ad:
			result = OperationStatus.DestinationTooSmall;
			break;
		}
		P_2 = length - P_0.Length;
		P_3 = length2 - P_1.Length;
		return result;
	}

	private protected unsafe virtual int FindFirstCharacterToEncode(ReadOnlySpan<char> P_0)
	{
		fixed (char* reference = &MemoryMarshal.GetReference(P_0))
		{
			return FindFirstCharacterToEncode(reference, P_0.Length);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual int FindFirstCharacterToEncodeUtf8(ReadOnlySpan<byte> P_0)
	{
		int length = P_0.Length;
		Rune rune;
		int num;
		while (!P_0.IsEmpty && Rune.DecodeFromUtf8(P_0, out rune, out num) == OperationStatus.Done && !WillEncode(rune.Value))
		{
			P_0 = P_0.Slice(num);
		}
		if (!P_0.IsEmpty)
		{
			return length - P_0.Length;
		}
		return -1;
	}

	[DoesNotReturn]
	private static void ThrowArgumentException_MaxOutputCharsPerInputChar()
	{
		throw new ArgumentException("TextEncoderDoesNotImplementMaxOutputCharsPerInputChar");
	}
}
