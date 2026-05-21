using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal sealed class DescendantQuery : DescendantBaseQuery
{
	private XPathNodeIterator _nodeIterator;

	internal DescendantQuery(Query P_0, string P_1, string P_2, XPathNodeType P_3, bool P_4, bool P_5)
		: base(P_0, P_1, P_2, P_3, P_4, P_5)
	{
	}

	public DescendantQuery(DescendantQuery P_0)
		: base(P_0)
	{
		_nodeIterator = Query.Clone(P_0._nodeIterator);
	}

	public override void Reset()
	{
		_nodeIterator = null;
		base.Reset();
	}

	public override XPathNavigator Advance()
	{
		while (true)
		{
			if (_nodeIterator == null)
			{
				position = 0;
				XPathNavigator xPathNavigator = qyInput.Advance();
				if (xPathNavigator == null)
				{
					return null;
				}
				if (base.NameTest)
				{
					if (base.TypeTest == XPathNodeType.ProcessingInstruction)
					{
						_nodeIterator = new IteratorFilter(xPathNavigator.SelectDescendants(base.TypeTest, matchSelf), base.Name);
					}
					else
					{
						_nodeIterator = xPathNavigator.SelectDescendants(base.Name, base.Namespace, matchSelf);
					}
				}
				else
				{
					_nodeIterator = xPathNavigator.SelectDescendants(base.TypeTest, matchSelf);
				}
			}
			if (_nodeIterator.MoveNext())
			{
				break;
			}
			_nodeIterator = null;
		}
		position++;
		currentNode = _nodeIterator.Current;
		return currentNode;
	}

	public override XPathNodeIterator Clone()
	{
		return new DescendantQuery(this);
	}
}
