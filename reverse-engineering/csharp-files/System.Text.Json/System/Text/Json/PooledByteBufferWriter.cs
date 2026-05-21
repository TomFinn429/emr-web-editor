using System.Buffers;

namespace System.Text.Json;

internal sealed class PooledByteBufferWriter : IBufferWriter<byte>, IDisposable
{
	private byte[] _rentedBuffer;

	private int _index;

	public ReadOnlyMemory<byte> WrittenMemory => _rentedBuffer.AsMemory(0, _index);

	private PooledByteBufferWriter()
	{
	}

	public PooledByteBufferWriter(int P_0)
	{
		_rentedBuffer = ArrayPool<byte>.Shared.Rent(P_0);
		_index = 0;
	}

	public void ClearAndReturnBuffers()
	{
		ClearHelper();
		byte[] rentedBuffer = _rentedBuffer;
		_rentedBuffer = null;
		ArrayPool<byte>.Shared.Return(rentedBuffer);
	}

	private void ClearHelper()
	{
		_rentedBuffer.AsSpan(0, _index).Clear();
		_index = 0;
	}

	public void Dispose()
	{
		if (_rentedBuffer != null)
		{
			ClearHelper();
			byte[] rentedBuffer = _rentedBuffer;
			_rentedBuffer = null;
			ArrayPool<byte>.Shared.Return(rentedBuffer);
		}
	}

	public void InitializeEmptyInstance(int P_0)
	{
		_rentedBuffer = ArrayPool<byte>.Shared.Rent(P_0);
		_index = 0;
	}

	public static PooledByteBufferWriter CreateEmptyInstanceForCaching()
	{
		return new PooledByteBufferWriter();
	}

	public void Advance(int P_0)
	{
		_index += P_0;
	}

	public Memory<byte> GetMemory(int P_0 = 0)
	{
		CheckAndResizeBuffer(P_0);
		return _rentedBuffer.AsMemory(_index);
	}

	private void CheckAndResizeBuffer(int P_0)
	{
		if (P_0 == 0)
		{
			P_0 = 256;
		}
		int num = _rentedBuffer.Length - _index;
		if (P_0 <= num)
		{
			return;
		}
		int num2 = _rentedBuffer.Length;
		int num3 = Math.Max(P_0, num2);
		int num4 = num2 + num3;
		if ((uint)num4 > 2147483647u)
		{
			num4 = num2 + P_0;
			if ((uint)num4 > 2147483647u)
			{
				ThrowHelper.ThrowOutOfMemoryException_BufferMaximumSizeExceeded((uint)num4);
			}
		}
		byte[] rentedBuffer = _rentedBuffer;
		_rentedBuffer = ArrayPool<byte>.Shared.Rent(num4);
		Span<byte> span = rentedBuffer.AsSpan(0, _index);
		span.CopyTo(_rentedBuffer);
		span.Clear();
		ArrayPool<byte>.Shared.Return(rentedBuffer);
	}
}
