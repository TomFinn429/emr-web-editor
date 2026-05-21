using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace MS.Internal.Xml.XPath;

internal sealed class StringFunctions : ValueQuery
{
	private readonly Function.FunctionType _funcType;

	private readonly IList<Query> _argList;

	private static readonly CompareInfo s_compareInfo = CultureInfo.InvariantCulture.CompareInfo;

	public override XPathResultType StaticType
	{
		get
		{
			if (_funcType == Function.FunctionType.FuncStringLength)
			{
				return XPathResultType.Number;
			}
			if (_funcType == Function.FunctionType.FuncStartsWith || _funcType == Function.FunctionType.FuncContains)
			{
				return XPathResultType.Boolean;
			}
			return XPathResultType.String;
		}
	}

	public StringFunctions(Function.FunctionType P_0, IList<Query> P_1)
	{
		_funcType = P_0;
		_argList = P_1;
	}

	private StringFunctions(StringFunctions P_0)
		: base(P_0)
	{
		_funcType = P_0._funcType;
		Query[] array = new Query[P_0._argList.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = Query.Clone(P_0._argList[i]);
		}
		_argList = array;
	}

	public override void SetXsltContext(XsltContext P_0)
	{
		for (int i = 0; i < _argList.Count; i++)
		{
			_argList[i].SetXsltContext(P_0);
		}
	}

	public override object Evaluate(XPathNodeIterator P_0)
	{
		return _funcType switch
		{
			Function.FunctionType.FuncString => toString(P_0), 
			Function.FunctionType.FuncConcat => Concat(P_0), 
			Function.FunctionType.FuncStartsWith => StartsWith(P_0), 
			Function.FunctionType.FuncContains => Contains(P_0), 
			Function.FunctionType.FuncSubstringBefore => SubstringBefore(P_0), 
			Function.FunctionType.FuncSubstringAfter => SubstringAfter(P_0), 
			Function.FunctionType.FuncSubstring => Substring(P_0), 
			Function.FunctionType.FuncStringLength => StringLength(P_0), 
			Function.FunctionType.FuncNormalize => Normalize(P_0), 
			Function.FunctionType.FuncTranslate => Translate(P_0), 
			_ => string.Empty, 
		};
	}

	internal static string toString(double P_0)
	{
		return P_0.ToString("R", NumberFormatInfo.InvariantInfo);
	}

	internal static string toString(bool P_0)
	{
		if (!P_0)
		{
			return "false";
		}
		return "true";
	}

	private string toString(XPathNodeIterator P_0)
	{
		if (_argList.Count > 0)
		{
			object obj = _argList[0].Evaluate(P_0);
			switch (Query.GetXPathType(obj))
			{
			case XPathResultType.NodeSet:
			{
				XPathNavigator xPathNavigator = _argList[0].Advance();
				if (xPathNavigator == null)
				{
					return string.Empty;
				}
				return xPathNavigator.Value;
			}
			case XPathResultType.String:
				return (string)obj;
			case XPathResultType.Boolean:
				if (!(bool)obj)
				{
					return "false";
				}
				return "true";
			case (XPathResultType)4:
				return ((XPathNavigator)obj).Value;
			default:
				return toString((double)obj);
			}
		}
		return P_0.Current.Value;
	}

	private string Concat(XPathNodeIterator P_0)
	{
		int num = 0;
		StringBuilder stringBuilder = new StringBuilder();
		while (num < _argList.Count)
		{
			stringBuilder.Append(_argList[num++].Evaluate(P_0).ToString());
		}
		return stringBuilder.ToString();
	}

	private bool StartsWith(XPathNodeIterator P_0)
	{
		string text = _argList[0].Evaluate(P_0).ToString();
		string text2 = _argList[1].Evaluate(P_0).ToString();
		if (text.Length >= text2.Length)
		{
			return string.CompareOrdinal(text, 0, text2, 0, text2.Length) == 0;
		}
		return false;
	}

