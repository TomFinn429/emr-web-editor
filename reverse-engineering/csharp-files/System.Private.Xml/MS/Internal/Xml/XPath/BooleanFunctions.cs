using System;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace MS.Internal.Xml.XPath;

internal sealed class BooleanFunctions : ValueQuery
{
	private readonly Query _arg;

	private readonly Function.FunctionType _funcType;

	public override XPathResultType StaticType => XPathResultType.Boolean;

	public BooleanFunctions(Function.FunctionType P_0, Query P_1)
	{
		_arg = P_1;
		_funcType = P_0;
	}

	private BooleanFunctions(BooleanFunctions P_0)
		: base(P_0)
	{
		_arg = Query.Clone(P_0._arg);
		_funcType = P_0._funcType;
	}

	public override void SetXsltContext(XsltContext P_0)
	{
		_arg?.SetXsltContext(P_0);
	}

	public override object Evaluate(XPathNodeIterator P_0)
	{
		return _funcType switch
		{
			Function.FunctionType.FuncBoolean => toBoolean(P_0), 
			Function.FunctionType.FuncNot => Not(P_0), 
			Function.FunctionType.FuncTrue => true, 
			Function.FunctionType.FuncFalse => false, 
			Function.FunctionType.FuncLang => Lang(P_0), 
			_ => false, 
		};
	}

	internal static bool toBoolean(double P_0)
	{
		if (P_0 != 0.0)
		{
			return !double.IsNaN(P_0);
		}
		return false;
	}

	internal static bool toBoolean(string P_0)
	{
		return P_0.Length > 0;
	}

	internal bool toBoolean(XPathNodeIterator P_0)
	{
		object obj = _arg.Evaluate(P_0);
		if (obj is XPathNodeIterator)
		{
			return _arg.Advance() != null;
		}
		if (obj is string text)
		{
			return toBoolean(text);
		}
		if (obj is double)
		{
			return toBoolean((double)obj);
		}
		if (obj is bool)
		{
			return (bool)obj;
		}
		return true;
	}

	private bool Not(XPathNodeIterator P_0)
	{
		return !(bool)_arg.Evaluate(P_0);
	}

	private bool Lang(XPathNodeIterator P_0)
	{
		string text = _arg.Evaluate(P_0).ToString();
		string xmlLang = P_0.Current.XmlLang;
		if (xmlLang.StartsWith(text, StringComparison.OrdinalIgnoreCase))
		{
			if (xmlLang.Length != text.Length)
			{
				return xmlLang[text.Length] == '-';
			}
			return true;
		}
		return false;
	}

	public override XPathNodeIterator Clone()
	{
		return new BooleanFunctions(this);
	}
}
