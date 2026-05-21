using System.Collections.Generic;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace MS.Internal.Xml.XPath;

internal abstract class CacheOutputQuery : Query
{
	internal Query input;

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

	public override XPathResultType StaticType => XPathResultType.NodeSet;

	public override int CurrentPosition => count;

	public override int Count => outputBuffer.Count;

	public override QueryProps Properties => (QueryProps)23;

	public CacheOutputQuery(Query P_0)
	{
		input = P_0;
		outputBuffer = new List<XPathNavigator>();
		count = 0;
	}

	protected CacheOutputQuery(CacheOutputQuery P_0)
		: base(P_0)
	{
		input = Query.Clone(P_0.input);
		outputBuffer = new List<XPathNavigator>(P_0.outputBuffer);
		count = P_0.count;
	}

	public override void Reset()
	{
		count = 0;
	}

	public override void SetXsltContext(XsltContext P_0)
	{
		input.SetXsltContext(P_0);
	}

	public override object Evaluate(XPathNodeIterator P_0)
	{
		outputBuffer.Clear();
		count = 0;
		return input.Evaluate(P_0);
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
