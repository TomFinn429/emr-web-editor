using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace MS.Internal.Xml.XPath;

internal abstract class Query : ResettableIterator
{
	public override int Count
	{
		get
		{
			if (count == -1)
			{
				Query query = (Query)Clone();
				query.Reset();
				count = 0;
				while (query.MoveNext())
				{
					count++;
				}
			}
			return count;
		}
	}

	public abstract XPathResultType StaticType { get; }

	public virtual QueryProps Properties => QueryProps.Merge;

	public Query()
	{
	}

	protected Query(Query P_0)
		: base(P_0)
	{
	}

	public override bool MoveNext()
	{
		return Advance() != null;
	}

	public virtual void SetXsltContext(XsltContext P_0)
	{
	}

	public abstract object Evaluate(XPathNodeIterator P_0);

	public abstract XPathNavigator Advance();

	[return: NotNullIfNotNull("input")]
	public static Query Clone(Query P_0)
	{
		if (P_0 != null)
		{
			return (Query)P_0.Clone();
		}
		return null;
	}

	[return: NotNullIfNotNull("input")]
	protected static XPathNodeIterator Clone(XPathNodeIterator P_0)
	{
		return P_0?.Clone();
	}

	[return: NotNullIfNotNull("input")]
	protected static XPathNavigator Clone(XPathNavigator P_0)
	{
		return P_0?.Clone();
	}

	public static bool Insert(List<XPathNavigator> P_0, XPathNavigator P_1)
	{
		int num = 0;
		int num2 = P_0.Count;
		if (num2 != 0)
		{
			switch (CompareNodes(P_0[num2 - 1], P_1))
			{
			case XmlNodeOrder.Same:
				return false;
			case XmlNodeOrder.Before:
				P_0.Add(P_1.Clone());
				return true;
			}
			num2--;
		}
		while (num < num2)
		{
			int median = GetMedian(num, num2);
			switch (CompareNodes(P_0[median], P_1))
			{
			case XmlNodeOrder.Same:
				return false;
			case XmlNodeOrder.Before:
				num = median + 1;
				break;
			default:
				num2 = median;
				break;
			}
		}
		P_0.Insert(num, P_1.Clone());
		return true;
	}

	private static int GetMedian(int P_0, int P_1)
	{
		return P_0 + P_1 >>> 1;
	}

	public static XmlNodeOrder CompareNodes(XPathNavigator P_0, XPathNavigator P_1)
	{
		XmlNodeOrder xmlNodeOrder = P_0.ComparePosition(P_1);
		if (xmlNodeOrder == XmlNodeOrder.Unknown)
		{
			XPathNavigator xPathNavigator = P_0.Clone();
			xPathNavigator.MoveToRoot();
			string baseURI = xPathNavigator.BaseURI;
			if (!xPathNavigator.MoveTo(P_1))
			{
				xPathNavigator = P_1.Clone();
			}
			xPathNavigator.MoveToRoot();
			string baseURI2 = xPathNavigator.BaseURI;
			int num = string.CompareOrdinal(baseURI, baseURI2);
			xmlNodeOrder = ((num >= 0) ? ((num > 0) ? XmlNodeOrder.After : XmlNodeOrder.Unknown) : XmlNodeOrder.Before);
		}
		return xmlNodeOrder;
	}

	protected static XPathResultType GetXPathType(object P_0)
	{
		if (P_0 is XPathNodeIterator)
		{
			return XPathResultType.NodeSet;
		}
		if (P_0 is string)
		{
			return XPathResultType.String;
		}
		if (P_0 is double)
		{
			return XPathResultType.Number;
		}
		if (P_0 is bool)
		{
			return XPathResultType.Boolean;
		}
		return (XPathResultType)4;
	}
}
