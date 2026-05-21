using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal class ForwardPositionQuery : CacheOutputQuery
{
	public ForwardPositionQuery(Query P_0)
		: base(P_0)
	{
	}

	protected ForwardPositionQuery(ForwardPositionQuery P_0)
		: base(P_0)
	{
	}

	public override object Evaluate(XPathNodeIterator P_0)
	{
		base.Evaluate(P_0);
		XPathNavigator xPathNavigator;
		while ((xPathNavigator = input.Advance()) != null)
		{
			outputBuffer.Add(xPathNavigator.Clone());
		}
		return this;
	}

	public override XPathNodeIterator Clone()
	{
		return new ForwardPositionQuery(this);
	}
}
