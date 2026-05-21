using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace MS.Internal.Xml.XPath;

internal sealed class NumericExpr : ValueQuery
{
	private readonly Operator.Op _op;

	private readonly Query _opnd1;

	private readonly Query _opnd2;

	public override XPathResultType StaticType => XPathResultType.Number;

	public NumericExpr(Operator.Op P_0, Query P_1, Query P_2)
	{
		if (P_1.StaticType != XPathResultType.Number)
		{
			P_1 = new NumberFunctions(Function.FunctionType.FuncNumber, P_1);
		}
		if (P_2.StaticType != XPathResultType.Number)
		{
			P_2 = new NumberFunctions(Function.FunctionType.FuncNumber, P_2);
		}
		_op = P_0;
		_opnd1 = P_1;
		_opnd2 = P_2;
	}

	private NumericExpr(NumericExpr P_0)
		: base(P_0)
	{
		_op = P_0._op;
		_opnd1 = Query.Clone(P_0._opnd1);
		_opnd2 = Query.Clone(P_0._opnd2);
	}

	public override void SetXsltContext(XsltContext P_0)
	{
		_opnd1.SetXsltContext(P_0);
		_opnd2.SetXsltContext(P_0);
	}

	public override object Evaluate(XPathNodeIterator P_0)
	{
		return GetValue(_op, XmlConvert.ToXPathDouble(_opnd1.Evaluate(P_0)), XmlConvert.ToXPathDouble(_opnd2.Evaluate(P_0)));
	}

	private static double GetValue(Operator.Op P_0, double P_1, double P_2)
	{
		return P_0 switch
		{
			Operator.Op.PLUS => P_1 + P_2, 
			Operator.Op.MINUS => P_1 - P_2, 
			Operator.Op.MOD => P_1 % P_2, 
			Operator.Op.DIV => P_1 / P_2, 
			Operator.Op.MUL => P_1 * P_2, 
			_ => 0.0, 
		};
	}

	public override XPathNodeIterator Clone()
	{
		return new NumericExpr(this);
	}
}
