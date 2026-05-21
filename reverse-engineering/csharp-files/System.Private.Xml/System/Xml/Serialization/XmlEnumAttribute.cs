namespace System.Xml.Serialization;

[AttributeUsage(AttributeTargets.Field)]
public class XmlEnumAttribute : Attribute
{
	private string _name;

	public XmlEnumAttribute(string? P_0)
	{
		_name = P_0;
	}
}
