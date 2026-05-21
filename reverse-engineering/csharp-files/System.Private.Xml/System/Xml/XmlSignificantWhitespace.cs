using System.Xml.XPath;

namespace System.Xml;

public class XmlSignificantWhitespace : XmlCharacterData
{
	public override string Name => OwnerDocument.strSignificantWhitespaceName;

	public override string LocalName => OwnerDocument.strSignificantWhitespaceName;

	public override XmlNodeType NodeType => XmlNodeType.SignificantWhitespace;

	public override XmlNode? ParentNode
	{
		get
		{
			switch (parentNode.NodeType)
			{
			case XmlNodeType.Document:
				return base.ParentNode;
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
			if (XmlCharacterData.CheckOnData(text))
			{
				Data = text;
				return;
			}
			throw new ArgumentException("Xdom_WS_Char");
		}
	}

	internal override XPathNodeType XPNodeType
	{
		get
		{
			XPathNodeType result = XPathNodeType.SignificantWhitespace;
			DecideXPNodeTypeForTextNodes(this, ref result);
			return result;
		}
	}

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

	protected internal XmlSignificantWhitespace(string? P_0, XmlDocument P_1)
		: base(P_0, P_1)
	{
		if (!P_1.IsLoading && !XmlCharacterData.CheckOnData(P_0))
		{
			throw new ArgumentException("Xdom_WS_Char");
		}
	}

	public override XmlNode CloneNode(bool P_0)
	{
		return OwnerDocument.CreateSignificantWhitespace(Data);
	}
}
