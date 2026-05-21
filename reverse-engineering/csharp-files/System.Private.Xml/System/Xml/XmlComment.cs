using System.Xml.XPath;

namespace System.Xml;

public class XmlComment : XmlCharacterData
{
	public override string Name => OwnerDocument.strCommentName;

	public override string LocalName => OwnerDocument.strCommentName;

	public override XmlNodeType NodeType => XmlNodeType.Comment;

	internal override XPathNodeType XPNodeType => XPathNodeType.Comment;

	protected internal XmlComment(string? P_0, XmlDocument P_1)
		: base(P_0, P_1)
	{
	}

	public override XmlNode CloneNode(bool P_0)
	{
		return OwnerDocument.CreateComment(Data);
	}
}
