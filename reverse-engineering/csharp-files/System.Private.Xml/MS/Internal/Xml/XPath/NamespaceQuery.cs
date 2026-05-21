using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal sealed class NamespaceQuery : BaseAxisQuery
{
	private bool _onNamespace;

	public NamespaceQuery(Query P_0, string P_1, string P_2, XPathNodeType P_3)
		: base(P_0, P_1, P_2, P_3)
	{
	}

	private NamespaceQuery(NamespaceQuery P_0)
		: base(P_0)
	{
		_onNamespace = P_0._onNamespace;
	}

	public override void Reset()
	{
		_onNamespace = false;
		base.Reset();
	}

	public override XPathNavigator Advance()
	{
		do
		{
			if (!_onNamespace)
			{
				currentNode = qyInput.Advance();
				if (currentNode == null)
				{
					return null;
				}
				position = 0;
				currentNode = currentNode.Clone();
				_onNamespace = currentNode.MoveToFirstNamespace();
			}
			else
			{
				_onNamespace = currentNode.MoveToNextNamespace();
			}
		}
		while (!_onNamespace || !matches(currentNode));
		position++;
		return currentNode;
	}

	public override bool matches(XPathNavigator P_0)
	{
		if (P_0.Value.Length == 0)
		{
			return false;
		}
		if (base.NameTest)
		{
			return base.Name.Equals(P_0.LocalName);
		}
		return true;
	}

	public override XPathNodeIterator Clone()
	{
		return new NamespaceQuery(this);
	}
}
