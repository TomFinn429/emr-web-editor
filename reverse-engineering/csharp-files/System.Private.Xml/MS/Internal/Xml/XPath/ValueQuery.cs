using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal abstract class ValueQuery : Query
{
	public sealed override XPathNavigator Current
	{
		get
		{
			throw XPathException.Create("Xp_NodeSetExpected");
		}
	}

	public sealed override int CurrentPosition
	{
		get
		{
			throw XPathException.Create("Xp_NodeSetExpected");
		}
	}

	public sealed override int Count
	{
		get
		{
			throw XPathException.Create("Xp_NodeSetExpected");
		}
	}

	public ValueQuery()
	{
	}

	protected ValueQuery(ValueQuery P_0)
		: base(P_0)
	{
	}

	public sealed override void Reset()
	{
	}

	public sealed override XPathNavigator Advance()
	{
		throw XPathException.Create("Xp_NodeSetExpected");
	}
}
