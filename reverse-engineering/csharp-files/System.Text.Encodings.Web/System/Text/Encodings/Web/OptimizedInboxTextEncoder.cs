using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Text.Encodings.Web;

internal sealed class OptimizedInboxTextEncoder
{
	[StructLayout((LayoutKind)2)]
	private struct AllowedAsciiCodePoints
	{
		[FieldOffset(0)]
		private unsafe fixed byte AsBytes[16];

		internal unsafe void PopulateAllowedCodePoints(in AllowedBmpCodePointsBitmap P_0)
		{
			this = default(AllowedAsciiCodePoints);
			for (int i = 32; i < 127; i++)
			{
				if (P_0.IsCharAllowed((char)i))
				{
					ref byte reference = ref AsBytes[i & 0xF];
					reference |= (byte)(1 << (i >> 4));
				}
			}
		}
	}

	private struct AsciiPreescapedData
	{
		private unsafe fixed ulong Data[128];

		internal unsafe void PopulatePreescapedData(in AllowedBmpCodePointsBitmap P_0, ScalarEscaperBase P_1)
		{
			this = default(AsciiPreescapedData);
			byte* intPtr = stackalloc byte[16];
			// IL initblk instruction
			Unsafe.InitBlock(intPtr, 0, 16);
			Span<char> span = new Span<char>(intPtr, 8);
			Span<char> span2 = span;
			for (int i = 0; i < 128; i++)
			{
				Rune rune = new Rune(i);
				ulong num;
				int num2;
				if (!Rune.IsControl(rune) && P_0.IsCharAllowed((char)i))
				{
					num = (uint)i;
					num2 = 1;
				}
				else
				{
					num2 = P_1.EncodeUtf16(rune, span2.Slice(0, 6));
					num = 0uL;
					span2.Slice(num2).Clear();
					for (int num3 = num2 - 1; num3 >= 0; num3--)
					{
						uint num4 = span2[num3];
						num = (num << 8) | num4;
					}
				}
				Data[i] = num | ((ulong)(uint)num2 << 56);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal unsafe readonly bool TryGetPreescapedData(uint P_0, out ulong P_1)
		{
			if (P_0 <= 127)
			{
				P_1 = Data[P_0];
				return true;
			}
			P_1 = 0uL;
			return false;
		}
	}

	private readonly AllowedAsciiCodePoints _allowedAsciiCodePoints;

	private readonly AsciiPreescapedData _asciiPreescapedData;

	private readonly AllowedBmpCodePointsBitmap _allowedBmpCodePoints;

	private readonly ScalarEscaperBase _scalarEscaper;

	internal OptimizedInboxTextEncoder(ScalarEscaperBase P_0, in AllowedBmpCodePointsBitmap P_1, bool P_2 = true, ReadOnlySpan<char> P_3 = default(ReadOnlySpan<char>))
	{
		_scalarEscaper = P_0;
		_allowedBmpCodePoints = P_1;
		_allowedBmpCodePoints.ForbidUndefinedCharacters();
		if (P_2)
		{
			_allowedBmpCodePoints.ForbidHtmlCharacters();
		}
		ReadOnlySpan<char> readOnlySpan = P_3;
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			char c = readOnlySpan[i];
			_allowedBmpCodePoints.ForbidChar(c);
		}
		_asciiPreescapedData.PopulatePreescapedData(in _allowedBmpCodePoints, P_0);
		_allowedAsciiCodePoints.PopulateAllowedCodePoints(in _allowedBmpCodePoints);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Obsolete("FindFirstCharacterToEncode has been deprecated. It should only be used by the TextEncoder adapter.")]
	public unsafe int FindFirstCharacterToEncode(char* P_0, int P_1)
	{
		return GetIndexOfFirstCharToEncode(new ReadOnlySpan<char>(P_0, P_1));
	}

