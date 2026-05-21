using System;
using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal abstract class XPathAxisIterator : XPathNodeIterator
{
	internal XPathNavigator nav;

	internal XPathNodeType type;

	internal string name;

	internal string uri;

	internal int position;

	internal bool matchSelf;

	internal bool first = true;

	public override XPathNavigator Current => nav;

	public override int CurrentPosition => position;

	protected virtual bool Matches
	{
		get
		{
			if (name == null)
			{
				if (type != nav.NodeType && type != XPathNodeType.All)
				{
					if (type == XPathNodeType.Text)
					{
						if (nav.NodeType != XPathNodeType.Whitespace)
						{
							return nav.NodeType == XPathNodeType.SignificantWhitespace;
						}
						return true;
					}
					return false;
				}
				return true;
			}
			if (nav.NodeType == XPathNodeType.Element && (name.Length == 0 || name == nav.LocalName))
			{
				return uri == nav.NamespaceURI;
			}
			return false;
		}
	}

	public XPathAxisIterator(XPathNavigator P_0, bool P_1)
	{
		nav = P_0;
		matchSelf = P_1;
	}

	public XPathAxisIterator(XPathNavigator P_0, XPathNodeType P_1, bool P_2)
		: this(P_0, P_2)
	{
		type = P_1;
	}

	public XPathAxisIterator(XPathNavigator P_0, string P_1, string P_2, bool P_3)
		: this(P_0, P_3)
	{
		ArgumentNullException.ThrowIfNull(P_1, "name");
		ArgumentNullException.ThrowIfNull(P_2, "namespaceURI");
		name = P_1;
		uri = P_2;
	}

	public XPathAxisIterator(XPathAxisIterator P_0)
	{
		nav = P_0.nav.Clone();
		type = P_0.type;
		name = P_0.name;
		uri = P_0.uri;
		position = P_0.position;
		matchSelf = P_0.matchSelf;
		first = P_0.first;
	}
}
