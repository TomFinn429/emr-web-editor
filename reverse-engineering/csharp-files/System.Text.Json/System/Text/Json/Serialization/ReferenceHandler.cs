using System.Runtime.CompilerServices;

namespace System.Text.Json.Serialization;

public abstract class ReferenceHandler
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal virtual ReferenceResolver CreateResolver(bool P_0)
	{
		throw new NotSupportedException("Linked away");
	}
}
