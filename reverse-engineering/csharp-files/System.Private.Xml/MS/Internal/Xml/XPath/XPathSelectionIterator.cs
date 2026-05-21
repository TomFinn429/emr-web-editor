using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal sealed class XPathSelectionIterator : ResettableIterator
{
	private XPathNavigator _nav;

	private readonly Query _query;

	private int _position;

	public override int Count => _query.Count;

	public override XPathNavigator Current => _nav;

	public override int CurrentPosition => _position;

	internal XPathSelectionIterator(XPathNavigator P_0, Query P_1)
	{
		_nav = P_0.Clone();
		_query = P_1;
	}

	private XPathSelectionIterator(XPathSelectionIterator P_0)
	{
		_nav = P_0._nav.Clone();
		_query = (Query)P_0._query.Clone();
		_position = P_0._position;
	}

	public override void Reset()
	{
		_query.Reset();
	}

	public override bool MoveNext()
	{
		XPathNavigator xPathNavigator = _query.Advance();
		if (xPathNavigator != null)
		{
			_position++;
			if (!_nav.MoveTo(xPathNavigator))
			{
				_nav = xPathNavigator.Clone();
			}
			return true;
		}
		return false;
	}

	public override XPathNodeIterator Clone()
	{
		return new XPathSelectionIterator(this);
	}
}
