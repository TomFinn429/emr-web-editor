using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal sealed class GroupQuery : BaseAxisQuery
{
	public override XPathResultType StaticType => qyInput.StaticType;

	public override QueryProps Properties => QueryProps.Position;

	public GroupQuery(Query P_0)
		: base(P_0)
	{
	}

	private GroupQuery(GroupQuery P_0)
		: base(P_0)
	{
	}

	public override XPathNavigator Advance()
	{
		currentNode = qyInput.Advance();
		if (currentNode != null)
		{
			position++;
		}
		return currentNode;
	}

	public override object Evaluate(XPathNodeIterator P_0)
	{
		return qyInput.Evaluate(P_0);
	}

	public override XPathNodeIterator Clone()
	{
		return new GroupQuery(this);
	}
}
