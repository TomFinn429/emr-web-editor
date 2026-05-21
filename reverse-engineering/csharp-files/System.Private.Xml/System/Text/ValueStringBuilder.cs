using System.Buffers;
using System.Runtime.CompilerServices;

namespace System.Text;

internal ref struct ValueStringBuilder
{
	private char[] _arrayToReturnToPool;

	private Span<char> _chars;

	private int _pos;

	public int Length => _pos;

	public ref char this[int P_0] => ref _chars[P_0];

	public ValueStringBuilder(Span<char> P_0)
	{
		_arrayToReturnToPool = null;
		_chars = P_0;
		_pos = 0;
	}

	public void EnsureCapacity(int P_0)
	{
		if ((uint)P_0 > (uint)_chars.Length)
		{
			Grow(P_0 - _pos);
		}
	}

	public override string ToString()
	{
		string result = _chars.Slice(0, _pos).ToString();
		Dispose();
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Append(char P_0)
	{
		int pos = _pos;
		if ((uint)pos < (uint)_chars.Length)
		{
			_chars[pos] = P_0;
			_pos = pos + 1;
		}
		else
		{
			GrowAndAppend(P_0);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Append(string P_0)
	{
		if (P_0 != null)
		{
			int pos = _pos;
			if (P_0.Length == 1 && (uint)pos < (uint)_chars.Length)
			{
				_chars[pos] = P_0[0];
				_pos = pos + 1;
			}
			else
			{
				AppendSlow(P_0);
			}
		}
	}

	private void AppendSlow(string P_0)
	{
		int pos = _pos;
		if (pos > _chars.Length - P_0.Length)
		{
			Grow(P_0.Length);
		}
		P_0.CopyTo(_chars.Slice(pos));
		_pos += P_0.Length;
	}

	public void Append(ReadOnlySpan<char> P_0)
	{
		int pos = _pos;
		if (pos > _chars.Length - P_0.Length)
		{
			Grow(P_0.Length);
		}
		P_0.CopyTo(_chars.Slice(_pos));
		_pos += P_0.Length;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Span<char> AppendSpan(int P_0)
	{
		int pos = _pos;
		if (pos > _chars.Length - P_0)
		{
			Grow(P_0);
		}
		_pos = pos + P_0;
		return _chars.Slice(pos, P_0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GrowAndAppend(char P_0)
	{
		Grow(1);
		Append(P_0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Grow(int P_0)
	{
		int num = (int)Math.Max((uint)(_pos + P_0), Math.Min((uint)(_chars.Length * 2), 2147483591u));
		char[] array = ArrayPool<char>.Shared.Rent(num);
		_chars.Slice(0, _pos).CopyTo(array);
		char[] arrayToReturnToPool = _arrayToReturnToPool;
		_chars = (_arrayToReturnToPool = array);
		if (arrayToReturnToPool != null)
		{
			ArrayPool<char>.Shared.Return(arrayToReturnToPool);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Dispose()
	{
		char[] arrayToReturnToPool = _arrayToReturnToPool;
		this = default(System.Text.ValueStringBuilder);
		if (arrayToReturnToPool != null)
		{
			ArrayPool<char>.Shared.Return(arrayToReturnToPool);
		}
	}

	internal void AppendSpanFormattable<T>(T P_0, string P_1 = null, IFormatProvider P_2 = null) where T : ISpanFormattable
	{
		Span<char> destination = _chars.Slice(_pos);
		ReadOnlySpan<char> format = P_1;
		if (P_0.TryFormat(destination, out var charsWritten, format, P_2))
		{
			_pos += charsWritten;
		}
		else
		{
			Append(P_0.ToString(P_1, P_2));
		}
	}
}
