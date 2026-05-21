namespace System.Xml;

public class XmlNotation : XmlNode
{
	private readonly string _publicId;

	private readonly string _systemId;

	private readonly string _name;

	public override string Name => _name;

	public override string LocalName => _name;

	public override XmlNodeType NodeType => XmlNodeType.Notation;

	public override bool IsReadOnly => true;

	public override string InnerXml
	{
		set
		{
			throw new InvalidOperationException("Xdom_Set_InnerXml");
		}
	}

	internal XmlNotation(string P_0, string P_1, string P_2, XmlDocument P_3)
		: base(P_3)
	{
		_name = P_3.NameTable.Add(P_0);
		_publicId = P_1;
		_systemId = P_2;
	}

	public override XmlNode CloneNode(bool P_0)
	{
		throw new InvalidOperationException("Xdom_Node_Cloning");
	}
}
