using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal sealed class Operator : AstNode
{
	public enum Op
	{
		INVALID,
		OR,
		AND,
		EQ,
		NE,
		LT,
		LE,
		GT,
		GE,
		PLUS,
		MINUS,
		MUL,
		DIV,
		MOD,
		UNION
	}

	private static readonly Op[] s_invertOp = new Op[9]
	{
		Op.INVALID,
		Op.INVALID,
		Op.INVALID,
		Op.EQ,
		Op.NE,
		Op.GT,
		Op.GE,
		Op.LT,
		Op.LE
	};

	private readonly Op _opType;

	private readonly AstNode _opnd1;

	private readonly AstNode _opnd2;

	public override AstType Type => AstType.Operator;

	public override XPathResultType ReturnType
	{
		get
		{
			if (_opType <= Op.GE)
			{
				return XPathResultType.Boolean;
			}
			if (_opType <= Op.MOD)
			{
				return XPathResultType.Number;
			}
			return XPathResultType.NodeSet;
		}
	}

	public Op OperatorType => _opType;

	public AstNode Operand1 => _opnd1;

	public AstNode Operand2 => _opnd2;

	public static Op InvertOperator(Op P_0)
	{
		return s_invertOp[(int)P_0];
	}

	public Operator(Op P_0, AstNode P_1, AstNode P_2)
	{
		_opType = P_0;
		_opnd1 = P_1;
		_opnd2 = P_2;
	}
}
