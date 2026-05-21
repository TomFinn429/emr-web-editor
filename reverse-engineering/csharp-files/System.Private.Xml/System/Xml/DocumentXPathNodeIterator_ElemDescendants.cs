using System.Xml.XPath;

namespace System.Xml;

internal abstract class DocumentXPathNodeIterator_ElemDescendants : XPathNodeIterator
{
	private readonly DocumentXPathNavigator _nav;

	private int _level;

	private int _position;

	public override XPathNavigator Current => _nav;

	public override int CurrentPosition => _position;

	internal DocumentXPathNodeIterator_ElemDescendants(DocumentXPathNavigator P_0)
	{
		_nav = (DocumentXPathNavigator)P_0.Clone();
		_level = 0;
		_position = 0;
	}

	internal DocumentXPathNodeIterator_ElemDescendants(DocumentXPathNodeIterator_ElemDescendants P_0)
	{
		_nav = (DocumentXPathNavigator)P_0._nav.Clone();
		_level = P_0._level;
		_position = P_0._position;
	}

	protected abstract bool Match(XmlNode P_0);

	protected void SetPosition(int P_0)
	{
		_position = P_0;
	}

	public override bool MoveNext()
	{
		XmlNode xmlNode;
		do
		{
			if (_nav.MoveToFirstChild())
			{
				_level++;
			}
			else
			{
				if (_level == 0)
				{
					return false;
				}
				while (!_nav.MoveToNext())
				{
					_level--;
					if (_level == 0)
					{
						return false;
					}
					if (!_nav.MoveToParent())
					{
						return false;
					}
				}
			}
			xmlNode = (XmlNode)_nav.UnderlyingObject;
		}
		while (xmlNode.NodeType != XmlNodeType.Element || !Match(xmlNode));
		_position++;
		return true;
	}
}
