using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Text;

internal ref struct ValueStringBuilder
{
	private char[] _arrayToReturnToPool;

	private Span<char> _chars;

	private int _pos;

	public int Length
	{
		get
		{
			return _pos;
		}
		set
		{
			_pos = pos;
		}
	}

	public ref char this[int P_0] => ref _chars[P_0];

	public Span<char> RawChars => _chars;

	public ValueStringBuilder(Span<char> P_0)
	{
		_arrayToReturnToPool = null;
		_chars = P_0;
		_pos = 0;
	}

	public ValueStringBuilder(int P_0)
	{
		_arrayToReturnToPool = ArrayPool<char>.Shared.Rent(P_0);
		_chars = _arrayToReturnToPool;
		_pos = 0;
	}

	public void EnsureCapacity(int P_0)
	{
		if ((uint)P_0 > (uint)_chars.Length)
		{
			Grow(P_0 - _pos);
		}
	}

	public ref char GetPinnableReference()
	{
		return ref MemoryMarshal.GetReference(_chars);
	}

	public override string ToString()
	{
		string result = _chars.Slice(0, _pos).ToString();
		Dispose();
		return result;
	}

	public ReadOnlySpan<char> AsSpan()
	{
		return _chars.Slice(0, _pos);
	}

	public ReadOnlySpan<char> AsSpan(int P_0)
	{
		return _chars.Slice(P_0, _pos - P_0);
	}

	public ReadOnlySpan<char> AsSpan(int P_0, int P_1)
	{
		return _chars.Slice(P_0, P_1);
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

	public unsafe void Append(char* P_0, int P_1)
	{
		int pos = _pos;
		if (pos > _chars.Length - P_1)
		{
			Grow(P_1);
		}
		Span<char> span = _chars.Slice(_pos, P_1);
		for (int i = 0; i < span.Length; i++)
		{
			span[i] = *(P_0++);
		}
		_pos += P_1;
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

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Append(Rune P_0)
	{
		int pos = _pos;
		Span<char> chars = _chars;
		if ((uint)(pos + 1) < (uint)chars.Length && (uint)pos < (uint)chars.Length)
		{
			if (P_0.Value <= 65535)
			{
				chars[pos] = (char)P_0.Value;
				_pos = pos + 1;
			}
			else
			{
				chars[pos] = (char)((long)P_0.Value + 56557568L >> 10);
				chars[pos + 1] = (char)(((ulong)P_0.Value & 0x3FFuL) + 56320);
				_pos = pos + 2;
			}
		}
		else
		{
			GrowAndAppend(P_0);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GrowAndAppend(Rune P_0)
	{
		Grow(2);
		Append(P_0);
	}
}
