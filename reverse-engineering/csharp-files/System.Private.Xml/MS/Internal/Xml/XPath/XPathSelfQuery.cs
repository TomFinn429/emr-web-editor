using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal sealed class XPathSelfQuery : BaseAxisQuery
{
	public XPathSelfQuery(Query P_0, string P_1, string P_2, XPathNodeType P_3)
		: base(P_0, P_1, P_2, P_3)
	{
	}

	private XPathSelfQuery(XPathSelfQuery P_0)
		: base(P_0)
	{
	}

	public override XPathNavigator Advance()
	{
		while ((currentNode = qyInput.Advance()) != null)
		{
			if (matches(currentNode))
			{
				position = 1;
				return currentNode;
			}
		}
		return null;
	}

	public override XPathNodeIterator Clone()
	{
		return new XPathSelfQuery(this);
	}
}
