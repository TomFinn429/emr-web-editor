using System.Collections;

namespace System.Xml.XPath;

public abstract class XPathNodeIterator : ICloneable, IEnumerable
{
	private sealed class Enumerator : IEnumerator
	{
		private readonly XPathNodeIterator _original;

		private XPathNodeIterator _current;

		private bool _iterationStarted;

		public object Current
		{
			get
			{
				if (_iterationStarted)
				{
					if (_current == null)
					{
						throw new InvalidOperationException(System.SR.Format("Sch_EnumFinished", string.Empty));
					}
					return _current.Current.Clone();
				}
				throw new InvalidOperationException(System.SR.Format("Sch_EnumNotStarted", string.Empty));
			}
		}

		public Enumerator(XPathNodeIterator P_0)
		{
			_original = P_0.Clone();
		}

		public bool MoveNext()
		{
			if (!_iterationStarted)
			{
				_current = _original.Clone();
				_iterationStarted = true;
			}
			if (_current == null || !_current.MoveNext())
			{
				_current = null;
				return false;
			}
			return true;
		}

		public void Reset()
		{
			_iterationStarted = false;
		}
	}

	internal int count = -1;

	public abstract XPathNavigator? Current { get; }

	public abstract int CurrentPosition { get; }

	public virtual int Count
	{
		get
		{
			if (count == -1)
			{
				XPathNodeIterator xPathNodeIterator = Clone();
				while (xPathNodeIterator.MoveNext())
				{
				}
				count = xPathNodeIterator.CurrentPosition;
			}
			return count;
		}
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public abstract XPathNodeIterator Clone();

	public abstract bool MoveNext();

	public virtual IEnumerator GetEnumerator()
	{
		return new Enumerator(this);
	}
}
