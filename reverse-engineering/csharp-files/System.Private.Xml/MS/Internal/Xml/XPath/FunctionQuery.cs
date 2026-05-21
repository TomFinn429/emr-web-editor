using System;
using System.Collections.Generic;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace MS.Internal.Xml.XPath;

internal sealed class FunctionQuery : ExtensionQuery
{
	private readonly IList<Query> _args;

	private IXsltContextFunction _function;

	public override XPathResultType StaticType
	{
		get
		{
			XPathResultType xPathResultType = ((_function != null) ? _function.ReturnType : XPathResultType.Any);
			if (xPathResultType == XPathResultType.Error)
			{
				xPathResultType = XPathResultType.Any;
			}
			return xPathResultType;
		}
	}

	public FunctionQuery(string P_0, string P_1, List<Query> P_2)
		: base(P_0, P_1)
	{
		_args = P_2;
	}

	private FunctionQuery(FunctionQuery P_0)
		: base(P_0)
	{
		_function = P_0._function;
		Query[] array = new Query[P_0._args.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = Query.Clone(P_0._args[i]);
		}
		_args = array;
		_args = array;
	}

	public override void SetXsltContext(XsltContext P_0)
	{
		if (P_0 == null)
		{
			throw XPathException.Create("Xp_NoContext");
		}
		if (xsltContext == P_0)
		{
			return;
		}
		xsltContext = P_0;
		foreach (Query arg in _args)
		{
			arg.SetXsltContext(P_0);
		}
		XPathResultType[] array = new XPathResultType[_args.Count];
		for (int i = 0; i < _args.Count; i++)
		{
			array[i] = _args[i].StaticType;
		}
		_function = xsltContext.ResolveFunction(prefix, name, array);
		if (_function == null)
		{
			throw XPathException.Create("Xp_UndefFunc", base.QName);
		}
	}

	public override object Evaluate(XPathNodeIterator P_0)
	{
		if (xsltContext == null)
		{
			throw XPathException.Create("Xp_NoContext");
		}
		object[] array = new object[_args.Count];
		for (int i = 0; i < _args.Count; i++)
		{
			array[i] = _args[i].Evaluate(P_0);
			if (array[i] is XPathNodeIterator)
			{
				array[i] = new XPathSelectionIterator(P_0.Current, _args[i]);
			}
		}
		try
		{
			return ProcessResult(_function.Invoke(xsltContext, array, P_0.Current));
		}
		catch (Exception ex)
		{
			throw XPathException.Create("Xp_FunctionFailed", base.QName, ex);
		}
	}

	public override XPathNodeIterator Clone()
	{
		return new FunctionQuery(this);
	}
}
