using System.Xml.XPath;

namespace System.Xml.Xsl;

public interface IXsltContextVariable
{
	XPathResultType VariableType { get; }

	object Evaluate(XsltContext P_0);
}
