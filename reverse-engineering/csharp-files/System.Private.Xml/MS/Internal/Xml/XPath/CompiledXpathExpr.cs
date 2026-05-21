using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace MS.Internal.Xml.XPath;

internal class CompiledXpathExpr : XPathExpression
{
	private sealed class UndefinedXsltContext : XsltContext
	{
		private readonly IXmlNamespaceResolver _nsResolver;

		public override string DefaultNamespace => string.Empty;

		public override bool Whitespace => false;

		public UndefinedXsltContext(IXmlNamespaceResolver P_0)
			: base(false)
		{
			_nsResolver = P_0;
		}

		public override string LookupNamespace(string P_0)
		{
			if (P_0.Length == 0)
			{
				return string.Empty;
			}
			string text = _nsResolver.LookupNamespace(P_0);
			if (text == null)
			{
				throw XPathException.Create("XmlUndefinedAlias", P_0);
			}
			return text;
		}

		public override IXsltContextVariable ResolveVariable(string P_0, string P_1)
		{
			throw XPathException.Create("Xp_UndefinedXsltContext");
		}

		public override IXsltContextFunction ResolveFunction(string P_0, string P_1, XPathResultType[] P_2)
		{
			throw XPathException.Create("Xp_UndefinedXsltContext");
		}

		public override bool PreserveWhitespace(XPathNavigator P_0)
		{
			return false;
		}
	}

	private Query _query;

	private readonly string _expr;

	private bool _needContext;

	internal Query QueryTree
	{
		get
		{
			if (_needContext)
			{
				throw XPathException.Create("Xp_NoContext");
			}
			return _query;
		}
	}

	internal CompiledXpathExpr(Query P_0, string P_1, bool P_2)
	{
		_query = P_0;
		_expr = P_1;
		_needContext = P_2;
	}

	public override void SetContext(IXmlNamespaceResolver P_0)
	{
		XsltContext xsltContext = P_0 as XsltContext;
		if (xsltContext == null)
		{
			if (P_0 == null)
			{
				P_0 = new XmlNamespaceManager(new NameTable());
			}
			xsltContext = new UndefinedXsltContext(P_0);
		}
		_query.SetXsltContext(xsltContext);
		_needContext = false;
	}
}
