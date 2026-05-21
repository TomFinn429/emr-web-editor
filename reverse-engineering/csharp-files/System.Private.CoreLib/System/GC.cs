using System.Runtime;
using System.Runtime.CompilerServices;

namespace System;

public static class GC
{
	internal static readonly object EPHEMERON_TOMBSTONE = get_ephemeron_tombstone();

	public static int MaxGeneration => GetMaxGeneration();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetMaxGeneration();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void InternalCollect(int P_0);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void register_ephemeron_array(Ephemeron[] P_0);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern object get_ephemeron_tombstone();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern long GetTotalAllocatedBytes(bool P_0 = false);

	public static void Collect()
	{
		InternalCollect(MaxGeneration);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void KeepAlive(object? P_0)
	{
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern void WaitForPendingFinalizers();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void _SuppressFinalize(object P_0);

	public static void SuppressFinalize(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "obj");
		_SuppressFinalize(P_0);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void _ReRegisterForFinalize(object P_0);

	public static void ReRegisterForFinalize(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "obj");
		_ReRegisterForFinalize(P_0);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern long GetTotalMemory(bool P_0);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void _GetGCMemoryInfo(out long P_0, out long P_1, out long P_2, out long P_3, out long P_4, out long P_5);

	public static GCMemoryInfo GetGCMemoryInfo()
	{
		GCMemoryInfoData gCMemoryInfoData = new GCMemoryInfoData();
		_GetGCMemoryInfo(out gCMemoryInfoData._highMemoryLoadThresholdBytes, out gCMemoryInfoData._memoryLoadBytes, out gCMemoryInfoData._totalAvailableMemoryBytes, out gCMemoryInfoData._totalCommittedBytes, out gCMemoryInfoData._heapSizeBytes, out gCMemoryInfoData._fragmentedBytes);
		return new GCMemoryInfo(gCMemoryInfoData);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern Array AllocPinnedArray(Type P_0, int P_1);

	public static T[] AllocateUninitializedArray<T>(int P_0, bool P_1 = false)
	{
		return AllocateArray<T>(P_0, P_1);
	}

	public static T[] AllocateArray<T>(int P_0, bool P_1 = false)
	{
		if (P_1)
		{
			if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
			{
				ThrowHelper.ThrowInvalidTypeWithPointersNotSupported(typeof(T));
			}
			return Unsafe.As<T[]>(AllocPinnedArray(typeof(T[]), P_0));
		}
		return new T[P_0];
	}
}
