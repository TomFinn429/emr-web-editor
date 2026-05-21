namespace System.Text.Json;

internal static class Utf8JsonWriterCache
{
	private sealed class ThreadLocalState
	{
		public readonly PooledByteBufferWriter BufferWriter;

		public readonly Utf8JsonWriter Writer;

		public int RentedWriters;

		public ThreadLocalState()
		{
			BufferWriter = PooledByteBufferWriter.CreateEmptyInstanceForCaching();
			Writer = Utf8JsonWriter.CreateEmptyInstanceForCaching();
		}
	}

	[ThreadStatic]
	private static ThreadLocalState t_threadLocalState;

	public static Utf8JsonWriter RentWriterAndBuffer(JsonSerializerOptions P_0, out PooledByteBufferWriter P_1)
	{
		ThreadLocalState threadLocalState = t_threadLocalState ?? (t_threadLocalState = new ThreadLocalState());
		Utf8JsonWriter utf8JsonWriter;
		if (threadLocalState.RentedWriters++ == 0)
		{
			P_1 = threadLocalState.BufferWriter;
			utf8JsonWriter = threadLocalState.Writer;
			P_1.InitializeEmptyInstance(P_0.DefaultBufferSize);
			utf8JsonWriter.Reset(P_1, P_0.GetWriterOptions());
		}
		else
		{
			P_1 = new PooledByteBufferWriter(P_0.DefaultBufferSize);
			utf8JsonWriter = new Utf8JsonWriter(P_1, P_0.GetWriterOptions());
		}
		return utf8JsonWriter;
	}

	public static void ReturnWriterAndBuffer(Utf8JsonWriter P_0, PooledByteBufferWriter P_1)
	{
		ThreadLocalState threadLocalState = t_threadLocalState;
		P_0.ResetAllStateForCacheReuse();
		P_1.ClearAndReturnBuffers();
		threadLocalState.RentedWriters--;
	}
}
