using System.Collections;
using System.Globalization;

namespace System;

internal sealed class InvariantComparer : IComparer
{
	private readonly CompareInfo _compareInfo;

	internal static readonly InvariantComparer Default = new InvariantComparer();

	internal InvariantComparer()
	{
		_compareInfo = CultureInfo.InvariantCulture.CompareInfo;
	}

	public int Compare(object P_0, object P_1)
	{
		if (P_0 is string text && P_1 is string text2)
		{
			return _compareInfo.Compare(text, text2);
		}
		return Comparer.Default.Compare(P_0, P_1);
	}
}
