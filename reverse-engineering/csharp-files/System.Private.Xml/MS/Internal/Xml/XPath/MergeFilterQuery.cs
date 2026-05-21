using System.Xml.XPath;
using System.Xml.Xsl;

namespace MS.Internal.Xml.XPath;

internal sealed class MergeFilterQuery : CacheOutputQuery
{
	private readonly Query _child;

	public MergeFilterQuery(Query P_0, Query P_1)
		: base(P_0)
	{
		_child = P_1;
	}

	private MergeFilterQuery(MergeFilterQuery P_0)
		: base(P_0)
	{
		_child = Query.Clone(P_0._child);
	}

	public override void SetXsltContext(XsltContext P_0)
	{
		base.SetXsltContext(P_0);
		_child.SetXsltContext(P_0);
	}

	public override object Evaluate(XPathNodeIterator P_0)
	{
		base.Evaluate(P_0);
		while (input.Advance() != null)
		{
			_child.Evaluate(input);
			XPathNavigator xPathNavigator;
			while ((xPathNavigator = _child.Advance()) != null)
			{
				Query.Insert(outputBuffer, xPathNavigator);
			}
		}
		return this;
	}

	public override XPathNodeIterator Clone()
	{
		return new MergeFilterQuery(this);
	}
}
