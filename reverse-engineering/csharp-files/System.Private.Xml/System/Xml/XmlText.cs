using System.Xml.XPath;

namespace System.Xml;

public class XmlText : XmlCharacterData
{
	public override string Name => OwnerDocument.strTextName;

	public override string LocalName => OwnerDocument.strTextName;

	public override XmlNodeType NodeType => XmlNodeType.Text;

	public override XmlNode? ParentNode
	{
		get
		{
			switch (parentNode.NodeType)
			{
			case XmlNodeType.Document:
				return null;
			case XmlNodeType.Text:
			case XmlNodeType.CDATA:
			case XmlNodeType.Whitespace:
			case XmlNodeType.SignificantWhitespace:
			{
				XmlNode xmlNode = parentNode.parentNode;
				while (xmlNode.IsText)
				{
					xmlNode = xmlNode.parentNode;
				}
				return xmlNode;
			}
			default:
				return parentNode;
			}
		}
	}

	public override string? Value
	{
		get
		{
			return Data;
		}
		set
		{
			Data = data;
			XmlNode xmlNode = parentNode;
			if (xmlNode != null && xmlNode.NodeType == XmlNodeType.Attribute && xmlNode is XmlUnspecifiedAttribute { Specified: false } xmlUnspecifiedAttribute)
			{
				xmlUnspecifiedAttribute.SetSpecified(true);
			}
		}
	}

	internal override XPathNodeType XPNodeType => XPathNodeType.Text;

	internal override bool IsText => true;

	public override XmlNode? PreviousText
	{
		get
		{
			if (parentNode != null && parentNode.IsText)
			{
				return parentNode;
			}
			return null;
		}
	}

	internal XmlText(string P_0)
		: this(P_0, null)
	{
	}

	protected internal XmlText(string? P_0, XmlDocument P_1)
		: base(P_0, P_1)
	{
	}

	public override XmlNode CloneNode(bool P_0)
	{
		return OwnerDocument.CreateTextNode(Data);
	}
}
