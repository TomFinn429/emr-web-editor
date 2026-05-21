namespace System.Xml.Serialization;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = true)]
public class XmlElementAttribute : Attribute
{
	private string _elementName;

	private Type _type;

	private int _order = -1;

	public XmlElementAttribute(string? P_0, Type? P_1)
	{
		_elementName = P_0;
		_type = P_1;
	}
}
