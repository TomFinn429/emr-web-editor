using System.Collections;
using System.Runtime.CompilerServices;

namespace System.ComponentModel;

public class ComponentCollection : ReadOnlyCollectionBase
{
	public virtual IComponent? this[string? P_0]
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}
}
