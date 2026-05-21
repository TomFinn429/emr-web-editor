using System.Xml.XPath;
using System.Xml.Xsl;

namespace MS.Internal.Xml.XPath;

internal sealed class FilterQuery : BaseAxisQuery
{
	private readonly Query _cond;

	private readonly bool _noPosition;

	public Query Condition => _cond;

	public override QueryProps Properties => QueryProps.Position | (qyInput.Properties & (QueryProps)24);

	public FilterQuery(Query P_0, Query P_1, bool P_2)
		: base(P_0)
	{
		_cond = P_1;
		_noPosition = P_2;
	}

	private FilterQuery(FilterQuery P_0)
		: base(P_0)
	{
		_cond = Query.Clone(P_0._cond);
		_noPosition = P_0._noPosition;
	}

	public override void Reset()
	{
		_cond.Reset();
		base.Reset();
	}

	public override void SetXsltContext(XsltContext P_0)
	{
		base.SetXsltContext(P_0);
		_cond.SetXsltContext(P_0);
		if (_cond.StaticType != XPathResultType.Number && _cond.StaticType != XPathResultType.Any && _noPosition && qyInput is ReversePositionQuery reversePositionQuery)
		{
			qyInput = reversePositionQuery.input;
		}
	}

	public override XPathNavigator Advance()
	{
		while ((currentNode = qyInput.Advance()) != null)
		{
			if (EvaluatePredicate())
			{
				position++;
				return currentNode;
			}
		}
		return null;
	}

	internal bool EvaluatePredicate()
	{
		object obj = _cond.Evaluate(qyInput);
		if (obj is XPathNodeIterator)
		{
			return _cond.Advance() != null;
		}
		if (obj is string)
		{
			return ((string)obj).Length != 0;
		}
		if (obj is double)
		{
			return (double)obj == (double)qyInput.CurrentPosition;
		}
		if (obj is bool)
		{
			return (bool)obj;
		}
		return true;
	}

	public override XPathNodeIterator Clone()
	{
		return new FilterQuery(this);
	}
}
