using System;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace MS.Internal.Xml.XPath;

internal sealed class UnionExpr : Query
{
	internal Query qy1;

	internal Query qy2;

	private bool _advance1;

	private bool _advance2;

	private XPathNavigator _currentNode;

	private XPathNavigator _nextNode;

	public override XPathResultType StaticType => XPathResultType.NodeSet;

	public override XPathNavigator Current => _currentNode;

	public override int CurrentPosition
	{
		get
		{
			throw new InvalidOperationException();
		}
	}

	public UnionExpr(Query P_0, Query P_1)
	{
		qy1 = P_0;
		qy2 = P_1;
		_advance1 = true;
		_advance2 = true;
	}

	private UnionExpr(UnionExpr P_0)
		: base(P_0)
	{
		qy1 = Query.Clone(P_0.qy1);
		qy2 = Query.Clone(P_0.qy2);
		_advance1 = P_0._advance1;
		_advance2 = P_0._advance2;
		_currentNode = Query.Clone(P_0._currentNode);
		_nextNode = Query.Clone(P_0._nextNode);
	}

	public override void Reset()
	{
		qy1.Reset();
		qy2.Reset();
		_advance1 = true;
		_advance2 = true;
		_nextNode = null;
	}

	public override void SetXsltContext(XsltContext P_0)
	{
		qy1.SetXsltContext(P_0);
		qy2.SetXsltContext(P_0);
	}

	public override object Evaluate(XPathNodeIterator P_0)
	{
		qy1.Evaluate(P_0);
		qy2.Evaluate(P_0);
		_advance1 = true;
		_advance2 = true;
		_nextNode = null;
		ResetCount();
		return this;
	}

	private XPathNavigator ProcessSamePosition(XPathNavigator P_0)
	{
		_currentNode = P_0;
		_advance1 = (_advance2 = true);
		return P_0;
	}

	private XPathNavigator ProcessBeforePosition(XPathNavigator P_0, XPathNavigator P_1)
	{
		_nextNode = P_1;
		_advance2 = false;
		_advance1 = true;
		_currentNode = P_0;
		return P_0;
	}

	private XPathNavigator ProcessAfterPosition(XPathNavigator P_0, XPathNavigator P_1)
	{
		_nextNode = P_0;
		_advance1 = false;
		_advance2 = true;
		_currentNode = P_1;
		return P_1;
	}

	public override XPathNavigator Advance()
	{
		XPathNavigator xPathNavigator = ((!_advance1) ? _nextNode : qy1.Advance());
		XPathNavigator xPathNavigator2 = ((!_advance2) ? _nextNode : qy2.Advance());
		if (xPathNavigator == null || xPathNavigator2 == null)
		{
			if (xPathNavigator2 == null)
			{
				_advance1 = true;
				_advance2 = false;
				_currentNode = xPathNavigator;
				_nextNode = null;
				return xPathNavigator;
			}
			_advance1 = false;
			_advance2 = true;
			_currentNode = xPathNavigator2;
			_nextNode = null;
			return xPathNavigator2;
		}
		return Query.CompareNodes(xPathNavigator, xPathNavigator2) switch
		{
			XmlNodeOrder.Before => ProcessBeforePosition(xPathNavigator, xPathNavigator2), 
			XmlNodeOrder.After => ProcessAfterPosition(xPathNavigator, xPathNavigator2), 
			_ => ProcessSamePosition(xPathNavigator), 
		};
	}

	public override XPathNodeIterator Clone()
	{
		return new UnionExpr(this);
	}
}
