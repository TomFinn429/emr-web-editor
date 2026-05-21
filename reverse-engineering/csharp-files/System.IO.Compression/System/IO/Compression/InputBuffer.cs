namespace System.IO.Compression;

internal sealed class InputBuffer
{
	private Memory<byte> _buffer;

	private uint _bitBuffer;

	private int _bitsInBuffer;

	public int AvailableBits => _bitsInBuffer;

	public int AvailableBytes => _buffer.Length + _bitsInBuffer / 8;

	public bool EnsureBitsAvailable(int P_0)
	{
		if (_bitsInBuffer < P_0)
		{
			if (NeedsInput())
			{
				return false;
			}
			_bitBuffer |= (uint)(_buffer.Span[0] << _bitsInBuffer);
			_buffer = _buffer.Slice(1);
			_bitsInBuffer += 8;
			if (_bitsInBuffer < P_0)
			{
				if (NeedsInput())
				{
					return false;
				}
				_bitBuffer |= (uint)(_buffer.Span[0] << _bitsInBuffer);
				_buffer = _buffer.Slice(1);
				_bitsInBuffer += 8;
			}
		}
		return true;
	}

	public uint TryLoad16Bits()
	{
		if (_bitsInBuffer < 8)
		{
			if (_buffer.Length > 1)
			{
				Span<byte> span = _buffer.Span;
				_bitBuffer |= (uint)(span[0] << _bitsInBuffer);
				_bitBuffer |= (uint)(span[1] << _bitsInBuffer + 8);
				_buffer = _buffer.Slice(2);
				_bitsInBuffer += 16;
			}
			else if (_buffer.Length != 0)
			{
				_bitBuffer |= (uint)(_buffer.Span[0] << _bitsInBuffer);
				_buffer = _buffer.Slice(1);
				_bitsInBuffer += 8;
			}
		}
		else if (_bitsInBuffer < 16 && !_buffer.IsEmpty)
		{
			_bitBuffer |= (uint)(_buffer.Span[0] << _bitsInBuffer);
			_buffer = _buffer.Slice(1);
			_bitsInBuffer += 8;
		}
		return _bitBuffer;
	}

	private static uint GetBitMask(int P_0)
	{
		return (uint)((1 << P_0) - 1);
	}

	public int GetBits(int P_0)
	{
		if (!EnsureBitsAvailable(P_0))
		{
			return -1;
		}
		int result = (int)(_bitBuffer & GetBitMask(P_0));
		_bitBuffer >>= P_0;
		_bitsInBuffer -= P_0;
		return result;
	}

	public int CopyTo(Memory<byte> P_0)
	{
		int num = 0;
		while (_bitsInBuffer > 0 && !P_0.IsEmpty)
		{
			P_0.Span[0] = (byte)_bitBuffer;
			P_0 = P_0.Slice(1);
			_bitBuffer >>= 8;
			_bitsInBuffer -= 8;
			num++;
		}
		if (P_0.IsEmpty)
		{
			return num;
		}
		int num2 = Math.Min(P_0.Length, _buffer.Length);
		_buffer.Slice(0, num2).CopyTo(P_0);
		_buffer = _buffer.Slice(num2);
		return num + num2;
	}

	public int CopyTo(byte[] P_0, int P_1, int P_2)
	{
		return CopyTo(P_0.AsMemory(P_1, P_2));
	}

	public bool NeedsInput()
	{
		return _buffer.IsEmpty;
	}

	public void SetInput(Memory<byte> P_0)
	{
		if (_buffer.IsEmpty)
		{
			_buffer = P_0;
		}
	}

	public void SetInput(byte[] P_0, int P_1, int P_2)
	{
		SetInput(P_0.AsMemory(P_1, P_2));
	}

	public void SkipBits(int P_0)
	{
		_bitBuffer >>= P_0;
		_bitsInBuffer -= P_0;
	}

	public void SkipToByteBoundary()
	{
		_bitBuffer >>= _bitsInBuffer % 8;
		_bitsInBuffer -= _bitsInBuffer % 8;
	}
}
