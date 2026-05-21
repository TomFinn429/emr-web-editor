using System.Xml.XPath;

namespace System.Xml.Xsl;

public interface IXsltContextFunction
{
	XPathResultType ReturnType { get; }

	object Invoke(XsltContext P_0, object[] P_1, XPathNavigator P_2);
}
