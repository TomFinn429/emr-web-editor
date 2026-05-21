namespace System.Buffers;

public interface IBufferWriter<T>
{
	void Advance(int P_0);

	Memory<T> GetMemory(int P_0 = 0);
}
