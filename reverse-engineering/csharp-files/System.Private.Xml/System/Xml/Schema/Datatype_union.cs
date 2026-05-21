using System.Runtime.CompilerServices;

namespace System.Xml.Schema;

internal sealed class Datatype_union : Datatype_anySimpleType
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool HasAtomicMembers()
	{
		throw new NotSupportedException("Linked away");
	}
}
