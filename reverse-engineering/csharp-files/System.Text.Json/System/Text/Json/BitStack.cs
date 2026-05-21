using System.Runtime.CompilerServices;

namespace System.Text.Json;

internal struct BitStack
{
	private int[] _array;

	private ulong _allocationFreeContainer;

	private int _currentDepth;

	public int CurrentDepth => _currentDepth;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void PushTrue()
	{
		if (_currentDepth < 64)
		{
			_allocationFreeContainer = (_allocationFreeContainer << 1) | 1;
		}
		else
		{
			PushToArray(true);
		}
		_currentDepth++;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void PushFalse()
	{
		if (_currentDepth < 64)
		{
			_allocationFreeContainer <<= 1;
		}
		else
		{
			PushToArray(false);
		}
		_currentDepth++;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PushToArray(bool P_0)
	{
		if (_array == null)
		{
			_array = new int[2];
		}
		int num = _currentDepth - 64;
		int num3;
		int num2 = Div32Rem(num, out num3);
		if (num2 >= _array.Length)
		{
			DoubleArray(num2);
		}
		int num4 = _array[num2];
		num4 = ((!P_0) ? (num4 & ~(1 << num3)) : (num4 | (1 << num3)));
		_array[num2] = num4;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool Pop()
	{
		_currentDepth--;
		if (_currentDepth < 64)
		{
			_allocationFreeContainer >>= 1;
			return (_allocationFreeContainer & 1) != 0;
		}
		if (_currentDepth == 64)
		{
			return (_allocationFreeContainer & 1) != 0;
		}
		return PopFromArray();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool PopFromArray()
	{
		int num = _currentDepth - 64 - 1;
		int num3;
		int num2 = Div32Rem(num, out num3);
		return (_array[num2] & (1 << num3)) != 0;
	}

	private void DoubleArray(int P_0)
	{
		int num = Math.Max(P_0 + 1, _array.Length * 2);
		Array.Resize(ref _array, num);
	}

	public void SetFirstBit()
	{
		_currentDepth++;
		_allocationFreeContainer = 1uL;
	}

	public void ResetFirstBit()
	{
		_currentDepth++;
		_allocationFreeContainer = 0uL;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int Div32Rem(int P_0, out int P_1)
	{
		uint result = (uint)P_0 / 32u;
		P_1 = P_0 & 0x1F;
		return (int)result;
	}
}
