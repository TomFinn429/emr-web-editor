using System.Runtime.CompilerServices;

namespace System.ComponentModel;

public abstract class MemberDescriptor
{
	public virtual AttributeCollection Attributes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public virtual string Name
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}
}
