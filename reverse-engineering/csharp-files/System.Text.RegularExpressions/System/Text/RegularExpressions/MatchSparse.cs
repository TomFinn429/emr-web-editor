using System.Collections;

namespace System.Text.RegularExpressions;

internal sealed class MatchSparse : Match
{
	private new readonly Hashtable _caps;

	internal MatchSparse(Regex P_0, Hashtable P_1, int P_2, string P_3, int P_4)
		: base(P_0, P_2, P_3, P_4)
	{
		_caps = P_1;
	}
}
