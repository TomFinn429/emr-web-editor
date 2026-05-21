using System.Collections.Generic;
using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal sealed class QueryBuilder
{
	private enum Flags
	{
		None = 0,
		SmartDesc = 1,
		PosFilter = 2,
		Filter = 4
	}

	private enum Props
	{
		None = 0,
		PosFilter = 1,
		HasPosition = 2,
		HasLast = 4,
		NonFlat = 8
	}

	private string _query;

	private bool _allowVar;

	private bool _allowKey;

	private bool _allowCurrent;

	private bool _needContext;

	private BaseAxisQuery _firstInput;

	private int _parseDepth;

	private void Reset()
	{
		_parseDepth = 0;
		_needContext = false;
	}

	private Query ProcessAxis(Axis P_0, Flags P_1, out Props P_2)
	{
		if (P_0.Prefix.Length > 0)
		{
			_needContext = true;
		}
		_firstInput = null;
		Query query3;
		Query query2;
		if (P_0.Input != null)
		{
			Flags flags = Flags.None;
			if ((P_1 & Flags.PosFilter) == 0)
			{
				if (P_0.Input is Axis axis && P_0.TypeOfAxis == Axis.AxisType.Child && axis.TypeOfAxis == Axis.AxisType.DescendantOrSelf && axis.NodeType == XPathNodeType.All)
				{
					Query query;
					if (axis.Input != null)
					{
						query = ProcessNode(axis.Input, Flags.SmartDesc, out P_2);
					}
					else
					{
						query = new ContextQuery();
						P_2 = Props.None;
					}
					query2 = new DescendantQuery(query, P_0.Name, P_0.Prefix, P_0.NodeType, false, axis.AbbrAxis);
					if ((P_2 & Props.NonFlat) != Props.None)
					{
						query2 = new DocumentOrderQuery(query2);
					}
					P_2 |= Props.NonFlat;
					return query2;
				}
				if (P_0.TypeOfAxis == Axis.AxisType.Descendant || P_0.TypeOfAxis == Axis.AxisType.DescendantOrSelf)
				{
					flags |= Flags.SmartDesc;
				}
			}
			query3 = ProcessNode(P_0.Input, flags, out P_2);
		}
		else
		{
			query3 = new ContextQuery();
			P_2 = Props.None;
		}
		switch (P_0.TypeOfAxis)
		{
		case Axis.AxisType.Ancestor:
			query2 = new XPathAncestorQuery(query3, P_0.Name, P_0.Prefix, P_0.NodeType, false);
			P_2 |= Props.NonFlat;
			break;
		case Axis.AxisType.AncestorOrSelf:
			query2 = new XPathAncestorQuery(query3, P_0.Name, P_0.Prefix, P_0.NodeType, true);
			P_2 |= Props.NonFlat;
			break;
		case Axis.AxisType.Child:
			query2 = (((P_2 & Props.NonFlat) == 0) ? new ChildrenQuery(query3, P_0.Name, P_0.Prefix, P_0.NodeType) : new CacheChildrenQuery(query3, P_0.Name, P_0.Prefix, P_0.NodeType));
			break;
		case Axis.AxisType.Parent:
			query2 = new ParentQuery(query3, P_0.Name, P_0.Prefix, P_0.NodeType);
			break;
		case Axis.AxisType.Descendant:
			if ((P_1 & Flags.SmartDesc) != Flags.None)
			{
				query2 = new DescendantOverDescendantQuery(query3, false, P_0.Name, P_0.Prefix, P_0.NodeType, false);
			}
			else
			{
				query2 = new DescendantQuery(query3, P_0.Name, P_0.Prefix, P_0.NodeType, false, false);
				if ((P_2 & Props.NonFlat) != Props.None)
				{
					query2 = new DocumentOrderQuery(query2);
				}
			}
			P_2 |= Props.NonFlat;
			break;
		case Axis.AxisType.DescendantOrSelf:
			if ((P_1 & Flags.SmartDesc) != Flags.None)
			{
				query2 = new DescendantOverDescendantQuery(query3, true, P_0.Name, P_0.Prefix, P_0.NodeType, P_0.AbbrAxis);
			}
			else
			{
				query2 = new DescendantQuery(query3, P_0.Name, P_0.Prefix, P_0.NodeType, true, P_0.AbbrAxis);
				if ((P_2 & Props.NonFlat) != Props.None)
				{
					query2 = new DocumentOrderQuery(query2);
				}
			}
			P_2 |= Props.NonFlat;
			break;
		case Axis.AxisType.Preceding:
			query2 = new PrecedingQuery(query3, P_0.Name, P_0.Prefix, P_0.NodeType);
			P_2 |= Props.NonFlat;
			break;
		case Axis.AxisType.Following:
			query2 = new FollowingQuery(query3, P_0.Name, P_0.Prefix, P_0.NodeType);
			P_2 |= Props.NonFlat;
			break;
		case Axis.AxisType.FollowingSibling:
			query2 = new FollSiblingQuery(query3, P_0.Name, P_0.Prefix, P_0.NodeType);
			if ((P_2 & Props.NonFlat) != Props.None)
			{
				query2 = new DocumentOrderQuery(query2);
			}
			break;
		case Axis.AxisType.PrecedingSibling:
			query2 = new PreSiblingQuery(query3, P_0.Name, P_0.Prefix, P_0.NodeType);
			break;
		case Axis.AxisType.Attribute:
			query2 = new AttributeQuery(query3, P_0.Name, P_0.Prefix, P_0.NodeType);
			break;
		case Axis.AxisType.Self:
			query2 = new XPathSelfQuery(query3, P_0.Name, P_0.Prefix, P_0.NodeType);
			break;
		case Axis.AxisType.Namespace:
			query2 = (((P_0.NodeType != XPathNodeType.All && P_0.NodeType != XPathNodeType.Element && P_0.NodeType != XPathNodeType.Attribute) || P_0.Prefix.Length != 0) ? ((Query)new EmptyQuery()) : ((Query)new NamespaceQuery(query3, P_0.Name, P_0.Prefix, P_0.NodeType)));
			break;
		default:
			throw XPathException.Create("Xp_NotSupported", _query);
		}
		return query2;
	}

	private static bool CanBeNumber(Query P_0)
	{
		if (P_0.StaticType != XPathResultType.Any)
		{
			return P_0.StaticType == XPathResultType.Number;
		}
		return true;
	}

	private Query ProcessFilter(Filter P_0, Flags P_1, out Props P_2)
	{
		bool flag = (P_1 & Flags.Filter) == 0;
		Props props;
		Query query = ProcessNode(P_0.Condition, Flags.None, out props);
		if (CanBeNumber(query) || (props & (Props)6) != Props.None)
		{
			props |= Props.HasPosition;
			P_1 |= Flags.PosFilter;
		}
		P_1 &= (Flags)(-2);
		Query query2 = ProcessNode(P_0.Input, P_1 | Flags.Filter, out P_2);
		if (P_0.Input.Type != AstNode.AstType.Filter)
		{
			P_2 &= (Props)(-2);
		}
		if ((props & Props.HasPosition) != Props.None)
		{
			P_2 |= Props.PosFilter;
		}
		if (query2 is FilterQuery filterQuery && (props & Props.HasPosition) == 0 && filterQuery.Condition.StaticType != XPathResultType.Any)
		{
			Query query3 = filterQuery.Condition;
			if (query3.StaticType == XPathResultType.Number)
			{
				query3 = new LogicalExpr(Operator.Op.EQ, new NodeFunctions(Function.FunctionType.FuncPosition, null), query3);
			}
			query = new BooleanExpr(Operator.Op.AND, query3, query);
			query2 = filterQuery.qyInput;
		}
		if ((P_2 & Props.PosFilter) != Props.None && query2 is DocumentOrderQuery)
		{
			query2 = ((DocumentOrderQuery)query2).input;
		}
		if (_firstInput == null)
		{
			_firstInput = query2 as BaseAxisQuery;
		}
		bool flag2 = (query2.Properties & QueryProps.Merge) != 0;
		bool flag3 = (query2.Properties & QueryProps.Reverse) != 0;
		if ((props & Props.HasPosition) != Props.None)
		{
			if (flag3)
			{
				query2 = new ReversePositionQuery(query2);
			}
			else if ((props & Props.HasLast) != Props.None)
			{
				query2 = new ForwardPositionQuery(query2);
			}
		}
		if (flag && _firstInput != null)
		{
			if (flag2 && (P_2 & Props.PosFilter) != Props.None)
			{
				query2 = new FilterQuery(query2, query, false);
				Query qyInput = _firstInput.qyInput;
				if (!(qyInput is ContextQuery))
				{
					_firstInput.qyInput = new ContextQuery();
					_firstInput = null;
					return new MergeFilterQuery(qyInput, query2);
				}
				_firstInput = null;
				return query2;
			}
			_firstInput = null;
		}
		return new FilterQuery(query2, query, (props & Props.HasPosition) == 0);
	}

	private Query ProcessOperator(Operator P_0, out Props P_1)
	{
		Props props;
		Query query = ProcessNode(P_0.Operand1, Flags.None, out props);
		Props props2;
		Query query2 = ProcessNode(P_0.Operand2, Flags.None, out props2);
		P_1 = props | props2;
		switch (P_0.OperatorType)
		{
		case Operator.Op.PLUS:
		case Operator.Op.MINUS:
		case Operator.Op.MUL:
		case Operator.Op.DIV:
		case Operator.Op.MOD:
			return new NumericExpr(P_0.OperatorType, query, query2);
		case Operator.Op.EQ:
		case Operator.Op.NE:
		case Operator.Op.LT:
		case Operator.Op.LE:
		case Operator.Op.GT:
		case Operator.Op.GE:
			return new LogicalExpr(P_0.OperatorType, query, query2);
		case Operator.Op.OR:
		case Operator.Op.AND:
			return new BooleanExpr(P_0.OperatorType, query, query2);
		case Operator.Op.UNION:
			P_1 |= Props.NonFlat;
			return new UnionExpr(query, query2);
		default:
			return null;
		}
	}

	private Query ProcessVariable(Variable P_0)
	{
		_needContext = true;
		if (!_allowVar)
		{
			throw XPathException.Create("Xp_InvalidKeyPattern", _query);
		}
		return new VariableQuery(P_0.Localname, P_0.Prefix);
	}

	private Query ProcessFunction(Function P_0, out Props P_1)
	{
		P_1 = Props.None;
		switch (P_0.TypeOfFunction)
		{
		case Function.FunctionType.FuncLast:
		{
			Query result = new NodeFunctions(P_0.TypeOfFunction, null);
			P_1 |= Props.HasLast;
			return result;
		}
		case Function.FunctionType.FuncPosition:
		{
			Query result = new NodeFunctions(P_0.TypeOfFunction, null);
			P_1 |= Props.HasPosition;
			return result;
		}
		case Function.FunctionType.FuncCount:
			return new NodeFunctions(Function.FunctionType.FuncCount, ProcessNode(P_0.ArgumentList[0], Flags.None, out P_1));
		case Function.FunctionType.FuncID:
		{
			Query result = new IDQuery(ProcessNode(P_0.ArgumentList[0], Flags.None, out P_1));
			P_1 |= Props.NonFlat;
			return result;
		}
		case Function.FunctionType.FuncLocalName:
		case Function.FunctionType.FuncNameSpaceUri:
		case Function.FunctionType.FuncName:
			if (P_0.ArgumentList != null && P_0.ArgumentList.Count > 0)
			{
				return new NodeFunctions(P_0.TypeOfFunction, ProcessNode(P_0.ArgumentList[0], Flags.None, out P_1));
			}
			return new NodeFunctions(P_0.TypeOfFunction, null);
		case Function.FunctionType.FuncString:
		case Function.FunctionType.FuncConcat:
		case Function.FunctionType.FuncStartsWith:
		case Function.FunctionType.FuncContains:
		case Function.FunctionType.FuncSubstringBefore:
		case Function.FunctionType.FuncSubstringAfter:
		case Function.FunctionType.FuncSubstring:
		case Function.FunctionType.FuncStringLength:
		case Function.FunctionType.FuncNormalize:
		case Function.FunctionType.FuncTranslate:
			return new StringFunctions(P_0.TypeOfFunction, ProcessArguments(P_0.ArgumentList, out P_1));
		case Function.FunctionType.FuncNumber:
		case Function.FunctionType.FuncSum:
		case Function.FunctionType.FuncFloor:
		case Function.FunctionType.FuncCeiling:
		case Function.FunctionType.FuncRound:
			if (P_0.ArgumentList != null && P_0.ArgumentList.Count > 0)
			{
				return new NumberFunctions(P_0.TypeOfFunction, ProcessNode(P_0.ArgumentList[0], Flags.None, out P_1));
			}
			return new NumberFunctions(Function.FunctionType.FuncNumber, null);
		case Function.FunctionType.FuncTrue:
		case Function.FunctionType.FuncFalse:
			return new BooleanFunctions(P_0.TypeOfFunction, null);
		case Function.FunctionType.FuncBoolean:
		case Function.FunctionType.FuncNot:
		case Function.FunctionType.FuncLang:
			return new BooleanFunctions(P_0.TypeOfFunction, ProcessNode(P_0.ArgumentList[0], Flags.None, out P_1));
		case Function.FunctionType.FuncUserDefined:
		{
			_needContext = true;
			if (!_allowCurrent && P_0.Name == "current" && P_0.Prefix.Length == 0)
			{
				throw XPathException.Create("Xp_CurrentNotAllowed");
			}
			if (!_allowKey && P_0.Name == "key" && P_0.Prefix.Length == 0)
			{
				throw XPathException.Create("Xp_InvalidKeyPattern", _query);
			}
			Query result = new FunctionQuery(P_0.Prefix, P_0.Name, ProcessArguments(P_0.ArgumentList, out P_1));
			P_1 |= Props.NonFlat;
			return result;
		}
		default:
			throw XPathException.Create("Xp_NotSupported", _query);
		}
	}

	private List<Query> ProcessArguments(List<AstNode> P_0, out Props P_1)
	{
		int count = P_0.Count;
		List<Query> list = new List<Query>(count);
		P_1 = Props.None;
		for (int i = 0; i < count; i++)
		{
			list.Add(ProcessNode(P_0[i], Flags.None, out var props));
			P_1 |= props;
		}
		return list;
	}

	private Query ProcessNode(AstNode P_0, Flags P_1, out Props P_2)
	{
		if (++_parseDepth > 1024)
		{
			throw XPathException.Create("Xp_QueryTooComplex");
		}
		Query result = null;
		P_2 = Props.None;
		switch (P_0.Type)
		{
		case AstNode.AstType.Axis:
			result = ProcessAxis((Axis)P_0, P_1, out P_2);
			break;
		case AstNode.AstType.Operator:
			result = ProcessOperator((Operator)P_0, out P_2);
			break;
		case AstNode.AstType.Filter:
			result = ProcessFilter((Filter)P_0, P_1, out P_2);
			break;
		case AstNode.AstType.ConstantOperand:
			result = new OperandQuery(((Operand)P_0).OperandValue);
			break;
		case AstNode.AstType.Variable:
			result = ProcessVariable((Variable)P_0);
			break;
		case AstNode.AstType.Function:
			result = ProcessFunction((Function)P_0, out P_2);
			break;
		case AstNode.AstType.Group:
			result = new GroupQuery(ProcessNode(((Group)P_0).GroupNode, Flags.None, out P_2));
			break;
		case AstNode.AstType.Root:
			result = new AbsoluteQuery();
			break;
		}
		_parseDepth--;
		return result;
	}

	private Query Build(AstNode P_0, string P_1)
	{
		Reset();
		_query = P_1;
		Props props;
		return ProcessNode(P_0, Flags.None, out props);
	}

	internal Query Build(string P_0, bool P_1, bool P_2)
	{
		_allowVar = P_1;
		_allowKey = P_2;
		_allowCurrent = true;
		return Build(XPathParser.ParseXPathExpression(P_0), P_0);
	}

	internal Query Build(string P_0, out bool P_1)
	{
		Query result = Build(P_0, true, true);
		P_1 = _needContext;
		return result;
	}
}
