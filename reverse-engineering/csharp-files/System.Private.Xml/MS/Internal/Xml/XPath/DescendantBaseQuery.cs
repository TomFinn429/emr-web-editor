using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal abstract class DescendantBaseQuery : BaseAxisQuery
{
	protected bool matchSelf;

	protected bool abbrAxis;

	public DescendantBaseQuery(Query P_0, string P_1, string P_2, XPathNodeType P_3, bool P_4, bool P_5)
		: base(P_0, P_1, P_2, P_3)
	{
		matchSelf = P_4;
		abbrAxis = P_5;
	}

	public DescendantBaseQuery(DescendantBaseQuery P_0)
		: base(P_0)
	{
		matchSelf = P_0.matchSelf;
		abbrAxis = P_0.abbrAxis;
	}
}
