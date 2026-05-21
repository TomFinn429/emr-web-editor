namespace System.Xml;

public class XmlEntityReference : XmlLinkedNode
{
	private readonly string _name;

	private XmlLinkedNode _lastChild;

	public override string Name => _name;

	public override string LocalName => _name;

	public override string? Value
	{
		get
		{
			return null;
		}
		set
		{
			throw new InvalidOperationException("Xdom_EntRef_SetVal");
		}
	}

	public override XmlNodeType NodeType => XmlNodeType.EntityReference;

	public override bool IsReadOnly => true;

	internal override bool IsContainer => true;

	internal override XmlLinkedNode? LastNode
	{
		get
		{
			return _lastChild;
		}
		set
		{
			_lastChild = lastChild;
		}
	}

	public override string BaseURI => OwnerDocument.BaseURI;

	internal string ChildBaseURI
	{
		get
		{
			XmlEntity entityNode = OwnerDocument.GetEntityNode(_name);
			if (entityNode != null)
			{
				if (!string.IsNullOrEmpty(entityNode.SystemId))
				{
					return ConstructBaseURI(entityNode.BaseURI, entityNode.SystemId);
				}
				return entityNode.BaseURI;
			}
			return string.Empty;
		}
	}

	protected internal XmlEntityReference(string P_0, XmlDocument P_1)
		: base(P_1)
	{
		if (!P_1.IsLoading && P_0.StartsWith('#'))
		{
			throw new ArgumentException("Xdom_InvalidCharacter_EntityReference");
		}
		_name = P_1.NameTable.Add(P_0);
		P_1.fEntRefNodesPresent = true;
	}

	public override XmlNode CloneNode(bool P_0)
	{
		return OwnerDocument.CreateEntityReference(_name);
	}

	internal override void SetParent(XmlNode P_0)
	{
		base.SetParent(P_0);
		if (LastNode == null && P_0 != null && P_0 != OwnerDocument)
		{
			XmlLoader xmlLoader = new XmlLoader();
			xmlLoader.ExpandEntityReference(this);
		}
	}

	internal override void SetParentForLoad(XmlNode P_0)
	{
		SetParent(P_0);
	}

	internal override bool IsValidChildType(XmlNodeType P_0)
	{
		switch (P_0)
		{
		case XmlNodeType.Element:
		case XmlNodeType.Text:
		case XmlNodeType.CDATA:
		case XmlNodeType.EntityReference:
		case XmlNodeType.ProcessingInstruction:
		case XmlNodeType.Comment:
		case XmlNodeType.Whitespace:
		case XmlNodeType.SignificantWhitespace:
			return true;
		default:
			return false;
		}
	}

	private static string ConstructBaseURI(string P_0, string P_1)
	{
		if (P_0 == null)
		{
			return P_1;
		}
		int num = P_0.LastIndexOf('/') + 1;
		string text = P_0;
		if (num > 0 && num < P_0.Length)
		{
			text = P_0.Substring(0, num);
		}
		else if (num == 0)
		{
			text += "\\";
		}
		return text + P_1.Replace('\\', '/');
	}
}
