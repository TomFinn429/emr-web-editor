using System.Xml.XPath;
using System.Xml.Xsl;

namespace MS.Internal.Xml.XPath;

internal sealed class VariableQuery : ExtensionQuery
{
	private IXsltContextVariable _variable;

	public override XPathResultType StaticType
	{
		get
		{
			if (_variable != null)
			{
				return Query.GetXPathType(Evaluate(null));
			}
			XPathResultType xPathResultType = ((_variable != null) ? _variable.VariableType : XPathResultType.Any);
			if (xPathResultType == XPathResultType.Error)
			{
				xPathResultType = XPathResultType.Any;
			}
			return xPathResultType;
		}
	}

	public VariableQuery(string P_0, string P_1)
		: base(P_1, P_0)
	{
	}

	private VariableQuery(VariableQuery P_0)
		: base(P_0)
	{
		_variable = P_0._variable;
	}

	public override void SetXsltContext(XsltContext P_0)
	{
		if (P_0 == null)
		{
			throw XPathException.Create("Xp_NoContext");
		}
		if (xsltContext != P_0)
		{
			xsltContext = P_0;
			_variable = xsltContext.ResolveVariable(prefix, name);
			if (_variable == null)
			{
				throw XPathException.Create("Xp_UndefVar", base.QName);
			}
		}
	}

	public override object Evaluate(XPathNodeIterator P_0)
	{
		if (xsltContext == null)
		{
			throw XPathException.Create("Xp_NoContext");
		}
		return ProcessResult(_variable.Evaluate(xsltContext));
	}

	public override XPathNodeIterator Clone()
	{
		return new VariableQuery(this);
	}
}
