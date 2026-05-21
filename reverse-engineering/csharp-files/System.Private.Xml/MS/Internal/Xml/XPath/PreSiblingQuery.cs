using System.Collections.Generic;
using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal sealed class PreSiblingQuery : CacheAxisQuery
{
	public override QueryProps Properties => base.Properties | QueryProps.Reverse;

	public PreSiblingQuery(Query P_0, string P_1, string P_2, XPathNodeType P_3)
		: base(P_0, P_1, P_2, P_3)
	{
	}

	private PreSiblingQuery(PreSiblingQuery P_0)
		: base(P_0)
	{
	}

	private static bool NotVisited(XPathNavigator P_0, List<XPathNavigator> P_1)
	{
		XPathNavigator xPathNavigator = P_0.Clone();
		xPathNavigator.MoveToParent();
		for (int i = 0; i < P_1.Count; i++)
		{
			if (xPathNavigator.IsSamePosition(P_1[i]))
			{
				return false;
			}
		}
		P_1.Add(xPathNavigator);
		return true;
	}

	public override object Evaluate(XPathNodeIterator P_0)
	{
		base.Evaluate(P_0);
		List<XPathNavigator> list = new List<XPathNavigator>();
		Stack<XPathNavigator> stack = new Stack<XPathNavigator>();
		while ((currentNode = qyInput.Advance()) != null)
		{
			stack.Push(currentNode.Clone());
		}
		while (stack.Count != 0)
		{
			XPathNavigator xPathNavigator = stack.Pop();
			if (xPathNavigator.NodeType == XPathNodeType.Attribute || xPathNavigator.NodeType == XPathNodeType.Namespace || !NotVisited(xPathNavigator, list))
			{
				continue;
			}
			XPathNavigator xPathNavigator2 = xPathNavigator.Clone();
			if (!xPathNavigator2.MoveToParent())
			{
				continue;
			}
			bool flag = xPathNavigator2.MoveToFirstChild();
			while (!xPathNavigator2.IsSamePosition(xPathNavigator))
			{
				if (matches(xPathNavigator2))
				{
					Query.Insert(outputBuffer, xPathNavigator2);
				}
				if (!xPathNavigator2.MoveToNext())
				{
					break;
				}
			}
		}
		return this;
	}

	public override XPathNodeIterator Clone()
	{
		return new PreSiblingQuery(this);
	}
}
