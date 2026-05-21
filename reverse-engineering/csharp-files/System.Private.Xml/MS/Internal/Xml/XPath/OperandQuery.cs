using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal sealed class OperandQuery : ValueQuery
{
	internal object val;

	public override XPathResultType StaticType => Query.GetXPathType(val);

	public OperandQuery(object P_0)
	{
		val = P_0;
	}

	public override object Evaluate(XPathNodeIterator P_0)
	{
		return val;
	}

	public override XPathNodeIterator Clone()
	{
		return this;
	}
}
