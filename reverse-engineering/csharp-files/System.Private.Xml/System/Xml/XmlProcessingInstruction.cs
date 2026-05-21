using System.Diagnostics.CodeAnalysis;
using System.Xml.XPath;

namespace System.Xml;

public class XmlProcessingInstruction : XmlLinkedNode
{
	private readonly string _target;

	private string _data;

	public override string Name => _target;

	public override string LocalName => Name;

	public override string Value
	{
		get
		{
			return _data;
		}
		[param: AllowNull]
		set
		{
			Data = data;
		}
	}

	public string Data
	{
		[param: AllowNull]
		set
		{
			XmlNode xmlNode = ParentNode;
			string text = text2 ?? string.Empty;
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

	public override string InnerText
	{
		get
		{
			return _data;
		}
		[param: AllowNull]
		set
		{
			Data = data;
		}
	}

	public override XmlNodeType NodeType => XmlNodeType.ProcessingInstruction;

	internal override string XPLocalName => Name;

	internal override XPathNodeType XPNodeType => XPathNodeType.ProcessingInstruction;

	protected internal XmlProcessingInstruction(string P_0, string? P_1, XmlDocument P_2)
		: base(P_2)
	{
		ArgumentNullException.ThrowIfNull(P_0, "target");
		if (P_0.Length == 0)
		{
			throw new ArgumentException("Xml_EmptyName", "target");
		}
		_target = P_0;
		_data = P_1 ?? string.Empty;
	}

	public override XmlNode CloneNode(bool P_0)
	{
		return OwnerDocument.CreateProcessingInstruction(_target, _data);
	}
}
