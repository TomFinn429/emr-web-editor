using System.Runtime.CompilerServices;

namespace System.Text.Json.Serialization;

public abstract class ReferenceResolver
{
	public abstract void AddReference(string P_0, object P_1);

	public abstract string GetReference(object P_0, out bool P_1);

	public abstract object ResolveReference(string P_0);

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal virtual void PopReferenceForCycleDetection()
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal virtual void PushReferenceForCycleDetection(object P_0)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal virtual bool ContainsReferenceForCycleDetection(object P_0)
	{
		throw new NotSupportedException("Linked away");
	}
}
