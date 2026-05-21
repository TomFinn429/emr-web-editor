using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal sealed class FollowingQuery : BaseAxisQuery
{
	private XPathNavigator _input;

	private XPathNodeIterator _iterator;

	public FollowingQuery(Query P_0, string P_1, string P_2, XPathNodeType P_3)
		: base(P_0, P_1, P_2, P_3)
	{
	}

	private FollowingQuery(FollowingQuery P_0)
		: base(P_0)
	{
		_input = Query.Clone(P_0._input);
		_iterator = Query.Clone(P_0._iterator);
	}

	public override void Reset()
	{
		_iterator = null;
		base.Reset();
	}

	public override XPathNavigator Advance()
	{
		if (_iterator == null)
		{
			_input = qyInput.Advance();
			if (_input == null)
			{
				return null;
			}
			XPathNavigator xPathNavigator;
			do
			{
				xPathNavigator = _input.Clone();
				_input = qyInput.Advance();
			}
			while (xPathNavigator.IsDescendant(_input));
			_input = xPathNavigator;
			_iterator = XPathEmptyIterator.Instance;
		}
		while (!_iterator.MoveNext())
		{
			bool flag;
			if (_input.NodeType == XPathNodeType.Attribute || _input.NodeType == XPathNodeType.Namespace)
			{
				_input.MoveToParent();
				flag = false;
			}
			else
			{
				while (!_input.MoveToNext())
				{
					if (!_input.MoveToParent())
					{
						return null;
					}
				}
				flag = true;
			}
			if (base.NameTest)
			{
				_iterator = _input.SelectDescendants(base.Name, base.Namespace, flag);
			}
			else
			{
				_iterator = _input.SelectDescendants(base.TypeTest, flag);
			}
		}
		position++;
		currentNode = _iterator.Current;
		return currentNode;
	}

	public override XPathNodeIterator Clone()
	{
		return new FollowingQuery(this);
	}
}
