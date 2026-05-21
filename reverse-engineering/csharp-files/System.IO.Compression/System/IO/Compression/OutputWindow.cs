namespace System.IO.Compression;

internal sealed class OutputWindow
{
	private readonly byte[] _window = new byte[262144];

	private int _end;

	private int _bytesUsed;

	public int FreeBytes => 262144 - _bytesUsed;

	internal void ClearBytesUsed()
	{
		_bytesUsed = 0;
	}

	public void Write(byte P_0)
	{
		_window[_end++] = P_0;
		_end &= 262143;
		_bytesUsed++;
	}

	public void WriteLengthDistance(int P_0, int P_1)
	{
		_bytesUsed += P_0;
		int num = (_end - P_1) & 0x3FFFF;
		int num2 = 262144 - P_0;
		if (num <= num2 && _end < num2)
		{
			if (P_0 <= P_1)
			{
				Array.Copy(_window, num, _window, _end, P_0);
				_end += P_0;
			}
			else
			{
				while (P_0-- > 0)
				{
					_window[_end++] = _window[num++];
				}
			}
		}
		else
		{
			while (P_0-- > 0)
			{
				_window[_end++] = _window[num++];
				_end &= 262143;
				num &= 0x3FFFF;
			}
		}
	}

	public int CopyFrom(InputBuffer P_0, int P_1)
	{
		P_1 = Math.Min(Math.Min(P_1, 262144 - _bytesUsed), P_0.AvailableBytes);
		int num = 262144 - _end;
		int num2;
		if (P_1 > num)
		{
			num2 = P_0.CopyTo(_window, _end, num);
			if (num2 == num)
			{
				num2 += P_0.CopyTo(_window, 0, P_1 - num);
			}
		}
		else
		{
			num2 = P_0.CopyTo(_window, _end, P_1);
		}
		_end = (_end + num2) & 0x3FFFF;
		_bytesUsed += num2;
		return num2;
	}

	public int CopyTo(Span<byte> P_0)
	{
		int num;
		if (P_0.Length > _bytesUsed)
		{
			num = _end;
			P_0 = P_0.Slice(0, _bytesUsed);
		}
		else
		{
			num = (_end - _bytesUsed + P_0.Length) & 0x3FFFF;
		}
		int length = P_0.Length;
		int num2 = P_0.Length - num;
		if (num2 > 0)
		{
			_window.AsSpan(262144 - num2, num2).CopyTo(P_0);
			P_0 = P_0.Slice(num2, num);
		}
		_window.AsSpan(num - P_0.Length, P_0.Length).CopyTo(P_0);
		_bytesUsed -= length;
		return length;
	}
}
