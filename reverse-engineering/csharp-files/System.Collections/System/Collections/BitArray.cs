using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace System.Collections;

[Serializable]
[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public sealed class BitArray : ICollection, IEnumerable, ICloneable
{
	private sealed class BitArrayEnumeratorSimple : IEnumerator, ICloneable
	{
		private readonly BitArray _bitArray;

		private int _index;

		private readonly int _version;

		private bool _currentElement;

		public object Current
		{
			get
			{
				if ((uint)_index >= (uint)_bitArray.m_length)
				{
					throw GetInvalidOperationException(_index);
				}
				return _currentElement;
			}
		}

		internal BitArrayEnumeratorSimple(BitArray P_0)
		{
			_bitArray = P_0;
			_index = -1;
			_version = P_0._version;
		}

		public object Clone()
		{
			return MemberwiseClone();
		}

		public bool MoveNext()
		{
			if (_version != _bitArray._version)
			{
				throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
			}
			if (_index < _bitArray.m_length - 1)
			{
				_index++;
				_currentElement = _bitArray.Get(_index);
				return true;
			}
			_index = _bitArray.m_length;
			return false;
		}

		public void Reset()
		{
			if (_version != _bitArray._version)
			{
				throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
			}
			_index = -1;
		}

		private InvalidOperationException GetInvalidOperationException(int P_0)
		{
			if (P_0 == -1)
			{
				return new InvalidOperationException("InvalidOperation_EnumNotStarted");
			}
			return new InvalidOperationException("InvalidOperation_EnumEnded");
		}
	}

	private int[] m_array;

	private int m_length;

	private int _version;

	public bool this[int P_0]
	{
		get
		{
			return Get(P_0);
		}
		set
		{
			Set(num, flag);
		}
	}

	public int Count => m_length;

	public object SyncRoot => this;

	public bool IsSynchronized => false;

	public BitArray(int P_0)
		: this(P_0, false)
	{
	}

	public BitArray(int P_0, bool P_1)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("length", P_0, "ArgumentOutOfRange_NeedNonNegNum");
		}
		m_array = new int[GetInt32ArrayLengthFromBitLength(P_0)];
		m_length = P_0;
		if (P_1)
		{
			Array.Fill(m_array, -1);
			Div32Rem(P_0, out var num);
			if (num > 0)
			{
				int[] array = m_array;
				array[array.Length - 1] = (1 << num) - 1;
			}
		}
		_version = 0;
	}

	public BitArray(BitArray P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "bits");
		int int32ArrayLengthFromBitLength = GetInt32ArrayLengthFromBitLength(P_0.m_length);
		m_array = new int[int32ArrayLengthFromBitLength];
		Array.Copy(P_0.m_array, m_array, int32ArrayLengthFromBitLength);
		m_length = P_0.m_length;
		_version = P_0._version;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool Get(int P_0)
	{
		if ((uint)P_0 >= (uint)m_length)
		{
			ThrowArgumentOutOfRangeException(P_0);
		}
		return (m_array[P_0 >> 5] & (1 << P_0)) != 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Set(int P_0, bool P_1)
	{
		if ((uint)P_0 >= (uint)m_length)
		{
			ThrowArgumentOutOfRangeException(P_0);
		}
		int num = 1 << P_0;
		ref int reference = ref m_array[P_0 >> 5];
		if (P_1)
		{
			reference |= num;
		}
		else
		{
			reference &= ~num;
		}
		_version++;
	}

	public void CopyTo(Array P_0, int P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "array");
		if (P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("index", P_1, "ArgumentOutOfRange_NeedNonNegNum");
		}
		if (P_0.Rank != 1)
		{
			throw new ArgumentException("Arg_RankMultiDimNotSupported", "array");
		}
		if (P_0 is int[] array)
		{
			Div32Rem(m_length, out var num);
			if (num == 0)
			{
				Array.Copy(m_array, 0, array, P_1, m_array.Length);
				return;
			}
			int num2 = m_length - 1 >> 5;
			Array.Copy(m_array, 0, array, P_1, num2);
			array[P_1 + num2] = m_array[num2] & ((1 << num) - 1);
			return;
		}
		if (P_0 is byte[] array2)
		{
			int num3 = GetByteArrayLengthFromBitLength(m_length);
			if (P_0.Length - P_1 < num3)
			{
				throw new ArgumentException("Argument_InvalidOffLen");
			}
			uint num4 = (uint)(m_length & 7);
			if (num4 != 0)
			{
				num3--;
			}
			Span<byte> span = array2.AsSpan(P_1);
			int num6;
			int num5 = Div4Rem(num3, out num6);
			for (int i = 0; i < num5; i++)
			{
				BinaryPrimitives.WriteInt32LittleEndian(span, m_array[i]);
				span = span.Slice(4);
			}
			if (num4 != 0)
			{
				span[num6] = (byte)((m_array[num5] >> num6 * 8) & ((1 << (int)num4) - 1));
			}
			switch (num6)
			{
			default:
				return;
			case 3:
				span[2] = (byte)(m_array[num5] >> 16);
				goto case 2;
			case 2:
				span[1] = (byte)(m_array[num5] >> 8);
				break;
			case 1:
				break;
			}
			span[0] = (byte)m_array[num5];
			return;
		}
		uint num7;
		if (P_0 is bool[] array3)
		{
			if (P_0.Length - P_1 < m_length)
			{
				throw new ArgumentException("Argument_InvalidOffLen");
			}
			num7 = 0u;
			if (m_length >= 32)
			{
				Vector128<byte> vector = Vector128.Create(0L, 72340172838076673L).AsByte();
				Vector128<byte> vector2 = Vector128.Create(144680345676153346L, 217020518514230019L).AsByte();
				if (false)
				{
				}
				if (false)
				{
				}
				if (false)
				{
					goto IL_0227;
				}
			}
			goto IL_0253;
		}
		throw new ArgumentException("Arg_BitArrayTypeUnsupported", "array");
		IL_0227:
		int num9;
		int num8 = Div32Rem((int)num7, out num9);
		array3[P_1 + (int)num7] = ((m_array[num8] >> num9) & 1) != 0;
		num7++;
		goto IL_0253;
		IL_0253:
		if (num7 >= (uint)m_length)
		{
			return;
		}
		goto IL_0227;
	}

	public object Clone()
	{
		return new BitArray(this);
	}

	public IEnumerator GetEnumerator()
	{
		return new BitArrayEnumeratorSimple(this);
	}

	private static int GetInt32ArrayLengthFromBitLength(int P_0)
	{
		return P_0 - 1 + 32 >>> 5;
	}

	private static int GetByteArrayLengthFromBitLength(int P_0)
	{
		return P_0 - 1 + 8 >>> 3;
	}

	private static int Div32Rem(int P_0, out int P_1)
	{
		uint result = (uint)P_0 / 32u;
		P_1 = P_0 & 0x1F;
		return (int)result;
	}

	private static int Div4Rem(int P_0, out int P_1)
	{
		uint result = (uint)P_0 / 4u;
		P_1 = P_0 & 3;
		return (int)result;
	}

	private static void ThrowArgumentOutOfRangeException(int P_0)
	{
		throw new ArgumentOutOfRangeException("index", P_0, "ArgumentOutOfRange_IndexMustBeLess");
	}
}
