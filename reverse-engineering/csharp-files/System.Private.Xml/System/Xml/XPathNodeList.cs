using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;

namespace System.Xml;

internal sealed class XPathNodeList : XmlNodeList
{
	private readonly List<XmlNode> _list;

	private readonly XPathNodeIterator _nodeIterator;

	private bool _done;

	public override int Count
	{
		get
		{
			if (!_done)
			{
				ReadUntil(2147483647);
			}
			return _list.Count;
		}
	}

	public XPathNodeList(XPathNodeIterator P_0)
	{
		_nodeIterator = P_0;
		_list = new List<XmlNode>();
		_done = false;
	}

	private static XmlNode GetNode(XPathNavigator P_0)
	{
		IHasXmlNode hasXmlNode = (IHasXmlNode)P_0;
		return hasXmlNode.GetNode();
	}

	internal int ReadUntil(int P_0)
	{
		int num = _list.Count;
		while (!_done && num <= P_0)
		{
			if (_nodeIterator.MoveNext())
			{
				XmlNode node = GetNode(_nodeIterator.Current);
				if (node != null)
				{
					_list.Add(node);
					num++;
				}
				continue;
			}
			_done = true;
			break;
		}
		return num;
	}

	public override XmlNode Item(int P_0)
	{
		if (_list.Count <= P_0)
		{
			ReadUntil(P_0);
		}
		if (P_0 < 0 || _list.Count <= P_0)
		{
			return null;
		}
		return _list[P_0];
	}

	public override IEnumerator GetEnumerator()
	{
		return new XmlNodeListEnumerator(this);
	}
}