	[Obsolete("TryEncodeUnicodeScalar has been deprecated. It should only be used by the TextEncoder adapter.")]
	public unsafe bool TryEncodeUnicodeScalar(int P_0, char* P_1, int P_2, out int P_3)
	{
		Span<char> span = new Span<char>(P_1, P_2);
		if (_allowedBmpCodePoints.IsCodePointAllowed((uint)P_0))
		{
			if (!span.IsEmpty)
			{
				span[0] = (char)P_0;
				P_3 = 1;
				return true;
			}
		}
		else
		{
			int num = _scalarEscaper.EncodeUtf16(new Rune(P_0), span);
			if (num >= 0)
			{
				P_3 = num;
				return true;
			}
		}
		P_3 = 0;
		return false;
	}

	public OperationStatus Encode(ReadOnlySpan<char> P_0, Span<char> P_1, out int P_2, out int P_3, bool P_4)
	{
		_AssertThisNotNull();
		int num = 0;
		int num2 = 0;
		OperationStatus result;
		while (true)
		{
			int num4;
			Rune replacementChar;
			if (SpanUtility.IsValidIndex(P_0, num))
			{
				char c = P_0[num];
				if (_asciiPreescapedData.TryGetPreescapedData(c, out var num3))
				{
					if (SpanUtility.IsValidIndex(P_1, num2))
					{
						P_1[num2] = (char)(byte)num3;
						if (((int)num3 & 0xFF00) == 0)
						{
							num2++;
							num++;
							continue;
						}
						num3 >>= 8;
						num4 = num2 + 1;
						while (SpanUtility.IsValidIndex(P_1, num4))
						{
							P_1[num4++] = (char)(byte)num3;
							if ((byte)(num3 >>= 8) != 0)
							{
								continue;
							}
							goto IL_0091;
						}
					}
					goto IL_0148;
				}
				if (Rune.TryCreate(c, out replacementChar))
				{
					goto IL_00e1;
				}
				int num5 = num + 1;
				if (SpanUtility.IsValidIndex(P_0, num5))
				{
					if (Rune.TryCreate(c, P_0[num5], out replacementChar))
					{
						goto IL_00e1;
					}
				}
				else if (!P_4 && char.IsHighSurrogate(c))
				{
					result = OperationStatus.NeedMoreData;
					break;
				}
				replacementChar = Rune.ReplacementChar;
				goto IL_010d;
			}
			result = OperationStatus.Done;
			break;
			IL_0148:
			result = OperationStatus.DestinationTooSmall;
			break;
			IL_0091:
			num2 = num4;
			num++;
			continue;
			IL_010d:
			int num6 = _scalarEscaper.EncodeUtf16(replacementChar, P_1.Slice(num2));
			if (num6 >= 0)
			{
				num2 += num6;
				num += replacementChar.Utf16SequenceLength;
				continue;
			}
			goto IL_0148;
			IL_00e1:
			if (!IsScalarValueAllowed(replacementChar))
			{
				goto IL_010d;
			}
			if (replacementChar.TryEncodeToUtf16(P_1.Slice(num2), out var num7))
			{
				num2 += num7;
				num += num7;
				continue;
			}
			goto IL_0148;
		}
		P_2 = num;
		P_3 = num2;
		return result;
	}

