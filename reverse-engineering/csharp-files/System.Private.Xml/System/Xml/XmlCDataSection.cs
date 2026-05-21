using System.Xml.XPath;

namespace System.Xml;

public class XmlCDataSection : XmlCharacterData
{
	public override string Name => OwnerDocument.strCDataSectionName;

	public override string LocalName => OwnerDocument.strCDataSectionName;

	public override XmlNodeType NodeType => XmlNodeType.CDATA;

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

	protected internal XmlCDataSection(string? P_0, XmlDocument P_1)
		: base(P_0, P_1)
	{
	}

	public override XmlNode CloneNode(bool P_0)
	{
		return OwnerDocument.CreateCDataSection(Data);
	}
}
