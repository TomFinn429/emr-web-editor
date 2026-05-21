namespace System.Xml;

internal sealed class XmlUnspecifiedAttribute : XmlAttribute
{
	private bool _fSpecified;

	public override bool Specified => _fSpecified;

	public override string InnerText
	{
		set
		{
			base.InnerText = innerText;
			_fSpecified = true;
		}
	}

	internal XmlUnspecifiedAttribute(string P_0, string P_1, string P_2, XmlDocument P_3)
		: base(P_0, P_1, P_2, P_3)
	{
	}

	public override XmlNode CloneNode(bool P_0)
	{
		XmlDocument ownerDocument = OwnerDocument;
		XmlUnspecifiedAttribute xmlUnspecifiedAttribute = (XmlUnspecifiedAttribute)ownerDocument.CreateDefaultAttribute(Prefix, LocalName, NamespaceURI);
		xmlUnspecifiedAttribute.CopyChildren(ownerDocument, this, true);
		xmlUnspecifiedAttribute._fSpecified = true;
		return xmlUnspecifiedAttribute;
	}

	public override XmlNode RemoveChild(XmlNode P_0)
	{
		XmlNode result = base.RemoveChild(P_0);
		_fSpecified = true;
		return result;
	}

	public override XmlNode AppendChild(XmlNode P_0)
	{
		XmlNode result = base.AppendChild(P_0);
		_fSpecified = true;
		return result;
	}

	internal void SetSpecified(bool P_0)
	{
		_fSpecified = P_0;
	}
}
