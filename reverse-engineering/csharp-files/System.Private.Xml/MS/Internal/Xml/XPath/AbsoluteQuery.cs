using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal sealed class AbsoluteQuery : ContextQuery
{
	public AbsoluteQuery()
	{
	}

	private AbsoluteQuery(AbsoluteQuery P_0)
		: base(P_0)
	{
	}

	public override object Evaluate(XPathNodeIterator P_0)
	{
		contextNode = P_0.Current.Clone();
		contextNode.MoveToRoot();
		count = 0;
		return this;
	}

	public override XPathNodeIterator Clone()
	{
		return new AbsoluteQuery(this);
	}
}
