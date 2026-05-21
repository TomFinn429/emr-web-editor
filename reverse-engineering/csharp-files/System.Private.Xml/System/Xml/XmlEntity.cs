namespace System.Xml;

public class XmlEntity : XmlNode
{
	private readonly string _publicId;

	private readonly string _systemId;

	private readonly string _notationName;

	private readonly string _name;

	private string _baseURI = string.Empty;

	private XmlLinkedNode _lastChild;

	private bool _childrenFoliating;

	public override bool IsReadOnly => true;

	public override string Name => _name;

	public override string LocalName => _name;

	public override string InnerText
	{
		get
		{
			return base.InnerText;
		}
		set
		{
			throw new InvalidOperationException("Xdom_Ent_Innertext");
		}
	}

	internal override bool IsContainer => true;

	internal override XmlLinkedNode? LastNode
	{
		get
		{
			if (_lastChild == null && !_childrenFoliating)
			{
				_childrenFoliating = true;
				XmlLoader xmlLoader = new XmlLoader();
				xmlLoader.ExpandEntity(this);
			}
			return _lastChild;
		}
		set
		{
			_lastChild = lastChild;
		}
	}

	public override XmlNodeType NodeType => XmlNodeType.Entity;

	public string? SystemId => _systemId;

	public override string InnerXml
	{
		set
		{
			throw new InvalidOperationException("Xdom_Set_InnerXml");
		}
	}

	public override string BaseURI => _baseURI;

	internal XmlEntity(string P_0, string P_1, string P_2, string P_3, string P_4, XmlDocument P_5)
		: base(P_5)
	{
		_name = P_5.NameTable.Add(P_0);
		_publicId = P_2;
		_systemId = P_3;
		_notationName = P_4;
		_childrenFoliating = false;
	}

	public override XmlNode CloneNode(bool P_0)
	{
		throw new InvalidOperationException("Xdom_Node_Cloning");
	}

	internal override bool IsValidChildType(XmlNodeType P_0)
	{
		if (P_0 != XmlNodeType.Text && P_0 != XmlNodeType.Element && P_0 != XmlNodeType.ProcessingInstruction && P_0 != XmlNodeType.Comment && P_0 != XmlNodeType.CDATA && P_0 != XmlNodeType.Whitespace && P_0 != XmlNodeType.SignificantWhitespace)
		{
			return P_0 == XmlNodeType.EntityReference;
		}
		return true;
	}

	internal void SetBaseURI(string P_0)
	{
		_baseURI = P_0;
	}
}
