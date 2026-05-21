using System.Xml.XPath;
using System.Xml.Xsl;

namespace MS.Internal.Xml.XPath;

internal sealed class LogicalExpr : ValueQuery
{
	private delegate bool cmpXslt(Operator.Op P_0, object P_1, object P_2);

	private struct NodeSet
	{
		private readonly Query _opnd;

		private XPathNavigator _current;

		public string Value => _current.Value;

		public NodeSet(object P_0)
		{
			_opnd = (Query)P_0;
			_current = null;
		}

		public bool MoveNext()
		{
			_current = _opnd.Advance();
			return _current != null;
		}

		public void Reset()
		{
			_opnd.Reset();
		}
	}

	private readonly Operator.Op _op;

	private readonly Query _opnd1;

	private readonly Query _opnd2;

	private static readonly cmpXslt[][] s_CompXsltE = new cmpXslt[5][]
	{
		new cmpXslt[5] { cmpNumberNumber, null, null, null, null },
		new cmpXslt[5] { cmpStringNumber, cmpStringStringE, null, null, null },
		new cmpXslt[5] { cmpBoolNumberE, cmpBoolStringE, cmpBoolBoolE, null, null },
		new cmpXslt[5] { cmpQueryNumber, cmpQueryStringE, cmpQueryBoolE, cmpQueryQueryE, null },
		new cmpXslt[5] { cmpRtfNumber, cmpRtfStringE, cmpRtfBoolE, cmpRtfQueryE, cmpRtfRtfE }
	};

	private static readonly cmpXslt[][] s_CompXsltO = new cmpXslt[5][]
	{
		new cmpXslt[5] { cmpNumberNumber, null, null, null, null },
		new cmpXslt[5] { cmpStringNumber, cmpStringStringO, null, null, null },
		new cmpXslt[5] { cmpBoolNumberO, cmpBoolStringO, cmpBoolBoolO, null, null },
		new cmpXslt[5] { cmpQueryNumber, cmpQueryStringO, cmpQueryBoolO, cmpQueryQueryO, null },
		new cmpXslt[5] { cmpRtfNumber, cmpRtfStringO, cmpRtfBoolO, cmpRtfQueryO, cmpRtfRtfO }
	};

	public override XPathResultType StaticType => XPathResultType.Boolean;

	public LogicalExpr(Operator.Op P_0, Query P_1, Query P_2)
	{
		_op = P_0;
		_opnd1 = P_1;
		_opnd2 = P_2;
	}

