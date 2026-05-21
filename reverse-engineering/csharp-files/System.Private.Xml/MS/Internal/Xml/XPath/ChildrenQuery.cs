using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal class ChildrenQuery : BaseAxisQuery
{
	private XPathNodeIterator _iterator = XPathEmptyIterator.Instance;

	public ChildrenQuery(Query P_0, string P_1, string P_2, XPathNodeType P_3)
		: base(P_0, P_1, P_2, P_3)
	{
	}

	protected ChildrenQuery(ChildrenQuery P_0)
		: base(P_0)
	{
		_iterator = Query.Clone(P_0._iterator);
	}

	public override void Reset()
	{
		_iterator = XPathEmptyIterator.Instance;
		base.Reset();
	}

	public override XPathNavigator Advance()
	{
		while (!_iterator.MoveNext())
		{
			XPathNavigator xPathNavigator = qyInput.Advance();
			if (xPathNavigator == null)
			{
				return null;
			}
			if (base.NameTest)
			{
				if (base.TypeTest == XPathNodeType.ProcessingInstruction)
				{
					_iterator = new IteratorFilter(xPathNavigator.SelectChildren(base.TypeTest), base.Name);
				}
				else
				{
					_iterator = xPathNavigator.SelectChildren(base.Name, base.Namespace);
				}
			}
			else
			{
				_iterator = xPathNavigator.SelectChildren(base.TypeTest);
			}
			position = 0;
		}
		position++;
		currentNode = _iterator.Current;
		return currentNode;
	}

	public override XPathNodeIterator Clone()
	{
		return new ChildrenQuery(this);
	}
}
