using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal sealed class XPathSingletonIterator : ResettableIterator
{
	private readonly XPathNavigator _nav;

	private int _position;

	public override XPathNavigator Current => _nav;

	public override int CurrentPosition => _position;

	public override int Count => 1;

	public XPathSingletonIterator(XPathNavigator P_0)
	{
		_nav = P_0;
	}

	public XPathSingletonIterator(XPathNavigator P_0, bool P_1)
		: this(P_0)
	{
		if (P_1)
		{
			_position = 1;
		}
	}

	public XPathSingletonIterator(XPathSingletonIterator P_0)
	{
		_nav = P_0._nav.Clone();
		_position = P_0._position;
	}

	public override XPathNodeIterator Clone()
	{
		return new XPathSingletonIterator(this);
	}

	public override bool MoveNext()
	{
		if (_position == 0)
		{
			_position = 1;
			return true;
		}
		return false;
	}

	public override void Reset()
	{
		_position = 0;
	}
}
