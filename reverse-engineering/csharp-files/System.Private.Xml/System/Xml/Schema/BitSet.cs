using System.Diagnostics.CodeAnalysis;

namespace System.Xml.Schema;

internal sealed class BitSet
{
	private readonly int _count;

	private uint[] _bits;

	public int Count => _count;

	public bool this[int P_0] => Get(P_0);

	private BitSet(int P_0, uint[] P_1)
	{
		_count = P_0;
		_bits = P_1;
	}

	public BitSet(int P_0)
	{
		_count = P_0;
		_bits = new uint[Subscript(P_0 + 31)];
	}

	public void Clear()
	{
		int num = _bits.Length;
		int num2 = num;
		while (num2-- > 0)
		{
			_bits[num2] = 0u;
		}
	}

	public void Set(int P_0)
	{
		int num = Subscript(P_0);
		EnsureLength(num + 1);
		_bits[num] |= (uint)(1 << P_0);
	}

	public bool Get(int P_0)
	{
		bool result = false;
		if (P_0 < _count)
		{
			int num = Subscript(P_0);
			result = (_bits[num] & (1 << P_0)) != 0;
		}
		return result;
	}

	public int NextSet(int P_0)
	{
		int num = P_0 + 1;
		if (num == _count)
		{
			return -1;
		}
		int num2 = Subscript(num);
		num &= 0x1F;
		uint num3;
		for (num3 = _bits[num2] >> num; num3 == 0; num3 = _bits[num2])
		{
			if (++num2 == _bits.Length)
			{
				return -1;
			}
			num = 0;
		}
		while ((num3 & 1) == 0)
		{
			num3 >>= 1;
			num++;
		}
		return (num2 << 5) + num;
	}

	public void And(BitSet P_0)
	{
		if (this != P_0)
		{
			int num = _bits.Length;
			int num2 = P_0._bits.Length;
			int i = ((num > num2) ? num2 : num);
			int num3 = i;
			while (num3-- > 0)
			{
				_bits[num3] &= P_0._bits[num3];
			}
			for (; i < num; i++)
			{
				_bits[i] = 0u;
			}
		}
	}

	public void Or(BitSet P_0)
	{
		if (this != P_0)
		{
			int num = P_0._bits.Length;
			EnsureLength(num);
			int num2 = num;
			while (num2-- > 0)
			{
				_bits[num2] |= P_0._bits[num2];
			}
		}
	}

	public override int GetHashCode()
	{
		int num = 1234;
		int num2 = _bits.Length;
		while (--num2 >= 0)
		{
			num ^= (int)_bits[num2] * (num2 + 1);
		}
		return num ^ num;
	}

	public override bool Equals([NotNullWhen(true)] object P_0)
	{
		if (P_0 != null)
		{
			if (this == P_0)
			{
				return true;
			}
			BitSet bitSet = (BitSet)P_0;
			int num = _bits.Length;
			int num2 = bitSet._bits.Length;
			int num3 = ((num > num2) ? num2 : num);
			int num4 = num3;
			while (num4-- > 0)
			{
				if (_bits[num4] != bitSet._bits[num4])
				{
					return false;
				}
			}
			if (num > num3)
			{
				int num5 = num;
				while (num5-- > num3)
				{
					if (_bits[num5] != 0)
					{
						return false;
					}
				}
			}
			else
			{
				int num6 = num2;
				while (num6-- > num3)
				{
					if (bitSet._bits[num6] != 0)
					{
						return false;
					}
				}
			}
			return true;
		}
		return false;
	}

	public BitSet Clone()
	{
		return new BitSet(_count, (uint[])_bits.Clone());
	}

	public bool Intersects(BitSet P_0)
	{
		int num = Math.Min(_bits.Length, P_0._bits.Length);
		while (--num >= 0)
		{
			if ((_bits[num] & P_0._bits[num]) != 0)
			{
				return true;
			}
		}
		return false;
	}

	private static int Subscript(int P_0)
	{
		return P_0 >> 5;
	}

	private void EnsureLength(int P_0)
	{
		if (P_0 > _bits.Length)
		{
			int num = 2 * _bits.Length;
			if (num < P_0)
			{
				num = P_0;
			}
			uint[] array = new uint[num];
			Array.Copy(_bits, array, _bits.Length);
			_bits = array;
		}
	}
}
