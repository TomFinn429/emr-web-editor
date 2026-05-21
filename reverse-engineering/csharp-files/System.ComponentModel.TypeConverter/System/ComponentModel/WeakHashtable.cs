using System.Collections;

namespace System.ComponentModel;

internal sealed class WeakHashtable : Hashtable
{
	private sealed class WeakKeyComparer : IEqualityComparer
	{
		bool IEqualityComparer.Equals(object P_0, object P_1)
		{
			if (P_0 == null)
			{
				return P_1 == null;
			}
			if (P_1 != null && P_0.GetHashCode() == P_1.GetHashCode())
			{
				if (P_0 is WeakReference weakReference)
				{
					if (!weakReference.IsAlive)
					{
						return false;
					}
					P_0 = weakReference.Target;
				}
				if (P_1 is WeakReference weakReference2)
				{
					if (!weakReference2.IsAlive)
					{
						return false;
					}
					P_1 = weakReference2.Target;
				}
				return P_0 == P_1;
			}
			return false;
		}

		int IEqualityComparer.GetHashCode(object P_0)
		{
			return P_0.GetHashCode();
		}
	}

	private static readonly IEqualityComparer s_comparer = new WeakKeyComparer();

	internal WeakHashtable()
		: base(s_comparer)
	{
	}
}
