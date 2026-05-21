using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal sealed class ParentQuery : CacheAxisQuery
{
	public ParentQuery(Query P_0, string P_1, string P_2, XPathNodeType P_3)
		: base(P_0, P_1, P_2, P_3)
	{
	}

	private ParentQuery(ParentQuery P_0)
		: base(P_0)
	{
	}

	public override object Evaluate(XPathNodeIterator P_0)
	{
		base.Evaluate(P_0);
		XPathNavigator xPathNavigator;
		while ((xPathNavigator = qyInput.Advance()) != null)
		{
			xPathNavigator = xPathNavigator.Clone();
			if (xPathNavigator.MoveToParent() && matches(xPathNavigator))
			{
				Query.Insert(outputBuffer, xPathNavigator);
			}
		}
		return this;
	}

	public override XPathNodeIterator Clone()
	{
		return new ParentQuery(this);
	}
}
