using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal sealed class IteratorFilter : XPathNodeIterator
{
	private readonly XPathNodeIterator _innerIterator;

	private readonly string _name;

	private int _position;

	public override XPathNavigator Current => _innerIterator.Current;

	public override int CurrentPosition => _position;

	internal IteratorFilter(XPathNodeIterator P_0, string P_1)
	{
		_innerIterator = P_0;
		_name = P_1;
	}

	private IteratorFilter(IteratorFilter P_0)
	{
		_innerIterator = P_0._innerIterator.Clone();
		_name = P_0._name;
		_position = P_0._position;
	}

	public override XPathNodeIterator Clone()
	{
		return new IteratorFilter(this);
	}

	public override bool MoveNext()
	{
		while (_innerIterator.MoveNext())
		{
			if (_innerIterator.Current.LocalName == _name)
			{
				_position++;
				return true;
			}
		}
		return false;
	}
}
