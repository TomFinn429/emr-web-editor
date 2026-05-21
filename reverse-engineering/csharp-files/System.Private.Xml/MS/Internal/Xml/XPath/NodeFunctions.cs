using System.Xml.XPath;
using System.Xml.Xsl;

namespace MS.Internal.Xml.XPath;

internal sealed class NodeFunctions : ValueQuery
{
	private readonly Query _arg;

	private readonly Function.FunctionType _funcType;

	private XsltContext _xsltContext;

	public override XPathResultType StaticType => Function.ReturnTypes[(int)_funcType];

	public NodeFunctions(Function.FunctionType P_0, Query P_1)
	{
		_funcType = P_0;
		_arg = P_1;
	}

	public override void SetXsltContext(XsltContext P_0)
	{
		_xsltContext = (P_0.Whitespace ? P_0 : null);
		_arg?.SetXsltContext(P_0);
	}

	private XPathNavigator EvaluateArg(XPathNodeIterator P_0)
	{
		if (_arg == null)
		{
			return P_0.Current;
		}
		_arg.Evaluate(P_0);
		return _arg.Advance();
	}

	public override object Evaluate(XPathNodeIterator P_0)
	{
		switch (_funcType)
		{
		case Function.FunctionType.FuncPosition:
			return (double)P_0.CurrentPosition;
		case Function.FunctionType.FuncLast:
			return (double)P_0.Count;
		case Function.FunctionType.FuncNameSpaceUri:
		{
			XPathNavigator xPathNavigator2 = EvaluateArg(P_0);
			if (xPathNavigator2 != null)
			{
				return xPathNavigator2.NamespaceURI;
			}
			break;
		}
		case Function.FunctionType.FuncLocalName:
		{
			XPathNavigator xPathNavigator2 = EvaluateArg(P_0);
			if (xPathNavigator2 != null)
			{
				return xPathNavigator2.LocalName;
			}
			break;
		}
		case Function.FunctionType.FuncName:
		{
			XPathNavigator xPathNavigator2 = EvaluateArg(P_0);
			if (xPathNavigator2 != null)
			{
				return xPathNavigator2.Name;
			}
			break;
		}
		case Function.FunctionType.FuncCount:
		{
			_arg.Evaluate(P_0);
			int num = 0;
			if (_xsltContext != null)
			{
				XPathNavigator xPathNavigator;
				while ((xPathNavigator = _arg.Advance()) != null)
				{
					if (xPathNavigator.NodeType != XPathNodeType.Whitespace || _xsltContext.PreserveWhitespace(xPathNavigator))
					{
						num++;
					}
				}
			}
			else
			{
				while (_arg.Advance() != null)
				{
					num++;
				}
			}
			return (double)num;
		}
		}
		return string.Empty;
	}

	public override XPathNodeIterator Clone()
	{
		NodeFunctions nodeFunctions = new NodeFunctions(_funcType, Query.Clone(_arg));
		nodeFunctions._xsltContext = _xsltContext;
		return nodeFunctions;
	}
}
