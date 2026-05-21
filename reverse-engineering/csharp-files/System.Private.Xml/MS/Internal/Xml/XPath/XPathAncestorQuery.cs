using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal sealed class XPathAncestorQuery : CacheAxisQuery
{
	private readonly bool _matchSelf;

	public override int CurrentPosition => outputBuffer.Count - count + 1;

	public override QueryProps Properties => base.Properties | QueryProps.Reverse;

	public XPathAncestorQuery(Query P_0, string P_1, string P_2, XPathNodeType P_3, bool P_4)
		: base(P_0, P_1, P_2, P_3)
	{
		_matchSelf = P_4;
	}

	private XPathAncestorQuery(XPathAncestorQuery P_0)
		: base(P_0)
	{
		_matchSelf = P_0._matchSelf;
	}

	public override object Evaluate(XPathNodeIterator P_0)
	{
		base.Evaluate(P_0);
		XPathNavigator xPathNavigator = null;
		XPathNavigator xPathNavigator2;
		while ((xPathNavigator2 = qyInput.Advance()) != null)
		{
			if (!_matchSelf || !matches(xPathNavigator2) || Query.Insert(outputBuffer, xPathNavigator2))
			{
				if (xPathNavigator == null || !xPathNavigator.MoveTo(xPathNavigator2))
				{
					xPathNavigator = xPathNavigator2.Clone();
				}
				while (xPathNavigator.MoveToParent() && (!matches(xPathNavigator) || Query.Insert(outputBuffer, xPathNavigator)))
				{
				}
			}
		}
		return this;
	}

	public override XPathNodeIterator Clone()
	{
		return new XPathAncestorQuery(this);
	}
}
