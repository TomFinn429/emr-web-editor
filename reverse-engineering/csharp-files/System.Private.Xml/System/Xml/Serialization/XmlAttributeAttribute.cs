namespace System.Xml.Serialization;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
public class XmlAttributeAttribute : Attribute
{
	private string _attributeName;

	public XmlAttributeAttribute(string? P_0)
	{
		_attributeName = P_0;
	}
}
