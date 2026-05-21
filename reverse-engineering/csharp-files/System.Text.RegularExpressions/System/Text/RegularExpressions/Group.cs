using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions;

public class Group : Capture
{
	internal static readonly Group s_emptyGroup = new Group(string.Empty, Array.Empty<int>(), 0, string.Empty);

	internal readonly int[] _caps;

	internal int _capcount;

	[CompilerGenerated]
	private readonly string _003CName_003Ek__BackingField;

	internal Group(string P_0, int[] P_1, int P_2, string P_3)
		: base(P_0, (P_2 != 0) ? P_1[(P_2 - 1) * 2] : 0, (P_2 != 0) ? P_1[P_2 * 2 - 1] : 0)
	{
		_caps = P_1;
		_capcount = P_2;
		_003CName_003Ek__BackingField = P_3;
	}
}
