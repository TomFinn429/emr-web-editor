using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal class ContextQuery : Query
{
	protected XPathNavigator contextNode;

	public override XPathNavigator Current => contextNode;

	public override XPathResultType StaticType => XPathResultType.NodeSet;

	public override int CurrentPosition => count;

	public override int Count => 1;

	public override QueryProps Properties => (QueryProps)23;

	public ContextQuery()
	{
		count = 0;
	}

	protected ContextQuery(ContextQuery P_0)
		: base(P_0)
	{
		contextNode = P_0.contextNode;
	}

	public override void Reset()
	{
		count = 0;
	}

	public override object Evaluate(XPathNodeIterator P_0)
	{
		contextNode = P_0.Current;
		count = 0;
		return this;
	}

	public override XPathNavigator Advance()
	{
		if (count == 0)
		{
			count = 1;
			return contextNode;
		}
		return null;
	}

	public override XPathNodeIterator Clone()
	{
		return new ContextQuery(this);
	}
}