	private LogicalExpr(LogicalExpr P_0)
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
		Operator.Op op = _op;
		object obj = _opnd1.Evaluate(P_0);
		object obj2 = _opnd2.Evaluate(P_0);
		int num = (int)Query.GetXPathType(obj);
		int num2 = (int)Query.GetXPathType(obj2);
		if (num < num2)
		{
			op = Operator.InvertOperator(op);
			object obj3 = obj;
			obj = obj2;
			obj2 = obj3;
			int num3 = num;
			num = num2;
			num2 = num3;
		}
		cmpXslt cmpXslt = ((op != Operator.Op.EQ && op != Operator.Op.NE) ? s_CompXsltO[num][num2] : s_CompXsltE[num][num2]);
		return cmpXslt(op, obj, obj2);
	}

	private static bool cmpQueryQueryE(Operator.Op P_0, object P_1, object P_2)
	{
		bool flag = P_0 == Operator.Op.EQ;
		NodeSet nodeSet = new NodeSet(P_1);
		NodeSet nodeSet2 = new NodeSet(P_2);
		while (true)
		{
			if (!nodeSet.MoveNext())
			{
				return false;
			}
			if (!nodeSet2.MoveNext())
			{
				break;
			}
			string value = nodeSet.Value;
			do
			{
				if (value == nodeSet2.Value == flag)
				{
					return true;
				}
			}
			while (nodeSet2.MoveNext());
			nodeSet2.Reset();
		}
		return false;
	}

	private static bool cmpQueryQueryO(Operator.Op P_0, object P_1, object P_2)
	{
		NodeSet nodeSet = new NodeSet(P_1);
		NodeSet nodeSet2 = new NodeSet(P_2);
		while (true)
		{
			if (!nodeSet.MoveNext())
			{
				return false;
			}
			if (!nodeSet2.MoveNext())
			{
				break;
			}
			double num = NumberFunctions.Number(nodeSet.Value);
			do
			{
				if (cmpNumberNumber(P_0, num, NumberFunctions.Number(nodeSet2.Value)))
				{
					return true;
				}
			}
			while (nodeSet2.MoveNext());
			nodeSet2.Reset();
		}
		return false;
	}

	private static bool cmpQueryNumber(Operator.Op P_0, object P_1, object P_2)
	{
		NodeSet nodeSet = new NodeSet(P_1);
		double num = (double)P_2;
		while (nodeSet.MoveNext())
		{
			if (cmpNumberNumber(P_0, NumberFunctions.Number(nodeSet.Value), num))
			{
				return true;
			}
		}
		return false;
	}

	private static bool cmpQueryStringE(Operator.Op P_0, object P_1, object P_2)
	{
		NodeSet nodeSet = new NodeSet(P_1);
		string text = (string)P_2;
		while (nodeSet.MoveNext())
		{
			if (cmpStringStringE(P_0, nodeSet.Value, text))
			{
				return true;
			}
		}
		return false;
	}

	private static bool cmpQueryStringO(Operator.Op P_0, object P_1, object P_2)
	{
		NodeSet nodeSet = new NodeSet(P_1);
		double num = NumberFunctions.Number((string)P_2);
		while (nodeSet.MoveNext())
		{
			if (cmpNumberNumberO(P_0, NumberFunctions.Number(nodeSet.Value), num))
			{
				return true;
			}
		}
		return false;
	}

	private static bool cmpRtfQueryE(Operator.Op P_0, object P_1, object P_2)
	{
		string text = Rtf(P_1);
		NodeSet nodeSet = new NodeSet(P_2);
		while (nodeSet.MoveNext())
		{
			if (cmpStringStringE(P_0, text, nodeSet.Value))
			{
				return true;
			}
		}
		return false;
	}

	private static bool cmpRtfQueryO(Operator.Op P_0, object P_1, object P_2)
	{
		double num = NumberFunctions.Number(Rtf(P_1));
		NodeSet nodeSet = new NodeSet(P_2);
		while (nodeSet.MoveNext())
		{
			if (cmpNumberNumberO(P_0, num, NumberFunctions.Number(nodeSet.Value)))
			{
				return true;
			}
		}
		return false;
	}

	private static bool cmpQueryBoolE(Operator.Op P_0, object P_1, object P_2)
	{
		bool flag = new NodeSet(P_1).MoveNext();
		bool flag2 = (bool)P_2;
		return cmpBoolBoolE(P_0, flag, flag2);
	}

	private static bool cmpQueryBoolO(Operator.Op P_0, object P_1, object P_2)
	{
		double num = (new NodeSet(P_1).MoveNext() ? 1.0 : 0.0);
		double num2 = NumberFunctions.Number((bool)P_2);
		return cmpNumberNumberO(P_0, num, num2);
	}

	private static bool cmpBoolBoolE(Operator.Op P_0, bool P_1, bool P_2)
	{
		return P_0 == Operator.Op.EQ == (P_1 == P_2);
	}

	private static bool cmpBoolBoolE(Operator.Op P_0, object P_1, object P_2)
	{
		bool flag = (bool)P_1;
		bool flag2 = (bool)P_2;
		return cmpBoolBoolE(P_0, flag, flag2);
	}

	private static bool cmpBoolBoolO(Operator.Op P_0, object P_1, object P_2)
	{
		double num = NumberFunctions.Number((bool)P_1);
		double num2 = NumberFunctions.Number((bool)P_2);
		return cmpNumberNumberO(P_0, num, num2);
	}

	private static bool cmpBoolNumberE(Operator.Op P_0, object P_1, object P_2)
	{
		bool flag = (bool)P_1;
		bool flag2 = BooleanFunctions.toBoolean((double)P_2);
		return cmpBoolBoolE(P_0, flag, flag2);
	}

	private static bool cmpBoolNumberO(Operator.Op P_0, object P_1, object P_2)
	{
		double num = NumberFunctions.Number((bool)P_1);
		double num2 = (double)P_2;
		return cmpNumberNumberO(P_0, num, num2);
	}

	private static bool cmpBoolStringE(Operator.Op P_0, object P_1, object P_2)
	{
		bool flag = (bool)P_1;
		bool flag2 = BooleanFunctions.toBoolean((string)P_2);
		return cmpBoolBoolE(P_0, flag, flag2);
	}

	private static bool cmpRtfBoolE(Operator.Op P_0, object P_1, object P_2)
	{
		bool flag = BooleanFunctions.toBoolean(Rtf(P_1));
		bool flag2 = (bool)P_2;
		return cmpBoolBoolE(P_0, flag, flag2);
	}

	private static bool cmpBoolStringO(Operator.Op P_0, object P_1, object P_2)
	{
		return cmpNumberNumberO(P_0, NumberFunctions.Number((bool)P_1), NumberFunctions.Number((string)P_2));
	}

	private static bool cmpRtfBoolO(Operator.Op P_0, object P_1, object P_2)
	{
		return cmpNumberNumberO(P_0, NumberFunctions.Number(Rtf(P_1)), NumberFunctions.Number((bool)P_2));
	}

	private static bool cmpNumberNumber(Operator.Op P_0, double P_1, double P_2)
	{
		return P_0 switch
		{
			Operator.Op.LT => P_1 < P_2, 
			Operator.Op.GT => P_1 > P_2, 
			Operator.Op.LE => P_1 <= P_2, 
			Operator.Op.GE => P_1 >= P_2, 
			Operator.Op.EQ => P_1 == P_2, 
			Operator.Op.NE => P_1 != P_2, 
			_ => false, 
		};
	}

	private static bool cmpNumberNumberO(Operator.Op P_0, double P_1, double P_2)
	{
		return P_0 switch
		{
			Operator.Op.LT => P_1 < P_2, 
			Operator.Op.GT => P_1 > P_2, 
			Operator.Op.LE => P_1 <= P_2, 
			Operator.Op.GE => P_1 >= P_2, 
			_ => false, 
		};
	}

	private static bool cmpNumberNumber(Operator.Op P_0, object P_1, object P_2)
	{
		double num = (double)P_1;
		double num2 = (double)P_2;
		return cmpNumberNumber(P_0, num, num2);
	}

	private static bool cmpStringNumber(Operator.Op P_0, object P_1, object P_2)
	{
		double num = (double)P_2;
		double num2 = NumberFunctions.Number((string)P_1);
		return cmpNumberNumber(P_0, num2, num);
	}

	private static bool cmpRtfNumber(Operator.Op P_0, object P_1, object P_2)
	{
		double num = (double)P_2;
		double num2 = NumberFunctions.Number(Rtf(P_1));
		return cmpNumberNumber(P_0, num2, num);
	}

	private static bool cmpStringStringE(Operator.Op P_0, string P_1, string P_2)
	{
		return P_0 == Operator.Op.EQ == (P_1 == P_2);
	}

	private static bool cmpStringStringE(Operator.Op P_0, object P_1, object P_2)
	{
		string text = (string)P_1;
		string text2 = (string)P_2;
		return cmpStringStringE(P_0, text, text2);
	}

	private static bool cmpRtfStringE(Operator.Op P_0, object P_1, object P_2)
	{
		string text = Rtf(P_1);
		string text2 = (string)P_2;
		return cmpStringStringE(P_0, text, text2);
	}

	private static bool cmpRtfRtfE(Operator.Op P_0, object P_1, object P_2)
	{
		string text = Rtf(P_1);
		string text2 = Rtf(P_2);
		return cmpStringStringE(P_0, text, text2);
	}

	private static bool cmpStringStringO(Operator.Op P_0, object P_1, object P_2)
	{
		double num = NumberFunctions.Number((string)P_1);
		double num2 = NumberFunctions.Number((string)P_2);
		return cmpNumberNumberO(P_0, num, num2);
	}

	private static bool cmpRtfStringO(Operator.Op P_0, object P_1, object P_2)
	{
		double num = NumberFunctions.Number(Rtf(P_1));
		double num2 = NumberFunctions.Number((string)P_2);
		return cmpNumberNumberO(P_0, num, num2);
	}

	private static bool cmpRtfRtfO(Operator.Op P_0, object P_1, object P_2)
	{
		double num = NumberFunctions.Number(Rtf(P_1));
		double num2 = NumberFunctions.Number(Rtf(P_2));
		return cmpNumberNumberO(P_0, num, num2);
	}

	public override XPathNodeIterator Clone()
	{
		return new LogicalExpr(this);
	}

	private static string Rtf(object P_0)
	{
		return ((XPathNavigator)P_0).Value;
	}
}
