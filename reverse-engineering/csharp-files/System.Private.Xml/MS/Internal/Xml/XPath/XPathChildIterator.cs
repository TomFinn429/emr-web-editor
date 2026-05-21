using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal sealed class XPathChildIterator : XPathAxisIterator
{
	public XPathChildIterator(XPathNavigator P_0, XPathNodeType P_1)
		: base(P_0, P_1, false)
	{
	}

	public XPathChildIterator(XPathNavigator P_0, string P_1, string P_2)
		: base(P_0, P_1, P_2, false)
	{
	}

	public XPathChildIterator(XPathChildIterator P_0)
		: base(P_0)
	{
	}

	public override XPathNodeIterator Clone()
	{
		return new XPathChildIterator(this);
	}

	public override bool MoveNext()
	{
		while (first ? nav.MoveToFirstChild() : nav.MoveToNext())
		{
			first = false;
			if (Matches)
			{
				position++;
				return true;
			}
		}
		return false;
	}
}
