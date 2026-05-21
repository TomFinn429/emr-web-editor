using System.Xml;
using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal sealed class IDQuery : CacheOutputQuery
{
	public IDQuery(Query P_0)
		: base(P_0)
	{
	}

	private IDQuery(IDQuery P_0)
		: base(P_0)
	{
	}

	public override object Evaluate(XPathNodeIterator P_0)
	{
		object obj = base.Evaluate(P_0);
		XPathNavigator xPathNavigator = P_0.Current.Clone();
		switch (Query.GetXPathType(obj))
		{
		case XPathResultType.NodeSet:
		{
			XPathNavigator xPathNavigator2;
			while ((xPathNavigator2 = input.Advance()) != null)
			{
				ProcessIds(xPathNavigator, xPathNavigator2.Value);
			}
			break;
		}
		case XPathResultType.String:
			ProcessIds(xPathNavigator, (string)obj);
			break;
		case XPathResultType.Number:
			ProcessIds(xPathNavigator, StringFunctions.toString((double)obj));
			break;
		case XPathResultType.Boolean:
			ProcessIds(xPathNavigator, StringFunctions.toString((bool)obj));
			break;
		case (XPathResultType)4:
			ProcessIds(xPathNavigator, ((XPathNavigator)obj).Value);
			break;
		}
		return this;
	}

	private void ProcessIds(XPathNavigator P_0, string P_1)
	{
		string[] array = XmlConvert.SplitString(P_1);
		for (int i = 0; i < array.Length; i++)
		{
			if (P_0.MoveToId(array[i]))
			{
				Query.Insert(outputBuffer, P_0);
			}
		}
	}

	public override XPathNodeIterator Clone()
	{
		return new IDQuery(this);
	}
}
