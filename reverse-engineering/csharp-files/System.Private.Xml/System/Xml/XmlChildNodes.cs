using System.Collections;

namespace System.Xml;

internal sealed class XmlChildNodes : XmlNodeList
{
	private readonly XmlNode _container;

	public override int Count
	{
		get
		{
			int num = 0;
			for (XmlNode xmlNode = _container.FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
			{
				num++;
			}
			return num;
		}
	}

	public XmlChildNodes(XmlNode P_0)
	{
		_container = P_0;
	}

	public override XmlNode Item(int P_0)
	{
		if (P_0 < 0)
		{
			return null;
		}
		XmlNode xmlNode = _container.FirstChild;
		while (xmlNode != null)
		{
			if (P_0 == 0)
			{
				return xmlNode;
			}
			xmlNode = xmlNode.NextSibling;
			P_0--;
		}
		return null;
	}

	public override IEnumerator GetEnumerator()
	{
		if (_container.FirstChild == null)
		{
			return XmlDocument.EmptyEnumerator;
		}
		return new XmlChildEnumerator(_container);
	}
}
