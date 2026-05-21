using System.Diagnostics.CodeAnalysis;
using System.Xml.XPath;

namespace System.Xml;

public abstract class XmlCharacterData : XmlLinkedNode
{
	private string _data;

	public override string? Value
	{
		get
		{
			return Data;
		}
		set
		{
			Data = data;
		}
	}

	public override string InnerText
	{
		get
		{
			return Value;
		}
		set
		{
			Value = value2;
		}
	}

	public virtual string Data
	{
		get
		{
			if (_data != null)
			{
				return _data;
			}
			return string.Empty;
		}
		[param: AllowNull]
		set
		{
			XmlNode xmlNode = ParentNode;
			XmlNodeChangedEventArgs eventArgs = GetEventArgs(this, xmlNode, xmlNode, _data, text, XmlNodeChangedAction.Change);
			if (eventArgs != null)
			{
				BeforeEvent(eventArgs);
			}
			_data = text;
			if (eventArgs != null)
			{
				AfterEvent(eventArgs);
			}
		}
	}

	protected internal XmlCharacterData(string? P_0, XmlDocument P_1)
		: base(P_1)
	{
		_data = P_0;
	}

	internal static bool CheckOnData(string P_0)
	{
		return XmlCharType.IsOnlyWhitespace(P_0);
	}

	internal bool DecideXPNodeTypeForTextNodes(XmlNode P_0, ref XPathNodeType P_1)
	{
		for (XmlNode xmlNode = P_0; xmlNode != null; xmlNode = xmlNode.NextSibling)
		{
			switch (xmlNode.NodeType)
			{
			case XmlNodeType.SignificantWhitespace:
				P_1 = XPathNodeType.SignificantWhitespace;
				break;
			case XmlNodeType.Text:
			case XmlNodeType.CDATA:
				P_1 = XPathNodeType.Text;
				return false;
			case XmlNodeType.EntityReference:
				if (!DecideXPNodeTypeForTextNodes(xmlNode.FirstChild, ref P_1))
				{
					return false;
				}
				break;
			default:
				return false;
			case XmlNodeType.Whitespace:
				break;
			}
		}
		return true;
	}
}
