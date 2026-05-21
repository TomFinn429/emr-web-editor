using System;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace MS.Internal.Xml.XPath;

internal sealed class NumberFunctions : ValueQuery
{
	private readonly Query _arg;

	private readonly Function.FunctionType _ftype;

	public override XPathResultType StaticType => XPathResultType.Number;

	public NumberFunctions(Function.FunctionType P_0, Query P_1)
	{
		_arg = P_1;
		_ftype = P_0;
	}

	private NumberFunctions(NumberFunctions P_0)
		: base(P_0)
	{
		_arg = Query.Clone(P_0._arg);
		_ftype = P_0._ftype;
	}

	public override void SetXsltContext(XsltContext P_0)
	{
		_arg?.SetXsltContext(P_0);
	}

	internal static double Number(bool P_0)
	{
		if (!P_0)
		{
			return 0.0;
		}
		return 1.0;
	}

	internal static double Number(string P_0)
	{
		return XmlConvert.ToXPathDouble(P_0);
	}

	public override object Evaluate(XPathNodeIterator P_0)
	{
		return _ftype switch
		{
			Function.FunctionType.FuncNumber => Number(P_0), 
			Function.FunctionType.FuncSum => Sum(P_0), 
			Function.FunctionType.FuncFloor => Floor(P_0), 
			Function.FunctionType.FuncCeiling => Ceiling(P_0), 
			Function.FunctionType.FuncRound => Round(P_0), 
			_ => throw new InvalidOperationException(), 
		};
	}

	private double Number(XPathNodeIterator P_0)
	{
		if (_arg == null)
		{
			return XmlConvert.ToXPathDouble(P_0.Current.Value);
		}
		object obj = _arg.Evaluate(P_0);
		switch (Query.GetXPathType(obj))
		{
		case XPathResultType.NodeSet:
		{
			XPathNavigator xPathNavigator = _arg.Advance();
			if (xPathNavigator != null)
			{
				return Number(xPathNavigator.Value);
			}
			break;
		}
		case XPathResultType.String:
			return Number((string)obj);
		case XPathResultType.Boolean:
			return Number((bool)obj);
		case XPathResultType.Number:
			return (double)obj;
		case (XPathResultType)4:
			return Number(((XPathNavigator)obj).Value);
		}
		return 0.0 / 0.0;
	}

	private double Sum(XPathNodeIterator P_0)
	{
		double num = 0.0;
		_arg.Evaluate(P_0);
		XPathNavigator xPathNavigator;
		while ((xPathNavigator = _arg.Advance()) != null)
		{
			num += Number(xPathNavigator.Value);
		}
		return num;
	}

	private double Floor(XPathNodeIterator P_0)
	{
		return Math.Floor((double)_arg.Evaluate(P_0));
	}

	private double Ceiling(XPathNodeIterator P_0)
	{
		return Math.Ceiling((double)_arg.Evaluate(P_0));
	}

	private double Round(XPathNodeIterator P_0)
	{
		double num = XmlConvert.ToXPathDouble(_arg.Evaluate(P_0));
		return XmlConvert.XPathRound(num);
	}

	public override XPathNodeIterator Clone()
	{
		return new NumberFunctions(this);
	}
}
