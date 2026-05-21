using System.Xml;
using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal sealed class CacheChildrenQuery : ChildrenQuery
{
	private XPathNavigator _nextInput;

	private readonly ClonableStack<XPathNavigator> _elementStk;

	private readonly ClonableStack<int> _positionStk;

	private bool _needInput;

	public CacheChildrenQuery(Query P_0, string P_1, string P_2, XPathNodeType P_3)
		: base(P_0, P_1, P_2, P_3)
	{
		_elementStk = new ClonableStack<XPathNavigator>();
		_positionStk = new ClonableStack<int>();
		_needInput = true;
	}

	private CacheChildrenQuery(CacheChildrenQuery P_0)
		: base(P_0)
	{
		_nextInput = Query.Clone(P_0._nextInput);
		_elementStk = P_0._elementStk.Clone();
		_positionStk = P_0._positionStk.Clone();
		_needInput = P_0._needInput;
	}

	public override void Reset()
	{
		_nextInput = null;
		_elementStk.Clear();
		_positionStk.Clear();
		_needInput = true;
		base.Reset();
	}

	public override XPathNavigator Advance()
	{
		do
		{
			IL_0000:
			if (_needInput)
			{
				if (_elementStk.Count == 0)
				{
					currentNode = GetNextInput();
					if (currentNode == null)
					{
						return null;
					}
					if (!currentNode.MoveToFirstChild())
					{
						goto IL_0000;
					}
					position = 0;
				}
				else
				{
					currentNode = _elementStk.Pop();
					position = _positionStk.Pop();
					if (!DecideNextNode())
					{
						goto IL_0000;
					}
				}
				_needInput = false;
			}
			else if (!currentNode.MoveToNext() || !DecideNextNode())
			{
				_needInput = true;
				goto IL_0000;
			}
		}
		while (!matches(currentNode));
		position++;
		return currentNode;
	}

	private bool DecideNextNode()
	{
		_nextInput = GetNextInput();
		if (_nextInput != null && Query.CompareNodes(currentNode, _nextInput) == XmlNodeOrder.After)
		{
			_elementStk.Push(currentNode);
			_positionStk.Push(position);
			currentNode = _nextInput;
			_nextInput = null;
			if (!currentNode.MoveToFirstChild())
			{
				return false;
			}
			position = 0;
		}
		return true;
	}

	private XPathNavigator GetNextInput()
	{
		XPathNavigator xPathNavigator;
		if (_nextInput != null)
		{
			xPathNavigator = _nextInput;
			_nextInput = null;
		}
		else
		{
			xPathNavigator = qyInput.Advance();
			if (xPathNavigator != null)
			{
				xPathNavigator = xPathNavigator.Clone();
			}
		}
		return xPathNavigator;
	}

	public override XPathNodeIterator Clone()
	{
		return new CacheChildrenQuery(this);
	}
}
