using System.Xml.XPath;

namespace System.Xml.Xsl;

public abstract class XsltContext : XmlNamespaceManager
{
	public abstract bool Whitespace { get; }

	internal XsltContext(bool P_0)
	{
	}

	public abstract IXsltContextVariable ResolveVariable(string P_0, string P_1);

	public abstract IXsltContextFunction ResolveFunction(string P_0, string P_1, XPathResultType[] P_2);

	public abstract bool PreserveWhitespace(XPathNavigator P_0);
}
