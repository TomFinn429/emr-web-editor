using System.Xml.XPath;
using System.Xml.Xsl;

namespace MS.Internal.Xml.XPath;

internal abstract class ExtensionQuery : Query
{
	protected string prefix;

	protected string name;

	protected XsltContext xsltContext;

	private ResettableIterator _queryIterator;

	public override XPathNavigator Current
	{
		get
		{
			if (_queryIterator == null)
			{
				throw XPathException.Create("Xp_NodeSetExpected");
			}
			if (_queryIterator.CurrentPosition == 0)
			{
				Advance();
			}
			return _queryIterator.Current;
		}
	}

	public override int CurrentPosition
	{
		get
		{
			if (_queryIterator != null)
			{
				return _queryIterator.CurrentPosition;
			}
			return 0;
		}
	}

	protected string QName
	{
		get
		{
			if (prefix.Length == 0)
			{
				return name;
			}
			return prefix + ":" + name;
		}
	}

	public override int Count
	{
		get
		{
			if (_queryIterator != null)
			{
				return _queryIterator.Count;
			}
			return 1;
		}
	}

	public override XPathResultType StaticType => XPathResultType.Any;

	public ExtensionQuery(string P_0, string P_1)
	{
		prefix = P_0;
		name = P_1;
	}

	protected ExtensionQuery(ExtensionQuery P_0)
		: base(P_0)
	{
		prefix = P_0.prefix;
		name = P_0.name;
		xsltContext = P_0.xsltContext;
		_queryIterator = (ResettableIterator)Query.Clone(P_0._queryIterator);
	}

	public override void Reset()
	{
		_queryIterator?.Reset();
	}

	public override XPathNavigator Advance()
	{
		if (_queryIterator == null)
		{
			throw XPathException.Create("Xp_NodeSetExpected");
		}
		if (_queryIterator.MoveNext())
		{
			return _queryIterator.Current;
		}
		return null;
	}

	protected object ProcessResult(object P_0)
	{
		if (P_0 is string)
		{
			return P_0;
		}
		if (P_0 is double)
		{
			return P_0;
		}
		if (P_0 is bool)
		{
			return P_0;
		}
		if (P_0 is XPathNavigator)
		{
			return P_0;
		}
		if (P_0 is int)
		{
			return (double)(int)P_0;
		}
		if (P_0 == null)
		{
			_queryIterator = XPathEmptyIterator.Instance;
			return this;
		}
		if (P_0 is ResettableIterator resettableIterator)
		{
			_queryIterator = (ResettableIterator)resettableIterator.Clone();
			return this;
		}
		if (P_0 is XPathNodeIterator xPathNodeIterator)
		{
			_queryIterator = new XPathArrayIterator(xPathNodeIterator);
			return this;
		}
		if (P_0 is IXPathNavigable iXPathNavigable)
		{
			return iXPathNavigable.CreateNavigator();
		}
		if (P_0 is short)
		{
			return (double)(short)P_0;
		}
		if (P_0 is long)
		{
			return (double)(long)P_0;
		}
		if (P_0 is uint)
		{
			return (double)(uint)P_0;
		}
		if (P_0 is ushort)
		{
			return (double)(int)(ushort)P_0;
		}
		if (P_0 is ulong)
		{
			return (double)(ulong)P_0;
		}
		if (P_0 is float)
		{
			return (double)(float)P_0;
		}
		if (P_0 is decimal)
		{
			return (double)(decimal)P_0;
		}
		return P_0.ToString();
	}
}
