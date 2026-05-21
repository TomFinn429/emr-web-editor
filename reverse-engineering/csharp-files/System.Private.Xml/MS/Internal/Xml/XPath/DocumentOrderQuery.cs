using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal sealed class DocumentOrderQuery : CacheOutputQuery
{
	public DocumentOrderQuery(Query P_0)
		: base(P_0)
	{
	}

	private DocumentOrderQuery(DocumentOrderQuery P_0)
		: base(P_0)
	{
	}

	public override object Evaluate(XPathNodeIterator P_0)
	{
		base.Evaluate(P_0);
		XPathNavigator xPathNavigator;
		while ((xPathNavigator = input.Advance()) != null)
		{
			Query.Insert(outputBuffer, xPathNavigator);
		}
		return this;
	}

	public override XPathNodeIterator Clone()
	{
		return new DocumentOrderQuery(this);
	}
}
