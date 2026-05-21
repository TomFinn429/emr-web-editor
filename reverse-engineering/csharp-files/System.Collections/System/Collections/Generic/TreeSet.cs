using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

[Serializable]
[TypeForwardedFrom("System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public sealed class TreeSet<T> : SortedSet<T>
{
	public TreeSet(IComparer<T>? P_0)
		: base(P_0)
	{
	}

	internal override bool AddIfNotPresent(T P_0)
	{
		bool flag = base.AddIfNotPresent(P_0);
		if (!flag)
		{
			throw new ArgumentException(System.SR.Format("Argument_AddingDuplicate", P_0));
		}
		return flag;
	}
}
