namespace System.Xml;

public interface IXmlNamespaceResolver
{
	string? LookupNamespace(string P_0);

	string? LookupPrefix(string P_0);
}