	public OperationStatus EncodeUtf8(ReadOnlySpan<byte> P_0, Span<byte> P_1, out int P_2, out int P_3, bool P_4)
	{
		_AssertThisNotNull();
		int num = 0;
		int num2 = 0;
		OperationStatus result;
		while (true)
		{
			int num5;
			if (SpanUtility.IsValidIndex(P_0, num))
			{
				uint num3 = P_0[num];
				if (_asciiPreescapedData.TryGetPreescapedData(num3, out var num4))
				{
					if (SpanUtility.TryWriteUInt64LittleEndian(P_1, num2, num4))
					{
						num2 += (int)(num4 >> 56);
						num++;
						continue;
					}
					num5 = num2;
					while (SpanUtility.IsValidIndex(P_1, num5))
					{
						P_1[num5++] = (byte)num4;
						if ((byte)(num4 >>= 8) != 0)
						{
							continue;
						}
						goto IL_0076;
					}
				}
				else
				{
					Rune rune;
					int num6;
					OperationStatus operationStatus = Rune.DecodeFromUtf8(P_0.Slice(num), out rune, out num6);
					if (operationStatus != OperationStatus.Done)
					{
						if (!P_4 && operationStatus == OperationStatus.NeedMoreData)
						{
							result = OperationStatus.NeedMoreData;
							break;
						}
					}
					else if (IsScalarValueAllowed(rune))
					{
						if (rune.TryEncodeToUtf8(P_1.Slice(num2), out var num7))
						{
							num2 += num7;
							num += num7;
							continue;
						}
						goto IL_0103;
					}
					int num8 = _scalarEscaper.EncodeUtf8(rune, P_1.Slice(num2));
					if (num8 >= 0)
					{
						num2 += num8;
						num += num6;
						continue;
					}
				}
				goto IL_0103;
			}
			result = OperationStatus.Done;
			break;
			IL_0076:
			num2 = num5;
			num++;
			continue;
			IL_0103:
			result = OperationStatus.DestinationTooSmall;
			break;
		}
		P_2 = num;
		P_3 = num2;
		return result;
	}

	public int GetIndexOfFirstByteToEncode(ReadOnlySpan<byte> P_0)
	{
		int length = P_0.Length;
		_ = 0;
		if (false)
		{
			goto IL_0010;
		}
		goto IL_0045;
		IL_0010:
		if (Rune.DecodeFromUtf8(P_0, out var rune, out var num) == OperationStatus.Done && num < 4 && _allowedBmpCodePoints.IsCharAllowed((char)rune.Value))
		{
			P_0 = P_0.Slice(num);
			goto IL_0045;
		}
		goto IL_004e;
		IL_004e:
		if (!P_0.IsEmpty)
		{
			return length - P_0.Length;
		}
		return -1;
		IL_0045:
		if (!P_0.IsEmpty)
		{
			goto IL_0010;
		}
		goto IL_004e;
	}

	public unsafe int GetIndexOfFirstCharToEncode(ReadOnlySpan<char> P_0)
	{
		fixed (char* ptr = P_0)
		{
			nuint num = (uint)P_0.Length;
			nuint num2 = 0u;
			if (false)
			{
			}
			if (false)
			{
			}
			if (num2 < num)
			{
				_AssertThisNotNull();
				nint num3 = 0;
				while (true)
				{
					if (num - num2 >= 8)
					{
						num3 = -1;
						if (_allowedBmpCodePoints.IsCharAllowed(ptr[(nuint)((nint)num2 + ++num3)]) && _allowedBmpCodePoints.IsCharAllowed(ptr[(nuint)((nint)num2 + ++num3)]) && _allowedBmpCodePoints.IsCharAllowed(ptr[(nuint)((nint)num2 + ++num3)]) && _allowedBmpCodePoints.IsCharAllowed(ptr[(nuint)((nint)num2 + ++num3)]) && _allowedBmpCodePoints.IsCharAllowed(ptr[(nuint)((nint)num2 + ++num3)]) && _allowedBmpCodePoints.IsCharAllowed(ptr[(nuint)((nint)num2 + ++num3)]) && _allowedBmpCodePoints.IsCharAllowed(ptr[(nuint)((nint)num2 + ++num3)]) && _allowedBmpCodePoints.IsCharAllowed(ptr[(nuint)((nint)num2 + ++num3)]))
						{
							num2 += 8;
							continue;
						}
						num2 += (nuint)num3;
						break;
					}
					for (; num2 < num && _allowedBmpCodePoints.IsCharAllowed(ptr[num2]); num2++)
					{
					}
					break;
				}
			}
			int num4 = (int)num2;
			if (num4 == (int)num)
			{
				num4 = -1;
			}
			return num4;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool IsScalarValueAllowed(Rune P_0)
	{
		return _allowedBmpCodePoints.IsCodePointAllowed((uint)P_0.Value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void _AssertThisNotNull()
	{
		_ = GetType() == typeof(OptimizedInboxTextEncoder);
	}
}
