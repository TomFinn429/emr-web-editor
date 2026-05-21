using MS.Internal.Xml.XPath;

namespace System.Xml.XPath;

public abstract class XPathExpression
{
	internal XPathExpression()
	{
	}

	public abstract void SetContext(IXmlNamespaceResolver? P_0);

	public static XPathExpression Compile(string P_0)
	{
		return Compile(P_0, null);
	}

	public static XPathExpression Compile(string P_0, IXmlNamespaceResolver? P_1)
	{
		bool flag;
		Query query = new QueryBuilder().Build(P_0, out flag);
		CompiledXpathExpr compiledXpathExpr = new CompiledXpathExpr(query, P_0, flag);
		if (P_1 != null)
		{
			compiledXpathExpr.SetContext(P_1);
		}
		return compiledXpathExpr;
	}
}
