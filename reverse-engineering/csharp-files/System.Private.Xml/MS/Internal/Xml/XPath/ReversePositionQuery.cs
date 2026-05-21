using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal sealed class ReversePositionQuery : ForwardPositionQuery
{
	public override int CurrentPosition => outputBuffer.Count - count + 1;

	public override QueryProps Properties => base.Properties | QueryProps.Reverse;

	public ReversePositionQuery(Query P_0)
		: base(P_0)
	{
	}

	private ReversePositionQuery(ReversePositionQuery P_0)
		: base(P_0)
	{
	}

	public override XPathNodeIterator Clone()
	{
		return new ReversePositionQuery(this);
	}
}
