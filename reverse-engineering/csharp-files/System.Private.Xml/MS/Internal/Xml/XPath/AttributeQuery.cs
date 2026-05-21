using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal sealed class AttributeQuery : BaseAxisQuery
{
	private bool _onAttribute;

	public AttributeQuery(Query P_0, string P_1, string P_2, XPathNodeType P_3)
		: base(P_0, P_1, P_2, P_3)
	{
	}

	private AttributeQuery(AttributeQuery P_0)
		: base(P_0)
	{
		_onAttribute = P_0._onAttribute;
	}

	public override void Reset()
	{
		_onAttribute = false;
		base.Reset();
	}

	public override XPathNavigator Advance()
	{
		do
		{
			if (!_onAttribute)
			{
				currentNode = qyInput.Advance();
				if (currentNode == null)
				{
					return null;
				}
				position = 0;
				currentNode = currentNode.Clone();
				_onAttribute = currentNode.MoveToFirstAttribute();
			}
			else
			{
				_onAttribute = currentNode.MoveToNextAttribute();
			}
		}
		while (!_onAttribute || !matches(currentNode));
		position++;
		return currentNode;
	}

	public override XPathNodeIterator Clone()
	{
		return new AttributeQuery(this);
	}
}
