using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal sealed class XPathDescendantIterator : XPathAxisIterator
{
	private int _level;

	public XPathDescendantIterator(XPathNavigator P_0, XPathNodeType P_1, bool P_2)
		: base(P_0, P_1, P_2)
	{
	}

	public XPathDescendantIterator(XPathNavigator P_0, string P_1, string P_2, bool P_3)
		: base(P_0, P_1, P_2, P_3)
	{
	}

	public XPathDescendantIterator(XPathDescendantIterator P_0)
		: base(P_0)
	{
		_level = P_0._level;
	}

	public override XPathNodeIterator Clone()
	{
		return new XPathDescendantIterator(this);
	}

	public override bool MoveNext()
	{
		if (_level == -1)
		{
			return false;
		}
		if (first)
		{
			first = false;
			if (matchSelf && Matches)
			{
				position = 1;
				return true;
			}
		}
		do
		{
			if (nav.MoveToFirstChild())
			{
				_level++;
				continue;
			}
			while (true)
			{
				if (_level == 0)
				{
					_level = -1;
					return false;
				}
				if (nav.MoveToNext())
				{
					break;
				}
				nav.MoveToParent();
				_level--;
			}
		}
		while (!Matches);
		position++;
		return true;
	}
}