	private bool Contains(XPathNodeIterator P_0)
	{
		string text = _argList[0].Evaluate(P_0).ToString();
		string text2 = _argList[1].Evaluate(P_0).ToString();
		return s_compareInfo.IndexOf(text, text2, CompareOptions.Ordinal) >= 0;
	}

	private string SubstringBefore(XPathNodeIterator P_0)
	{
		string text = _argList[0].Evaluate(P_0).ToString();
		string text2 = _argList[1].Evaluate(P_0).ToString();
		if (text2.Length == 0)
		{
			return text2;
		}
		int num = s_compareInfo.IndexOf(text, text2, CompareOptions.Ordinal);
		if (num >= 1)
		{
			return text.Substring(0, num);
		}
		return string.Empty;
	}

	private string SubstringAfter(XPathNodeIterator P_0)
	{
		string text = _argList[0].Evaluate(P_0).ToString();
		string text2 = _argList[1].Evaluate(P_0).ToString();
		if (text2.Length == 0)
		{
			return text;
		}
		int num = s_compareInfo.IndexOf(text, text2, CompareOptions.Ordinal);
		if (num >= 0)
		{
			return text.Substring(num + text2.Length);
		}
		return string.Empty;
	}

	private string Substring(XPathNodeIterator P_0)
	{
		string text = _argList[0].Evaluate(P_0).ToString();
		double num = XmlConvert.XPathRound(XmlConvert.ToXPathDouble(_argList[1].Evaluate(P_0))) - 1.0;
		if (double.IsNaN(num) || (double)text.Length <= num)
		{
			return string.Empty;
		}
		if (_argList.Count == 3)
		{
			double num2 = XmlConvert.XPathRound(XmlConvert.ToXPathDouble(_argList[2].Evaluate(P_0)));
			if (double.IsNaN(num2))
			{
				return string.Empty;
			}
			if (num < 0.0 || num2 < 0.0)
			{
				num2 = num + num2;
				if (!(num2 > 0.0))
				{
					return string.Empty;
				}
				num = 0.0;
			}
			double num3 = (double)text.Length - num;
			if (num2 > num3)
			{
				num2 = num3;
			}
			return text.Substring((int)num, (int)num2);
		}
		if (num < 0.0)
		{
			num = 0.0;
		}
		return text.Substring((int)num);
	}

	private double StringLength(XPathNodeIterator P_0)
	{
		if (_argList.Count > 0)
		{
			return _argList[0].Evaluate(P_0).ToString().Length;
		}
		return P_0.Current.Value.Length;
	}

	private string Normalize(XPathNodeIterator P_0)
	{
		string text = ((_argList.Count <= 0) ? P_0.Current.Value : _argList[0].Evaluate(P_0).ToString());
		int num = -1;
		char[] array = text.ToCharArray();
		bool flag = false;
		for (int i = 0; i < array.Length; i++)
		{
			if (!XmlCharType.IsWhiteSpace(array[i]))
			{
				flag = true;
				num++;
				array[num] = array[i];
			}
			else if (flag)
			{
				flag = false;
				num++;
				array[num] = ' ';
			}
		}
		if (num > -1 && array[num] == ' ')
		{
			num--;
		}
		return new string(array, 0, num + 1);
	}

	private string Translate(XPathNodeIterator P_0)
	{
		string text = _argList[0].Evaluate(P_0).ToString();
		string text2 = _argList[1].Evaluate(P_0).ToString();
		string text3 = _argList[2].Evaluate(P_0).ToString();
		int num = -1;
		char[] array = text.ToCharArray();
		for (int i = 0; i < array.Length; i++)
		{
			int num2 = text2.IndexOf(array[i]);
			if (num2 != -1)
			{
				if (num2 < text3.Length)
				{
					num++;
					array[num] = text3[num2];
				}
			}
			else
			{
				num++;
				array[num] = array[i];
			}
		}
		return new string(array, 0, num + 1);
	}

	public override XPathNodeIterator Clone()
	{
		return new StringFunctions(this);
	}
}
