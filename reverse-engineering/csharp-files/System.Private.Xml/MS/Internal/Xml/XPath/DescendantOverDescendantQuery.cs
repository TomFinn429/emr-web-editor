using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal sealed class DescendantOverDescendantQuery : DescendantBaseQuery
{
	private int _level;

	public DescendantOverDescendantQuery(Query P_0, bool P_1, string P_2, string P_3, XPathNodeType P_4, bool P_5)
		: base(P_0, P_2, P_3, P_4, P_1, P_5)
	{
	}

	private DescendantOverDescendantQuery(DescendantOverDescendantQuery P_0)
		: base(P_0)
	{
		_level = P_0._level;
	}

	public override void Reset()
	{
		_level = 0;
		base.Reset();
	}

	public override XPathNavigator Advance()
	{
		while (true)
		{
			if (_level == 0)
			{
				currentNode = qyInput.Advance();
				position = 0;
				if (currentNode == null)
				{
					return null;
				}
				if (matchSelf && matches(currentNode))
				{
					break;
				}
				currentNode = currentNode.Clone();
				if (!MoveToFirstChild())
				{
					continue;
				}
			}
			else if (!MoveUpUntilNext())
			{
				continue;
			}
			do
			{
				if (matches(currentNode))
				{
					position++;
					return currentNode;
				}
			}
			while (MoveToFirstChild());
		}
		position = 1;
		return currentNode;
	}

	private bool MoveToFirstChild()
	{
		if (currentNode.MoveToFirstChild())
		{
			_level++;
			return true;
		}
		return false;
	}

	private bool MoveUpUntilNext()
	{
		while (!currentNode.MoveToNext())
		{
			_level--;
			if (_level == 0)
			{
				return false;
			}
			bool flag = currentNode.MoveToParent();
		}
		return true;
	}

	public override XPathNodeIterator Clone()
	{
		return new DescendantOverDescendantQuery(this);
	}
}
