using System.Collections.Generic;
using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal abstract class CacheAxisQuery : BaseAxisQuery
{
	protected List<XPathNavigator> outputBuffer;

	public override XPathNavigator Current
	{
		get
		{
			if (count == 0)
			{
				return null;
			}
			return outputBuffer[count - 1];
		}
	}

	public override int CurrentPosition => count;

	public override int Count => outputBuffer.Count;

	public override QueryProps Properties => (QueryProps)23;

	public CacheAxisQuery(Query P_0, string P_1, string P_2, XPathNodeType P_3)
		: base(P_0, P_1, P_2, P_3)
	{
		outputBuffer = new List<XPathNavigator>();
		count = 0;
	}

	protected CacheAxisQuery(CacheAxisQuery P_0)
		: base(P_0)
	{
		outputBuffer = new List<XPathNavigator>(P_0.outputBuffer);
		count = P_0.count;
	}

	public override void Reset()
	{
		count = 0;
	}

	public override object Evaluate(XPathNodeIterator P_0)
	{
		base.Evaluate(P_0);
		outputBuffer.Clear();
		return this;
	}

	public override XPathNavigator Advance()
	{
		if (count < outputBuffer.Count)
		{
			return outputBuffer[count++];
		}
		return null;
	}
}
