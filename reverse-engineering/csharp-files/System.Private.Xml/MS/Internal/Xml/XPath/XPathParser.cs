using System;
using System.Collections.Generic;
using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal struct XPathParser
{
	private sealed class ParamInfo
	{
		private readonly Function.FunctionType _ftype;

		private readonly int _minargs;

		private readonly int _maxargs;

		private readonly XPathResultType[] _argTypes;

		public Function.FunctionType FType => _ftype;

		public int Minargs => _minargs;

		public int Maxargs => _maxargs;

		public XPathResultType[] ArgTypes => _argTypes;

		internal ParamInfo(Function.FunctionType P_0, int P_1, int P_2, XPathResultType[] P_3)
		{
			_ftype = P_0;
			_minargs = P_1;
			_maxargs = P_2;
			_argTypes = P_3;
		}
	}

	private XPathScanner _scanner;

	private int _parseDepth;

	private static readonly XPathResultType[] s_temparray1 = Array.Empty<XPathResultType>();

	private static readonly XPathResultType[] s_temparray2 = new XPathResultType[1] { XPathResultType.NodeSet };

	private static readonly XPathResultType[] s_temparray3 = new XPathResultType[1] { XPathResultType.Any };

	private static readonly XPathResultType[] s_temparray4 = new XPathResultType[1] { XPathResultType.String };

	private static readonly XPathResultType[] s_temparray5 = new XPathResultType[2]
	{
		XPathResultType.String,
		XPathResultType.String
	};

	private static readonly XPathResultType[] s_temparray6 = new XPathResultType[3]
	{
		XPathResultType.String,
		XPathResultType.Number,
		XPathResultType.Number
	};

	private static readonly XPathResultType[] s_temparray7 = new XPathResultType[3]
	{
		XPathResultType.String,
		XPathResultType.String,
		XPathResultType.String
	};

	private static readonly XPathResultType[] s_temparray8 = new XPathResultType[1] { XPathResultType.Boolean };

	private static readonly XPathResultType[] s_temparray9 = new XPathResultType[1];

	private static readonly Dictionary<string, ParamInfo> s_functionTable = CreateFunctionTable();

	private static readonly Dictionary<string, Axis.AxisType> s_AxesTable = CreateAxesTable();

	private bool IsNodeType
	{
		get
		{
			if (_scanner.Prefix.Length == 0)
			{
				if (!(_scanner.Name == "node") && !(_scanner.Name == "text") && !(_scanner.Name == "processing-instruction"))
				{
					return _scanner.Name == "comment";
				}
				return true;
			}
			return false;
		}
	}

	private bool IsPrimaryExpr
	{
		get
		{
			if (_scanner.Kind != XPathScanner.LexKind.String && _scanner.Kind != XPathScanner.LexKind.Number && _scanner.Kind != XPathScanner.LexKind.Dollar && _scanner.Kind != XPathScanner.LexKind.LParens)
			{
				if (_scanner.Kind == XPathScanner.LexKind.Name && _scanner.CanBeFunction)
				{
					return !IsNodeType;
				}
				return false;
			}
			return true;
		}
	}

	private XPathParser(string P_0)
	{
		_scanner = new XPathScanner(P_0);
		_parseDepth = 0;
	}

	public static AstNode ParseXPathExpression(string P_0)
	{
		XPathParser xPathParser = new XPathParser(P_0);
		AstNode result = xPathParser.ParseExpression(null);
		if (xPathParser._scanner.Kind != XPathScanner.LexKind.Eof)
		{
			throw XPathException.Create("Xp_InvalidToken", xPathParser._scanner.SourceText);
		}
		return result;
	}

	private AstNode ParseExpression(AstNode P_0)
	{
		if (++_parseDepth > 200)
		{
			throw XPathException.Create("Xp_QueryTooComplex");
		}
		AstNode result = ParseOrExpr(P_0);
		_parseDepth--;
		return result;
	}

	private AstNode ParseOrExpr(AstNode P_0)
	{
		AstNode astNode = ParseAndExpr(P_0);
		while (TestOp("or"))
		{
			NextLex();
			astNode = new Operator(Operator.Op.OR, astNode, ParseAndExpr(P_0));
		}
		return astNode;
	}

	private AstNode ParseAndExpr(AstNode P_0)
	{
		AstNode astNode = ParseEqualityExpr(P_0);
		while (TestOp("and"))
		{
			NextLex();
			astNode = new Operator(Operator.Op.AND, astNode, ParseEqualityExpr(P_0));
		}
		return astNode;
	}

	private AstNode ParseEqualityExpr(AstNode P_0)
	{
		AstNode astNode = ParseRelationalExpr(P_0);
		while (true)
		{
			Operator.Op op = ((_scanner.Kind == XPathScanner.LexKind.Eq) ? Operator.Op.EQ : ((_scanner.Kind == XPathScanner.LexKind.Ne) ? Operator.Op.NE : Operator.Op.INVALID));
			if (op == Operator.Op.INVALID)
			{
				break;
			}
			NextLex();
			astNode = new Operator(op, astNode, ParseRelationalExpr(P_0));
		}
		return astNode;
	}

	private AstNode ParseRelationalExpr(AstNode P_0)
	{
		AstNode astNode = ParseAdditiveExpr(P_0);
		while (true)
		{
			Operator.Op op = ((_scanner.Kind == XPathScanner.LexKind.Lt) ? Operator.Op.LT : ((_scanner.Kind == XPathScanner.LexKind.Le) ? Operator.Op.LE : ((_scanner.Kind == XPathScanner.LexKind.Gt) ? Operator.Op.GT : ((_scanner.Kind == XPathScanner.LexKind.Ge) ? Operator.Op.GE : Operator.Op.INVALID))));
			if (op == Operator.Op.INVALID)
			{
				break;
			}
			NextLex();
			astNode = new Operator(op, astNode, ParseAdditiveExpr(P_0));
		}
		return astNode;
	}

	private AstNode ParseAdditiveExpr(AstNode P_0)
	{
		AstNode astNode = ParseMultiplicativeExpr(P_0);
		while (true)
		{
			Operator.Op op = ((_scanner.Kind == XPathScanner.LexKind.Plus) ? Operator.Op.PLUS : ((_scanner.Kind == XPathScanner.LexKind.Minus) ? Operator.Op.MINUS : Operator.Op.INVALID));
			if (op == Operator.Op.INVALID)
			{
				break;
			}
			NextLex();
			astNode = new Operator(op, astNode, ParseMultiplicativeExpr(P_0));
		}
		return astNode;
	}

	private AstNode ParseMultiplicativeExpr(AstNode P_0)
	{
		AstNode astNode = ParseUnaryExpr(P_0);
		while (true)
		{
			Operator.Op op = ((_scanner.Kind == XPathScanner.LexKind.Star) ? Operator.Op.MUL : (TestOp("div") ? Operator.Op.DIV : (TestOp("mod") ? Operator.Op.MOD : Operator.Op.INVALID)));
			if (op == Operator.Op.INVALID)
			{
				break;
			}
			NextLex();
			astNode = new Operator(op, astNode, ParseUnaryExpr(P_0));
		}
		return astNode;
	}

	private AstNode ParseUnaryExpr(AstNode P_0)
	{
		bool flag = false;
		while (_scanner.Kind == XPathScanner.LexKind.Minus)
		{
			NextLex();
			flag = !flag;
		}
		if (flag)
		{
			return new Operator(Operator.Op.MUL, ParseUnionExpr(P_0), new Operand(-1.0));
		}
		return ParseUnionExpr(P_0);
	}

	private AstNode ParseUnionExpr(AstNode P_0)
	{
		AstNode astNode = ParsePathExpr(P_0);
		while (_scanner.Kind == XPathScanner.LexKind.Union)
		{
			NextLex();
			AstNode astNode2 = ParsePathExpr(P_0);
			CheckNodeSet(astNode.ReturnType);
			CheckNodeSet(astNode2.ReturnType);
			astNode = new Operator(Operator.Op.UNION, astNode, astNode2);
		}
		return astNode;
	}

	private AstNode ParsePathExpr(AstNode P_0)
	{
		AstNode astNode;
		if (IsPrimaryExpr)
		{
			astNode = ParseFilterExpr(P_0);
			if (_scanner.Kind == XPathScanner.LexKind.Slash)
			{
				NextLex();
				astNode = ParseRelativeLocationPath(astNode);
			}
			else if (_scanner.Kind == XPathScanner.LexKind.SlashSlash)
			{
				NextLex();
				astNode = ParseRelativeLocationPath(new Axis(Axis.AxisType.DescendantOrSelf, astNode));
			}
		}
		else
		{
			astNode = ParseLocationPath(null);
		}
		return astNode;
	}

	private AstNode ParseFilterExpr(AstNode P_0)
	{
		AstNode astNode = ParsePrimaryExpr(P_0);
		while (_scanner.Kind == XPathScanner.LexKind.LBracket)
		{
			astNode = new Filter(astNode, ParsePredicate(astNode));
		}
		return astNode;
	}

	private AstNode ParsePredicate(AstNode P_0)
	{
		CheckNodeSet(P_0.ReturnType);
		PassToken(XPathScanner.LexKind.LBracket);
		AstNode result = ParseExpression(P_0);
		PassToken(XPathScanner.LexKind.RBracket);
		return result;
	}

	private AstNode ParseLocationPath(AstNode P_0)
	{
		if (_scanner.Kind == XPathScanner.LexKind.Slash)
		{
			NextLex();
			AstNode astNode = new Root();
			if (IsStep(_scanner.Kind))
			{
				astNode = ParseRelativeLocationPath(astNode);
			}
			return astNode;
		}
		if (_scanner.Kind == XPathScanner.LexKind.SlashSlash)
		{
			NextLex();
			return ParseRelativeLocationPath(new Axis(Axis.AxisType.DescendantOrSelf, new Root()));
		}
		return ParseRelativeLocationPath(P_0);
	}

	private AstNode ParseRelativeLocationPath(AstNode P_0)
	{
		AstNode astNode = P_0;
		while (true)
		{
			astNode = ParseStep(astNode);
			if (XPathScanner.LexKind.SlashSlash == _scanner.Kind)
			{
				NextLex();
				astNode = new Axis(Axis.AxisType.DescendantOrSelf, astNode);
				continue;
			}
			if (XPathScanner.LexKind.Slash != _scanner.Kind)
			{
				break;
			}
			NextLex();
		}
		return astNode;
	}

	private static bool IsStep(XPathScanner.LexKind P_0)
	{
		if (P_0 != XPathScanner.LexKind.Dot && P_0 != XPathScanner.LexKind.DotDot && P_0 != XPathScanner.LexKind.At && P_0 != XPathScanner.LexKind.Axe && P_0 != XPathScanner.LexKind.Star)
		{
			return P_0 == XPathScanner.LexKind.Name;
		}
		return true;
	}

	private AstNode ParseStep(AstNode P_0)
	{
		AstNode astNode;
		if (XPathScanner.LexKind.Dot == _scanner.Kind)
		{
			NextLex();
			astNode = new Axis(Axis.AxisType.Self, P_0);
		}
		else if (XPathScanner.LexKind.DotDot == _scanner.Kind)
		{
			NextLex();
			astNode = new Axis(Axis.AxisType.Parent, P_0);
		}
		else
		{
			Axis.AxisType axisType = Axis.AxisType.Child;
			switch (_scanner.Kind)
			{
			case XPathScanner.LexKind.At:
				axisType = Axis.AxisType.Attribute;
				NextLex();
				break;
			case XPathScanner.LexKind.Axe:
				axisType = GetAxis();
				NextLex();
				break;
			}
			XPathNodeType xPathNodeType = ((axisType != Axis.AxisType.Attribute) ? XPathNodeType.Element : XPathNodeType.Attribute);
			astNode = ParseNodeTest(P_0, axisType, xPathNodeType);
			while (XPathScanner.LexKind.LBracket == _scanner.Kind)
			{
				astNode = new Filter(astNode, ParsePredicate(astNode));
			}
		}
		return astNode;
	}

	private AstNode ParseNodeTest(AstNode P_0, Axis.AxisType P_1, XPathNodeType P_2)
	{
		string text;
		string text2;
		switch (_scanner.Kind)
		{
		case XPathScanner.LexKind.Name:
			if (_scanner.CanBeFunction && IsNodeType)
			{
				text = string.Empty;
				text2 = string.Empty;
				P_2 = ((_scanner.Name == "comment") ? XPathNodeType.Comment : ((_scanner.Name == "text") ? XPathNodeType.Text : ((_scanner.Name == "node") ? XPathNodeType.All : ((_scanner.Name == "processing-instruction") ? XPathNodeType.ProcessingInstruction : XPathNodeType.Root))));
				NextLex();
				PassToken(XPathScanner.LexKind.LParens);
				if (P_2 == XPathNodeType.ProcessingInstruction && _scanner.Kind != XPathScanner.LexKind.RParens)
				{
					CheckToken(XPathScanner.LexKind.String);
					text2 = _scanner.StringValue;
					NextLex();
				}
				PassToken(XPathScanner.LexKind.RParens);
			}
			else
			{
				text = _scanner.Prefix;
				text2 = _scanner.Name;
				NextLex();
				if (text2 == "*")
				{
					text2 = string.Empty;
				}
			}
			break;
		case XPathScanner.LexKind.Star:
			text = string.Empty;
			text2 = string.Empty;
			NextLex();
			break;
		default:
			throw XPathException.Create("Xp_NodeSetExpected", _scanner.SourceText);
		}
		return new Axis(P_1, P_0, text, text2, P_2);
	}

	private AstNode ParsePrimaryExpr(AstNode P_0)
	{
		AstNode astNode = null;
		switch (_scanner.Kind)
		{
		case XPathScanner.LexKind.String:
			astNode = new Operand(_scanner.StringValue);
			NextLex();
			break;
		case XPathScanner.LexKind.Number:
			astNode = new Operand(_scanner.NumberValue);
			NextLex();
			break;
		case XPathScanner.LexKind.Dollar:
			NextLex();
			CheckToken(XPathScanner.LexKind.Name);
			astNode = new Variable(_scanner.Name, _scanner.Prefix);
			NextLex();
			break;
		case XPathScanner.LexKind.LParens:
			NextLex();
			astNode = ParseExpression(P_0);
			if (astNode.Type != AstNode.AstType.ConstantOperand)
			{
				astNode = new Group(astNode);
			}
			PassToken(XPathScanner.LexKind.RParens);
			break;
		case XPathScanner.LexKind.Name:
			if (_scanner.CanBeFunction && !IsNodeType)
			{
				astNode = ParseMethod(null);
			}
			break;
		}
		return astNode;
	}

	private AstNode ParseMethod(AstNode P_0)
	{
		List<AstNode> list = new List<AstNode>();
		string name = _scanner.Name;
		string prefix = _scanner.Prefix;
		PassToken(XPathScanner.LexKind.Name);
		PassToken(XPathScanner.LexKind.LParens);
		if (_scanner.Kind != XPathScanner.LexKind.RParens)
		{
			while (true)
			{
				list.Add(ParseExpression(P_0));
				if (_scanner.Kind == XPathScanner.LexKind.RParens)
				{
					break;
				}
				PassToken(XPathScanner.LexKind.Comma);
			}
		}
		PassToken(XPathScanner.LexKind.RParens);
		if (prefix.Length == 0 && s_functionTable.TryGetValue(name, out var paramInfo))
		{
			int num = list.Count;
			if (num < paramInfo.Minargs)
			{
				throw XPathException.Create("Xp_InvalidNumArgs", name, _scanner.SourceText);
			}
			if (paramInfo.FType == Function.FunctionType.FuncConcat)
			{
				for (int i = 0; i < num; i++)
				{
					AstNode astNode = list[i];
					if (astNode.ReturnType != XPathResultType.String)
					{
						astNode = new Function(Function.FunctionType.FuncString, astNode);
					}
					list[i] = astNode;
				}
			}
			else
			{
				if (paramInfo.Maxargs < num)
				{
					throw XPathException.Create("Xp_InvalidNumArgs", name, _scanner.SourceText);
				}
				if (paramInfo.ArgTypes.Length < num)
				{
					num = paramInfo.ArgTypes.Length;
				}
				for (int j = 0; j < num; j++)
				{
					AstNode astNode2 = list[j];
					if (paramInfo.ArgTypes[j] == XPathResultType.Any || paramInfo.ArgTypes[j] == astNode2.ReturnType)
					{
						continue;
					}
					switch (paramInfo.ArgTypes[j])
					{
					case XPathResultType.NodeSet:
						if (!(astNode2 is Variable) && (!(astNode2 is Function) || astNode2.ReturnType != XPathResultType.Any))
						{
							throw XPathException.Create("Xp_InvalidArgumentType", name, _scanner.SourceText);
						}
						break;
					case XPathResultType.String:
						astNode2 = new Function(Function.FunctionType.FuncString, astNode2);
						break;
					case XPathResultType.Number:
						astNode2 = new Function(Function.FunctionType.FuncNumber, astNode2);
						break;
					case XPathResultType.Boolean:
						astNode2 = new Function(Function.FunctionType.FuncBoolean, astNode2);
						break;
					}
					list[j] = astNode2;
				}
			}
			return new Function(paramInfo.FType, list);
		}
		return new Function(prefix, name, list);
	}

	private void CheckToken(XPathScanner.LexKind P_0)
	{
		if (_scanner.Kind != P_0)
		{
			throw XPathException.Create("Xp_InvalidToken", _scanner.SourceText);
		}
	}

	private void PassToken(XPathScanner.LexKind P_0)
	{
		CheckToken(P_0);
		NextLex();
	}

	private void NextLex()
	{
		_scanner.NextLex();
	}

	private bool TestOp(string P_0)
	{
		if (_scanner.Kind == XPathScanner.LexKind.Name && _scanner.Prefix.Length == 0)
		{
			return _scanner.Name.Equals(P_0);
		}
		return false;
	}

	private void CheckNodeSet(XPathResultType P_0)
	{
		if (P_0 != XPathResultType.NodeSet && P_0 != XPathResultType.Any)
		{
			throw XPathException.Create("Xp_NodeSetExpected", _scanner.SourceText);
		}
	}

	private static Dictionary<string, ParamInfo> CreateFunctionTable()
	{
		Dictionary<string, ParamInfo> dictionary = new Dictionary<string, ParamInfo>(36);
		dictionary.Add("last", new ParamInfo(Function.FunctionType.FuncLast, 0, 0, s_temparray1));
		dictionary.Add("position", new ParamInfo(Function.FunctionType.FuncPosition, 0, 0, s_temparray1));
		dictionary.Add("name", new ParamInfo(Function.FunctionType.FuncName, 0, 1, s_temparray2));
		dictionary.Add("namespace-uri", new ParamInfo(Function.FunctionType.FuncNameSpaceUri, 0, 1, s_temparray2));
		dictionary.Add("local-name", new ParamInfo(Function.FunctionType.FuncLocalName, 0, 1, s_temparray2));
		dictionary.Add("count", new ParamInfo(Function.FunctionType.FuncCount, 1, 1, s_temparray2));
		dictionary.Add("id", new ParamInfo(Function.FunctionType.FuncID, 1, 1, s_temparray3));
		dictionary.Add("string", new ParamInfo(Function.FunctionType.FuncString, 0, 1, s_temparray3));
		dictionary.Add("concat", new ParamInfo(Function.FunctionType.FuncConcat, 2, 100, s_temparray4));
		dictionary.Add("starts-with", new ParamInfo(Function.FunctionType.FuncStartsWith, 2, 2, s_temparray5));
		dictionary.Add("contains", new ParamInfo(Function.FunctionType.FuncContains, 2, 2, s_temparray5));
		dictionary.Add("substring-before", new ParamInfo(Function.FunctionType.FuncSubstringBefore, 2, 2, s_temparray5));
		dictionary.Add("substring-after", new ParamInfo(Function.FunctionType.FuncSubstringAfter, 2, 2, s_temparray5));
		dictionary.Add("substring", new ParamInfo(Function.FunctionType.FuncSubstring, 2, 3, s_temparray6));
		dictionary.Add("string-length", new ParamInfo(Function.FunctionType.FuncStringLength, 0, 1, s_temparray4));
		dictionary.Add("normalize-space", new ParamInfo(Function.FunctionType.FuncNormalize, 0, 1, s_temparray4));
		dictionary.Add("translate", new ParamInfo(Function.FunctionType.FuncTranslate, 3, 3, s_temparray7));
		dictionary.Add("boolean", new ParamInfo(Function.FunctionType.FuncBoolean, 1, 1, s_temparray3));
		dictionary.Add("not", new ParamInfo(Function.FunctionType.FuncNot, 1, 1, s_temparray8));
		dictionary.Add("true", new ParamInfo(Function.FunctionType.FuncTrue, 0, 0, s_temparray8));
		dictionary.Add("false", new ParamInfo(Function.FunctionType.FuncFalse, 0, 0, s_temparray8));
		dictionary.Add("lang", new ParamInfo(Function.FunctionType.FuncLang, 1, 1, s_temparray4));
		dictionary.Add("number", new ParamInfo(Function.FunctionType.FuncNumber, 0, 1, s_temparray3));
		dictionary.Add("sum", new ParamInfo(Function.FunctionType.FuncSum, 1, 1, s_temparray2));
		dictionary.Add("floor", new ParamInfo(Function.FunctionType.FuncFloor, 1, 1, s_temparray9));
		dictionary.Add("ceiling", new ParamInfo(Function.FunctionType.FuncCeiling, 1, 1, s_temparray9));
		dictionary.Add("round", new ParamInfo(Function.FunctionType.FuncRound, 1, 1, s_temparray9));
		return dictionary;
	}

	private static Dictionary<string, Axis.AxisType> CreateAxesTable()
	{
		Dictionary<string, Axis.AxisType> dictionary = new Dictionary<string, Axis.AxisType>(13);
		dictionary.Add("ancestor", Axis.AxisType.Ancestor);
		dictionary.Add("ancestor-or-self", Axis.AxisType.AncestorOrSelf);
		dictionary.Add("attribute", Axis.AxisType.Attribute);
		dictionary.Add("child", Axis.AxisType.Child);
		dictionary.Add("descendant", Axis.AxisType.Descendant);
		dictionary.Add("descendant-or-self", Axis.AxisType.DescendantOrSelf);
		dictionary.Add("following", Axis.AxisType.Following);
		dictionary.Add("following-sibling", Axis.AxisType.FollowingSibling);
		dictionary.Add("namespace", Axis.AxisType.Namespace);
		dictionary.Add("parent", Axis.AxisType.Parent);
		dictionary.Add("preceding", Axis.AxisType.Preceding);
		dictionary.Add("preceding-sibling", Axis.AxisType.PrecedingSibling);
		dictionary.Add("self", Axis.AxisType.Self);
		return dictionary;
	}

	private Axis.AxisType GetAxis()
	{
		if (!s_AxesTable.TryGetValue(_scanner.Name, out var result))
		{
			throw XPathException.Create("Xp_InvalidToken", _scanner.SourceText);
		}
		return result;
	}
}
