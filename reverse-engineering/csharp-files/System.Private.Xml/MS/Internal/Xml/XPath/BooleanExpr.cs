using System.Xml.XPath;
using System.Xml.Xsl;

namespace MS.Internal.Xml.XPath;

internal sealed class BooleanExpr : ValueQuery
{
	private readonly Query _opnd1;

	private readonly Query _opnd2;

	private readonly bool _isOr;

	public override XPathResultType StaticType => XPathResultType.Boolean;

	public BooleanExpr(Operator.Op P_0, Query P_1, Query P_2)
	{
		if (P_1.StaticType != XPathResultType.Boolean)
		{
			P_1 = new BooleanFunctions(Function.FunctionType.FuncBoolean, P_1);
		}
		if (P_2.StaticType != XPathResultType.Boolean)
		{
			P_2 = new BooleanFunctions(Function.FunctionType.FuncBoolean, P_2);
		}
		_opnd1 = P_1;
		_opnd2 = P_2;
		_isOr = P_0 == Operator.Op.OR;
	}

	private BooleanExpr(BooleanExpr P_0)
		: base(P_0)
	{
		_opnd1 = Query.Clone(P_0._opnd1);
		_opnd2 = Query.Clone(P_0._opnd2);
		_isOr = P_0._isOr;
	}

	public override void SetXsltContext(XsltContext P_0)
	{
		_opnd1.SetXsltContext(P_0);
		_opnd2.SetXsltContext(P_0);
	}

	public override object Evaluate(XPathNodeIterator P_0)
	{
		object obj = _opnd1.Evaluate(P_0);
		if ((bool)obj == _isOr)
		{
			return obj;
		}
		return _opnd2.Evaluate(P_0);
	}

	public override XPathNodeIterator Clone()
	{
		return new BooleanExpr(this);
	}
}
