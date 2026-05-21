using System;
using System.Collections;
using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal class XPathArrayIterator : ResettableIterator
{
	protected IList list;

	protected int index;

	public override XPathNavigator Current
	{
		get
		{
			if (index < 1)
			{
				throw new InvalidOperationException(System.SR.Format("Sch_EnumNotStarted", string.Empty));
			}
			return (XPathNavigator)list[index - 1];
		}
	}

	public override int CurrentPosition => index;

	public override int Count => list.Count;

	public XPathArrayIterator(XPathArrayIterator P_0)
	{
		list = P_0.list;
		index = P_0.index;
	}

	public XPathArrayIterator(XPathNodeIterator P_0)
	{
		list = new ArrayList();
		while (P_0.MoveNext())
		{
			list.Add(P_0.Current.Clone());
		}
	}

	public override XPathNodeIterator Clone()
	{
		return new XPathArrayIterator(this);
	}

	public override bool MoveNext()
	{
		if (index == list.Count)
		{
			return false;
		}
		index++;
		return true;
	}

	public override void Reset()
	{
		index = 0;
	}

	public override IEnumerator GetEnumerator()
	{
		return list.GetEnumerator();
	}
}
